using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataAccessLayer;
namespace WindowsFormsApp1
{
    public partial class normalUser : Form
    {
        private List<Stocks> list;
        public normalUser()
        {
            InitializeComponent();
            list = new DataAccess().ReadDataBase();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtCode.Text = string.Empty;
            txtquantity.Text = string.Empty;
            txtSearch.Text = string.Empty;
            //combobox needs to go here maybe
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        private void btnClearQuantity_Click(object sender, EventArgs e)
        {
            txtquantity.Text = string.Empty;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string itemID = txtCode.Text;
            string quantity = txtquantity.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            List<string> searchResults = new List<string>();
            foreach (var element in list)
            {
                if(searchText == element.ItemCode)
                {
                    searchResults.Add(element.ItemCode);
                }
                else if (searchText == element.Description)
                {
                    searchResults.Add(element.Description);
                }
            }
            lbSearch.DataSource = searchResults;
        }
        private void lbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
           string search = lbSearch.SelectedItem.ToString();
           foreach(var element in list)
            {
                if (element.ItemCode == search)
                {
                    txtCode.Text = element.ItemCode;
                    cmbDescription.SelectedItem = element.Description;
                }
                else if(element.Description == search)
                {
                    txtCode.Text = element.ItemCode;
                    cmbDescription.SelectedItem = element.Description;
                }
            }
        }
        private void cmbDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> desList = new List<string>();
            while(list.GetEnumerator().MoveNext())
            desList.Add(list.GetEnumerator().Current.Description);
            cmbDescription.DataSource = desList;
        }
    }
}
