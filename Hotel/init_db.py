"""
Database initialization script with sample data
Run this script to populate the database with sample hotels and users
"""

from sqlalchemy.orm import Session
from app import Base, engine, SessionLocal, get_password_hash, User, Hotel, HotelAmenity

def init_db():
    # Create all tables
    Base.metadata.create_all(bind=engine)
    
    db = SessionLocal()
    
    try:
        # Check if data already exists
        if db.query(User).count() > 0:
            print("Database already initialized. Skipping...")
            return
        
        # Create sample users
        users = [
            User(
                email="admin@hotel.com",
                hashed_password=get_password_hash("admin123"),
                name="Admin User",
                is_owner=True
            ),
            User(
                email="john@example.com",
                hashed_password=get_password_hash("password123"),
                name="John Doe",
                is_owner=False
            ),
            User(
                email="owner@hotel.com",
                hashed_password=get_password_hash("owner123"),
                name="Hotel Owner",
                is_owner=True
            )
        ]
        
        for user in users:
            db.add(user)
        db.commit()
        
        # Get owner user
        owner = db.query(User).filter(User.email == "owner@hotel.com").first()
        
        # Create sample hotels
        hotels_data = [
            {
                "name": "Azure Coast Retreat",
                "location": "Santorini, Greece",
                "description": "Experience the ultimate Mediterranean luxury in our stunning coastal retreat. White-washed villas cascade down the cliff, offering breathtaking views of the Aegean Sea.",
                "price": 350.0,
                "capacity": 6,
                "bedrooms": 3,
                "bathrooms": 2,
                "image": "assets/images/village_coastal_luxury_1764037481506.png",
                "category": "coastal",
                "featured": True,
                "latitude": 36.3932,
                "longitude": 25.4615,
                "amenities": ["Infinity Pool", "Ocean View", "WiFi", "Air Conditioning", "Kitchen", "Parking", "Beach Access", "Restaurant"]
            },
            {
                "name": "Alpine Paradise Lodge",
                "location": "Swiss Alps, Switzerland",
                "description": "Nestled in the heart of the Swiss Alps, our mountain retreat offers cozy wooden chalets with panoramic mountain views.",
                "price": 420.0,
                "capacity": 8,
                "bedrooms": 4,
                "bathrooms": 3,
                "image": "assets/images/village_mountain_retreat_1764037497020.png",
                "category": "mountain",
                "featured": True,
                "latitude": 46.2044,
                "longitude": 6.1432,
                "amenities": ["Mountain View", "Fireplace", "Ski Storage", "Sauna", "WiFi", "Heating", "Kitchen", "Parking"]
            },
            {
                "name": "Maldives Water Villas",
                "location": "Maldives",
                "description": "Discover paradise in our exclusive overwater bungalows. Wake up to crystal-clear turquoise waters and pristine white sand beaches.",
                "price": 650.0,
                "capacity": 4,
                "bedrooms": 2,
                "bathrooms": 2,
                "image": "assets/images/village_tropical_paradise_1764037516016.png",
                "category": "tropical",
                "featured": True,
                "latitude": 3.2028,
                "longitude": 73.2207,
                "amenities": ["Overwater Villa", "Private Pool", "Snorkeling", "Spa Access", "WiFi", "Air Conditioning", "Restaurant", "Butler Service"]
            },
            {
                "name": "Desert Oasis Resort",
                "location": "Dubai, UAE",
                "description": "Experience Arabian luxury in our exclusive desert oasis. Traditional architecture meets modern comfort.",
                "price": 480.0,
                "capacity": 5,
                "bedrooms": 3,
                "bathrooms": 2,
                "image": "assets/images/village_desert_oasis_1764037532670.png",
                "category": "desert",
                "featured": False,
                "latitude": 25.2048,
                "longitude": 55.2708,
                "amenities": ["Pool", "Desert View", "WiFi", "Air Conditioning", "Spa", "Restaurant", "Safari Tours", "Parking"]
            },
            {
                "name": "Nordic Lake Cabins",
                "location": "Lapland, Finland",
                "description": "Serene lakeside cabins in the heart of Finnish Lapland. Perfect for Northern Lights viewing and peaceful nature retreats.",
                "price": 320.0,
                "capacity": 4,
                "bedrooms": 2,
                "bathrooms": 1,
                "image": "assets/images/village_lakeside_cabin_1764037591953.png",
                "category": "lakeside",
                "featured": False,
                "latitude": 68.9961,
                "longitude": 27.4249,
                "amenities": ["Lake View", "Sauna", "Fireplace", "WiFi", "Heating", "Kitchen", "Boat Rental", "Fishing"]
            },
            {
                "name": "Tuscan Vineyard Villas",
                "location": "Tuscany, Italy",
                "description": "Immerse yourself in Italian countryside charm at our Tuscan vineyard estate. Stone villas surrounded by rolling hills and vineyards.",
                "price": 380.0,
                "capacity": 6,
                "bedrooms": 3,
                "bathrooms": 2,
                "image": "assets/images/village_countryside_vineyard_1764037610747.png",
                "category": "countryside",
                "featured": False,
                "latitude": 43.7696,
                "longitude": 11.2558,
                "amenities": ["Vineyard View", "Pool", "Wine Tasting", "WiFi", "Kitchen", "Garden", "Parking", "Bicycles"]
            },
            {
                "name": "Coastal Sunset Haven",
                "location": "Algarve, Portugal",
                "description": "Luxurious beachfront escape on Portugal's stunning Algarve coast. Modern villas with panoramic ocean views.",
                "price": 295.0,
                "capacity": 5,
                "bedrooms": 2,
                "bathrooms": 2,
                "image": "assets/images/hero_background_1764037443889.png",
                "category": "coastal",
                "featured": True,
                "latitude": 37.0179,
                "longitude": -7.9304,
                "amenities": ["Beach Access", "Ocean View", "Pool", "WiFi", "Air Conditioning", "Kitchen", "Terrace", "Parking"]
            }
        ]
        
        for hotel_data in hotels_data:
            amenities = hotel_data.pop("amenities")
            hotel = Hotel(**hotel_data, owner_id=owner.id)
            db.add(hotel)
            db.flush()  # Get the hotel ID
            
            # Add amenities
            for amenity in amenities:
                db_amenity = HotelAmenity(hotel_id=hotel.id, amenity=amenity)
                db.add(db_amenity)
        
        db.commit()
        print("Database initialized successfully!")
        print(f"Created {len(users)} users and {len(hotels_data)} hotels")
        print("\nSample login credentials:")
        print("  Admin: admin@hotel.com / admin123")
        print("  User: john@example.com / password123")
        print("  Owner: owner@hotel.com / owner123")
        
    except Exception as e:
        db.rollback()
        print(f"Error initializing database: {e}")
        raise
    finally:
        db.close()

if __name__ == "__main__":
    init_db()

