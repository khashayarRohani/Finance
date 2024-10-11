# Full Stack Finance News Web App

## Overview

This project is a full-stack application designed for displaying and searching for stocks. Users can view comprehensive information about companies, including their profiles, balance sheets, income statements, and more. The app allows users to manage their stock portfolios by adding stocks, leaving comments, and removing them as needed.

The frontend is built using **React Native** with **TypeScript**, leveraging features such as nested routes, dynamic routes, and protected route services. The backend is developed with **ASP.NET Web API** and uses **Entity Framework** for database interactions.

## Walk Through

The Stock Portfolio Web App serves as a comprehensive platform for stock market enthusiasts and investors. Users can search for stocks and access detailed information about each company, including:

- **Company Profile**: Essential details about the company, including its history, mission, and key statistics.
- **Financial Statements**: Users can view the balance sheet, income statement, and other financial documents to make informed investment decisions.
- **Portfolio Management**: Users can easily add stocks to their portfolio, leave comments about their investment strategies, or remove stocks they no longer wish to track.

The frontend incorporates several advanced features, such as:

- **Nested Routes**: For seamless navigation between different sections of the app.
- **Dynamic Routes**: To handle various stock profiles and details.
- **Protected Routes**: Ensuring that certain features are accessible only to authenticated users.

To manage user authentication and state, I implemented a custom hook for managing login, logout, and registration. A dedicated context and provider were created to share necessary information throughout the app, ensuring a smooth user experience.

For interaction with external APIs, I utilized **Axios** for efficient API calls, preferring it over the native fetch method for its speed and ease of use. I integrated the **Financial Modeling Prep API** to retrieve stock data and implemented **React Toastify** for notifications, enhancing the user experience with real-time alerts.

### Loading States and Notifications

To improve usability, the app employs loading spinners during data fetching, providing visual feedback to users while they wait for information. Notifications are handled via **React Toastify**, alerting users to actions like adding or removing stocks from their portfolio.

### Backend Implementation

On the backend, I utilized **ASP.NET Web API** with **Entity Framework** to interact with a **SQL Server** database. The backend architecture includes:

- **Mapping Services**: For transferring data between database models and Data Transfer Objects (DTOs).
- **JWT Authentication**: Implemented to manage user claims and secure API endpoints.
- **Dependency Injection**: Used extensively for interfaces and repositories, promoting a clean and maintainable code structure.
- **LINQ Queries**: For data retrieval and manipulation, ensuring efficient data handling.

---

### External APIs

This application utilizes the [Financial Modeling Prep API](https://site.financialmodelingprep.com/) API to retrieve real-time stock and financial data. The API provides essential information, such as:

- **Company Profiles**: Key details about the company, including background and financial metrics.
- **Balance Sheets**: Displays the financial health of companies by showing assets, liabilities, and shareholder equity.
- **Income Statements**: Provides a breakdown of a company's revenue, expenses, and profitability.
- **Stock Information**: Real-time data on stock prices, market trends, and historical performance.
  By integrating this API, the app ensures that users have access to the latest and most accurate financial data to make informed investment decisions.

---

## Table of Contents

1. [Tech Stack](#tech-stack)
2. [Prerequisites](#prerequisites)
3. [Running the Application](#running-the-application)
   - [Frontend](#running-the-frontend)
   - [Backend](#running-the-backend)
4. [Dependencies](#dependencies)

---

## Tech Stack

- **Frontend**: React Native (with TypeScript)
- **Styling**: Tailwind CSS
- **Backend**: ASP.NET Web API
- **Database**: SQL Server
- **Authentication**: JSON Web Tokens (JWT) for claims-based authentication
- **API Communication**: Axios for efficient API interactions
- **State Management**: Custom context and provider for sharing state across the app
- **Routing**: Nested, dynamic, and protected routes for user navigation
- **Loading Indicators**: React Spinners for loading states
- **Notifications**: React Toastify for user notifications
- **External APIs**: Financial Modeling Prep API for displaying stock market data
- **Architecture**: The backend uses services, repositories, and interfaces for clean code structure and separation of concerns.

---

## Prerequisites

Before running this project, make sure you have the following installed:

- **Node.js** (v16.x.x or later) and NPM
- **React Native CLI**
- **TypeScript**
- **Tailwind CSS**
- **.NET 6 SDK** or later
- **Postman** or similar API client for testing backend APIs
- **SQL Server** (for database)

---

## Dependencies

### Frontend

The frontend uses the following key dependencies:

```json
{
  "@hookform/resolvers": "^3.9.0",
  "@types/react-router": "^5.1.20",
  "@types/react-router-dom": "^5.3.3",
  "autoprefixer": "^10.4.20",
  "axios": "^1.7.7",
  "dotenv": "^16.4.5",
  "postcss": "^8.4.47",
  "react": "^18.3.1",
  "react-dom": "^18.3.1",
  "react-hook-form": "^7.53.0",
  "react-icons": "^5.3.0",
  "react-router": "^6.26.2",
  "react-router-dom": "^6.26.2",
  "react-spinners": "^0.14.1",
  "react-toastify": "^10.0.5",
  "uuid": "^10.0.0",
  "yup": "^1.4.0",
  "tailwindcss": "^3.3.1"
}
```

### Backend Nuget:

- DotNetEnv: 3.1.1
- Microsoft.AspNetCore.Authentication.JwtBearer: 8.0.8
- Microsoft.AspNetCore.Identity.EntityFrameworkCore: 8.0.8
- Microsoft.AspNetCore.Mvc.NewtonsoftJson: 8.0.8
- Microsoft.AspNetCore.OpenApi: 8.0.8
- Microsoft.EntityFrameworkCore.Design: 8.0.8
- Microsoft.EntityFrameworkCore.SqlServer: 8.0.8
- Microsoft.EntityFrameworkCore.Tools: 8.0.8
- Microsoft.Extensions.Identity.Core: 8.0.8
- Newtonsoft.Json: 13.0.3
- Swashbuckle.AspNetCore: 6.4.0

---
