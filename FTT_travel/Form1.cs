using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FTT_travel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
              
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Drivers drv = new Drivers();
            drv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Drivers drivers = new Drivers();
            drivers.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Orders orders  = new Orders();
            orders.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Prices_Lists prices_Lists = new Prices_Lists();
            prices_Lists.Show();
        }
    }
}
