using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class Product
    {
        public string ID_P { get; set; }
        public string Name { get; set; }
        public Product(string ID_P, string Name)
        {
            this.ID_P = ID_P;
            this.Name = Name;
        }
    }
}
