using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssessedExercise1
{
    public partial class Form1 : Form
    {
        CustomerQueue CustomerQ = new CustomerQueue();
        public Form1()
        {
          
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Enqueue_Click(object sender, EventArgs e)
        {

            int CustomerAgeToInt = 0;
            float CustomerOwedToFloat = 0;
            bool ageParsed = false;
            bool amountParsed = false;
            bool noExcludedChars = true;
            string excludedChars = "!\"£$%^&*()-_=+}{[].,?/><:;|1234567890";

            string name = NameTextbox.Text;

            // this solution was taken and tweaked from StackOverFlow @ https://stackoverflow.com/questions/4503542/check-for-special-characters-in-a-string 
            foreach (char C in excludedChars)
            {
                if (name.Contains(C))
                    noExcludedChars = false;
            }
            if (noExcludedChars == false)
                MessageBox.Show("Name cannot contain special characters or numbers");

            try { 
              CustomerAgeToInt = Convert.ToInt16(AgeTextbox.Text); 
                ageParsed = true;
            } catch (FormatException)
            {
                MessageBox.Show("Age cannot be null & must be a number");
            }
           
            string address = AddressTextbox.Text;

            try
            {
                CustomerOwedToFloat = float.Parse(AmountOwedTextbox.Text);
                amountParsed = true;
            } catch (FormatException)
            {
                MessageBox.Show("Amount owed cannot be null & must be a number");
            }

            if (ageParsed == true && amountParsed == true && noExcludedChars == true)
            {
                Customer newCustomer = new Customer(name, CustomerAgeToInt, address, CustomerOwedToFloat);
                CustomerQ.Enqueue(newCustomer);
                int queLength = CustomerQ.QueueLength();
                QueueNo.Text = queLength.ToString();

                float OverallTotal = CustomerQ.totalOwed();
                String OverallTotalToString = OverallTotal.ToString();
                TotalTextBox.Text = OverallTotalToString;

                string biggestDebtee = CustomerQ.biggestDebtee();
                biggestDebteeTextbox.Text = biggestDebtee;
            } 
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dequeue_Click(object sender, EventArgs e)
        {
           Customer nextCust = CustomerQ.Peek();
           nextCustomer.Text = nextCust.getInformation(nextCust.Name);
           CustomerQ.Dequeue(nextCust);
           int queLength = CustomerQ.QueueLength();
           QueueNo.Text = queLength.ToString();

           float OverallTotal = CustomerQ.totalOwed();
           String OverallTotalToString = OverallTotal.ToString();
           TotalTextBox.Text = OverallTotalToString;

           string biggestDebtee = CustomerQ.biggestDebtee();
           biggestDebteeTextbox.Text = biggestDebtee;


        }
    }
}
