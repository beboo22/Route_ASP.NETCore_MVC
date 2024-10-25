# MVC Project with Route Academy

## Overview

This project is a web application built using the MVC (Model-View-Controller) architectural pattern, structured into three distinct tiers: **Business Logic Layer (BLL)**, **Data Access Layer (DAL)**, and **Presentation Layer (PLL)**. The application manages departments, employees, user identities, and roles.

## Achievements

1. **Three-Tier Architecture**: The project is organized into three layers:
   - **BLL (Business Logic Layer)**: Contains the business logic and service classes that handle the core functionality of the application.
   - **DAL (Data Access Layer)**: Manages database connections and includes repositories that interact with the database.
   - **PLL (Presentation Layer)**: Responsible for the user interface, including controllers, views, and models.

2. **Service Implementation**: Developed services in the BLL to encapsulate business logic and facilitate communication between the controller and data layer.

3. **Database Connection and Repository**: Established a robust connection to the database in the DAL, implementing repositories to perform CRUD operations on data.

4. **Controller, View, and Model Creation**: Built the PLL to handle HTTP requests, render views, and manage models for the application.

## Database Structure

The application utilizes a relational database with the following tables:
- **Department**: Stores department information.
- **Employee**: Manages employee records.
- **UserIdentity**: Handles user authentication and identity management.
- **RoleIdentity**: Manages user roles and permissions.
- Other relevant tables as necessary.

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Database server (e.g., SQL Server, MySQL)
- Visual Studio or any compatible IDE

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/beboo22/Route_ASP.NETCore_MVC.git
