﻿namespace AwsSecretManager
{
    public static class Secret
    {
        public static void AddAmazonSecretsManager(
          this IConfigurationBuilder configurationBuilder,
          string region,
          string secretName)
        {
            var configurationSource = new SecretManagerSource(region, secretName);
            configurationBuilder.Add(configurationSource);
        }
    }
}
