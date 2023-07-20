using CsvHelper.Configuration.Attributes;

namespace MeetingCalc.Model
{
    public class WageData
    {
        [Name("Department")]
        public string Department { get; set; } = "";

        [Name("Last Name")]
        public string LastName { get; set; } = "";

        [Name("First Name")]
        public string FirstName { get; set; } = "";

        [Name("Job Title")]
        public string JobTitle { get; set; } = "";

        [Name("Hourly Rate ")]
        public double HourlyRate { get; set; } = 0.0;

        public string DisplayName => $"{FirstName} {LastName}";
    }
}

