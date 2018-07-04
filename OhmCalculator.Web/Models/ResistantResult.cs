namespace OhmCalculator.Web.Models
{
    public class ResistantResult
    {
        public ResistantResult(double ohmResult, string tolerance, double minimum, double maximum)
        {
            this.OhmResult = ohmResult;
            this.Tolerance = tolerance;
            this.Minimum = minimum;
            this.Maximum = maximum;
        }

        public double OhmResult { get; set; }
        public string Tolerance { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
    }
}