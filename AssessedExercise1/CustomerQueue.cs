using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AssessedExercise1
{
    internal class CustomerQueue
    {
        private readonly int maxSize = 10;
        private Customer[] store;
        private int head = 0;
        private int tail = 0;
        private int numItems;

        public CustomerQueue() 
        { 
           store = new Customer[maxSize];
        }

        public void Enqueue(Customer value) 
        { 
            numItems = numItems + 1;
            store[tail] = value;
            tail = tail + 1;

            if (tail == maxSize)
            {
                tail = 0;
            }
        }

        public Customer Dequeue(Customer customer) 
        {
            Customer headItem;
            numItems = numItems - 1;
            headItem = store[head];
            head = head + 1;

            if (head == maxSize)
            {
                head = 0;
            }
            return headItem;
        }

         public Customer Peek() 
        {
            return store[head];
        }

        public string PrintNextCustomer()
        {
            Customer nextCustomer = store[head];
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + nextCustomer.Name);
            sb.AppendLine("Age: " + nextCustomer.Age);
            sb.AppendLine("Address: " + nextCustomer.Address);
            sb.AppendLine("Amount owed: " + nextCustomer.AmountOwed);
            return sb.ToString();
     
        }

        public int QueueLength()
        {
            int noCustomers = tail - head;
            return noCustomers; 
        }

        public float totalOwed()
        {   
            float total = 0;

            for (int i = head; i < head + numItems; i++)
            {
                total = total + store[i].AmountOwed;
            } return total;
        }

       public string biggestDebtee()
       {
            if (store == null)
            {
                return null;
            }

            Customer biggestDebtee = store[head];

            for (int i = head; i < head + numItems; i++)
            {
                if (store[i].AmountOwed > biggestDebtee.AmountOwed)
                {
                    biggestDebtee = store[i];
                }
            }

            if (biggestDebtee != null)
            {
                return biggestDebtee.getInformation(biggestDebtee.Name);
            } 

            return null;

       }
    }
}
