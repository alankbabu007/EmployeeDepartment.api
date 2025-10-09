﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartment.entity.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName {  get; set; }
        public string Email {  get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
