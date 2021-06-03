using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class Specification
    {
        public string ID_S { get; set; }
        public string ID_P { get; set; }
        public string Property { get; set; }
        public string Data_Type { get; set; }
        public Specification(string ID_S, string ID_P, string Property, string Data_Type)
        {
            this.ID_S = ID_S;
            this.ID_P = ID_P;
            this.Property = Property;
            this.Data_Type = Data_Type;
        }
        public Specification()
        {

        }
    }
}
