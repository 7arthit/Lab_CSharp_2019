using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amazon_Project
{
    public partial class Form1 : Form
    {
        APD65_63011212019Entities context = new APD65_63011212019Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var idstr = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
            Console.WriteLine(idstr);

            var result = context.MenuAmazons.Where(p => p.Menu_Name == idstr).First();
            string[] item = new string[]
            {
                result.Menu_Name,
                result.Price.ToString(),
                result.Id.ToString(),
            };

            listView2.Items.Add(new ListViewItem(item));
            int sum = calculateTotal(listView2.Items);
            label5.Text = sum.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var result1 = menuAmazonBindingSource.DataSource = context.MenuAmazons.Where((m) => m.Type_Menu == 1).ToList();
            dataGridView4.DataSource = result1;
            var result2 = menuAmazonBindingSource1.DataSource = context.MenuAmazons.Where((m) => m.Type_Menu == 2).ToList();
            dataGridView5.DataSource = result2;
            var result3 = menuAmazonBindingSource2.DataSource = context.MenuAmazons.Where((m) => m.Type_Menu == 3).ToList();
            dataGridView6.DataSource = result3;
            var result4 = listBillBindingSource.DataSource = context.ListBills.ToList();
            dataGridView2.DataSource = result4;


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListBill bill = new ListBill();
            bill.Order_Date = DateTime.Now;
            bill.Total_Amount = int.Parse(label5.Text);
            context.ListBills.Add(bill);

            int change = context.SaveChanges();
            MessageBox.Show(" Chang " + change + " records");

            if (change == 1)
            {
                foreach (ListViewItem item in listView2.Items)
                {
                    BillItem billitem = new BillItem();
                    billitem.Bill_Id = billitem.Id;
                    billitem.Menu_Id = int.Parse(item.SubItems[2].Text);
                    billitem.Price = int.Parse(item.SubItems[1].Text);

                    context.BillItems.Add(billitem);
                    context.SaveChanges();
                }
            }

            listView2.Clear();
        }


        private void menuAmazonBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int calculateTotal(ListView.ListViewItemCollection items)
        {
            int sum = 0;
            foreach (ListViewItem item in items)
            {
                sum += int.Parse(item.SubItems[1].Text);
            }
            return sum;
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var idstr = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
            Console.WriteLine(idstr);

            var result = context.MenuAmazons.Where(p => p.Menu_Name == idstr).First();
            string[] item = new string[]
            {
                result.Menu_Name,
                result.Price.ToString(),
                result.Id.ToString(),
            };

            listView2.Items.Add(new ListViewItem(item));
            int sum = calculateTotal(listView2.Items);
            label5.Text = sum.ToString();
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var idstr = dataGridView6.SelectedRows[0].Cells[0].Value.ToString();
            Console.WriteLine(idstr);

            var result = context.MenuAmazons.Where(p => p.Menu_Name == idstr).First();
            string[] item = new string[]
            {
                result.Menu_Name,
                result.Price.ToString(),
                result.Id.ToString(),
            };

            listView2.Items.Add(new ListViewItem(item));
            int sum = calculateTotal(listView2.Items);
            label5.Text = sum.ToString();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
