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
    public partial class Companies : Form
    {
        bool _AddNew = false;
        Operations opr = new Operations();
        public Companies()
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
            txtCompName.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            txtCompName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_AddNew == true)
            {
                if (txtCompName.Text != "")
                {
                    opr.connect();
                    opr.cmd.CommandText = "insert into Companies (Company_Name) values ('" + txtCompName.Text + "')";
                    int aff = opr.cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("تم التسجيل بنجاح");
                        _AddNew = false;
                        txtCompName.Enabled = false;
                        btnSave.Enabled = false;
                        btnNew.Enabled = true;
                        txtCompName.Clear();
                        opr.disconnect();
                    }

                }

            }
        }
    }
}
