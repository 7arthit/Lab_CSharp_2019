using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0302_2019
{
    public partial class Form1 : Form
    {
        APD65_63011212019Entities context = new APD65_63011212019Entities(); //1 ตัวแทนเชื่อมต่อ
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           studentBindingSource.DataSource = context.Student.ToList();//2 ข้อมูลมาผูก studentBindingSource.DataSource
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            studentBindingSource.EndEdit();
            int change = context.SaveChanges();
            MessageBox.Show("Change: " + change + " records ");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
