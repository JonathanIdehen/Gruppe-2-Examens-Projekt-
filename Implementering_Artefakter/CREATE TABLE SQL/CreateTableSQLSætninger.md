    
    CREATE TABLE Employee(
    EmployeeID INT PRIMARY KEY,
    Role INT,
    Name NVARCHAR(50)
    );

------
    
    CREATE TABLE Task(
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255) NULL,
    Deadline DATETIME2 NOT NULL,
    Priority INT,
    Category INT,
    Status INT,
    EmployeeID INT NULL, 
    IsOneTime BIT NOT NULL,
    IsAvailableForAssignment BIT NOT NULL,
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
    );
