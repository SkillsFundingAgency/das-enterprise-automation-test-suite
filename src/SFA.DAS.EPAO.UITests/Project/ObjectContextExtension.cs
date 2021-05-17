using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EPAO.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string ApplyOrganisationName = "applyorganisationname";
        private const string ApplyStandardName = "applystandardname";
        private const string OrganisationIdentifier = "organisationidentifier";
        private const string LearnerULN = "learneruln";
        private const string LearnerFirstName = "learnerfirstname";
        private const string LearnerLastName = "learnerlastname";
        private const string LearnerStandardCode = "learnerstandardcode";
        #endregion

        public static void SetApplyOrganisationName(this ObjectContext objectContext, string value) => objectContext.Replace(ApplyOrganisationName, value);
        public static string GetApplyOrganisationName(this ObjectContext objectContext) => objectContext.Get(ApplyOrganisationName);

        public static void SetApplyStandardName(this ObjectContext objectContext, string value) => objectContext.Replace(ApplyStandardName, value);
        public static string GetApplyStandardName(this ObjectContext objectContext) => objectContext.Get(ApplyStandardName);

        public static void SetOrganisationIdentifier(this ObjectContext objectContext, string value) => objectContext.Replace(OrganisationIdentifier, value);
        public static string GetOrganisationIdentifier(this ObjectContext objectContext) => objectContext.Get(OrganisationIdentifier);

        public static void SetLearnerDetails(this ObjectContext objectContext, string uln, string standardcode, string firstname, string lastname)
        {
            objectContext.Replace(LearnerULN, uln);
            objectContext.Replace(LearnerStandardCode, standardcode);
            objectContext.Replace(LearnerFirstName, firstname);
            objectContext.Replace(LearnerLastName, lastname);
        }

        public static string GetLearnerULN(this ObjectContext objectContext) => objectContext.Get(LearnerULN);
        public static string GetLearnerFirstName(this ObjectContext objectContext) => objectContext.Get(LearnerFirstName);
        public static string GetLearnerLastName(this ObjectContext objectContext) => objectContext.Get(LearnerLastName);
        public static string GetLearnerStandardCode(this ObjectContext objectContext) => objectContext.Get(LearnerStandardCode);

    }
}
