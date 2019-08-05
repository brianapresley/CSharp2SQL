using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CSharp2SQLProject {
    class Program {
        static void Main(string[] args) {
            var sql = "SELECT * from Orders;";
            var orders = SelectOrder(sql); //Can also input a valid SQL statement in (sql)
            foreach (var order in orders) {
                Console.WriteLine($"{order.ID} | {order.Date}");
            }


            sql = "SELECT * from Customers Where State = 'OH';";
            var customers = SelectCustomer(sql); //Can also input a valid SQL statement in (sql)
            foreach (var customer in customers) {
                Console.WriteLine(customer.Name);

            }
        }


        static List<Order> SelectOrder(string sql) {
            var connOrders = @"server=localhost\sqlexpress;database=CustomerOrderDb;trusted_connection=true;";
            var connect = new SqlConnection(connOrders);
            connect.Open();
            if (connect.State != ConnectionState.Open) {
                throw new Exception("Connection did not open!"); 
                }
                var orderList = new List<Order>();
                var ordercmd = new SqlCommand(sql, connect);
                var reader = ordercmd.ExecuteReader();

                while (reader.Read()) {
                    var id = (int)reader["Id"];
                    var date = (DateTime)reader["Date"];
                    var notes = reader.IsDBNull(reader.GetOrdinal("Note"))
                        ? null
                        : reader["Note"].ToString();
                    var CustomerId = (int)reader["CustomerId"];
                var order = new Order(id, date, notes, CustomerId);
                orderList.Add(order);
                }
            reader.Close();

            connect.Close();
            return orderList;
            }   

        static List<Customer> SelectCustomer(string sql) { //To access SQL from C# 
                //Step 1!!
                var connStr = @"server=localhost\sqlexpress;database=CustomerOrderDb;trusted_connection=true;"; // To identify the server, the instance; database name and authentication;
                //Step 2!! Create an instance
                var connection = new SqlConnection(connStr);
                //Step 3!! Check to see if connection opened
                connection.Open();
                if (connection.State != ConnectionState.Open) { //To determine if connection is open != means is not
                    throw new Exception("Connection did not open!"); //To create an error if connection not opened successfully
                }
                var customerList = new List<Customer>();
                //var sql = "SELECT * from Customers Where State = 'OH';"; //Enter SQL Statement
                //Step 4!! Create a SQL command
                var cmd = new SqlCommand(sql, connection);
                //Step 5!! Create a SQL reader and give it a variable name
                var reader = cmd.ExecuteReader();
                //Read statement moves the pointer down to the next row of sql table; returns a boolean; usually false when there are no more rows
                //Step 6!! Create a while loop to read all data in a selected table/column
                while (reader.Read()) { // Access each column by identifying the column name but you must change/cast the object to the correct data type
                    var id = (int)reader["ID"]; //Input an index into square brackets, 0 is column 1; or just input the column name
                    var name = reader["Name"].ToString();
                    var city = reader["City"].ToString();
                    var state = reader["State"].ToString();
                    var active = (bool)reader["Active"];
                    var code = reader.IsDBNull(reader.GetOrdinal("Code")) //If you have to check for Null, use 'IsDBNull'
                        ? null //If Column "Code" has a field that is null, display null; else display value in the field as a string
                        : reader["Code"].ToString();
                    var customer = new Customer(id, name, city, state, active, code);
                    customerList.Add(customer); //Adds custmer to the list
                }

                reader.Close(); //Good practice to close the data reader after program runs
                connection.Close(); //To close connection after program runs
                return customerList;
            }

        }
    }
