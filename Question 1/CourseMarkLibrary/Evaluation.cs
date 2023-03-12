using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMarkLibrary
{
    internal class Evaluation : IEvaluation
    {
        public string Description => intDesc;
        public string intDesc;
        public double BasisMarks => intBasis;
        public double intBasis;

        public double EarnedMarks => intEarned;
        public double intEarned;
        public double Weight => intWeight;
        public double intWeight;


        public Evaluation(string desc, double basis, double earned, double weight)
        {
            intDesc= desc;
            intBasis = basis;
            intEarned= earned;
            intWeight = weight;
        }

        public double CalcCourseMarks()
        {
            return Weight * EarnedMarks / BasisMarks;
        }

        public double CalcPercent()
        {
            return 100 * EarnedMarks / BasisMarks;
        }
    }
}
