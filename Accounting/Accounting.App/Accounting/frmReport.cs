using Accounting.DataLayer.Context;
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

namespace Accounting.App.Accounting
{
    public partial class frmReport : Form
    {
        public int TypeId = 0;
        public frmReport()
        {
            InitializeComponent();
        }



        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }
        void Filter()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var result = db.AccountingRepository.Get(a => a.TypeID == TypeId);
                dgReport.Rows.Clear();
                foreach (var accounting in result)
                {
                    string customerName = db.CustomerRepository.GetCustomerNameById(accounting.CustomerID);
                    dgReport.Rows.Add(accounting.ID, customerName, accounting.Amount, accounting.Description, accounting.Date.ToShamsi());
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgReport.CurrentRow != null)
            {
                int accountingId = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                if (RtlMessageBox.Show("آیا از حذف این شخص مطمئن هستید", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (UnitOfWork db = new UnitOfWork())
                    {
                        db.AccountingRepository.Delete(accountingId);
                        db.Save();
                        Filter();
                    }
                }
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgReport.CurrentRow != null)
            {
                int accountingId = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                frmAccounting frmNew =new frmAccounting();
                frmNew.AccountID = accountingId;
                if (frmNew.ShowDialog() == DialogResult.OK)
                {
                    Filter();
                }

            }
        }
    }
}
