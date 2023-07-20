using MeetingCalc.Repository;

namespace MeetingCalc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new Config();

            var graphConnection = new GraphConnection(config);
            var graphRepository = new GraphRepository(graphConnection);

            var wageDataRepository = new WageDataRepository(config.WageDataFilePath);

            var runner = new Runner(graphRepository, wageDataRepository);

            runner.RunAsync(config.UserEmail).Wait();
        }
    }
}
