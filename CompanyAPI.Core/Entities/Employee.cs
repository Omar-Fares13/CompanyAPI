﻿namespace EmployeeManagement.Core.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
