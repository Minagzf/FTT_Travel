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

    public partial class Capacities : Form
    {
        bool _AddNew = false;
        Operations opr = new Operations();
        public Capacities()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _AddNew = true;
            txtCapacity.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            txtCapacity.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_AddNew == true)
            {
                if (txtCapacity.Text != "")
                {
                    opr.connect();
                    opr.cmd.CommandText = "insert into Capacity (Capacity_Capacity) values ('" + txtCapacity.Text + "')";
                    int aff = opr.cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("تم التسجيل بنجاح");
                        _AddNew = false;
                        txtCapacity.Enabled = false;
                        btnSave.Enabled = false;
                        btnNew.Enabled = true;
                        txtCapacity.Clear();
                        opr.disconnect();
                    }

                }

            }
        }

        private void Capacities_Load(object sender, EventArgs e)
        {

        }
    }
}
