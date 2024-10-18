using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            // Set up the ListView
            listView1.Columns.Add("Items", 200);
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.View = View.Details;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string itemText = TextBox.Text.Trim();
            if (!string.IsNullOrEmpty(itemText))
            {
                ListViewItem item = new ListViewItem(itemText);
                listView1.Items.Add(item);
                textBoxInput.Clear();
            }
            else
            {
                MessageBox.Show("Please enter an item.");
            }
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }
    }
}