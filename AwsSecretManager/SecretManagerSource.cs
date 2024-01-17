namespace AwsSecretManager
{
    public class SecretManagerSource : IConfigurationSource
    {
        private readonly string _region;
        private readonly string _secretName;

        public SecretManagerSource(string region, string secretName)
        {
            _region = region;
            _secretName = secretName;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SecretManagerProvider(_region, _secretName);
        }
    }
}
