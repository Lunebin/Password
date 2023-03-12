using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMarkLibrary
{
    public interface IEvaluation
    {
        string Description { get; }
        double BasisMarks { get; }
        double EarnedMarks { get; }
        double Weight { get; }

        public double CalcPercent();
        public double CalcCourseMarks();

    }
}
