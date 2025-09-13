# Movie Search API

A .NET 9 Web API that provides movie search functionality using the OMDB API and stores request analytics in MongoDB.

## Features

- 🔍 Search movies by title using OMDB API
- 📊 Request analytics and logging
- 🗄️ MongoDB integration for data persistence
- 🔐 API Key authentication
- 📈 Admin endpoints for analytics
- 🐳 Docker support for MongoDB

## Prerequisites

- .NET 9 SDK
- Docker and Docker Compose
- MongoDB (via Docker)

## Quick Start

### 1. Clone the Repository
```bash
git clone <repository-url>
cd movie-search
```

### 2. Set Up Environment Variables
Create a `.env` file in the project root:
```bash
cp .env-example .env
```

Edit `.env` with your MongoDB credentials:
```env
MONGO_INITDB_ROOT_USERNAME=root
MONGO_INITDB_ROOT_PASSWORD=root
```

### 3. Start MongoDB
```bash
# Start MongoDB container
sudo docker-compose up -d

# Verify MongoDB is running
sudo docker ps
```

### 4. Fix MongoDB Permissions (Important!)
If you encounter permission errors with MongoDB, run these commands:

```bash
# Stop the container
sudo docker-compose down

# Fix permissions on the data directory
sudo chown -R 999:999 ./docker/mongo-data

# Start fresh
sudo docker-compose up -d

# Test connection
sudo docker exec -it movie-search-db mongosh --eval "db.adminCommand('ping')"
```

### 5. Configure the application

### API Key Authentication
Set your API key in `appsettings.Development.json`:
```json
{
  "Authentication": {
    "ApiKey": {
      "HeaderName": "X-API-KEY",
      "Key": "your-api-key-here"
    }
  }
}
```

### MongoDB Settings
Configure MongoDB connection in `appsettings.Development.json`:
```json
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://root:root@localhost:27017",
    "DatabaseName": "MovieDb"
  }
}
```

### OMDB API Settings
Configure external movie API in `appsettings.Development.json`:
```json
{
  "ExternalServices": {
    "MovieApiSettings": {
      "BaseUrl": "http://www.omdbapi.com",
      "ApiKey": "your-omdb-api-key"
    }
  }
}
```

### 6. Run the Application
```bash
# Navigate to the API project
cd src/MovieSearch.Api

# Run the application
dotnet run
```

The API will be available at:
- **API**: http://localhost:5062

## API Endpoints

### Movie Search
- **GET** `/api/movies?movieTitle={title}`
  - Search for a movie by title

### Admin Endpoints
- Requires API key in header: `X-API-KEY`
- **GET** `/api/admin/requests` - Get all requests
- **GET** `/api/admin/requests/range?startDate={date}&endDate={date}` - Get requests by date range
- **GET** `/api/admin/requests/day/{date}` - Get requests by specific day
- **GET** `/api/admin/requests/ip/{ipAddress}` - Get requests by IP address

## Project Structure

```
src/
├── MovieSearch.Api/                 # Main API project
│   ├── Controllers/                 # API controllers
│   ├── Filters/                     # Authentication filters
│   └── Program.cs                   # Application entry point
├── MovieSearch.Api.Application/      # Application layer
│   ├── Contracts/                   # Service interfaces
│   ├── Services/                    # Business logic services
│   └── Dtos/                        # Data transfer objects
├── MovieSearch.Api.Domain/          # Domain entities
│   └── Entities/                    # Domain models
├── MovieSearch.Api.Infrastructure/   # Infrastructure layer
│   ├── Database/                    # MongoDB repositories
│   ├── Integrations/               # External API clients
│   └── Dtos/                       # Infrastructure DTOs
└── MovieSearch.Api.Shared/          # Shared components
    ├── Exceptions/                  # Custom exceptions
    └── Options/                     # Configuration options
```

## Troubleshooting

### MongoDB Permission Issues
If you see errors like "Permission denied" when starting MongoDB:

1. **Check container status**:
   ```bash
   sudo docker logs movie-search-db
   ```

2. **Fix permissions**:
   ```bash
   sudo chown -R 999:999 ./docker/mongo-data
   sudo chmod -R 755 ./docker/mongo-data
   ```

3. **Restart container**:
   ```bash
   sudo docker-compose down
   sudo docker-compose up -d
   ```

### Authentication Errors
If you get MongoDB authentication errors:

1. **Verify environment variables**:
   ```bash
   sudo docker inspect movie-search-db | grep -A 10 "Env"
   ```

2. **Check connection string** in `appsettings.Development.json`

3. **Restart with fresh data**:
   ```bash
   sudo docker-compose down
   sudo rm -rf ./docker/mongo-data/*
   sudo docker-compose up -d
   ```

### API Key Issues
- Ensure the `X-API-KEY` header is included in requests
- Verify the API key matches the one in `appsettings.Development.json`

## Technologies Used

- **.NET 9** - Web API framework
- **MongoDB** - NoSQL database
- **MongoDB.Driver** - MongoDB .NET driver
- **Docker** - Containerization
- **OMDB API** - External movie data source