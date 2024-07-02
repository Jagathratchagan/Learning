using EmbeddedSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace EmbeddedSQL.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class NonEmbeddedSQLController : ControllerBase
    {

        [HttpGet("GetEmployeesList")]
        public IEnumerable<Employee> GetEmployeesList()
        {
            using (var obj = new LocalDbContext())
            {
                return obj.Employees.ToList();
            }
        }

        [HttpGet("GetEmployee")]
        public IEnumerable<Employee> GetEmployee()
        {
            using (var obj1 = new LocalDbContext())
            {
                return obj1.Employees.Where(emp => emp.EmpId == 1).ToList();
            }
        }

        [HttpGet("GetEmployeeUsingStoredProcedure")]
        public IEnumerable<Employee> GetEmployeeUsingStoredProcedure()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=LocalDB;Trusted_Connection=True;";
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetAllEmployees", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int employeeId = reader.GetInt32(0);
                                string employeeName = reader.GetString(1);
                                string department = reader.GetString(2);
                                string salary = reader[3].ToString();
                                string dob = reader[4].ToString();
                                string gender = reader.GetString(5);

                                Employee employee = new Employee(employeeId, employeeName, department, Convert.ToDecimal(salary), Convert.ToDateTime(dob), gender);
                                employees.Add(employee);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }

            return employees.ToList();

        }
    }
 
}
