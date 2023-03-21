namespace BasicGraphClientConsoleApp
{
    using Microsoft.Graph;
    using Microsoft.Identity.Client;

    public class GraphClientFactory
    {
        private static readonly string ClientId = "";
        private static readonly string TenantId = "";
        private static readonly string ClientSecret = "";
        private static readonly string[] Scopes = { "https://graph.microsoft.com/.default" };

        private static GraphServiceClient? graphClient;

        public static GraphServiceClient GetGraphClient()
        {
            graphClient ??= CreateGraphClient();
            return graphClient;
        }

        private static GraphServiceClient CreateGraphClient()
        {
            var clientApp = ConfidentialClientApplicationBuilder
                .Create(ClientId)
                .WithTenantId(TenantId)
                .WithClientSecret(ClientSecret)
                .Build();

            return new GraphServiceClient(new FuncAuthenticationProvider(async (request) =>
            {
                var result = await clientApp.AcquireTokenForClient(Scopes).ExecuteAsync();
                request.Headers.Add("Authorization", $"Bearer {result.AccessToken}");
            }));
        }
    }
}
