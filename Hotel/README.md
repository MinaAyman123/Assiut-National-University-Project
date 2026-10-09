# Hotel Booking System - FastAPI Backend

A comprehensive hotel booking system built with FastAPI, SQLite, and Python. This backend provides a RESTful API for managing hotels, bookings, users, and reviews.

## Features

- **User Authentication**: Register, login, and JWT-based authentication
- **Hotel Management**: CRUD operations for hotels with amenities
- **Booking System**: Create, view, and cancel bookings with availability checking
- **Reviews & Ratings**: Add reviews and automatically calculate hotel ratings
- **Search & Filter**: Filter hotels by location, category, price, rating, and more
- **Owner Support**: Special role for hotel owners to manage their properties

## Installation

1. Install dependencies:
```bash
pip install -r requirements.txt
```

2. Run the application:
```bash
python app.py
```

Or using uvicorn directly:
```bash
uvicorn app:app --reload
```

The API will be available at `http://localhost:8000`

## API Documentation

Once the server is running, you can access:
- **Interactive API Docs**: `http://localhost:8000/docs` (Swagger UI)
- **Alternative Docs**: `http://localhost:8000/redoc` (ReDoc)

## Database Schema

The SQLite database includes the following tables:

- **users**: User accounts with authentication
- **hotels**: Hotel/villa listings
- **hotel_amenities**: Amenities for each hotel
- **bookings**: User bookings
- **reviews**: User reviews and ratings

## API Endpoints

### Authentication
- `POST /api/auth/register` - Register a new user
- `POST /api/auth/login` - Login and get JWT token
- `GET /api/auth/me` - Get current user info

### Hotels
- `GET /api/hotels` - List all hotels (with filters)
- `GET /api/hotels/{hotel_id}` - Get hotel details
- `POST /api/hotels` - Create a new hotel (owner only)
- `PUT /api/hotels/{hotel_id}` - Update hotel (owner only)
- `DELETE /api/hotels/{hotel_id}` - Delete hotel (owner only)

### Bookings
- `GET /api/bookings` - Get user's bookings
- `GET /api/bookings/{booking_id}` - Get booking details
- `POST /api/bookings` - Create a new booking
- `PUT /api/bookings/{booking_id}/cancel` - Cancel a booking

### Reviews
- `GET /api/hotels/{hotel_id}/reviews` - Get hotel reviews
- `POST /api/reviews` - Create a review

## Usage Examples

### Register a User
```bash
curl -X POST "http://localhost:8000/api/auth/register" \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "password": "password123",
    "name": "John Doe",
    "is_owner": false
  }'
```

### Login
```bash
curl -X POST "http://localhost:8000/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "password": "password123"
  }'
```

### Get Hotels (with filters)
```bash
curl "http://localhost:8000/api/hotels?location=Santorini&min_price=300&max_price=500"
```

### Create a Booking (requires authentication)
```bash
curl -X POST "http://localhost:8000/api/bookings" \
  -H "Authorization: Bearer YOUR_TOKEN" \
  -H "Content-Type: application/json" \
  -d '{
    "hotel_id": 1,
    "check_in": "2025-12-01",
    "check_out": "2025-12-05",
    "guests": 2
  }'
```

## Frontend Integration

The frontend files in the `template/` and `static/` directories are served automatically. To connect the frontend JavaScript to the API, update the API base URL in your JavaScript files:

```javascript
const API_BASE_URL = 'http://localhost:8000/api';
```

## Security Notes

- Change the `SECRET_KEY` in production
- Use environment variables for sensitive configuration
- Implement rate limiting for production
- Add HTTPS in production
- Consider using OAuth2 for enhanced security

## Database

The SQLite database file (`hotel_booking.db`) will be created automatically when you first run the application. The database schema is defined using SQLAlchemy ORM.

## License

This project is open source and available for educational purposes.

