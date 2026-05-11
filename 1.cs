using System;
using System.Collections.Generic;

namespace main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<_2> list = new List<_2>
            {
                new _2(1, "Иванов", "Иван", 8.5, 10),
                new _2(2, "Петров", "Пётр", 6.3, 11),
                new _2(3, "Сидоров", "Сидор", 9.1, 10),
                new _2(4, "Козлов", "Кирилл", 5.7, 9),
                new _2(5, "Морозов", "Максим", 7.8, 11)
            };

            _3.WriteToFile(list);

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== ЖУРНАЛ КЛАССА ===");
                Console.WriteLine("1. Просмотр базы данных");
                Console.WriteLine("2. Удаление студента (по ID)");
                Console.WriteLine("3. Добавление студента");
                Console.WriteLine("4. LINQ-запросы");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _3.ShowAll(list);
                        break;

                    case "2":
                        Console.Write("Введите ID для удаления: ");
                        int id = int.Parse(Console.ReadLine());
                        _3.Delete(list, id);
                        _3.WriteToFile(list);
                        break;

                    case "3":
                        _3.Add(list);
                        _3.WriteToFile(list);
                        break;

                    case "4":
                        Console.WriteLine("\n=== LINQ-ЗАПРОСЫ ===");
                        Console.WriteLine("1. Студенты со средним баллом выше 7");
                        Console.WriteLine("2. Студенты определённого класса");
                        Console.WriteLine("3. Максимальный средний балл");
                        Console.WriteLine("4. Количество студентов в классе");
                        Console.Write("Выберите запрос: ");

                        string linq = Console.ReadLine();

                        switch (linq)
                        {
                            case "1":
                                _3.GetHighAvg(list);
                                break;
                            case "2":
                                Console.Write("Введите класс: ");
                                int grade = int.Parse(Console.ReadLine());
                                _3.GetByGrade(list, grade);
                                break;
                            case "3":
                                _3.GetMaxAvg(list);
                                break;
                            case "4":
                                Console.Write("Введите класс: ");
                                int g = int.Parse(Console.ReadLine());
                                _3.GetCountByGrade(list, g);
                                break;
                        }
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Неверный пункт!");
                        break;
                }
            }
        }
    }
}
