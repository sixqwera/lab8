using System;
using System.Collections.Generic;
using System.IO;

namespace main
{
    internal class _3
    {
        public static void WriteToFile(List<_2> students)
        {
            BinaryWriter writer = new BinaryWriter(File.Open("student.dat", FileMode.Create));

            foreach (var timeI in students)
            {
                writer.Write(timeI.Id);
                writer.Write(timeI.LastName);
                writer.Write(timeI.FirstName);
                writer.Write(timeI.Avg);
                writer.Write(timeI.Grade);
            }

            writer.Close();
        }

        public static List<_2> ReadFromFile()
        {
            List<_2> list = new List<_2>();

            BinaryReader reader = new BinaryReader(File.Open("student.dat", FileMode.Open));

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int id = reader.ReadInt32();
                string lastName = reader.ReadString();
                string firstName = reader.ReadString();
                double avg = reader.ReadDouble();
                int grade = reader.ReadInt32();

                list.Add(new _2(id, lastName, firstName, avg, grade));
            }

            reader.Close();

            return list;
        }
        public static void ShowAll(List<_2> students)
        {
            foreach (var timeI in students)
            {
                Console.WriteLine(timeI); 
            }
        }

        public static void Delete(List<_2> list, int id)
        {
            _2 student = list.Find(stud => stud.Id == id);

            if (student == null)
            {
                Console.WriteLine("Студент не найден!");
                return;
            }

            list.Remove(student);
            Console.WriteLine("Студент удалён!");
        }

        public static void Add(List<_2> list)
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Фамилия: ");
            string lastName = Console.ReadLine();

            Console.Write("Имя: ");
            string firstName = Console.ReadLine();

            Console.Write("Средний балл: ");
            double avg = double.Parse(Console.ReadLine());

            Console.Write("Класс: ");
            int grade = int.Parse(Console.ReadLine());

            list.Add(new _2(id, lastName, firstName, avg, grade));
            Console.WriteLine("Студент добавлен!");
        }

        public static void GetHighAvg(List<_2> students)
        {
            var result = students.Where(s => s.Avg > 7).ToList();
            foreach (var s in result)
                Console.WriteLine(s);
        }

        public static void GetByGrade(List<_2> list, int grade)
        {
            var result = list.Where(s => s.Grade == grade).ToList();
            foreach (var s in result)
                Console.WriteLine(s);
        }

        public static void GetMaxAvg(List<_2> list)
        {
            double max = list.Max(s => s.Avg);
            Console.WriteLine($"Максимальный средний балл: {max}");
        }

        public static void GetCountByGrade(List<_2> list, int grade)
        {
            int count = list.Count(s => s.Grade == grade);
            Console.WriteLine($"Количество студентов в {grade} классе: {count}");
        }

    }
}
