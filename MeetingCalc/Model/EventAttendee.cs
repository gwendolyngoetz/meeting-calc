namespace MeetingCalc.Model
{
    public class EventAttendee
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Subject { get; set; } = "";
        public double MeetingLengthInMinutes { get; set; } = 0.0;
        public string Id { get; set; } = "";
    }
}

