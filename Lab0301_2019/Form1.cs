using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0301_2019
{
    public partial class Form1 : Form
    {
        StudentProjectEntities Context = new StudentProjectEntities(); //1 สร้าง Context การเชื่อมต่อ
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Linq Query
            // var result = from s in Context.Students //เอาข้อมูล Students ใส่ตัวแปร s
            //                 select s;
            // dataGridView1.DataSource = result.ToList(); //แปลง result ให้เป็น List ก่อน ค่อยเอามาใส่ DataSource

            // Linq Method สั้นกว่า
            var result = Context.Students; //เชื่อมต่อ Poproties
            dataGridView1.DataSource = result.ToList(); //แปลง result ให้เป็น List ก่อน ค่อยเอามาใส่ DataSource

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = Context.Students
              .Where(a => a.student_id == textBox1.Text);
              //Where เป็น method ข้อมูลที่ได้้มาใส่ใน a เอา a ไปค้นหา student_id ที่ textBox1 ที่พิมพ์มา
            dataGridView1.DataSource = result.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Context.Students.Where(a => a.student_id == textBox3.Text) //ค้นหา student_id = textBox3 ที่จะอัพเดท
                .First().student_fullname = textBox8.Text;// อัพเดท student_fullname = textBox8 ที่จะอัพเดท
            int chang = Context.SaveChanges();
            MessageBox.Show("Change: "+ chang + " records ");

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // var result = from s in Context.Students
            //              where s.student_id == textBox1.Text
            //              && s.student_password == textBox2.Text
            //              select s;
            // dataGridView1.DataSource = result.ToList();

            var result = Context.Students
                .Where(s => s.student_id == textBox1.Text // s ไปเช็ค student_id == textBox1 ที่พิมพ์มาไหม
                && s.student_password == textBox2.Text);// และ s ไปเช็ค student_password == textBox2 ที่พิมพ์มาไหม
            dataGridView1.DataSource = result.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = Context.Students
                .OrderByDescending(s => s.student_fullname);// OrderByDescending คือ การเรียงข้อมูล มากไปน้อย เรียงตาม ชื่อ student_fullname
            dataGridView1.DataSource = result.ToList();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = Context.Students
                .Select(s => new{ s.student_id, s.student_fullname})//เลือกเฉพาะ student_id student_fullname มาแสดง
                .OrderBy(s => s.student_id);//เรียงตาม student_id
            dataGridView1.DataSource = result.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Number of records: " + Context.Students.Count()); //MessageBox กล่องข้อความขึ้น และจำนวน
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Student student = new Student(); //สร้าง OBJ ของ student
            student.student_id = textBox4.Text; // student_id = ค่าที่รับ
            student.student_fullname = textBox7.Text; //student_fullname = ค่าที่รับ

            Context.Students.Add(student);//insert เพิ่ม Students.Add(student) ลงฐานข้อมูล
            int chang = Context.SaveChanges();//ลงฐานข้อมูล อัพเดท บน เซิฟเวอร์
            MessageBox.Show("Change: " + chang + " records ");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var result = Context.Students
                .Where(s => s.student_id == textBox5.Text); //ค้นหาสิ่งที่จะลบ ที่ student_id ที่ textBox5 ที่ค้นหา
            Context.Students.Remove(result.First());//.First() ตัวแรก ลบออกจากฐานข้อมูล local

            int chang = Context.SaveChanges();//แล้ว save จะไปลบบน server
            MessageBox.Show("Change: " + chang + " records ");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var result = Context.Students
                .Where(s => s.student_id == textBox6.Text);//อัพเดท student_id ที่ป้อน
            result.First().student_image = ImageToByteArray(pictureBox1.Image); // แปลงค่า student_image

            int chang = Context.SaveChanges();//save บนฐานข้อมูล
            MessageBox.Show("Change: " + chang + " records ");
        }
        public byte[] ImageToByteArray(Image image)// method public byte[] ส่ง พรามิเตอร์ image มา
        {
            var ms = new MemoryStream();//แปลงข้อมูล
            image.Save(ms, image.RawFormat);//บันทึกมาที่ ms 
            return ms.ToArray();// ส่งค่า
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //ถ้าเปิดไฟล์ ถ้ากดปุ่ม ok 
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);// pictureBox1.Image = ที่เอาเข้ามา
            }
        }
    }
}
