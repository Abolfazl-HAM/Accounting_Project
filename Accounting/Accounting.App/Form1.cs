using Accounting.App.Accounting;
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
    }
}
