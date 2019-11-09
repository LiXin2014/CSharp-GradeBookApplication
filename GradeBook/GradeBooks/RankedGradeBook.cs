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

            int range = numOfStudents / 5;

            if (averageGrade >= grades[range*1])
                return 'A';
            else if (averageGrade >= grades[range*2])
                return 'B';
            else if (averageGrade >= grades[range*3])
                return 'C';
            else if (averageGrade >= grades[range*4])
                return 'D';
            else
                return 'F';
        }
    }
}
