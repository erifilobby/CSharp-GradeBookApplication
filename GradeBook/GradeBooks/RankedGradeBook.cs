using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)

        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var inputGrade = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(d => d.AverageGrade).Select(d => d.AverageGrade).ToList();
            if (averageGrade >= grades[inputGrade - 1])
            {
                return 'A';
            }
            else if (averageGrade >= grades[(inputGrade * 2) - 1])
            {
                return 'B';
            }
            else if (averageGrade >= grades[(inputGrade * 3) - 1])
            {
                return 'C';
            }
            else if (averageGrade >= grades[(inputGrade * 4) - 1])
            {
                return 'D';
            }

            return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);

        }


    }
}