using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLProject {
     public class Order {

        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public int CustomerId { get; set; }

        public Order(int ID, DateTime Date, string Note, int CustomerId) {
            this.ID = ID;
            this.Date = Date;
            this.Note = Note;
            this.CustomerId = CustomerId;
        }

    }
}
