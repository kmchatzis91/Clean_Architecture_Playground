﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Domain.Entities
{
    public class Employee
    {
        public decimal EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal RoleId { get; set; }
        public decimal CompanyId { get; set; }
    }
}