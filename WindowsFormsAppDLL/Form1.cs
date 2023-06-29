using SimpelDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpelDLL;
using Calculate_area_circle;
using New_Library;

namespace WindowsFormsAppDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Simple simple = new Simple();
            String str = simple.SayHello("Arthit");
            Console.WriteLine(str);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            Simple simple = new Simple();
            int z = simple.AddNumber(a, b);
            
            textBox3.Text = z.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double c = double.Parse(textBox4.Text);

            CelCircle celcircle = new CelCircle();
            double y = celcircle.CelArea(c);

            //Shape shape = new Shape();
            //double y = shape.circle(c);

            textBox5.Text = y.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
