// ===================================
// BOOKING SYSTEM
// ===================================

// Booking class
class Booking {
    constructor(villageId, userId, checkIn, checkOut, guests, totalPrice) {
        this.id = Date.now();
        this.villageId = villageId;
        this.userId = userId;
        this.checkIn = checkIn;
        this.checkOut = checkOut;
        this.guests = guests;
        this.totalPrice = totalPrice;
        this.status = 'confirmed';
        this.createdAt = new Date().toISOString();
    }
}

// Get all bookings
function getAllBookings() {
    const bookings = localStorage.getItem('bookings');
    return bookings ? JSON.parse(bookings) : [];
}

// Save bookings
function saveBookings(bookings) {
    localStorage.setItem('bookings', JSON.stringify(bookings));
}

// Get user bookings
function getUserBookings(userId) {
    const bookings = getAllBookings();
    return bookings.filter(b => b.userId === userId);
}

// Get booking by ID
function getBookingById(bookingId) {
    const bookings = getAllBookings();
    return bookings.find(b => b.id === parseInt(bookingId));
}

// Calculate number of nights
function calculateNights(checkIn, checkOut) {
    const start = new Date(checkIn);
    const end = new Date(checkOut);
    const diffTime = Math.abs(end - start);
    const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
    return diffDays;
}

// Calculate total price
function calculateTotalPrice(pricePerNight, checkIn, checkOut, guests = 1) {
    const nights = calculateNights(checkIn, checkOut);
    const basePrice = pricePerNight * nights;
    // Add guest surcharge if more than 2 guests
    const guestSurcharge = guests > 2 ? (guests - 2) * 20 * nights : 0;
    const subtotal = basePrice + guestSurcharge;
    const serviceFee = subtotal * 0.1; // 10% service fee
    const total = subtotal + serviceFee;

    return {
        nights,
        basePrice,
        guestSurcharge,
        serviceFee,
        total
    };
}

// Validate booking dates
function validateBookingDates(checkIn, checkOut) {
    const today = new Date();
    today.setHours(0, 0, 0, 0);

    const checkInDate = new Date(checkIn);
    const checkOutDate = new Date(checkOut);

    if (checkInDate < today) {
        return { valid: false, message: 'Check-in date cannot be in the past' };
    }

    if (checkOutDate <= checkInDate) {
        return { valid: false, message: 'Check-out date must be after check-in date' };
    }

    const minStay = 1;
    const nights = calculateNights(checkIn, checkOut);

    if (nights < minStay) {
        return { valid: false, message: `Minimum stay is ${minStay} night(s)` };
    }

    return { valid: true };
}

// Check availability (simple check - no overlapping bookings)
function checkAvailability(villageId, checkIn, checkOut) {
    const bookings = getAllBookings();
    const villageBookings = bookings.filter(b =>
        b.villageId === parseInt(villageId) &&
        b.status !== 'cancelled'
    );

    const checkInDate = new Date(checkIn);
    const checkOutDate = new Date(checkOut);

    for (let booking of villageBookings) {
        const bookedCheckIn = new Date(booking.checkIn);
        const bookedCheckOut = new Date(booking.checkOut);

        // Check for overlap
        if (
            (checkInDate >= bookedCheckIn && checkInDate < bookedCheckOut) ||
            (checkOutDate > bookedCheckIn && checkOutDate <= bookedCheckOut) ||
            (checkInDate <= bookedCheckIn && checkOutDate >= bookedCheckOut)
        ) {
            return { available: false, message: 'Village is not available for selected dates' };
        }
    }

    return { available: true };
}

// Create booking
function createBooking(villageId, checkIn, checkOut, guests) {
    // Check if user is logged in
    const user = getCurrentUser();
    if (!user) {
        return { success: false, message: 'Please login to make a booking', requireAuth: true };
    }

    // Validate dates
    const dateValidation = validateBookingDates(checkIn, checkOut);
    if (!dateValidation.valid) {
        return { success: false, message: dateValidation.message };
    }

    // Check availability
    const availability = checkAvailability(villageId, checkIn, checkOut);
    if (!availability.available) {
        return { success: false, message: availability.message };
    }

    // Get village
    const village = getVillageById(villageId);
    if (!village) {
        return { success: false, message: 'Village not found' };
    }

    // Validate guest count
    if (guests < 1 || guests > village.capacity) {
        return { success: false, message: `Guest count must be between 1 and ${village.capacity}` };
    }

    // Calculate price
    const pricing = calculateTotalPrice(village.price, checkIn, checkOut, guests);

    // Create booking
    const booking = new Booking(
        parseInt(villageId),
        user.id,
        checkIn,
        checkOut,
        guests,
        pricing.total
    );

    // Save booking
    const bookings = getAllBookings();
    bookings.push(booking);
    saveBookings(bookings);

    return {
        success: true,
        message: 'Booking created successfully!',
        booking,
        pricing
    };
}

// Cancel booking
function cancelBooking(bookingId) {
    const bookings = getAllBookings();
    const bookingIndex = bookings.findIndex(b => b.id === parseInt(bookingId));

    if (bookingIndex === -1) {
        return { success: false, message: 'Booking not found' };
    }

    // Update status
    bookings[bookingIndex].status = 'cancelled';
    saveBookings(bookings);

    return { success: true, message: 'Booking cancelled successfully' };
}

// Update booking
function updateBooking(bookingId, updates) {
    const bookings = getAllBookings();
    const bookingIndex = bookings.findIndex(b => b.id === parseInt(bookingId));

    if (bookingIndex === -1) {
        return { success: false, message: 'Booking not found' };
    }

    const booking = bookings[bookingIndex];

    // If dates are being updated, validate and check availability
    if (updates.checkIn || updates.checkOut) {
        const newCheckIn = updates.checkIn || booking.checkIn;
        const newCheckOut = updates.checkOut || booking.checkOut;

        const dateValidation = validateBookingDates(newCheckIn, newCheckOut);
        if (!dateValidation.valid) {
            return { success: false, message: dateValidation.message };
        }

        // Temporarily remove this booking to check availability
        const tempBookings = bookings.filter((_, i) => i !== bookingIndex);
        localStorage.setItem('bookings', JSON.stringify(tempBookings));

        const availability = checkAvailability(booking.villageId, newCheckIn, newCheckOut);

        // Restore bookings
        saveBookings(bookings);

        if (!availability.available) {
            return { success: false, message: availability.message };
        }

        booking.checkIn = newCheckIn;
        booking.checkOut = newCheckOut;

        // Recalculate price
        const village = getVillageById(booking.villageId);
        const pricing = calculateTotalPrice(village.price, newCheckIn, newCheckOut, booking.guests);
        booking.totalPrice = pricing.total;
    }

    if (updates.guests) {
        const village = getVillageById(booking.villageId);
        if (updates.guests < 1 || updates.guests > village.capacity) {
            return { success: false, message: `Guest count must be between 1 and ${village.capacity}` };
        }
        booking.guests = updates.guests;

        // Recalculate price
        const pricing = calculateTotalPrice(village.price, booking.checkIn, booking.checkOut, updates.guests);
        booking.totalPrice = pricing.total;
    }

    bookings[bookingIndex] = booking;
    saveBookings(bookings);

    return { success: true, message: 'Booking updated successfully', booking };
}

// Format date for display
function formatDate(dateString) {
    const options = { year: 'numeric', month: 'short', day: 'numeric' };
    return new Date(dateString).toLocaleDateString('en-US', options);
}

// Format price
function formatPrice(price) {
    return new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 0
    }).format(price);
}
