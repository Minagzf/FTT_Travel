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
    public partial class DealingsLists : Form
    {
        bool _AddNew = false;
        Operations opr = new Operations();
        void BindGrid()
        {
            opr.cmd.CommandText = "select * from Dealings order by dl_id";
            opr.connect();
            DataTable grid_dt = new DataTable(); 
            opr.dataReader=opr.cmd.ExecuteReader();
            grid_dt.Load(opr.dataReader);
            dataGridView1.DataSource = grid_dt;
            opr.dataReader.Close();
            opr.disconnect();
        }
        public DealingsLists()
        {
            InitializeComponent();
        }

        private void DealingsLists_Load(object sender, EventArgs e)
        {
            BindGrid();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_AddNew == true)
            {
                if (txtDLName.Text != "")
                {
                    opr.connect();
                    opr.cmd.CommandText = "insert into Dealings (DL_Name) values ('" + txtDLName.Text + "')";
                    int aff = opr.cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("تم التسجيل بنجاح");
                        _AddNew = false;
                        txtDLName.Enabled = false;
                        btnSave.Enabled = false;
                        btnNew.Enabled = true;
                        txtDLName.Clear();
                        opr.disconnect();
                    }

                }

            }
            BindGrid();
            btnNew.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _AddNew = true;
           txtDLName.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            txtDLName.Focus(); 
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
