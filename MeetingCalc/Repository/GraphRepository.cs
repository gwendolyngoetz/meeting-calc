using Microsoft.Graph;
using Microsoft.Graph.Models;
using MeetingCalc.Model;

namespace MeetingCalc.Repository
{
    public class GraphRepository
    {
        private readonly GraphServiceClient _graphClient = default!;

        public GraphRepository(GraphConnection config)
        {
            _graphClient = config.GraphClient;
        }

        public async Task<List<EventAttendee>> GetEventAttendeesAsync(string email)
        {
            var events = await _graphClient.Users[email].Events.GetAsync();

            var results = new List<EventAttendee>();

            foreach (var eventItem in (events?.Value ?? new List<Event>()))
            {
                var startDateTime = eventItem.Start.ToDateTime();
                var endDateTime = eventItem.End.ToDateTime();
                var minutes = (endDateTime - startDateTime).TotalMinutes;
                
                results.Add(CreateEventAttendee(eventItem, eventItem?.Organizer?.EmailAddress, minutes));

                foreach (var attendee in (eventItem?.Attendees ?? new List<Attendee>()))
                {
                    results.Add(CreateEventAttendee(eventItem, attendee.EmailAddress, minutes));
                }
            }

            return results;
        }

        private EventAttendee CreateEventAttendee(Event? eventItem, EmailAddress? emailAddress, double minutes)
        {
            return new EventAttendee
            {
                Subject = eventItem?.Subject ?? "",
                MeetingLengthInMinutes = minutes,
                Id = eventItem?.Id ?? "",
                Name = emailAddress?.Name ?? "",
                Email = emailAddress?.Address ?? ""
            };
        }
    }
}

