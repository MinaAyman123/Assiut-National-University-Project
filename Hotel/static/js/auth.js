// ===================================
// AUTHENTICATION SYSTEM
// ===================================

// User class
class User {
    constructor(email, password, name) {
        this.id = Date.now();
        this.email = email;
        this.password = this.hashPassword(password);
        this.name = name;
        this.createdAt = new Date().toISOString();
    }

    // Simple password hashing (for demo purposes)
    hashPassword(password) {
        // In production, use proper encryption
        return btoa(password);
    }
}

// Check if user is logged in
function isLoggedIn() {
    return localStorage.getItem('currentUser') !== null;
}

// Get current user
function getCurrentUser() {
    const userData = localStorage.getItem('currentUser');
    return userData ? JSON.parse(userData) : null;
}

// Get all users
function getUsers() {
    const users = localStorage.getItem('users');
    return users ? JSON.parse(users) : [];
}

// Save users to localStorage
function saveUsers(users) {
    localStorage.setItem('users', JSON.stringify(users));
}

// Validate email format
function isValidEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

// Validate password strength
function isValidPassword(password) {
    // Minimum 6 characters
    return password.length >= 6;
}

// Sign up new user
function signUp(email, password, confirmPassword, name) {
    // Validation
    if (!email || !password || !confirmPassword || !name) {
        return { success: false, message: 'All fields are required' };
    }

    if (!isValidEmail(email)) {
        return { success: false, message: 'Please enter a valid email address' };
    }

    if (!isValidPassword(password)) {
        return { success: false, message: 'Password must be at least 6 characters long' };
    }

    if (password !== confirmPassword) {
        return { success: false, message: 'Passwords do not match' };
    }

    // Check if user already exists
    const users = getUsers();
    const existingUser = users.find(u => u.email === email);

    if (existingUser) {
        return { success: false, message: 'An account with this email already exists' };
    }

    // Create new user
    const newUser = new User(email, password, name);
    users.push(newUser);
    saveUsers(users);

    // Auto login
    login(email, password);

    return { success: true, message: 'Account created successfully!', user: newUser };
}

// Login user
function login(email, password) {
    // Validation
    if (!email || !password) {
        return { success: false, message: 'Email and password are required' };
    }

    // Find user
    const users = getUsers();
    const user = users.find(u => u.email === email);

    if (!user) {
        return { success: false, message: 'Invalid email or password' };
    }

    // Check password
    const hashedPassword = btoa(password);
    if (user.password !== hashedPassword) {
        return { success: false, message: 'Invalid email or password' };
    }

    // Save current user session
    localStorage.setItem('currentUser', JSON.stringify({
        id: user.id,
        email: user.email,
        name: user.name,
        loginTime: new Date().toISOString()
    }));

    return { success: true, message: 'Login successful!', user };
}

// Logout user
function logout() {
    localStorage.removeItem('currentUser');
    window.location.href = 'index.html';
}

// Protect page (redirect if not logged in)
function requireAuth() {
    if (!isLoggedIn()) {
        window.location.href = 'auth.html?redirect=' + encodeURIComponent(window.location.pathname);
    }
}

// Update user profile
function updateProfile(updates) {
    const currentUser = getCurrentUser();
    if (!currentUser) {
        return { success: false, message: 'Not logged in' };
    }

    // Update user in users list
    const users = getUsers();
    const userIndex = users.findIndex(u => u.id === currentUser.id);

    if (userIndex === -1) {
        return { success: false, message: 'User not found' };
    }

    // Update allowed fields
    if (updates.name) {
        users[userIndex].name = updates.name;
        currentUser.name = updates.name;
    }

    saveUsers(users);
    localStorage.setItem('currentUser', JSON.stringify(currentUser));

    return { success: true, message: 'Profile updated successfully!' };
}

// Initialize auth event listeners
function initAuthListeners() {
    // Update nav bar based on login status
    updateNavBar();
}

// Update navigation bar
function updateNavBar() {
    const authButtons = document.querySelector('.navbar-actions');
    if (!authButtons) return;

    if (isLoggedIn()) {
        const user = getCurrentUser();
        authButtons.innerHTML = `
      <a href="dashboard.html" class="btn btn-outline btn-sm">Dashboard</a>
      <button onclick="logout()" class="btn btn-secondary btn-sm">Logout</button>
    `;
    } else {
        authButtons.innerHTML = `
      <a href="auth.html" class="btn btn-outline btn-sm">Login</a>
      <a href="auth.html" class="btn btn-primary btn-sm">Sign Up</a>
    `;
    }
}

// Social login placeholders (UI only)
function loginWithGoogle() {
    alert('Google login would be implemented with OAuth 2.0 in production.');
}

function loginWithApple() {
    alert('Apple login would be implemented with Sign in with Apple in production.');
}
