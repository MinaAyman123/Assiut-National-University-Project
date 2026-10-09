// ===================================
// MAIN APPLICATION LOGIC
// ===================================

// Initialize the app
document.addEventListener('DOMContentLoaded', function () {
  // Initialize data
  initializeData();

  // Initialize auth
  initAuthListeners();

  // Page-specific initialization
  const currentPage = getCurrentPage();

  switch (currentPage) {
    case 'index':
      initHomePage();
      break;
    case 'villages':
      initVillagesPage();
      break;
    case 'village-details':
      initVillageDetailsPage();
      break;
    case 'booking':
      initBookingPage();
      break;
    case 'auth':
      initAuthPage();
      break;
    case 'dashboard':
      initDashboardPage();
      break;
  }

  // Initialize mobile menu
  initMobileMenu();
});

// Get current page name
function getCurrentPage() {
  const path = window.location.pathname;
  const page = path.substring(path.lastIndexOf('/') + 1);

  if (!page || page === '' || page === 'index.html') return 'index';
  return page.replace('.html', '');
}

// Initialize mobile menu
function initMobileMenu() {
  const toggle = document.querySelector('.mobile-menu-toggle');
  const menu = document.querySelector('.navbar-menu');

  if (toggle && menu) {
    toggle.addEventListener('click', () => {
      menu.classList.toggle('active');
    });
  }
}

// Home page initialization
function initHomePage() {
  loadFeaturedVillages();
  initSearchBar();
}

// Load featured villages
function loadFeaturedVillages() {
  const container = document.getElementById('featured-villages');
  if (!container) return;

  const villages = getFeaturedVillages();

  container.innerHTML = villages.map(village => `
    <div class="card animate-fade-in">
      <img src="${village.image}" alt="${village.name}" class="card-image">
      <div class="card-body">
        <h3 class="card-title">${village.name}</h3>
        <p class="card-subtitle">
          <svg width="14" height="14" viewBox="0 0 24 24" fill="currentColor">
            <path d="M12 2C8.13 2 5 5.13 5 9c0 5.25 7 13 7 13s7-7.75 7-13c0-3.87-3.13-7-7-7zm0 9.5c-1.38 0-2.5-1.12-2.5-2.5s1.12-2.5 2.5-2.5 2.5 1.12 2.5 2.5-1.12 2.5-2.5 2.5z"/>
          </svg>
          ${village.location}
        </p>
        ${generateStarRating(village.rating)}
        <p class="card-description">${village.description.substring(0, 100)}...</p>
        <div class="card-footer">
          <div>
            <span class="card-price">${formatPrice(village.price)}</span>
            <span class="card-price-label"> / night</span>
          </div>
          <a href="village-details.html?id=${village.id}" class="btn btn-primary btn-sm">View Details</a>
        </div>
      </div>
    </div>
  `).join('');
}

// Initialize search bar
function initSearchBar() {
  const searchForm = document.getElementById('search-form');
  if (!searchForm) return;

  searchForm.addEventListener('submit', (e) => {
    e.preventDefault();

    const location = document.getElementById('search-location')?.value || '';
    const checkIn = document.getElementById('search-checkin')?.value || '';
    const checkOut = document.getElementById('search-checkout')?.value || '';
    const maxPrice = document.getElementById('search-price')?.value || '';

    // Build query string
    const params = new URLSearchParams();
    if (location) params.set('location', location);
    if (checkIn) params.set('checkIn', checkIn);
    if (checkOut) params.set('checkOut', checkOut);
    if (maxPrice) params.set('maxPrice', maxPrice);

    window.location.href = `villages.html?${params.toString()}`;
  });
}

// Villages page initialization
function initVillagesPage() {
  loadVillages();
  initFilters();
  initSort();
}

// Load and display villages
function loadVillages() {
  const container = document.getElementById('villages-grid');
  if (!container) return;

  // Get filters from form inputs (if they exist) or URL parameters
  const maxPriceInput = document.getElementById('search-price');
  const categoryInputs = document.querySelectorAll('input[name="category"]');
  const ratingInputs = document.querySelectorAll('input[name="minRating"]');

  const filters = {
    location: getURLParameter('location'),
    minPrice: getURLParameter('minPrice'),
    maxPrice: maxPriceInput ? maxPriceInput.value : getURLParameter('maxPrice'),
    category: getSelectedRadioValue(categoryInputs) || getURLParameter('category'),
    minRating: getSelectedRadioValue(ratingInputs) || getURLParameter('minRating')
  };

  // Filter villages
  let villages = filterVillages(filters);

  // Sort villages
  const sortBy = getURLParameter('sort') || 'popular';
  villages = sortVillages(villages, sortBy);

  // Update count
  const countElement = document.getElementById('village-count');
  if (countElement) {
    countElement.textContent = `${villages.length} village${villages.length !== 1 ? 's' : ''} found`;
  }

  // Render villages
  container.innerHTML = villages.map(village => `
    <div class="card animate-fade-in">
      <img src="${village.image}" alt="${village.name}" class="card-image">
      <div class="card-body">
        <h3 class="card-title">${village.name}</h3>
        <p class="card-subtitle">
          <svg width="14" height="14" viewBox="0 0 24 24" fill="currentColor">
            <path d="M12 2C8.13 2 5 5.13 5 9c0 5.25 7 13 7 13s7-7.75 7-13c0-3.87-3.13-7-7-7zm0 9.5c-1.38 0-2.5-1.12-2.5-2.5s1.12-2.5 2.5-2.5 2.5 1.12 2.5 2.5-1.12 2.5-2.5 2.5z"/>
          </svg>
          ${village.location}
        </p>
        ${generateStarRating(village.rating)}
        <div class="card-footer" style="margin-top: var(--space-4);">
          <div>
            <span class="card-price">${formatPrice(village.price)}</span>
            <span class="card-price-label"> / night</span>
          </div>
          <a href="village-details.html?id=${village.id}" class="btn btn-primary btn-sm">Book Now</a>
        </div>
      </div>
    </div>
  `).join('');
}

// Helper function to get selected radio button value
function getSelectedRadioValue(radioButtons) {
  for (const radio of radioButtons) {
    if (radio.checked) {
      return radio.value || null;
    }
  }
  return null;
}

// Initialize filters
function initFilters() {
  const filterForm = document.getElementById('filter-form');
  if (!filterForm) return;

  filterForm.addEventListener('change', debounce(() => {
    loadVillages();
  }, 300));
}

// Initialize sort
function initSort() {
  const sortSelect = document.getElementById('sort-select');
  if (!sortSelect) return;

  sortSelect.addEventListener('change', (e) => {
    setURLParameter('sort', e.target.value);
    loadVillages();
  });
}

// Update task progress
function updateTaskProgress() {
  // This would be updated as we complete more features
}
