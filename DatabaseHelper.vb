Imports MySqlConnector
Imports Dapper

Public Class DatabaseHelper
    ' Connection string pointing to local Laragon MySQL server.
    ' Default Laragon MySQL has root user with no password on localhost.
    Private ReadOnly ConnectionString As String = "Server=127.0.0.1;User ID=root;Password=;AllowUserVariables=True;"
    Private ReadOnly DatabaseName As String = "school_clinic"

    Public Sub New()
        InitializeDatabase()
    End Sub

    Public Class InventoryItem
        Public Property Id As Integer
        Public Property MedicineName As String
        Public Property StockQuantity As Integer
    End Class

    Private Sub InitializeDatabase()
        ' Create database if it doesn't exist
        Using connection As New MySqlConnection(ConnectionString)
            connection.Execute($"CREATE DATABASE IF NOT EXISTS {DatabaseName}")
        End Using

        ' Create table if it doesn't exist
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Dim createVisitsQuery As String = "
                CREATE TABLE IF NOT EXISTS Visits (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    PatientType VARCHAR(50),
                    PatientName VARCHAR(100),
                    Age INT,
                    Height DOUBLE,
                    Weight DOUBLE,
                    Course VARCHAR(100),
                    Job VARCHAR(100),
                    ContactNumber VARCHAR(50),
                    ReasonForVisit VARCHAR(200),
                    Sickness VARCHAR(200),
                    Injury VARCHAR(200),
                    Prescription VARCHAR(200),
                    TimeIn DATETIME,
                    TimeOut DATETIME NULL
                )"
            connection.Execute(createVisitsQuery)

            Try
                connection.Execute("ALTER TABLE Visits ADD COLUMN Gender VARCHAR(50)")
            Catch ex As Exception
            End Try
            Try
                connection.Execute("ALTER TABLE Visits ADD COLUMN StudentID VARCHAR(100)")
            Catch ex As Exception
            End Try
            Try
                connection.Execute("ALTER TABLE Visits ADD COLUMN Year VARCHAR(50)")
            Catch ex As Exception
            End Try
            Try
                connection.Execute("ALTER TABLE Visits ADD COLUMN DoctorAssigned VARCHAR(100)")
            Catch ex As Exception
            End Try

            Dim createInventoryQuery As String = "
                CREATE TABLE IF NOT EXISTS Inventory (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    MedicineName VARCHAR(100) UNIQUE,
                    StockQuantity INT
                )"
            connection.Execute(createInventoryQuery)

            Dim createUsersQuery As String = "
                CREATE TABLE IF NOT EXISTS Users (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    Username VARCHAR(50) UNIQUE,
                    Password VARCHAR(255),
                    Role VARCHAR(50)
                )"
            connection.Execute(createUsersQuery)

            ' Seed default admin user if not exists
            Dim count = connection.ExecuteScalar(Of Integer)("SELECT COUNT(*) FROM Users")
            If count = 0 Then
                connection.Execute("INSERT INTO Users (Username, Password, Role) VALUES ('admin', 'admin123', 'Admin')")
                connection.Execute("INSERT INTO Users (Username, Password, Role) VALUES ('nurse', 'nurse123', 'Staff')")
            End If

            Dim createAppointmentsQuery As String = "
                CREATE TABLE IF NOT EXISTS Appointments (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    PatientName VARCHAR(100),
                    AppointmentDate DATETIME,
                    Reason VARCHAR(200)
                )"
            connection.Execute(createAppointmentsQuery)
        End Using
    End Sub

    ' --- AUTHENTICATION ---
    Public Function AuthenticateUser(username As String, password As String) As String
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Dim role = connection.ExecuteScalar(Of String)("SELECT Role FROM Users WHERE Username = @User AND Password = @Pass", New With {.User = username, .Pass = password})
            Return role
        End Using
    End Function

    ' --- INVENTORY METHODS ---
    Public Function GetInventory() As System.Collections.Generic.List(Of InventoryItem)
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Return connection.Query(Of InventoryItem)("SELECT * FROM Inventory ORDER BY MedicineName").AsList()
        End Using
    End Function

    Public Sub AddOrUpdateInventory(itemName As String, quantity As Integer)
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Dim query As String = "
                INSERT INTO Inventory (MedicineName, StockQuantity) 
                VALUES (@Name, @Qty) 
                ON DUPLICATE KEY UPDATE StockQuantity = StockQuantity + @Qty"
            connection.Execute(query, New With {.Name = itemName, .Qty = quantity})
        End Using
    End Sub

    Public Sub DeductInventory(itemName As String, quantity As Integer)
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Dim query As String = "
                UPDATE Inventory 
                SET StockQuantity = StockQuantity - @Qty 
                WHERE MedicineName = @Name AND StockQuantity >= @Qty"
            connection.Execute(query, New With {.Name = itemName, .Qty = quantity})
        End Using
    End Sub
    
    Public Sub DeleteInventoryItem(id As Integer)
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            connection.Execute("DELETE FROM Inventory WHERE Id = @Id", New With { Key .Id = id })
        End Using
    End Sub

    Public Function GetDatabaseConnectionString() As String
        Return $"{ConnectionString}Database={DatabaseName};"
    End Function

    Public Function GetAllVisits() As System.Collections.Generic.List(Of VisitRecord)
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Return connection.Query(Of VisitRecord)("SELECT * FROM Visits ORDER BY TimeIn DESC").AsList()
        End Using
    End Function

    Public Sub InsertVisit(visit As VisitRecord)
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Dim query As String = "
                INSERT INTO Visits (PatientType, PatientName, Age, Height, Weight, Course, Job, ContactNumber, ReasonForVisit, Sickness, Injury, Prescription, Gender, StudentID, Year, DoctorAssigned, TimeIn, TimeOut)
                VALUES (@PatientType, @PatientName, @Age, @Height, @Weight, @Course, @Job, @ContactNumber, @ReasonForVisit, @Sickness, @Injury, @Prescription, @Gender, @StudentID, @Year, @DoctorAssigned, @TimeIn, @TimeOut)"
            connection.Execute(query, visit)
        End Using
    End Sub

    Public Sub UpdateVisit(visit As VisitRecord)
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Dim query As String = "
                UPDATE Visits SET 
                    PatientType = @PatientType,
                    PatientName = @PatientName,
                    Age = @Age,
                    Height = @Height,
                    Weight = @Weight,
                    Course = @Course,
                    Job = @Job,
                    ContactNumber = @ContactNumber,
                    ReasonForVisit = @ReasonForVisit,
                    Sickness = @Sickness,
                    Injury = @Injury,
                    Prescription = @Prescription,
                    Gender = @Gender,
                    StudentID = @StudentID,
                    Year = @Year,
                    DoctorAssigned = @DoctorAssigned,
                    TimeIn = @TimeIn,
                    TimeOut = @TimeOut
                WHERE Id = @Id"
            connection.Execute(query, visit)
        End Using
    End Sub

    Public Sub DeleteVisit(id As Integer)
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            connection.Execute("DELETE FROM Visits WHERE Id = @Id", New With { Key .Id = id })
        End Using
    End Sub

    Public Function GetTotalVisitsToday() As Integer
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Return connection.ExecuteScalar(Of Integer)("SELECT COUNT(*) FROM Visits WHERE DATE(TimeIn) = CURDATE()")
        End Using
    End Function

    Public Function GetTotalStudents() As Integer
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Return connection.ExecuteScalar(Of Integer)("SELECT COUNT(*) FROM Visits WHERE PatientType = 'Student'")
        End Using
    End Function

    Public Function GetTotalEmployees() As Integer
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Return connection.ExecuteScalar(Of Integer)("SELECT COUNT(*) FROM Visits WHERE PatientType = 'Employee'")
        End Using
    End Function

    ' --- APPOINTMENT METHODS ---
    Public Class AppointmentItem
        Public Property Id As Integer
        Public Property PatientName As String
        Public Property AppointmentDate As DateTime
        Public Property Reason As String
    End Class

    Public Function GetAppointments(selectedDate As DateTime) As System.Collections.Generic.List(Of AppointmentItem)
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Dim query As String = "SELECT * FROM Appointments WHERE DATE(AppointmentDate) = DATE(@SelectedDate) ORDER BY AppointmentDate"
            Return connection.Query(Of AppointmentItem)(query, New With { .SelectedDate = selectedDate.Date }).AsList()
        End Using
    End Function

    Public Sub AddAppointment(appointment As AppointmentItem)
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            Dim query As String = "INSERT INTO Appointments (PatientName, AppointmentDate, Reason) VALUES (@PatientName, @AppointmentDate, @Reason)"
            connection.Execute(query, appointment)
        End Using
    End Sub

    Public Sub DeleteAppointment(id As Integer)
        Using connection As New MySqlConnection(GetDatabaseConnectionString())
            connection.Execute("DELETE FROM Appointments WHERE Id = @Id", New With { Key .Id = id })
        End Using
    End Sub
End Class
