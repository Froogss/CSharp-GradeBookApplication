using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            List<char> outputGrades = new List<char> { 'A', 'B', 'C', 'D' };

            for (int i=0;i<6;i++)
            {
                double grade = grades[i];
                if (grade > averageGrade) continue;
                else
                {
                    if (grade == 5) return '5';
                    return outputGrades[i];
                }
            }
            return 'F';
            
            

            
        }
    }
}
