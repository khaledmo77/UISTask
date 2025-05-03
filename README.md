# UISTask - Transaction Overview System

UISTask is a web-based application that provides an interface to manage and display transaction data. It allows users to view a list of transactions, filter transactions by date, and view detailed information about each transaction. The application follows a **Repository Service Pattern** architecture, ensuring clean separation of concerns between the data access layer and the service layer.

## Features

- **Transaction Overview**: Displays a table of transactions with the ability to filter transactions by date.
- **Transaction Details**: View detailed information about a specific transaction, including associated products and transaction amounts.
- **Date Filter**: Filter transactions by a specific date, with the table updating dynamically based on the selected date.

## Technologies Used

- **ASP.NET Core MVC**: For building the web application and handling server-side logic.
- **jQuery**: For making AJAX requests and dynamically updating the page.
- **Bootstrap**: For UI components and responsive design, including modals.
- **Entity Framework Core**: For database access and management of transaction data.

## Getting Started

### Prerequisites

Before setting up this project, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) version 5.0 or higher.
- A code editor such as [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/).
- A SQL Server database (or another database of your choice) for storing transaction data.

### Installation

1. **Clone the repository**:

    ```bash
    git clone https://github.com/khaledmo77/UISTask.git
    ```

2. **Navigate to the project directory**:

    ```bash
    cd UISTask
    ```

3. **Restore project dependencies**:

    ```bash
    dotnet restore
    ```

4. **Run the application**:

    ```bash
    dotnet run
    ```

    The application should be running at `https://localhost:5001` or `http://localhost:5000`.

### Database Setup

The project uses a database to store transaction data. The database connection can be configured in the `appsettings.json` file under the `ConnectionStrings` section.

1. **Configure your database connection** in `appsettings.json`.

2. **Run the migration to set up the database**:

    ```bash
    dotnet ef database update
    ```

This will apply any pending migrations and set up your database schema.

## Usage

1. **Transaction Overview**: On the homepage, a table of transactions will be displayed.
2. **Filter by Date**: You can filter transactions by a specific date using the input field at the top of the page. The table will update dynamically based on the selected date.
3. **View Transaction Details**: Click on the **"View Details"** button in any row of the transaction table to open a modal with detailed information about the transaction.

### Example Workflow:
1. Open the page, and you will see a list of transactions.
2. Use the **Date Filter** to filter transactions by date.
3. Click on the **"View Details"** button to see more information about a specific transaction.

## API Endpoints

### 1. **GET /Transaction**

Fetches all transactions with optional date filtering.

- **Query Parameters**:
  - `startDate` (optional): The start date for filtering transactions.
  
### 2. **GET /Transaction/GetTransactionById**

Fetches details of a transaction by its ID.

- **Query Parameters**:
  - `transactionId`: The ID of the transaction to fetch.

## Folder Structure

UISTask
│
├── Controller

│ ├── TransactionController.cs

│ └── HomeController.cs

│
├── Models

│ ├── Transaction.cs

│ └── Product.cs

│
├── ViewModels

│ ├── TransactionOverviewViewModel.cs

│ └── TransactionItemViewModel.cs

│
├── Views

│ ├── Transaction

│ │ ├── Index.cshtml

│ │ └── _TransactionTableBody.cshtml

│ ├── Home

│ │ └── Index.cshtml

│
├── wwwroot

│ ├── css

│ └── js

│
├── appsettings.json

├── Startup.cs

└── Program.cs





## Contributing

If you'd like to contribute to this project, feel free to fork the repository, make your changes, and create a pull request. All contributions are welcome!

### Steps to Contribute:

1. Fork the repository on GitHub.
2. Clone your fork to your local machine.
3. Create a new branch for your feature or bug fix (`git checkout -b feature/your-feature`).
4. Make your changes and commit them (`git commit -am 'Add new feature'`).
5. Push to the branch (`git push origin feature/your-feature`).
6. Open a pull request on GitHub.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.

## Acknowledgements

- Thanks to **ASP.NET Core** for the powerful framework that enables building robust web applications.
- Thanks to **Bootstrap** for providing responsive, user-friendly UI components.
- Thanks to **Entity Framework Core** for efficient database handling.

---

For any questions or issues, please create an issue or reach out to the project maintainers.

Key Sections of the README:
Project Overview: A brief description of what the project does.

Features: Key features available in the application.

Technologies Used: A list of technologies that power the application.

Getting Started: Step-by-step guide to set up the project locally.

Database Setup: Instructions for configuring the database and running migrations.

Usage: Explains how users can interact with the application.

API Endpoints: Describes the key API endpoints available in the application.

Folder Structure: Overview of the project folder structure for developers.

Contributing: Guidelines on how to contribute to the project.

License: Licensing information for the project.

Acknowledgements: Credits to tools and frameworks used in the project.
