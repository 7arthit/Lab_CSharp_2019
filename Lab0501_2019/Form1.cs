using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0501_2019
{
    public partial class Form1 : Form
    {
        APD65_63011212019Entities1 context = new APD65_63011212019Entities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = context.Orders.ToList();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var orders = context.Orders; //เรียกข้อมูล
            crystalReport11.Database //ผูกข้อมูล report
                .Tables["Lab0501_2019_Order"]
                .SetDataSource(orders);
            crystalReportViewer1.ReportSource = crystalReport11; //รู้จักกันแล้ว
            crystalReportViewer1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var orders = context.Orders; //เรียกข้อมูล
            crystalReport21.Database //ผูกข้อมูล report
                .Tables["Lab0501_2019_Order"]
                .SetDataSource(orders);
            crystalReportViewer1.ReportSource = crystalReport21; //รู้จักกันแล้ว
            crystalReportViewer1.Show();
        }
    }
}
