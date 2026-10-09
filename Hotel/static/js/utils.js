// ===================================
// UTILITY FUNCTIONS
// ===================================

// Format date to YYYY-MM-DD
function formatDateInput(date) {
    if (!date) return '';
    const d = new Date(date);
    const year = d.getFullYear();
    const month = String(d.getMonth() + 1).padStart(2, '0');
    const day = String(d.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
}

// Get URL parameters
function getURLParameter(name) {
    const params = new URLSearchParams(window.location.search);
    return params.get(name);
}

// Set URL parameter
function setURLParameter(name, value) {
    const url = new URL(window.location);
    url.searchParams.set(name, value);
    window.history.pushState({}, '', url);
}

// Show toast notification
function showToast(message, type = 'info') {
    // Remove existing toast
    const existingToast = document.querySelector('.toast');
    if (existingToast) {
        existingToast.remove();
    }

    const toast = document.createElement('div');
    toast.className = `toast toast-${type}`;
    toast.textContent = message;
    toast.style.cssText = `
    position: fixed;
    top: 100px;
    right: 24px;
    background: ${type === 'success' ? '#34C759' : type === 'error' ? '#FF3B30' : '#007AFF'};
    color: white;
    padding: 16px 24px;
    border-radius: 12px;
    box-shadow: 0 8px 32px rgba(0, 0, 0, 0.16);
    z-index: 10000;
    animation: slideIn 0.3s ease-out;
    max-width: 400px;
    font-size: 14px;
    font-weight: 500;
  `;

    document.body.appendChild(toast);

    setTimeout(() => {
        toast.style.animation = 'fadeOut 0.3s ease-out';
        setTimeout(() => toast.remove(), 300);
    }, 3000);
}

// Show loading overlay
function showLoading() {
    const overlay = document.createElement('div');
    overlay.id = 'loading-overlay';
    overlay.style.cssText = `
    position: fixed;
    inset: 0;
    background: rgba(255, 255, 255, 0.9);
    backdrop-filter: blur(4px);
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 10000;
  `;

    overlay.innerHTML = `
    <div style="text-align: center;">
      <div style="width: 48px; height: 48px; border: 4px solid #E8E8ED; border-top-color: #007AFF; border-radius: 50%; animation: spin 1s linear infinite;"></div>
      <p style="margin-top: 16px; color: #6E6E73; font-size: 14px;">Loading...</p>
    </div>
  `;

    document.body.appendChild(overlay);
}

// Hide loading overlay
function hideLoading() {
    const overlay = document.getElementById('loading-overlay');
    if (overlay) {
        overlay.remove();
    }
}

// Generate star rating HTML
function generateStarRating(rating, showNumber = true) {
    const fullStars = Math.floor(rating);
    const hasHalfStar = rating % 1 >= 0.5;
    let html = '<div class="rating">';

    for (let i = 0; i < 5; i++) {
        if (i < fullStars) {
            html += '<span class="star">★</span>';
        } else if (i === fullStars && hasHalfStar) {
            html += '<span class="star">★</span>';
        } else {
            html += '<span class="star star-empty">★</span>';
        }
    }

    if (showNumber) {
        html += `<span class="rating-value">${rating.toFixed(1)}</span>`;
    }

    html += '</div>';
    return html;
}

// Debounce function
function debounce(func, wait) {
    let timeout;
    return function executedFunction(...args) {
        const later = () => {
            clearTimeout(timeout);
            func(...args);
        };
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
    };
}

// Scroll to top smoothly
function scrollToTop() {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
}

// Validate email
function validateEmail(email) {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
}

// Validate required fields
function validateForm(formData) {
    const errors = {};

    for (let [key, value] of Object.entries(formData)) {
        if (!value || value.trim() === '') {
            errors[key] = `${key.charAt(0).toUpperCase() + key.slice(1)} is required`;
        }
    }

    return errors;
}

// Show form errors
function showFormErrors(errors) {
    // Clear previous errors
    document.querySelectorAll('.error-message').forEach(el => el.remove());
    document.querySelectorAll('.input-error').forEach(el => el.classList.remove('input-error'));

    // Show new errors
    for (let [field, message] of Object.entries(errors)) {
        const input = document.getElementById(field) || document.querySelector(`[name="${field}"]`);
        if (input) {
            input.classList.add('input-error');
            const error = document.createElement('span');
            error.className = 'error-message';
            error.textContent = message;
            input.parentNode.appendChild(error);
        }
    }
}

// Clear form errors
function clearFormErrors() {
    document.querySelectorAll('.error-message').forEach(el => el.remove());
    document.querySelectorAll('.input-error').forEach(el => el.classList.remove('input-error'));
}

// Local storage helpers
const storage = {
    get(key, defaultValue = null) {
        try {
            const item = localStorage.getItem(key);
            return item ? JSON.parse(item) : defaultValue;
        } catch (e) {
            console.error('Error reading from localStorage:', e);
            return defaultValue;
        }
    },

    set(key, value) {
        try {
            localStorage.setItem(key, JSON.stringify(value));
            return true;
        } catch (e) {
            console.error('Error writing to localStorage:', e);
            return false;
        }
    },

    remove(key) {
        try {
            localStorage.removeItem(key);
            return true;
        } catch (e) {
            console.error('Error removing from localStorage:', e);
            return false;
        }
    }
};

// Add CSS animations dynamically
const animations = document.createElement('style');
animations.textContent = `
  @keyframes spin {
    to { transform: rotate(360deg); }
  }
  @keyframes slideIn {
    from {
      transform: translateX(100%);
      opacity: 0;
    }
    to {
      transform: translateX(0);
      opacity: 1;
    }
  }
  @keyframes fadeOut {
    from {
      opacity: 1;
    }
    to {
      opacity: 0;
    }
  }
`;
document.head.appendChild(animations);
