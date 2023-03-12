namespace CourseMarkLibrary
{
    public interface ICourse
    {
        public IEvaluation AddEvaluation(string desc, double basis, double earned, double weight);

        public double CalcTotalWeight();
        public double CalcTotalEarnedMarks();
        public double CalcPercent();

    }
}