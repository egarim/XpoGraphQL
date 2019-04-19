using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using XpoOrm.Models;
using XpoOrm.Services;

namespace XpoOrm.Schema
{
    public class CustomerQuery: ObjectGraphType<Object>
    {
        public CustomerQuery(ICustomerService ICustomerService)
        {
            this.Name = "Query";
            Field<ListGraphType<CustomerType>>("Customers", resolve: context => ICustomerService.GetCustomers());
        }
    }
}
