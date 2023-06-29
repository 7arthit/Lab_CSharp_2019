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
    public partial class Form2 : Form
    {
        //สร้าง porb ของ คลาส
        Form1 form1;
        public Form2(Form1 form1) // ส่ง รับ พรารามิเตอร์มา
        {
            this.form1 = form1;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.form1.Visible = true;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.form1.Show(); //ถ้ากดปิด form2 ให้ form1 กลับขึ้นมา show
            this.Visible = false; //form2 ปิดลง
        }
    }
}
