using Accounting.App.Accounting;
using Accounting.Utility.Convertor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void btnCustomer_Click_1(object sender, EventArgs e)
        {
            ListCustomers frmListCustomers = new ListCustomers();
            frmListCustomers.BindGrid();
            frmListCustomers.ShowDialog();
        }

        private void btnNewAccounting_Click(object sender, EventArgs e)
        {
            frmAccounting frmAccounting = new frmAccounting();
            
            frmAccounting.ShowDialog();
        }

        private void btnReportPay_Click(object sender, EventArgs e)
        {
            frmReport report = new frmReport();
            report.TypeId = 2;
            report.Text = "گزارش پرداختی ها";
            report.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmReport report = new frmReport();
            report.TypeId = 1;
            report.Text = "گزارش دریافتی ها";
            report.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                lblDate.Text = DateTime.Now.ToShamsi();
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.IsEdit = true;
            frmLogin.ShowDialog();
        }
    }
}
