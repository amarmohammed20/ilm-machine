# **iLM Machine**

iLM Machine is an API with a UI designed to distribute Islamic teachings across multiple communication and social platforms efficiently.

## **Setup & Run Instructions**

### **1. Run Microsoft SQL Server in Docker**

Ensure Docker is installed and running. Then, start the SQL Server container:

```bash
docker-compose up -d
```

This will:

- Pull and run the latest Microsoft SQL Server image.
- Expose port 1433 for database connections.
- Use SA_PASSWORD: "YourStrong!Passw0rd" (change as needed).

To check if it's running:

```bash
docker ps
```

To connect via SQL Server Management Studio (SSMS) or any client:

- Server: localhost,1433
- User: sa
- Password: YourStrong!Passw0rd

### **2. Run the .NET API (Backend)**

Navigate to the backend folder and run:

```bash
cd backend
dotnet run
```

This will start the API, typically on:

- http://localhost:5097

**Environment Variables**
Set up a .env file or configure appsettings.json to connect to the database:

```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=ILMMachineDB;User Id=sa;Password=YourStrong!Passw0rd;"
}
```

### **3. Run the React Frontend (UI)**

Navigate to the frontend folder:

```bash
cd frontend
npm install
npm run dev
```

This will start the frontend, usually at `http://localhost:3000`

**Connecting Frontend to Backend**
Ensure the frontend is calling the backend API correctly. In your .env.local file:

```bash
REACT_APP_API_BASE_URL=http://localhost:5097
```

## **Backend**

## ⚙️ Quick Commands with Makefile

You can run common backend tasks using `make` commands. Make sure you're in the `/backend` folder.

| Task                                   | Command                           |
| -------------------------------------- | --------------------------------- |
| Run backend API                        | `make run`                        |
| Add new migration                      | `make migrate name=MigrationName` |
| Apply migrations to DB                 | `make update-db`                  |
| Rebuild project                        | `make build`                      |
| Clean bin/obj                          | `make clean`                      |
| Reset database (drop + reapply schema) | `make reset-db`                   |

> 💡 Make sure `dotnet ef` CLI is installed: `dotnet tool install --global dotnet-ef`

## **Task List**

Below is a task list I need to work through:

### **Understanding**

1. The api in the backend. The Program.cs file
2. How security is enabled and configured

### **Tech Debt**

1. Implement the custom error codes in the api end points
