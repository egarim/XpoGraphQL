using DevExpress.Xpo;
using System;

namespace XpoOrm.Models
{
    public class Product : XPObject
    {
        public Product(Session session) : base(session)
        { }




        Category category;
        string description;
        string code;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [Size(500)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }
        
        public Category Category
        {
            get => category;
            set => SetPropertyValue(nameof(Category), ref category, value);
        }
    }
}
