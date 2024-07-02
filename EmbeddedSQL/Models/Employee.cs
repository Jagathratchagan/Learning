using System;
using System.Collections.Generic;

namespace EmbeddedSQL.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? Department { get; set; }

    public decimal? Salary { get; set; }

    public DateTime? DOB { get; set; }

    public string? Gender { get; set; }

    public Employee(int empId, string empName, string department, decimal salary, DateTime dob, string gender)
    {
        EmpId = empId;
        EmpName = empName;
        Department = department;
        Salary = salary;
        DOB = dob;
        Gender = gender;
    }

    public Employee()
    {

    }

}
