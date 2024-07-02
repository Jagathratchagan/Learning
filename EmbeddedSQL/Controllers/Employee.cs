namespace EmbeddedSQL.Controllers
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public DateTime DOB { get; set; }
        public char Gender { get; set; }

        public Employee(int empId, string empName, string department, decimal salary, DateTime dob, char gender)
        {
            EmpId = empId;
            EmpName = empName;
            Department = department;
            Salary = salary;
            DOB = dob;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"Employee[EmpId={EmpId}, EmpName={EmpName}, Department={Department}, Salary={Salary}, DOB={DOB.ToString("dd-MM-yyyy")}, Gender={Gender}]";
        }

    }
}
