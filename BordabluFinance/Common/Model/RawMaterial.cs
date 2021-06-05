using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class RawMaterial
    {
        public string ID_RM { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Cost { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public RawMaterial(string ID_RM, string Name, int Stock, decimal Cost, string Supplier, string Description)
        {
            this.ID_RM = ID_RM;
            this.Name = Name;
            this.Stock = Stock;
            this.Cost = Cost;
            this.Supplier = Supplier;
            this.Description = Description;
        }
        public RawMaterial()
        { }
    }
}
