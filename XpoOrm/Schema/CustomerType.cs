using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using XpoOrm.Models;

namespace XpoOrm.Schema
{
    public class CustomerType:ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(c => c.Oid);
            Field(c => c.Name);
            Field(c => c.Address,true);
        }
    }
}
