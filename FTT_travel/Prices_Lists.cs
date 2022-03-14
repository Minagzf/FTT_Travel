using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTT_travel
{
    public partial class Prices_Lists : Form
    {
        Operations opr = new Operations();
        void FillCombo()
        {
            opr.connect();
            #region campanies
            opr.cmd.CommandText = "select * from companies";
            opr.dataReader = opr.cmd.ExecuteReader();
            DataTable comp_dt = new DataTable();
            comp_dt.Load(opr.dataReader);
            CmbCompName.DataSource = comp_dt;
            CmbCompName.DisplayMember = "Company_Name";
            CmbCompName.ValueMember = "Company_ID";
            opr.dataReader.Close();
            #endregion

            #region Deals          
            opr.cmd.CommandText = "select * from Dealings";
            opr.dataReader = opr.cmd.ExecuteReader();
            DataTable Dealing_dt = new DataTable();
            Dealing_dt.Load(opr.dataReader);
            opr.dataReader.Close();            
            CmbDealName.DataSource = Dealing_dt;
            CmbDealName.DisplayMember = "DL_Name";
            CmbDealName.ValueMember = "DL_ID";
            #endregion

            #region Capacities
            opr.cmd.CommandText = "select * from Capacity";
            opr.dataReader = opr.cmd.ExecuteReader();
            DataTable capacity_dt = new DataTable();
            capacity_dt.Load(opr.dataReader);
            CmbCap.DataSource = capacity_dt;
            CmbCap.DisplayMember = "Capacity_Capacity";
            CmbCap.ValueMember = "Capacity_ID";
            opr.dataReader.Close();
            #endregion
            opr.disconnect();

        }
        void clear_controls()
        {
            CmbCap.Text = "";
            CmbCompName.Text = "";
            CmbDealName.Text = "";
            txt_Commission.Clear();
            TxtTotal.Clear();
            CmbCompName.Focus();
            chkVat.Checked = false;
        }
        public Prices_Lists()
        {
            InitializeComponent();
        }

       

 

        private void btnNew_Click(object sender, EventArgs e)
        {
            FillCombo();
            clear_controls();

        }

        private void Prices_Lists_Load(object sender, EventArgs e)
        {
            FillCombo();
            clear_controls();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            opr.cmd.CommandText = "insert into Prices_Lists (Company_ID,Deal_ID,Capacity_ID,Driver_Commision,Price,has_vat)" +
                " values ('" + CmbCompName.SelectedValue + "','" + CmbDealName.SelectedValue + "','" + CmbCap.SelectedValue + "','" + txt_Commission.Text + "','"+ TxtTotal.Text+"'," + chkVat.Checked +")";
            opr.connect();
            int aff = opr.cmd.ExecuteNonQuery();
           if (aff >0)
            {
                MessageBox.Show("تم التسجيل بنجاح");

            }
            opr.disconnect();
            clear_controls();
            
        }
    }
}
