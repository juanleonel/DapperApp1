using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace DapperApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            Connection cn = new Connection();
            txtInfo.Text = cn.ConnectionMethod();

            cn.MethodDump();
        }

        private void btnPerro_Click(object sender, EventArgs e)
        {
            Connection cn = new Connection();
            if (cn.SaveDog())
            {
                MessageBox.Show("Perro guardado :) ");
                dataGridView1.DataSource = cn.GetDogs();
            }
            else {
                MessageBox.Show("Perro NO guardado :( ");
            }
               
        }

        private void btnGetPerson_Click(object sender, EventArgs e)
        {
            Connection cn = new Connection();
            var person = cn.GetPersons();

            foreach (var item in person)
            {
                Console.WriteLine(item.Residience.Residence);
            }
        }

        private void btnOneToManyPerson_Click(object sender, EventArgs e)
        {
            Connection cn = new Connection();
            var person = cn.GetPersonsOnetoMany();

            foreach (var item in person)
            {
                Console.WriteLine(item.Residience.CountryName);
            }
        }
    }
}
