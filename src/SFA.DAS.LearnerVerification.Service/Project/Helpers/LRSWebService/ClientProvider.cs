using LrsWcfWebServiceReference;
using System.ServiceModel;

namespace SFA.DAS.LearnerVerification.Service.Project.Helpers.LRSWebService
{
    public class ClientProvider
    {
        private LearnerVerificationConfig _config { get; set; }

        public ClientProvider(LearnerVerificationConfig config)
        {
            _config = config;
        }

        public ClientWrapper Get()
        {
            var binding = new BasicHttpBinding();
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.UseDefaultWebProxy = true;

            var client = new LearnerPortTypeClient(binding, new EndpointAddress(_config.LV_WcfServiceBaseUrl));
            var certificateProvider = new CertificateProvider(_config);
            client.ClientCredentials.ClientCertificate.Certificate = certificateProvider.GetClientCertificate();

            return new ClientWrapper(client);
        }
    }
}