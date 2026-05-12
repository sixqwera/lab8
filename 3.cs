using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace main
{
    internal class Cheker
    {
        public static void WriteToFile(List<DataBase> students)
        {
            BinaryWriter writer = new BinaryWriter(
                File.Open("student.dat", FileMode.Create)
            );

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

        public static List<DataBase> ReadFromFile()
        {
            List<DataBase> list = new List<DataBase>();
            BinaryReader reader = new BinaryReader(
                File.Open("student.dat", FileMode.Open)
            );

            int id = 0;
            string lastName = "";
            string firstName = "";
            double avg = 0;
            int grade = 0;

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                id = reader.ReadInt32();
                lastName = reader.ReadString();
                firstName = reader.ReadString();
                avg = reader.ReadDouble();
                grade = reader.ReadInt32();
                list.Add(new DataBase(
                    id, lastName, firstName, avg, grade
                ));
            }

            reader.Close();
            return list;
        }

        public static void ShowAll(List<DataBase> students)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("Список студентов пуст.");
                return;
            }

            foreach (var timeI in students)
            {
                Console.WriteLine(timeI);
            }
        }

        public static void Delete(List<DataBase> list, int id)
        {
            DataBase student = list.Find(stud => stud.Id == id);

            if (student == null)
            {
                Console.WriteLine("Студент не найден!");
                return;
            }

            list.Remove(student);
            Console.WriteLine("Студент удалён!");
        }

        public static void Add(List<DataBase> list)
        {
            try
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());

                if (list.Any(s => s.Id == id))
                {
                    Console.WriteLine(
                        "Ошибка: Студент с таким ID уже существует!"
                    );
                    return;
                }

                Console.Write("Фамилия: ");
                string lastName = Console.ReadLine();
                Console.Write("Имя: ");
                string firstName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(lastName) ||
                    string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine(
                        "Ошибка: Имя и фамилия не могут быть пустыми!"
                    );
                    return;
                }

                Console.Write("Средний балл: ");
                double avg = double.Parse(Console.ReadLine());

                Console.Write("Класс: ");
                int grade = int.Parse(Console.ReadLine());

                list.Add(new DataBase(
                    id, lastName, firstName, avg, grade
                ));
                Console.WriteLine("Студент добавлен!");
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Ошибка: Введены некорректные данные!"
                );
            }
        }

        public static void GetHighAvg(List<DataBase> students)
        {
            var result = students.Where(s => s.Avg > 7).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine(
                    "Студентов со средним баллом выше 7 нет."
                );
                return;
            }

            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }

        public static void GetMaxAvg(List<DataBase> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine(
                    "Список пуст, невозможно вычислить балл."
                );
                return;
            }

            double max = list.Max(s => s.Avg);
            Console.WriteLine($"Максимальный средний балл: {max}");
        }

        public static void GetByGrade(List<DataBase> list, int grade)
        {
            var result = list.Where(s => s.Grade == grade).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine(
                    $"Нет студентов в {grade} классе!"
                );
                return;
            }

            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }

        public static void GetCountByGrade(
            List<DataBase> list, int grade)
        {
            int count = list.Count(s => s.Grade == grade);
            Console.WriteLine(
                $"Количество студентов в {grade} классе: {count}"
            );
        }
    }
}
