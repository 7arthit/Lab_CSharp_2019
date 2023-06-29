using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0101_2019
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //7 จากคลิป จุดสีแดง คือ break point ยังไม่ทำงานในบรรทัดนี้
            //8 ถ้าจะทำงาน ไปที่ step over (F10) ไปทีละบรรทัด จากนั้น กดดูค่าข้อมูล
            List<Student> Students = new List<Student>(); //2 สร้าง List Student s เพราะมีหลายคน

            Student Std1 = new Student(); //3 สร้างนักเรียนคนที่ 1
            Std1.Fullname = "Arthit";
            Std1.Quiz = 10;
            Std1.Midtrem = 40 ;
            Std1.Final = 30;

            Student Std2 = new Student(); //4 สร้างนักเรียนคนที่ 2
            Std1.Fullname = "Sathawat";
            Std1.Quiz = 15;
            Std1.Midtrem = 25;
            Std1.Final = 25;

            //6 เอา OBJ มาเพิ่มใน List 
            Students.Add(Std1); 
            Students.Add(Std2);

            //15 ทำ step over ทำงานตามลำดับ
            //16 ทำ step in two (F11) คือ ถ้ามี Method จะไปทำงานทันที
            foreach (Student student in Students)//11 วน Loop เอานักเรีนแต่ละคนมา
            {
                //12 เรียก Method score(None static) ไม่ได้เพราะ เป็น main Method ที่เป็น static
                student.Grade = new Program().score(student); //13 new Program() ถึงจะเรียกได้
                Console.WriteLine("Grade: " + student.Grade); //14 คำสั่ง Console.WriteLine โชว์ข้อความ
            }
            Console.ReadLine();

        }
        string score(Student student) //9 Method คำนวนเกรด ส่ง student มาประมวลผล
        {
            int sum = student.Quiz + student.Midtrem + student.Final; //10 หาค่า sum จาก student ที่ส่งเข้ามา
            if (sum < 50) return "F";
            else if (sum < 55) return "D";
            else if (sum < 60) return "D+";
            else if (sum < 65) return "C";
            else if (sum < 70) return "C+";
            else if (sum < 75) return "B";
            else if (sum < 80) return "B+";
            else if (sum < 100) return "A";
            else return "";
        }
    }
    class Student //1 สร้าง class
    {
        //5 ทำ public ก่อน ถึงใช้ข้าม class ได้
        public String Fullname; //1 ชื่อ
        public String Grade; //1 เกรด
        public int Quiz ; //1 คะแนนเก็บ
        public int Midtrem; //1 คะแนนกลางภาค
        public int Final; //1 คะแนนปลายภาค
    }
}
