from fastapi import FastAPI, HTTPException, Depends, status
from fastapi.security import HTTPBearer, HTTPAuthorizationCredentials
from fastapi.staticfiles import StaticFiles
from fastapi.responses import HTMLResponse, FileResponse
from fastapi.middleware.cors import CORSMiddleware
from sqlalchemy import create_engine, Column, Integer, String, Float, Boolean, DateTime, ForeignKey, Text
from sqlalchemy.orm import sessionmaker, Session, relationship, declarative_base
from pydantic import BaseModel, EmailStr
from typing import Optional, List
from datetime import datetime, date
import bcrypt
from jose import JWTError, jwt
import os
from pathlib import Path

# Database setup
SQLALCHEMY_DATABASE_URL = "sqlite:///./hotel_booking.db"
engine = create_engine(SQLALCHEMY_DATABASE_URL, connect_args={"check_same_thread": False})
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)
Base = declarative_base()

# Security
SECRET_KEY = "your-secret-key-change-in-production"
ALGORITHM = "HS256"
security = HTTPBearer()

# FastAPI app
app = FastAPI(title="Hotel Booking API", version="1.0.0")

# CORS middleware
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# Mount static files
static_path = Path(__file__).parent / "static"
template_path = Path(__file__).parent / "template"
assets_path = Path(__file__).parent / "static" / "assets"

if static_path.exists():
    app.mount("/static", StaticFiles(directory=str(static_path)), name="static")
# Note: /assets requests are handled by the route handler below for better control


# ===================================
# DATABASE MODELS
# ===================================

class User(Base):
    __tablename__ = "users"
    
    id = Column(Integer, primary_key=True, index=True)
    email = Column(String, unique=True, index=True, nullable=False)
    hashed_password = Column(String, nullable=False)
    name = Column(String, nullable=False)
    created_at = Column(DateTime, default=datetime.utcnow)
    is_owner = Column(Boolean, default=False)
    
    bookings = relationship("Booking", back_populates="user")
    reviews = relationship("Review", back_populates="user")


class Hotel(Base):
    __tablename__ = "hotels"
    
    id = Column(Integer, primary_key=True, index=True)
    name = Column(String, nullable=False)
    location = Column(String, nullable=False)
    description = Column(Text)
    price = Column(Float, nullable=False)
    rating = Column(Float, default=0.0)
    reviews_count = Column(Integer, default=0)
    capacity = Column(Integer, nullable=False)
    bedrooms = Column(Integer, nullable=False)
    bathrooms = Column(Integer, nullable=False)
    image = Column(String)
    category = Column(String)
    featured = Column(Boolean, default=False)
    availability = Column(Boolean, default=True)
    latitude = Column(Float)
    longitude = Column(Float)
    owner_id = Column(Integer, ForeignKey("users.id"))
    created_at = Column(DateTime, default=datetime.utcnow)
    
    bookings = relationship("Booking", back_populates="hotel")
    reviews = relationship("Review", back_populates="hotel")
    amenities = relationship("HotelAmenity", back_populates="hotel")


class HotelAmenity(Base):
    __tablename__ = "hotel_amenities"
    
    id = Column(Integer, primary_key=True, index=True)
    hotel_id = Column(Integer, ForeignKey("hotels.id"))
    amenity = Column(String, nullable=False)
    
    hotel = relationship("Hotel", back_populates="amenities")


class Booking(Base):
    __tablename__ = "bookings"
    
    id = Column(Integer, primary_key=True, index=True)
    hotel_id = Column(Integer, ForeignKey("hotels.id"), nullable=False)
    user_id = Column(Integer, ForeignKey("users.id"), nullable=False)
    check_in = Column(DateTime, nullable=False)
    check_out = Column(DateTime, nullable=False)
    guests = Column(Integer, nullable=False)
    total_price = Column(Float, nullable=False)
    status = Column(String, default="confirmed")  # confirmed, cancelled, completed
    created_at = Column(DateTime, default=datetime.utcnow)
    
    hotel = relationship("Hotel", back_populates="bookings")
    user = relationship("User", back_populates="bookings")


class Review(Base):
    __tablename__ = "reviews"
    
    id = Column(Integer, primary_key=True, index=True)
    hotel_id = Column(Integer, ForeignKey("hotels.id"), nullable=False)
    user_id = Column(Integer, ForeignKey("users.id"), nullable=False)
    rating = Column(Integer, nullable=False)  # 1-5
    comment = Column(Text)
    created_at = Column(DateTime, default=datetime.utcnow)
    
    hotel = relationship("Hotel", back_populates="reviews")
    user = relationship("User", back_populates="reviews")


# Create tables
Base.metadata.create_all(bind=engine)


# ===================================
# PYDANTIC SCHEMAS
# ===================================

class UserCreate(BaseModel):
    email: EmailStr
    password: str
    name: str
    is_owner: bool = False


class UserResponse(BaseModel):
    id: int
    email: str
    name: str
    is_owner: bool
    created_at: datetime
    
    class Config:
        from_attributes = True


class UserLogin(BaseModel):
    email: EmailStr
    password: str


class Token(BaseModel):
    access_token: str
    token_type: str


class HotelCreate(BaseModel):
    name: str
    location: str
    description: Optional[str] = None
    price: float
    capacity: int
    bedrooms: int
    bathrooms: int
    image: Optional[str] = None
    category: Optional[str] = None
    featured: bool = False
    latitude: Optional[float] = None
    longitude: Optional[float] = None
    amenities: List[str] = []


class HotelUpdate(BaseModel):
    name: Optional[str] = None
    location: Optional[str] = None
    description: Optional[str] = None
    price: Optional[float] = None
    capacity: Optional[int] = None
    bedrooms: Optional[int] = None
    bathrooms: Optional[int] = None
    image: Optional[str] = None
    category: Optional[str] = None
    featured: Optional[bool] = None
    availability: Optional[bool] = None
    latitude: Optional[float] = None
    longitude: Optional[float] = None
    amenities: Optional[List[str]] = None


class HotelResponse(BaseModel):
    id: int
    name: str
    location: str
    description: Optional[str]
    price: float
    rating: float
    reviews_count: int
    capacity: int
    bedrooms: int
    bathrooms: int
    image: Optional[str]
    category: Optional[str]
    featured: bool
    availability: bool
    latitude: Optional[float]
    longitude: Optional[float]
    amenities: List[str]
    created_at: datetime
    
    class Config:
        from_attributes = True


class BookingCreate(BaseModel):
    hotel_id: int
    check_in: date
    check_out: date
    guests: int


class BookingResponse(BaseModel):
    id: int
    hotel_id: int
    user_id: int
    check_in: datetime
    check_out: datetime
    guests: int
    total_price: float
    status: str
    created_at: datetime
    
    class Config:
        from_attributes = True


class ReviewCreate(BaseModel):
    hotel_id: int
    rating: int
    comment: Optional[str] = None


class ReviewResponse(BaseModel):
    id: int
    hotel_id: int
    user_id: int
    rating: int
    comment: Optional[str]
    created_at: datetime
    user_name: str
    
    class Config:
        from_attributes = True


# ===================================
# HELPER FUNCTIONS
# ===================================

def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


def verify_password(plain_password: str, hashed_password: str) -> bool:
    """Verify a password against a bcrypt hash"""
    # Ensure password is bytes
    if isinstance(plain_password, str):
        plain_password = plain_password.encode('utf-8')
    if isinstance(hashed_password, str):
        hashed_password = hashed_password.encode('utf-8')
    return bcrypt.checkpw(plain_password, hashed_password)


def get_password_hash(password: str) -> str:
    """Hash a password using bcrypt"""
    # Ensure password is bytes and truncate if necessary (bcrypt has 72 byte limit)
    if isinstance(password, str):
        password = password.encode('utf-8')
    # Truncate to 72 bytes if longer
    if len(password) > 72:
        password = password[:72]
    # Generate salt and hash
    salt = bcrypt.gensalt()
    hashed = bcrypt.hashpw(password, salt)
    # Return as string for database storage
    return hashed.decode('utf-8')


def create_access_token(data: dict):
    to_encode = data.copy()
    encoded_jwt = jwt.encode(to_encode, SECRET_KEY, algorithm=ALGORITHM)
    return encoded_jwt


async def get_current_user(
    credentials: HTTPAuthorizationCredentials = Depends(security),
    db: Session = Depends(get_db)
):
    credentials_exception = HTTPException(
        status_code=status.HTTP_401_UNAUTHORIZED,
        detail="Could not validate credentials",
        headers={"WWW-Authenticate": "Bearer"},
    )
    try:
        token = credentials.credentials
        payload = jwt.decode(token, SECRET_KEY, algorithms=[ALGORITHM])
        user_id: int = payload.get("sub")
        if user_id is None:
            raise credentials_exception
    except JWTError:
        raise credentials_exception
    
    user = db.query(User).filter(User.id == user_id).first()
    if user is None:
        raise credentials_exception
    return user


def calculate_booking_price(price_per_night: float, check_in: date, check_out: date, guests: int) -> dict:
    nights = (check_out - check_in).days
    base_price = price_per_night * nights
    guest_surcharge = (guests - 2) * 20 * nights if guests > 2 else 0
    subtotal = base_price + guest_surcharge
    service_fee = subtotal * 0.1
    total = subtotal + service_fee
    
    return {
        "nights": nights,
        "base_price": base_price,
        "guest_surcharge": guest_surcharge,
        "service_fee": service_fee,
        "total": total
    }


def check_availability(db: Session, hotel_id: int, check_in: date, check_out: date, exclude_booking_id: Optional[int] = None):
    check_in_dt = datetime.combine(check_in, datetime.min.time())
    check_out_dt = datetime.combine(check_out, datetime.min.time())
    
    query = db.query(Booking).filter(
        Booking.hotel_id == hotel_id,
        Booking.status != "cancelled",
        Booking.check_in < check_out_dt,
        Booking.check_out > check_in_dt
    )
    
    if exclude_booking_id:
        query = query.filter(Booking.id != exclude_booking_id)
    
    conflicting_bookings = query.all()
    return len(conflicting_bookings) == 0


# ===================================
# AUTHENTICATION ENDPOINTS
# ===================================

@app.post("/api/auth/register", response_model=UserResponse, status_code=status.HTTP_201_CREATED)
def register(user: UserCreate, db: Session = Depends(get_db)):
    # Check if user exists
    db_user = db.query(User).filter(User.email == user.email).first()
    if db_user:
        raise HTTPException(status_code=400, detail="Email already registered")
    
    # Create new user
    hashed_password = get_password_hash(user.password)
    db_user = User(
        email=user.email,
        hashed_password=hashed_password,
        name=user.name,
        is_owner=user.is_owner
    )
    db.add(db_user)
    db.commit()
    db.refresh(db_user)
    
    return db_user


@app.post("/api/auth/login", response_model=Token)
def login(user_credentials: UserLogin, db: Session = Depends(get_db)):
    user = db.query(User).filter(User.email == user_credentials.email).first()
    if not user or not verify_password(user_credentials.password, user.hashed_password):
        raise HTTPException(status_code=401, detail="Incorrect email or password")
    
    access_token = create_access_token(data={"sub": user.id})
    return {"access_token": access_token, "token_type": "bearer"}


@app.get("/api/auth/me", response_model=UserResponse)
def get_current_user_info(current_user: User = Depends(get_current_user)):
    return current_user


# ===================================
# HOTEL ENDPOINTS
# ===================================

@app.get("/api/hotels", response_model=List[HotelResponse])
def get_hotels(
    skip: int = 0,
    limit: int = 100,
    location: Optional[str] = None,
    category: Optional[str] = None,
    min_price: Optional[float] = None,
    max_price: Optional[float] = None,
    min_rating: Optional[float] = None,
    featured: Optional[bool] = None,
    db: Session = Depends(get_db)
):
    query = db.query(Hotel)
    
    if location:
        query = query.filter(Hotel.location.ilike(f"%{location}%"))
    if category:
        query = query.filter(Hotel.category == category)
    if min_price:
        query = query.filter(Hotel.price >= min_price)
    if max_price:
        query = query.filter(Hotel.price <= max_price)
    if min_rating:
        query = query.filter(Hotel.rating >= min_rating)
    if featured is not None:
        query = query.filter(Hotel.featured == featured)
    
    hotels = query.offset(skip).limit(limit).all()
    
    # Add amenities to response
    result = []
    for hotel in hotels:
        hotel_dict = {
            **{c.name: getattr(hotel, c.name) for c in hotel.__table__.columns},
            "amenities": [a.amenity for a in hotel.amenities]
        }
        result.append(HotelResponse(**hotel_dict))
    
    return result


@app.get("/api/hotels/{hotel_id}", response_model=HotelResponse)
def get_hotel(hotel_id: int, db: Session = Depends(get_db)):
    hotel = db.query(Hotel).filter(Hotel.id == hotel_id).first()
    if not hotel:
        raise HTTPException(status_code=404, detail="Hotel not found")
    
    hotel_dict = {
        **{c.name: getattr(hotel, c.name) for c in hotel.__table__.columns},
        "amenities": [a.amenity for a in hotel.amenities]
    }
    return HotelResponse(**hotel_dict)


@app.post("/api/hotels", response_model=HotelResponse, status_code=status.HTTP_201_CREATED)
def create_hotel(hotel: HotelCreate, current_user: User = Depends(get_current_user), db: Session = Depends(get_db)):
    if not current_user.is_owner:
        raise HTTPException(status_code=403, detail="Only owners can create hotels")
    
    db_hotel = Hotel(
        name=hotel.name,
        location=hotel.location,
        description=hotel.description,
        price=hotel.price,
        capacity=hotel.capacity,
        bedrooms=hotel.bedrooms,
        bathrooms=hotel.bathrooms,
        image=hotel.image,
        category=hotel.category,
        featured=hotel.featured,
        latitude=hotel.latitude,
        longitude=hotel.longitude,
        owner_id=current_user.id
    )
    db.add(db_hotel)
    db.commit()
    db.refresh(db_hotel)
    
    # Add amenities
    for amenity in hotel.amenities:
        db_amenity = HotelAmenity(hotel_id=db_hotel.id, amenity=amenity)
        db.add(db_amenity)
    db.commit()
    
    hotel_dict = {
        **{c.name: getattr(db_hotel, c.name) for c in db_hotel.__table__.columns},
        "amenities": hotel.amenities
    }
    return HotelResponse(**hotel_dict)


@app.put("/api/hotels/{hotel_id}", response_model=HotelResponse)
def update_hotel(
    hotel_id: int,
    hotel_update: HotelUpdate,
    current_user: User = Depends(get_current_user),
    db: Session = Depends(get_db)
):
    hotel = db.query(Hotel).filter(Hotel.id == hotel_id).first()
    if not hotel:
        raise HTTPException(status_code=404, detail="Hotel not found")
    
    if hotel.owner_id != current_user.id and not current_user.is_owner:
        raise HTTPException(status_code=403, detail="Not authorized to update this hotel")
    
    update_data = hotel_update.dict(exclude_unset=True)
    amenities = update_data.pop("amenities", None)
    
    for field, value in update_data.items():
        setattr(hotel, field, value)
    
    if amenities is not None:
        # Remove existing amenities
        db.query(HotelAmenity).filter(HotelAmenity.hotel_id == hotel_id).delete()
        # Add new amenities
        for amenity in amenities:
            db_amenity = HotelAmenity(hotel_id=hotel_id, amenity=amenity)
            db.add(db_amenity)
    
    db.commit()
    db.refresh(hotel)
    
    hotel_dict = {
        **{c.name: getattr(hotel, c.name) for c in hotel.__table__.columns},
        "amenities": [a.amenity for a in hotel.amenities]
    }
    return HotelResponse(**hotel_dict)


@app.delete("/api/hotels/{hotel_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_hotel(
    hotel_id: int,
    current_user: User = Depends(get_current_user),
    db: Session = Depends(get_db)
):
    hotel = db.query(Hotel).filter(Hotel.id == hotel_id).first()
    if not hotel:
        raise HTTPException(status_code=404, detail="Hotel not found")
    
    if hotel.owner_id != current_user.id and not current_user.is_owner:
        raise HTTPException(status_code=403, detail="Not authorized to delete this hotel")
    
    db.delete(hotel)
    db.commit()
    return None


# ===================================
# BOOKING ENDPOINTS
# ===================================

@app.get("/api/bookings", response_model=List[BookingResponse])
def get_bookings(
    current_user: User = Depends(get_current_user),
    db: Session = Depends(get_db)
):
    bookings = db.query(Booking).filter(Booking.user_id == current_user.id).all()
    return bookings


@app.get("/api/bookings/{booking_id}", response_model=BookingResponse)
def get_booking(booking_id: int, current_user: User = Depends(get_current_user), db: Session = Depends(get_db)):
    booking = db.query(Booking).filter(
        Booking.id == booking_id,
        Booking.user_id == current_user.id
    ).first()
    if not booking:
        raise HTTPException(status_code=404, detail="Booking not found")
    return booking


@app.post("/api/bookings", response_model=BookingResponse, status_code=status.HTTP_201_CREATED)
def create_booking(booking: BookingCreate, current_user: User = Depends(get_current_user), db: Session = Depends(get_db)):
    # Validate dates
    if booking.check_in >= booking.check_out:
        raise HTTPException(status_code=400, detail="Check-out date must be after check-in date")
    
    if booking.check_in < date.today():
        raise HTTPException(status_code=400, detail="Check-in date cannot be in the past")
    
    # Get hotel
    hotel = db.query(Hotel).filter(Hotel.id == booking.hotel_id).first()
    if not hotel:
        raise HTTPException(status_code=404, detail="Hotel not found")
    
    if not hotel.availability:
        raise HTTPException(status_code=400, detail="Hotel is not available")
    
    # Validate guest count
    if booking.guests < 1 or booking.guests > hotel.capacity:
        raise HTTPException(status_code=400, detail=f"Guest count must be between 1 and {hotel.capacity}")
    
    # Check availability
    if not check_availability(db, booking.hotel_id, booking.check_in, booking.check_out):
        raise HTTPException(status_code=400, detail="Hotel is not available for selected dates")
    
    # Calculate price
    pricing = calculate_booking_price(hotel.price, booking.check_in, booking.check_out, booking.guests)
    
    # Create booking
    db_booking = Booking(
        hotel_id=booking.hotel_id,
        user_id=current_user.id,
        check_in=datetime.combine(booking.check_in, datetime.min.time()),
        check_out=datetime.combine(booking.check_out, datetime.min.time()),
        guests=booking.guests,
        total_price=pricing["total"],
        status="confirmed"
    )
    db.add(db_booking)
    db.commit()
    db.refresh(db_booking)
    
    return db_booking


@app.put("/api/bookings/{booking_id}/cancel", response_model=BookingResponse)
def cancel_booking(booking_id: int, current_user: User = Depends(get_current_user), db: Session = Depends(get_db)):
    booking = db.query(Booking).filter(
        Booking.id == booking_id,
        Booking.user_id == current_user.id
    ).first()
    if not booking:
        raise HTTPException(status_code=404, detail="Booking not found")
    
    if booking.status == "cancelled":
        raise HTTPException(status_code=400, detail="Booking is already cancelled")
    
    booking.status = "cancelled"
    db.commit()
    db.refresh(booking)
    
    return booking


# ===================================
# REVIEW ENDPOINTS
# ===================================

@app.get("/api/hotels/{hotel_id}/reviews", response_model=List[ReviewResponse])
def get_hotel_reviews(hotel_id: int, db: Session = Depends(get_db)):
    reviews = db.query(Review).filter(Review.hotel_id == hotel_id).all()
    result = []
    for review in reviews:
        review_dict = {
            **{c.name: getattr(review, c.name) for c in review.__table__.columns},
            "user_name": review.user.name
        }
        result.append(ReviewResponse(**review_dict))
    return result


@app.post("/api/reviews", response_model=ReviewResponse, status_code=status.HTTP_201_CREATED)
def create_review(review: ReviewCreate, current_user: User = Depends(get_current_user), db: Session = Depends(get_db)):
    # Validate rating
    if review.rating < 1 or review.rating > 5:
        raise HTTPException(status_code=400, detail="Rating must be between 1 and 5")
    
    # Check if hotel exists
    hotel = db.query(Hotel).filter(Hotel.id == review.hotel_id).first()
    if not hotel:
        raise HTTPException(status_code=404, detail="Hotel not found")
    
    # Check if user already reviewed
    existing_review = db.query(Review).filter(
        Review.hotel_id == review.hotel_id,
        Review.user_id == current_user.id
    ).first()
    if existing_review:
        raise HTTPException(status_code=400, detail="You have already reviewed this hotel")
    
    # Create review
    db_review = Review(
        hotel_id=review.hotel_id,
        user_id=current_user.id,
        rating=review.rating,
        comment=review.comment
    )
    db.add(db_review)
    db.commit()
    
    # Update hotel rating
    all_reviews = db.query(Review).filter(Review.hotel_id == review.hotel_id).all()
    hotel.rating = sum(r.rating for r in all_reviews) / len(all_reviews)
    hotel.reviews_count = len(all_reviews)
    db.commit()
    db.refresh(db_review)
    
    review_dict = {
        **{c.name: getattr(db_review, c.name) for c in db_review.__table__.columns},
        "user_name": current_user.name
    }
    return ReviewResponse(**review_dict)


# ===================================
# STATIC FILE ROUTES (Handle asset requests)
# ===================================

@app.get("/assets/{file_path:path}")
async def serve_asset(file_path: str):
    """Serve assets from static/assets directory for backward compatibility"""
    asset_file = assets_path / file_path
    if asset_file.exists() and asset_file.is_file():
        return FileResponse(str(asset_file))
    # Fallback to static/assets
    static_asset = static_path / "assets" / file_path
    if static_asset.exists() and static_asset.is_file():
        return FileResponse(str(static_asset))
    raise HTTPException(status_code=404, detail="Asset not found")


# ===================================
# HTML ROUTES (Serve Frontend Pages)
# ===================================

@app.get("/", response_class=HTMLResponse)
async def read_root():
    index_path = template_path / "index.html"
    if index_path.exists():
        with open(index_path, "r", encoding="utf-8") as f:
            return f.read()
    return {"message": "Hotel Booking API", "version": "1.0.0"}


@app.get("/index.html", response_class=HTMLResponse)
async def index():
    index_path = template_path / "index.html"
    if index_path.exists():
        with open(index_path, "r", encoding="utf-8") as f:
            return f.read()
    raise HTTPException(status_code=404, detail="Page not found")


@app.get("/{page}.html", response_class=HTMLResponse)
async def serve_page(page: str):
    """Serve HTML pages"""
    page_path = template_path / f"{page}.html"
    if page_path.exists():
        with open(page_path, "r", encoding="utf-8") as f:
            return f.read()
    raise HTTPException(status_code=404, detail="Page not found")


if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="127.0.0.1", port=8000)

