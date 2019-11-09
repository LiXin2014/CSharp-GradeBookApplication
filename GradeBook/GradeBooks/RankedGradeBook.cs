using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int numOfStudents = Students.Count;
            if (numOfStudents < 5)
            {
                throw new InvalidOperationException();
            }
            List<double> grades = new List<double>();
            foreach(Student student in Students)
            {
                grades.Add(student.AverageGrade);
            }
            grades.Sort();
            grades.Reverse();

            int range = (int)Math.Ceiling(numOfStudents*0.2);

            if (averageGrade >= grades[range*1-1])
                return 'A';
            else if (averageGrade >= grades[range*2-1])
                return 'B';
            else if (averageGrade >= grades[range*3-1])
                return 'C';
            else if (averageGrade >= grades[range*4-1])
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
