// ===================================
// SAMPLE VILLAGE DATA
// ===================================

const villagesData = [
  {
    id: 1,
    name: "Azure Coast Retreat",
    location: "Santorini, Greece",
    description: "Experience the ultimate Mediterranean luxury in our stunning coastal retreat. White-washed villas cascade down the cliff, offering breathtaking views of the Aegean Sea. Each villa features a private infinity pool, modern amenities, and traditional Cycladic architecture.",
    price: 350,
    rating: 4.9,
    reviews: 247,
    capacity: 6,
    bedrooms: 3,
    bathrooms: 2,
    image: "/static/assets/images/village_coastal_luxury_1764037481506.png",
    gallery: [
      "/static/assets/images/village_coastal_luxury_1764037481506.png",
      "/static/assets/images/hero_background_1764037443889.png"
    ],
    amenities: [
      "Infinity Pool",
      "Ocean View",
      "WiFi",
      "Air Conditioning",
      "Kitchen",
      "Parking",
      "Beach Access",
      "Restaurant"
    ],
    coordinates: { lat: 36.3932, lng: 25.4615 },
    availability: true,
    featured: true,
    category: "coastal"
  },
  {
    id: 2,
    name: "Alpine Paradise Lodge",
    location: "Swiss Alps, Switzerland",
    description: "Nestled in the heart of the Swiss Alps, our mountain retreat offers cozy wooden chalets with panoramic mountain views. Perfect for both summer hiking and winter skiing adventures. Experience authentic Alpine hospitality with modern luxury.",
    price: 420,
    rating: 4.8,
    reviews: 189,
    capacity: 8,
    bedrooms: 4,
    bathrooms: 3,
    image: "/static/assets/images/village_mountain_retreat_1764037497020.png",
    gallery: [
      "/static/assets/images/village_mountain_retreat_1764037497020.png"
    ],
    amenities: [
      "Mountain View",
      "Fireplace",
      "Ski Storage",
      "Sauna",
      "WiFi",
      "Heating",
      "Kitchen",
      "Parking"
    ],
    coordinates: { lat: 46.2044, lng: 6.1432 },
    availability: true,
    featured: true,
    category: "mountain"
  },
  {
    id: 3,
    name: "Maldives Water Villas",
    location: "Maldives",
    description: "Discover paradise in our exclusive overwater bungalows. Wake up to crystal-clear turquoise waters and pristine white sand beaches. Each villa offers direct ocean access, glass floor panels for marine life viewing, and unparalleled privacy.",
    price: 650,
    rating: 5.0,
    reviews: 432,
    capacity: 4,
    bedrooms: 2,
    bathrooms: 2,
    image: "/static/assets/images/village_tropical_paradise_1764037516016.png",
    gallery: [
      "/static/assets/images/village_tropical_paradise_1764037516016.png"
    ],
    amenities: [
      "Overwater Villa",
      "Private Pool",
      "Snorkeling",
      "Spa Access",
      "WiFi",
      "Air Conditioning",
      "Restaurant",
      "Butler Service"
    ],
    coordinates: { lat: 3.2028, lng: 73.2207 },
    availability: true,
    featured: true,
    category: "tropical"
  },
  {
    id: 4,
    name: "Desert Oasis Resort",
    location: "Dubai, UAE",
    description: "Experience Arabian luxury in our exclusive desert oasis. Traditional architecture meets modern comfort in this stunning resort surrounded by golden dunes and lush gardens. Enjoy camel rides, desert safaris, and authentic Middle Eastern cuisine.",
    price: 480,
    rating: 4.7,
    reviews: 156,
    capacity: 5,
    bedrooms: 3,
    bathrooms: 2,
    image: "/static/assets/images/village_desert_oasis_1764037532670.png",
    gallery: [
      "/static/assets/images/village_desert_oasis_1764037532670.png"
    ],
    amenities: [
      "Pool",
      "Desert View",
      "WiFi",
      "Air Conditioning",
      "Spa",
      "Restaurant",
      "Safari Tours",
      "Parking"
    ],
    coordinates: { lat: 25.2048, lng: 55.2708 },
    availability: true,
    featured: false,
    category: "desert"
  },
  {
    id: 5,
    name: "Nordic Lake Cabins",
    location: "Lapland, Finland",
    description: "Serene lakeside cabins in the heart of Finnish Lapland. These modern wooden lodges on stilts offer breathtaking views of pristine lakes and forests. Perfect for Northern Lights viewing, aurora photography, and peaceful nature retreats.",
    price: 320,
    rating: 4.9,
    reviews: 203,
    capacity: 4,
    bedrooms: 2,
    bathrooms: 1,
    image: "/static/assets/images/village_lakeside_cabin_1764037591953.png",
    gallery: [
      "/static/assets/images/village_lakeside_cabin_1764037591953.png"
    ],
    amenities: [
      "Lake View",
      "Sauna",
      "Fireplace",
      "WiFi",
      "Heating",
      "Kitchen",
      "Boat Rental",
      "Fishing"
    ],
    coordinates: { lat: 68.9961, lng: 27.4249 },
    availability: true,
    featured: false,
    category: "lakeside"
  },
  {
    id: 6,
    name: "Tuscan Vineyard Villas",
    location: "Tuscany, Italy",
    description: "Immerse yourself in Italian countryside charm at our Tuscan vineyard estate. Stone villas surrounded by rolling hills, vineyards, and olive groves. Enjoy wine tasting, cooking classes, and authentic Italian hospitality.",
    price: 380,
    rating: 4.8,
    reviews: 298,
    capacity: 6,
    bedrooms: 3,
    bathrooms: 2,
    image: "/static/assets/images/village_countryside_vineyard_1764037610747.png",
    gallery: [
      "/static/assets/images/village_countryside_vineyard_1764037610747.png"
    ],
    amenities: [
      "Vineyard View",
      "Pool",
      "Wine Tasting",
      "WiFi",
      "Kitchen",
      "Garden",
      "Parking",
      "Bicycles"
    ],
    coordinates: { lat: 43.7696, lng: 11.2558 },
    availability: true,
    featured: false,
    category: "countryside"
  },
  {
    id: 7,
    name: "Coastal Sunset Haven",
    location: "Algarve, Portugal",
    description: "Luxurious beachfront escape on Portugal's stunning Algarve coast. Modern villas with panoramic ocean views, private beach access, and world-class amenities. Watch spectacular sunsets from your private terrace.",
    price: 295,
    rating: 4.7,
    reviews: 178,
    capacity: 5,
    bedrooms: 2,
    bathrooms: 2,
    image: "/static/assets/images/hero_background_1764037443889.png",
    gallery: [
      "/static/assets/images/hero_background_1764037443889.png"
    ],
    amenities: [
      "Beach Access",
      "Ocean View",
      "Pool",
      "WiFi",
      "Air Conditioning",
      "Kitchen",
      "Terrace",
      "Parking"
    ],
    coordinates: { lat: 37.0179, lng: -7.9304 },
    availability: true,
    featured: true,
    category: "coastal"
  }
];

// Sample User Reviews
const reviewsData = {
  1: [
    {
      id: 1,
      userId: 101,
      userName: "Sarah Johnson",
      avatar: "https://i.pravatar.cc/150?img=1",
      rating: 5,
      date: "2025-11-10",
      comment: "Absolutely stunning! The views were breathtaking and the service was impeccable. Can't wait to return!"
    },
    {
      id: 2,
      userId: 102,
      userName: "Michael Chen",
      avatar: "https://i.pravatar.cc/150?img=2",
      rating: 5,
      date: "2025-11-05",
      comment: "Perfect honeymoon destination. The infinity pool and sunset views made our stay unforgettable."
    },
    {
      id: 3,
      userId: 103,
      userName: "Emma Williams",
      avatar: "https://i.pravatar.cc/150?img=3",
      rating: 4,
      date: "2025-10-28",
      comment: "Beautiful location and well-maintained property. Only minor issue was the parking space."
    }
  ],
  2: [
    {
      id: 4,
      userId: 104,
      userName: "David Martinez",
      avatar: "https://i.pravatar.cc/150?img=4",
      rating: 5,
      date: "2025-11-12",
      comment: "The perfect mountain getaway! Cozy, clean, and the views are spectacular in every direction."
    },
    {
      id: 5,
      userId: 105,
      userName: "Lisa Anderson",
      avatar: "https://i.pravatar.cc/150?img=5",
      rating: 4,
      date: "2025-11-01",
      comment: "Great for skiing! The chalet was warm and comfortable after a long day on the slopes."
    }
  ],
  3: [
    {
      id: 6,
      userId: 106,
      userName: "James Taylor",
      avatar: "https://i.pravatar.cc/150?img=6",
      rating: 5,
      date: "2025-11-08",
      comment: "Pure paradise! The overwater villa exceeded all expectations. Snorkeling right from our deck was amazing."
    },
    {
      id: 7,
      userId: 107,
      userName: "Sophie Brown",
      avatar: "https://i.pravatar.cc/150?img=7",
      rating: 5,
      date: "2025-10-30",
      comment: "Most luxurious vacation ever. The butler service was fantastic and the water is unbelievably clear."
    }
  ]
};

// Initialize local storage with sample data if empty
function initializeData() {
  if (!localStorage.getItem('villages')) {
    localStorage.setItem('villages', JSON.stringify(villagesData));
  }
  if (!localStorage.getItem('reviews')) {
    localStorage.setItem('reviews', JSON.stringify(reviewsData));
  }
}

// Get all villages
function getVillages() {
  const data = localStorage.getItem('villages');
  return data ? JSON.parse(data) : villagesData;
}

// Get village by ID
function getVillageById(id) {
  const villages = getVillages();
  return villages.find(v => v.id === parseInt(id));
}

// Get featured villages
function getFeaturedVillages() {
  const villages = getVillages();
  return villages.filter(v => v.featured);
}

// Get reviews for a village
function getVillageReviews(villageId) {
  const data = localStorage.getItem('reviews');
  const reviews = data ? JSON.parse(data) : reviewsData;
  return reviews[villageId] || [];
}

// Filter villages
function filterVillages(filters) {
  let villages = getVillages();
  
  if (filters.location) {
    villages = villages.filter(v => 
      v.location.toLowerCase().includes(filters.location.toLowerCase())
    );
  }
  
  if (filters.minPrice) {
    villages = villages.filter(v => v.price >= filters.minPrice);
  }
  
  if (filters.maxPrice) {
    villages = villages.filter(v => v.price <= filters.maxPrice);
  }
  
  if (filters.category) {
    villages = villages.filter(v => v.category === filters.category);
  }
  
  if (filters.minRating) {
    villages = villages.filter(v => v.rating >= filters.minRating);
  }
  
  return villages;
}

// Sort villages
function sortVillages(villages, sortBy) {
  const sorted = [...villages];
  
  switch(sortBy) {
    case 'price-low':
      return sorted.sort((a, b) => a.price - b.price);
    case 'price-high':
      return sorted.sort((a, b) => b.price - a.price);
    case 'rating':
      return sorted.sort((a, b) => b.rating - a.rating);
    case 'popular':
      return sorted.sort((a, b) => b.reviews - a.reviews);
    default:
      return sorted;
  }
}
