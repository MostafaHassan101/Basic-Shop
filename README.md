# Basic Shop

## Introduction

Welcome to the Basic Shop web application project! This README file provides an overview of the tasks and technologies used in the project. The goal of this project is to develop a full-stack web application with a focus on both backend and frontend development. The application consists of three main pages: a Welcome page, a Product CRUD (Create, Read, Update, Delete) page, and a Shopping Cart CRUD page.

## Task Overview

The task involves building a Basic Shop web application with the following pages:
1. **Welcome Page**: A static welcome page with links to the admin and customer pages.
2. **Admin View**: A CRUD interface where admins (or anyone who clicks on that link) can create, list, and modify products.
3. **Shop and Cart View**: A CRUD interface for the Shopping Cart, displaying only visible products.

## Technologies Used

### Backend
- **Clean Architecture**: The project follows the principles of Clean Architecture to ensure a scalable and maintainable codebase.
- **.NET Core 8 API**: The backend is built using .NET Core 8 to create a robust and efficient API.

### Frontend
- **Single Page Application (SPA)**: The frontend is developed as a Single Page Application (SPA) using Angular v16.
- **Angular**: Angular is used for building the dynamic and responsive user interface.

## URLs

- **Website**: [http://bshopui.runasp.net](http://bshopui.runasp.net)
- **Web API**: [http://bshop.runasp.net/swagger/index.html](http://bshop.runasp.net/swagger/index.html)

## Getting Started

To get started with the project, follow these steps:

1. **Clone the Repository**: Clone the project repository to your local machine.
2. **Backend Setup**:
   - Navigate to the backend project directory.
   - Install the required dependencies using `dotnet restore`.
   - Run the database migrations to set up the database schema or restore the database backup in the `Database Backups` folder.
   - Start the backend server using `dotnet run`.
3. **Frontend Setup**:
   - Navigate to the frontend project directory.
   - Install the required dependencies using `npm install --force`.
   - Start the frontend development server using `ng serve`.
4. **Access the Application**: Open your browser and navigate to the provided URL to access the application.

## Conclusion

This README file provides an overview of the tasks and technologies used in the Basic Shop web application project. By following the instructions and requirements outlined above, you will be able to develop a fully functional web application with both backend and frontend components. If you have any questions or need further assistance, please refer to the project documentation or contact the project maintainers.

Happy coding!