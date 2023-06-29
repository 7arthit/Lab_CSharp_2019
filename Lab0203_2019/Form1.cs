using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0203_2019
{
    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //object
            Form2 form2 = new Form2(this); //this ส่งค่า ผ่าน คอนสตรัค
            form2.Show();//แสดง Form2
            this.Hide(); //ซ่อน Form1
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.form2 = new Form2(this);//Form2 ถูกสร้างตรงนี้
        }
    }
}
