# 🏨 Hotel Management System

A comprehensive hotel management system built with ASP.NET Core 8.0, featuring a modern web interface and robust REST API for managing hotel operations including bookings, staff, services, and customer communications.

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-purple)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-8.0-green)
![SQL Server](https://img.shields.io/badge/SQL_Server-Database-red)
![Bootstrap](https://img.shields.io/badge/Bootstrap-4.0-blue)

## 📖 Overview

This Hotel Management System provides a complete solution for hotel operations management. It includes both a RESTful API backend and a responsive web frontend, designed with clean architecture principles and modern development practices.

### 🎯 Key Features

- **🏠 Booking Management**: Complete reservation system with approval workflow
- **👥 Staff Management**: Employee registration and management
- **🛎️ Service Management**: Hotel services catalog and administration
- **📞 Contact System**: Customer inquiries and message management
- **🏃‍♂️ Guest Management**: Guest registration and profile management
- **🏨 Room Management**: Room inventory and pricing management
- **📧 Email Notifications**: Automated email system for booking status updates
- **🔐 Authentication & Authorization**: Secure login system with role-based access
- **📱 Responsive Design**: Mobile-friendly interface with Bootstrap
- **✅ Data Validation**: Comprehensive validation using FluentValidation


## 🎨 Project Screenshots
<img width="1255" height="914" alt="Ekran görüntüsü 2025-09-30 193622" src="https://github.com/user-attachments/assets/cdec15a6-a2ec-4fb8-971e-a8fe33657831" />
<img width="1255" height="919" alt="Ekran görüntüsü 2025-09-30 193642" src="https://github.com/user-attachments/assets/eec59235-af3c-4c74-9a77-d0b03914d1ac" />
<img width="1255" height="916" alt="Ekran görüntüsü 2025-09-30 194130" src="https://github.com/user-attachments/assets/e533d9e0-54e5-4817-8bd1-f3d7367f087a" />





## 🏗️ Architecture

The project follows Clean Architecture principles with clear separation of concerns:

```
HotelProject/
├── ApiConsume/                          # Backend API Layer
│   ├── HotelProject.Api/                # REST API Controllers
│   ├── HotelProject.BusinessLayer/      # Business Logic & Services
│   ├── HotelProject.DataAccessLayer/    # Data Access & Repository Pattern
│   ├── HotelProject.DtoLayer/           # Data Transfer Objects
│   └── HotelProject.EntityLayer/        # Domain Entities
└── Frontend/
    └── HotelProject.WebUI/              # MVC Web Application
```

## 🛠️ Technologies Used

### Backend
- **ASP.NET Core 8.0** - Web API framework
- **Entity Framework Core 8.0** - Object-Relational Mapping
- **SQL Server** - Database management system
- **AutoMapper 12.0** - Object-to-object mapping
- **FluentValidation 11.5** - Input validation
- **ASP.NET Core Identity 8.0** - Authentication & authorization
- **Swagger/OpenAPI** - API documentation

### Frontend
- **ASP.NET Core MVC 8.0** - Web framework
- **Bootstrap 4** - CSS framework
- **jQuery** - JavaScript library
- **Font Awesome** - Icon library
- **AdminLTE** - Admin dashboard template

### Development Tools
- **Repository Pattern** - Data access abstraction
- **Dependency Injection** - IoC container
- **SOLID Principles** - Clean code practices
- **RESTful API Design** - Standard HTTP methods

## 📋 Prerequisites

Before running this application, make sure you have the following installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB or full installation)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/) (optional, for database management)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/hotel-management-system.git
cd hotel-management-system
```

### 2. Database Setup

1. Update the connection string in both projects:
   - `ApiConsume/HotelProject.Api/appsettings.json`
   - `Frontend/HotelProject.WebUI/appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=HotelProjectDb;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

2. Apply database migrations:

```bash
# Navigate to the API project
cd ApiConsume/HotelProject.Api

# Create and apply migrations
dotnet ef database update
```

### 3. Run the Applications

#### Option 1: Using Visual Studio
1. Set both `HotelProject.Api` and `HotelProject.WebUI` as startup projects
2. Press `F5` to run both applications simultaneously

#### Option 2: Using Command Line

Terminal 1 (API):
```bash
cd ApiConsume/HotelProject.Api
dotnet run
```

Terminal 2 (Web UI):
```bash
cd Frontend/HotelProject.WebUI
dotnet run
```

### 4. Access the Applications

- **API Documentation**: `https://localhost:7242/swagger`
- **Web Application**: `https://localhost:7041`
- **Admin Panel**: `https://localhost:7041/AdminLayout`

### 5. Default Login Credentials

The system creates a default admin user on first run:
- **Email**: `admin@hotel.com`
- **Password**: `Admin123!`

## 📚 API Documentation

### Base URLs
- **API**: `https://localhost:7242/api`
- **Web UI**: `https://localhost:7041`

### Core Endpoints

#### 🏨 Booking Management
```http
GET    /api/Booking                     # Get all bookings
GET    /api/Booking/{id}                # Get booking by ID
POST   /api/Booking                     # Create new booking
PUT    /api/Booking                     # Update booking
DELETE /api/Booking/{id}                # Delete booking
PUT    /api/Booking/ApproveBooking      # Approve booking
PUT    /api/Booking/RejectBooking       # Reject booking
PUT    /api/Booking/AddToWaitList       # Add to wait list
GET    /api/Booking/GetByStatus/{status} # Get bookings by status
```

#### 🏠 Room Management
```http
GET    /api/Room                        # Get all rooms
GET    /api/Room/{id}                   # Get room by ID
POST   /api/Room                        # Create new room
PUT    /api/Room                        # Update room
DELETE /api/Room/{id}                   # Delete room
```

#### 👥 Staff Management
```http
GET    /api/Staff                       # Get all staff
GET    /api/Staff/{id}                  # Get staff by ID
POST   /api/Staff                       # Create new staff
PUT    /api/Staff                       # Update staff
DELETE /api/Staff/{id}                  # Delete staff
```

#### 🛎️ Service Management
```http
GET    /api/Service                     # Get all services
GET    /api/Service/{id}                # Get service by ID
POST   /api/Service                     # Create new service
PUT    /api/Service                     # Update service
DELETE /api/Service/{id}                # Delete service
```

### Request/Response Examples

#### Create Booking Request
```json
POST /api/Booking
{
    "name": "John Doe",
    "email": "john.doe@email.com",
    "checkIn": "2024-10-15T14:00:00",
    "checkOut": "2024-10-20T12:00:00",
    "adultCount": "2",
    "childrenCount": "1",
    "roomCount": "1",
    "specialRequest": "Late checkout if possible",
    "description": "Honeymoon suite preferred"
}
```

#### Booking Response
```json
{
    "bookingId": 1,
    "name": "John Doe",
    "email": "john.doe@email.com",
    "checkIn": "2024-10-15T14:00:00",
    "checkOut": "2024-10-20T12:00:00",
    "adultCount": "2",
    "childrenCount": "1",
    "roomCount": "1",
    "specialRequest": "Late checkout if possible",
    "description": "Honeymoon suite preferred",
    "status": "Pending"
}
```

## 🎨 Web Interface Features

### Public Pages
- **Homepage**: Hotel overview and featured services
- **Booking Form**: Online reservation system
- **Contact Page**: Customer inquiries
- **Services**: Hotel amenities and services

### Admin Dashboard
- **Booking Management**: View, approve, reject, and manage reservations
- **Staff Administration**: Employee management
- **Room Management**: Room inventory control
- **Service Management**: Hotel services administration
- **Contact Management**: Customer inquiry handling
- **Guest Management**: Guest profile administration

## 🔧 Configuration

### Email Settings
Configure SMTP settings in `appsettings.json`:

```json
{
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "SmtpUsername": "your-email@gmail.com",
    "SmtpPassword": "your-app-password",
    "FromEmail": "your-email@gmail.com",
    "FromName": "Hotel Management System"
  }
}
```

### Security Settings
- **CSRF Protection**: Enabled with X-CSRF-TOKEN header
- **HTTPS Redirection**: Enforced in production
- **Secure Cookies**: HttpOnly and SameSite policies
- **HSTS**: HTTP Strict Transport Security enabled

## 🧪 Testing

Run the test suite:

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## 📦 Deployment

### IIS Deployment

1. Publish the applications:
```bash
dotnet publish -c Release -o ./publish
```

2. Configure IIS with the published files
3. Update connection strings for production database
4. Configure SSL certificates

### Docker Deployment

```dockerfile
# Dockerfile example
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HotelProject.Api/HotelProject.Api.csproj", "HotelProject.Api/"]
RUN dotnet restore "HotelProject.Api/HotelProject.Api.csproj"
COPY . .
WORKDIR "/src/HotelProject.Api"
RUN dotnet build "HotelProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HotelProject.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelProject.Api.dll"]
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
