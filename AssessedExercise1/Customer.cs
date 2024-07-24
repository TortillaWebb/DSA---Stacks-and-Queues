using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessedExercise1
{
    internal class Customer
    {
            private string name;
            private int age;
            private string address;
            private float amountOwed;

            public Customer(string name, int age, string address, float amountOwed)
            {
                this.name = name;
                this.age = age;
                this.address = address;
                this.amountOwed = amountOwed;
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            public string Address 
            { 
                get { return address; }    
                set {  address = value; } 
            }

            public float AmountOwed
            {
                get { return amountOwed; }
                set { amountOwed = value; }

            }
            
            public string getInformation(string name)
            {   
            
            Customer customer = new Customer(name, age, address, amountOwed);
            customer.Name = name;
            customer.Age = age;
            customer.Address = address; 
            customer.AmountOwed = amountOwed;


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + customer.Name);
            sb.AppendLine("Age: " + customer.Age);
            sb.AppendLine("Address: " + customer.Address);
            sb.AppendLine("Amount owed: " + customer.AmountOwed);
            
            return sb.ToString();
            }

        }
    }
