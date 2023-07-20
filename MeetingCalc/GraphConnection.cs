using Azure.Identity;
using Microsoft.Graph;

namespace MeetingCalc
{
    public class GraphConnection
    {
        private readonly GraphServiceClient _graphClient = default!;

        public GraphServiceClient GraphClient => _graphClient;

        public GraphConnection(Config config)
        {
            var options = new DeviceCodeCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            };

            var clientSecretCredential = new ClientSecretCredential(config.TenantId, config.ClientId, config.ClientSecret, options);

            _graphClient = new GraphServiceClient(clientSecretCredential, config.Scopes); 
        }
    }
}
