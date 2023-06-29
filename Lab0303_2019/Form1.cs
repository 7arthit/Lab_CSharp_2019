using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0303_2019
{
    public partial class Form1 : Form
    {
        APD65_63011212019Entities context = new APD65_63011212019Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string student_id = comboBox1.Text;
            string subject_id = dataGridView2.SelectedRows[0]
                .Cells[0].Value.ToString();

            var toDel = context.Register
                .Where(r => r.student_id == student_id
                && r.subject_id == subject_id);
            context.Register.RemoveRange(toDel);

            int change = context.SaveChanges();
            MessageBox.Show("Change: " + change + " records ");

        }
            private void Form1_Load(object sender, EventArgs e)
        {
            StudentBindingSource1.DataSource = context.Student.ToList();
            subjectBindingSource.DataSource = context.Subject.ToList();
            registerBindingSource.DataSource = context.Register
                .Where(r => r.student_id == comboBox1.Text)
                .Select(r => new {r.subject_id, r.Subject.subject_name,
                r.Subject.subject_credit})
                .ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registerBindingSource.DataSource = context.Register
                .Where(r => r.student_id == comboBox1.Text)
                .Select(r => new {
                    r.subject_id,
                    r.Subject.subject_name,
                    r.Subject.subject_credit
                })
                .ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            registerBindingSource.DataSource = context.Register
                .Where(r => r.student_id == comboBox1.Text)
                .Select(r => new {
                    r.subject_id,
                    r.Subject.subject_name,
                    r.Subject.subject_credit
                })
                .ToList();
        }
    }
}
