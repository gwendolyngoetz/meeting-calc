namespace MeetingCalc
{
    public class Config
    {
        public string TenantId => "";
        public string ClientId => "";
        public string ClientSecret => "";
        public string[] Scopes => new[] { "https://graph.microsoft.com/.default" };

        public string UserEmail = "";
        public string WageDataFilePath => "fakewagedata.csv";
    }
}

