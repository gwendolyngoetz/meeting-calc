namespace MeetingCalc.Extensions
{
    public static class DoubleExtentions
    {
        public static string FormatAsCurrency(this double value)
        {
            return string.Format("${0:N2}", value);
        }
    }
}