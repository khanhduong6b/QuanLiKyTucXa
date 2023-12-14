# Web Quản lý ký túc xá

This project is an ASP.NET Core web application designed for managing a student housing system. It includes controllers for handling various aspects such as room management, student registration, billing, and more. The application is structured in an "Admin" area to separate administrative functionalities.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Dependencies](#dependencies)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Overview

The Dormitory Management System is an ASP.NET Core project designed to facilitate the administration and management of a student dormitory. The system provides functionalities for managing dormitory rooms, student registrations, and billing for utility services.

## Features

PhongsController: Manages dormitory rooms, including creation, modification, and deletion. It allows administrators to view details of each room, including the number of current and maximum occupants.

PhieuDangKiesController: Handles the registration process for students interested in staying at the dormitory. It includes functionalities for creating, updating, and deleting registration entries. Administrators can also view details of each registration.

SinhVienController: Manages student information, including details such as name, student ID, and contact information. This controller enables administrators to add, edit, and remove student records from the system.

HoaDonsController: Manages billing for utility services in the dormitory. It includes functionalities for creating invoices, updating billing information, and viewing details of each billing transaction.

HoaDonPhongsController: Handles billing for individual student rooms. It provides functionalities for creating, updating, and deleting billing entries for specific rooms. Administrators can view detailed information about each billing transaction.

## Getting Started

### Prerequisites

- .NET Core SDK
- Visual Studio or Visual Studio Code (optional)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/khanhduong6b/QuanLyBanHang.git
    ```

2. Navigate to the project directory:

    ```bash
    cd your-project
    ```

3. Restore dependencies:

    ```bash
    dotnet restore
    ```

4. Run the application:

    ```bash
    dotnet run
    ```

## Project Structure

The project follows a typical ASP.NET Core structure with separate controllers, models, and helper classes. The organization is designed to provide clarity and maintainability. Key directories include:

Areas: Contains the different functional areas of the application, such as Admin.
Controllers: Houses the controllers responsible for handling HTTP requests.
Models: Defines the data models used in the application.
Helper: Contains utility classes or methods used across the project.
wwwroot: Stores static files, such as stylesheets or client-side scripts.

