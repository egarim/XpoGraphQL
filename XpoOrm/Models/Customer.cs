using DevExpress.Xpo;
using System;

namespace XpoOrm.Models
{
    public class Customer : XPObject
    {
        public Customer(Session session) : base(session)
        { }



        string address;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Address
        {
            get => address;
            set => SetPropertyValue(nameof(Address), ref address, value);
        }
    }
}
