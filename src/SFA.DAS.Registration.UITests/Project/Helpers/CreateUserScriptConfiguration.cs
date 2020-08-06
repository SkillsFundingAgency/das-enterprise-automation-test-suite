using System;
using System.Text;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public enum ApprenticeshipEmployerType
    {
        NonLevy = 0,
        Levy = 1,
        Unknown = 2
    }

    public class CreateUserScriptConfiguration
    {
        /// <summary>
        /// Email of user to be created.
        /// Auto generated if not supplied
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password of user to be created
        /// Defaults to test if not supplied
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Account Type, Defaults to NonLevy if none Supplied
        /// </summary>
        public ApprenticeshipEmployerType ApprenticeshipEmployerType { get; set; }
        /// <summary>
        /// The Salt of the hash to be generated for the accound id private hash.
        /// Required.
        /// </summary>
        public string PrivateAccountHashSalt { get; set; }
        /// <summary>
        /// The allowed alphabet for the hash generated for the account id private hash.
        /// Required.
        /// </summary>
        public string PrivateAccountHashAllowedCharacters { get; set; }
        /// <summary>
        /// The Salt of the hash to be generated for the accont id public hash
        /// Required.
        /// </summary>
        public string PublichAccountHashSalt { get; set; }
        /// <summary>
        /// The allowed alphabet for the hash generated for the accound id public hash
        /// Required.
        /// </summary>
        public string PublicAccountHashAllowedCharacters { get; set; }
        /// <summary>
        /// The allowed alhabet for the hash generated for the account legal entity public hash
        /// Required
        /// </summary>
        public string PublicLegalEntityHashAllowedCharacters { get; set; }
        /// <summary>
        /// The Salt of the hash to be generated for the account legal entity public hash
        /// Required
        /// </summary>
        public string PublicLegalEntityHashSalt { get; set; }
        /// <summary>
        /// The name of the agreement to be signed as part of the records creation
        /// Required
        /// </summary>
        public string AgreementName { get; set; }
        /// <summary>
        /// The connection string to the employer profiles database
        /// Required
        /// </summary>
        public string EmployerUsersProfilesConnectionString { get; set; }
        /// <summary>
        /// The connection string to the employer users database
        /// Required
        /// </summary>
        public string EmployerUsersConnectionString { get; set; }
        /// <summary>
        /// The connection string to the employer accounts database
        /// Required
        /// </summary>
        public string EmployerAccountsConnectionString { get; set; }

        public void Validate()
        {
            var sb = new StringBuilder();

            if(string.IsNullOrEmpty(PrivateAccountHashSalt))
            {
                sb.Append($" {nameof(PrivateAccountHashSalt)} is Required.");
            }
            if (string.IsNullOrEmpty(PrivateAccountHashAllowedCharacters))
            {
                sb.Append($" {nameof(PrivateAccountHashAllowedCharacters)} is Required.");
            }
            if (string.IsNullOrEmpty(PublichAccountHashSalt))
            {
                sb.Append($" {nameof(PublichAccountHashSalt)} is Required.");
            }
            if (string.IsNullOrEmpty(PublicAccountHashAllowedCharacters))
            {
                sb.Append($" {nameof(PublicAccountHashAllowedCharacters)} is Required.");
            }
            if (string.IsNullOrEmpty(PublicLegalEntityHashAllowedCharacters))
            {
                sb.Append($" {nameof(PublicLegalEntityHashAllowedCharacters)} is Required.");
            }
            if (string.IsNullOrEmpty(PublicLegalEntityHashSalt))
            {
                sb.Append($" {nameof(PublicLegalEntityHashSalt)} is Required.");
            }
            if (string.IsNullOrEmpty(AgreementName))
            {
                sb.Append($" {nameof(AgreementName)} is Required.");
            }
            if (string.IsNullOrEmpty(EmployerAccountsConnectionString))
            {
                sb.Append($" {nameof(EmployerAccountsConnectionString)} is Required.");
            }
            if (string.IsNullOrEmpty(EmployerUsersConnectionString))
            {
                sb.Append($" {nameof(EmployerUsersConnectionString)} is Required.");
            }
            if (string.IsNullOrEmpty(EmployerUsersProfilesConnectionString))
            {
                sb.Append($" {nameof(EmployerUsersProfilesConnectionString)} is Required.");
            }


            var errors = sb.ToString();

            if(!string.IsNullOrEmpty(errors))
            {
                throw new InvalidOperationException(errors);
            }
        }
    }
}
