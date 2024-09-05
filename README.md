# BookAutomationApp

## Overview
**BookAutomationApp** is an ASP.NET Core MVC application designed to manage a collection of books and authors. It leverages Entity Framework Core for database management and integrates identity customization to handle user authentication and authorization. The application provides a robust and user-friendly interface for managing books, authors, and user accounts.

## Features
- **User Authentication and Authorization**: Customized identity management with roles and policies.
- **Book Management**: Create, read, update, and delete operations for books.
- **Author Management**: Manage author details and associate them with books.
- **Custom Layout**: The application uses a custom layout with Bootstrap for styling, including navigation links and a footer.
- **Responsive Design**: Ensures usability across various devices.

## Project Structure
The project is organized into the following key components:

- **Controllers**: Handles incoming requests, processes them, and returns the appropriate responses.
- **Models**: Defines the data structure and interacts with the database.
- **Views**: Contains the Razor pages responsible for rendering the UI.
- **Data**: Contains the application's DbContext and identity-related configurations.
- **wwwroot**: Contains static files like CSS, JavaScript, and images.

## Installation
To run this project locally, follow these steps:

1. **Clone the repository**:
    ```bash
    git clone https://github.com/Uricaryn/BookAutomationApp.git
    ```

2. **Navigate to the project directory**:
    ```bash
    cd BookAutomationApp
    ```

3. **Restore the project dependencies**:
    ```bash
    dotnet restore
    ```

4. **Update the database**:
    ```bash
    dotnet ef database update
    ```

5. **Run the application**:
    ```bash
    dotnet run
    ```

6. **Access the application**: Open a browser and go to `http://localhost:7185`.

## Configuration
The application settings are managed through the `appsettings.json` and `appsettings.Development.json` files. You can customize these files to suit your environment, particularly the database connection strings and identity settings.

## Usage
- **Home Page**: Overview of the application with links to the books and authors management pages.
- **Books Management**: View a list of books, add new books, edit existing ones, or delete them.
- **Authors Management**: Similar to book management, but for authors.
- **Account Management**: Users can register, log in, and manage their account details.

## Customization

### Identity Customization
The application uses ASP.NET Core Identity for user management. Roles and policies can be customized in the `Startup.cs` file to suit your specific requirements.

### Layout and Styling
The application uses Bootstrap for styling. The layout is defined in the `_Layout.cshtml` file, which includes the navigation bar, footer, and links to other resources.

## Contributing
If you wish to contribute to this project, please follow the standard GitHub fork-and-pull request workflow:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add new feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Create a new Pull Request.

## Contact
For any inquiries or feedback, feel free to reach out to the project maintainers at [onuranatca@hotmail.com.tr](mailto:onuranatca@hotmail.com.tr).

This project is licensed under the MIT License. For more details, please see the LICENSE.txt file.

