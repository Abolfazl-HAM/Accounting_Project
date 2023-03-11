using Accounting.DataLayer.Context;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;

namespace Accounting.App
{
    public partial class frmAccounting : Form
    {
        UnitOfWork db = new UnitOfWork();
        public frmAccounting()
        {
            InitializeComponent();
        }

        private void frmAccounting_Load(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = db.CustomerRepository.GetNameCustomers();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = db.CustomerRepository.GetNameCustomers(txtFilter.Text);
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           txtName.Text= dgvCustomers.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                if (rbPay.Checked || rbReciv.Checked)
                {
                    DataLayer.Accounting accounting = new DataLayer.Accounting()
                    {
                        Amount = int.Parse(txtAmount.Value.ToString()),
                        CustomerID = db.CustomerRepository.GetCustomerIdByName(txtName.Text),
                        TypeID = (rbReciv.Checked) ? 1 : 2,
                        Date = DateTime.Now,
                        Description = txtDescription.Text
                    };
                    db.AccountingRepository.Insert(accounting);
                    db.Save();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    RtlMessageBox.Show("لطفا نوع تراکنش خود را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
               
        }
    }
}
