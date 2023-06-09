﻿
using Accounting.DataLayer.Context;
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
    public partial class ListCustomers : Form
    {
        public ListCustomers()
        {
            InitializeComponent();
        }

      
        public void BindGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgCustomers.AutoGenerateColumns = false;
               dgCustomers.DataSource= db.CustomerRepository.GetAllCustomers();
                
            }
        }

        private void txtFilterCustomer_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgCustomers.DataSource = db.CustomerRepository.GetCustomersByFilter(txtFilterCustomer.Text);

            }
        }

       

       

        private void btnAddCustomer_Click_1(object sender, EventArgs e)
        {
            frmAddOrEditCustomer frmAddOrEdit = new frmAddOrEditCustomer();
            if (frmAddOrEdit.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnDeleteCustomer_Click_1(object sender, EventArgs e)
        {
            int CustomerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
            if (CustomerId != 0)
            {

                using (UnitOfWork db = new UnitOfWork())
                {
                    string name = dgCustomers.CurrentRow.Cells[1].Value.ToString();
                    if (RtlMessageBox.Show($" آیا از حذف {name} مطمئن هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        db.CustomerRepository.DeleteCustomer(CustomerId);
                        db.Save();
                        BindGrid();
                    }

                }
            }
            else
            {
                RtlMessageBox.Show("لطفا شخص مورد نظر را انتخاب کنید");
            }
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            BindGrid();
            txtFilterCustomer.Text = "";
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgCustomers.CurrentRow != null)
            {
                int CustomerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
                frmAddOrEditCustomer addOrEdit = new frmAddOrEditCustomer();
                addOrEdit.customerID = CustomerId;
                if (addOrEdit.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
           
        }

        
    }
}
