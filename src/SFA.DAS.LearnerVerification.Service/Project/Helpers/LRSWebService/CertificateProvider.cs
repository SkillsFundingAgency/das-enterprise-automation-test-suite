using Azure.Identity;
using Azure.Security.KeyVault.Certificates;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SFA.DAS.LearnerVerification.Service.Project.Helpers.LRSWebService
{
    public class CertificateProvider
    {
        private readonly LearnerVerificationConfig _config;
        private X509Certificate2 _x509Certificate;

        public CertificateProvider(LearnerVerificationConfig appSettings)
        {
            _config = appSettings;
        }

        public X509Certificate2 GetClientCertificate()
        {
            if (string.IsNullOrEmpty(_config.LV_KeyVaultUrl))
            {
                throw new ArgumentNullException(nameof(_config.LV_KeyVaultUrl), $"{nameof(_config.LV_KeyVaultUrl)} is not specified. That is required to run the app.");
            }

            if (string.IsNullOrEmpty(_config.LV_CertificateName))
            {
                throw new ArgumentNullException(nameof(_config.LV_CertificateName), $"{nameof(_config.LV_CertificateName)} for LRS Web Service is not specified. That is required to run the app.");
            }

            if (_x509Certificate == null)
            {
                SetupClientCertificate();
            }

            return _x509Certificate;
        }

        private void SetupClientCertificate()
        {
            var client = new CertificateClient(new Uri(_config.LV_KeyVaultUrl), new DefaultAzureCredential());
            _x509Certificate = client.DownloadCertificate(_config.LV_CertificateName);
        }
    }
}