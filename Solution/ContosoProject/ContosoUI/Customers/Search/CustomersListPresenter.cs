﻿using Data.DumbData;
using Domain.DAO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUI.Customers.Search
{
    class CustomersListPresenter
    {
        readonly CustomersListView view;
        readonly ICustomerRepository model = new CustomerDao();
        readonly IContactInfoRepository contactModel = new ContactsInfoDao();
        private List<Customer> customers = new List<Customer>();
        private List<string> cities = new List<string>();
        public List<Customer> Customers { get { return customers; } set { } }
        public List<string> Cities { get { return cities; } set { } }
        public CustomersListPresenter(CustomersListView view)
        {
            this.view = view;
            cities = contactModel.GetAll().Select(x => x.City).Distinct().ToList();
        }

        public void SearchCustomers(string city)
        {
            if (city == "Все города")
            {
                customers = model.GetAll().ToList();
            }
            else
            {
                customers = model.GetCustomersByCity(city).ToList();
            }
        }
    }
}