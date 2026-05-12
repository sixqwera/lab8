using System;
using System.Collections.Generic;
using System.Text;

namespace main
{
    internal class _2
    {
        private int _id;
        private string _lastName;
        private string _firstName;
        private double _avg;
        private int _grade;

        public _2(int id, string lastName, string firstName, double avg, int grade)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Avg = avg;
            Grade = grade;
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public double Avg
        {
            get
            {
                return _avg;
            }
            set
            {
                _avg = value;
            }
        }

        public int Grade
        {
            get
            {
                return _grade;
            }
            set
            {
                _grade = value;
            }
        }

        

        public override string ToString()
        {
            return $"ID: {Id} | Фамилия: {LastName} | Имя: {FirstName} | Средний балл: {Avg} | Класс: {Grade}";
        }
    }
}
