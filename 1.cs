using System;
using System.Collections.Generic;

namespace main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DataBase> list = new List<DataBase>
            {
                new DataBase(1, "Иванов", "Иван", 8.5, 10),
                new DataBase(2, "Петров", "Пётр", 6.3, 11),
                new DataBase(3, "Сидоров", "Сидор", 9.1, 10),
                new DataBase(4, "Козлов", "Кирилл", 5.7, 9),
                new DataBase(5, "Морозов", "Максим", 7.8, 11)
            };

            Cheker.WriteToFile(list);

            bool running = true;
            int id = 0;
            int grade = 0;
            int gradeCount = 0;

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
                        Cheker.ShowAll(list);
                        break;

                    case "2":
                        Console.Write("Введите ID для удаления: ");
                        id = int.Parse(Console.ReadLine());
                        Cheker.Delete(list, id);
                        Cheker.WriteToFile(list);
                        break;

                    case "3":
                        Cheker.Add(list);
                        Cheker.WriteToFile(list);
                        break;

                    case "4":
                        Console.WriteLine("\n=== LINQ-ЗАПРОСЫ ===");
                        Console.WriteLine(
                            "1. Студенты со средним баллом выше 7"
                        );
                        Console.WriteLine(
                            "2. Студенты определённого класса"
                        );
                        Console.WriteLine(
                            "3. Максимальный средний балл"
                        );
                        Console.WriteLine(
                            "4. Количество студентов в классе"
                        );
                        Console.Write("Выберите запрос: ");

                        string linq = Console.ReadLine();

                        switch (linq)
                        {
                            case "1":
                                Cheker.GetHighAvg(list);
                                break;

                            case "2":
                                Console.Write("Введите класс: ");
                                grade = int.Parse(Console.ReadLine());
                                Cheker.GetByGrade(list, grade);
                                break;

                            case "3":
                                Cheker.GetMaxAvg(list);
                                break;

                            case "4":
                                Console.Write("Введите класс: ");
                                gradeCount = int.Parse(Console.ReadLine());
                                Cheker.GetCountByGrade(list, gradeCount);
                                break;

                            default:
                                Console.WriteLine("Неверный пункт!");
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
