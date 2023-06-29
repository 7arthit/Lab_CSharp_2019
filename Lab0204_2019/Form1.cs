using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0204_2019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFormToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //เช็ค form2 ว่าถูกสร้างยัง
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form form in fc)
            {
                if (form.Name == "Form2")
                {
                    FormFound = true;
                    form.Focus();
                    break;
                }
            }
            if (FormFound == false)
            {
                Form2 form2 = new Form2();
                form2.MdiParent = this; //form2 มี Parent เป็น form1
                form2.Show();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //เช็ค form3 ว่าถูกสร้างยัง
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach(Form form in fc)
            {
                if(form.Name == "Form3")
                {
                    FormFound = true;
                    form.Focus();
                    break;
                }
            }
            if(FormFound == false)
            {
                Form3 form3 = new Form3();
                form3.MdiParent = this; //form3 มี Parent เป็น form1
                form3.Show();
            }
        }
    }
}
