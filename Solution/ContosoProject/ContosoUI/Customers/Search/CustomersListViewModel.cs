﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUI.Customers.Search
{
    public class CustomersListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int CounOrders { get; set; }
        public double SumOrders { get; set; }
        public bool IsActive { get; set; }
    }
}
