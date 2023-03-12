using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMarkLibrary
{
    public class Course : ICourse
    {
        List<Evaluation> evaluations = new List<Evaluation>();

        public Course()
        {

        }

        public IEvaluation AddEvaluation(string desc, double basis, double earned, double weight)
        {
            Evaluation e = new Evaluation(desc, basis, earned, weight);
            IEvaluation ev = e;

            evaluations.Add(e);
            return ev;
        }

        public double CalcPercent()
        {
            return 100 * CalcTotalEarnedMarks() / CalcTotalWeight();
        }

        public double CalcTotalEarnedMarks()
        {
            double result = 0;

            foreach(var e in evaluations)
            {
                result += e.CalcCourseMarks();
            }

            return result;
        }

        public double CalcTotalWeight()
        {
            double result = 0;

            foreach (var e in evaluations)
            {
                result += e.Weight;
            }

            return result;
        }
    }
}
