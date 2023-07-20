using MeetingCalc.Repository;
using MeetingCalc.Extensions;

namespace MeetingCalc
{
    public class Runner
    {
        private readonly GraphRepository _graphRepository;
        private readonly WageDataRepository _wageDataRepository;
        public Runner(GraphRepository graphRepository, WageDataRepository wageDataRepository)
        {
            _graphRepository = graphRepository;
            _wageDataRepository = wageDataRepository;
        }

        public async Task RunAsync(string email)
        {
            var eventAttendeesList = await _graphRepository.GetEventAttendeesAsync(email);
            var wageDataList = _wageDataRepository.GetData();

            var wageMeetingJoinedAndGroupByEventList = eventAttendeesList
                .Join(wageDataList,
                    ea => ea.Name,
                    wd => wd.DisplayName,
                    (eventAttendee, wageData) => new
                    {
                        EventName = eventAttendee.Subject,
                        EventId = eventAttendee.Id,
                        Name = eventAttendee.Name,
                        RatePerHour = wageData.HourlyRate,
                        RatePerMinute = wageData.HourlyRate / 60,
                        MeetingLengthInMinutes = eventAttendee.MeetingLengthInMinutes
                    }
                )
                .GroupBy(x => x.EventId);

            foreach (var groupedItem in wageMeetingJoinedAndGroupByEventList)
            {
                foreach (var item in groupedItem)
                {
                    Console.WriteLine($"{item.Name}\t{item.RatePerHour.FormatAsCurrency()}");
                }

                var single = groupedItem.First();
                var estimatedCostPerMinute = groupedItem.Sum(x => x.RatePerMinute);
                var estimatedCost = estimatedCostPerMinute * single.MeetingLengthInMinutes;
                Console.WriteLine("");
                Console.WriteLine($"{single.EventName} ({single.MeetingLengthInMinutes}) Estimated meeting cost: {estimatedCost.FormatAsCurrency()}");
                Console.WriteLine("\n-----------------------------------------------");
            }
        }
    }

}

