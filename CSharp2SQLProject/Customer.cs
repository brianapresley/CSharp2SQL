using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLProject {
    public class Customer {

        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool Active { get; set; }
        public string Code { get; set; }


        public Customer(int id, string name, string city, string state, bool active, string code) {
            this.ID = id;
            this.Name = name;
            this.City = city;
            this.State = state;
            this.Active = active;
            this.Code = code;
        }

    }
}
