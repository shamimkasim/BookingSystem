# Booking System

## Overview

The Booking System project is a web application designed to manage bookings efficiently. It provides user authentication, CRUD operations for booking data, and a user-friendly interface for managing bookings. The project follows Clean Architecture principles and uses Test-Driven Development (TDD) methodologies.

## Table of Contents

- [Project Overview](#project-overview)
- [Technologies Used](#technologies-used)
- [Project Structure](#project-structure)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [User Stories](#user-stories)
- [Contributing](#contributing)
- [License](#license)

## Project Overview

The goal of this project is to create a robust booking management system. Users can register, log in, and manage their bookings through a web interface. The system includes the following key features:

- User Authentication (Register, Login, Logout)
- Create, Read, Update, Delete (CRUD) operations for booking data
- RESTful API endpoints
- Front-end integration with the API
- Docker support for easy deployment

## Technologies Used

- .NET 5 or higher
- ASP.NET MVC
- ASP.NET Web API
- Dapper for data access
- Azure DevOps for project management
- Docker for containerization

## Project Structure

```plaintext
BookingSystem/
├── BookingSystem.API/           # Web API project
├── BookingSystem.Application/   # Application layer
├── BookingSystem.Domain/        # Domain layer
├── BookingSystem.Infrastructure/ # Infrastructure layer
├── BookingSystem.Web/           # MVC Web project
├── BookingSystem.Tests/         # Test project
├── docker-compose.yml           # Docker Compose file
└── README.md                    # Project README

## Create the Database

To set up the database for this project, follow these steps:

1. **Open your database management system (DBMS).** This guide assumes you are using a MySQL-compatible DBMS, but you may need to adjust the commands for other systems like PostgreSQL or SQL Server.

2. **Run the following SQL commands to create the database and tables:**

   ```sql
   CREATE DATABASE my_database;
   USE my_database;

   CREATE TABLE users (
       id INT AUTO_INCREMENT PRIMARY KEY,
       name VARCHAR(100) NOT NULL,
       email VARCHAR(100) NOT NULL UNIQUE,
       created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
   );

   CREATE TABLE posts (
       id INT AUTO_INCREMENT PRIMARY KEY,
       user_id INT NOT NULL,
       title VARCHAR(200) NOT NULL,
       content TEXT NOT NULL,
       created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
       FOREIGN KEY (user_id) REFERENCES users(id)
   );

