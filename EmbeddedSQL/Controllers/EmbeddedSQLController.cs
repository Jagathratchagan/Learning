using EmbeddedSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EmbeddedSQL.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmbeddedSQLController : ControllerBase
    {

        [HttpGet("UploadEmployeesData")]
        public List<Employee> UploadEmployeesData()
        {

            // Local variables
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=LocalDB;Trusted_Connection=True;";
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create table if it doesn't exist
                string DropTableQuery = @"
                    IF EXISTS (SELECT * FROM sysobjects WHERE name='Employee' AND xtype='U')
                    DROP TABLE Employee";
                using (SqlCommand cmd = new SqlCommand(DropTableQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                string createTableQuery = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employee' AND xtype='U')
                    CREATE TABLE Employee (
                        EmpId INT PRIMARY KEY,
                        EmpName NVARCHAR(50),
                        Department NVARCHAR(50),
                        Salary DECIMAL(18, 2),
                        DOB DATE,
                        Gender CHAR(1)
                    )";
                using (SqlCommand cmd = new SqlCommand(createTableQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                // Insert sample data
                string insertQuery = @"
                    INSERT INTO Employee (EmpId, EmpName, Department, Salary, DOB, Gender)
                    VALUES
                        (1, 'Jagathratchagan', 'IT', 10000.00, '2021-02-05', 'M'),
                        (2, 'Priya', 'HR', 12000.00, '1988-08-12', 'F'),
                        (3, 'John Doe', 'Finance', 11000.00, '1990-11-23', 'M'),
                        (4, 'Alice Johnson', 'Marketing', 10500.00, '1985-05-15', 'F'),
                        (5, 'Robert Brown', 'Sales', 9500.00, '1995-03-30', 'M'),
                        (6, 'Maria Garcia', 'IT', 13000.00, '1992-07-19', 'F'),
                        (7, 'David Smith', 'HR', 11500.00, '1987-01-01', 'M'),
                        (8, 'Emma Thomas', 'Finance', 12500.00, '1989-09-22', 'F'),
                        (9, 'Michael Clark', 'Marketing', 11800.00, '1986-06-08', 'M'),
                        (10, 'Linda Martinez', 'Sales', 9800.00, '1993-02-14', 'F')";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                // Retrieve and display data
                string selectQuery = "SELECT EmpId, EmpName, Department, Salary, DOB, Gender FROM Employee";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int empId = reader.GetInt32(0);
                        string empName = reader.GetString(1);
                        string department = reader.GetString(2);
                        decimal salary = reader.GetDecimal(3);
                        DateTime dob = reader.GetDateTime(4);
                        string gender = reader.GetString(5);

                        Employee employee = new Employee(empId, empName, department, salary, dob, gender);
                        employees.Add(employee);
                        //Console.WriteLine(employee);
                    }
                }
            }

            return employees;
            //return View();
        }

    }
}
