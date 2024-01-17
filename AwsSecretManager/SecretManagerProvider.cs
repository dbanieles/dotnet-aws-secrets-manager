using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Text.Json;

namespace AwsSecretManager
{
    public class SecretManagerProvider : ConfigurationProvider
    {
        private readonly string _region;
        private readonly string _secretName;

        public SecretManagerProvider(string region, string secretName)
        {
            _region = region;
            _secretName = secretName;
        }

        public async override void Load()
        {
            var secret = await GetSecret();
            Data = JsonSerializer.Deserialize<Dictionary<string, string>>(secret);
        }

        public async Task<string> GetSecret()
        {
            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(_region));

            var request = new GetSecretValueRequest()
            {
                SecretId = _secretName,
                VersionStage = "AWSCURRENT",
            };

            var response = await client.GetSecretValueAsync(request);

            return response.SecretString;
        }
    }
}
