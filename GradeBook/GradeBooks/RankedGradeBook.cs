﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int minimumStudetRequiredToRank = 5;

            if (this.Students.Count < minimumStudetRequiredToRank)
            {
                throw new InvalidOperationException("Ranked Grading requires a minimum of 5 students to work");
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if(grades[threshold-1] <= averageGrade)
            {
                return 'A';
            }
            else if(grades[threshold*2 - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[threshold * 3 - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[threshold * 4 - 1] <= averageGrade)
            {
                return 'D';
            }
            return 'F';
        }
    }
}
