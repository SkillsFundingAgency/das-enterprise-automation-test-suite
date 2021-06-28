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
        private const string LearnerStandardName = "learnerstandardname";
        private const string IsActiveStandard = "IsActiveStandard";
        private const string HasMultipleVersions = "HasMultipleVersions";
        private const string WithOptions = "WithOptions";
        private const string HasMultiStandards = "HasMultiStandards";
        #endregion

        public static void SetApplyOrganisationName(this ObjectContext objectContext, string value) => objectContext.Replace(ApplyOrganisationName, value);
        public static string GetApplyOrganisationName(this ObjectContext objectContext) => objectContext.Get(ApplyOrganisationName);

        public static void SetApplyStandardName(this ObjectContext objectContext, string value) => objectContext.Replace(ApplyStandardName, value);
        public static string GetApplyStandardName(this ObjectContext objectContext) => objectContext.Get(ApplyStandardName);

        public static void SetOrganisationIdentifier(this ObjectContext objectContext, string value) => objectContext.Replace(OrganisationIdentifier, value);
        public static string GetOrganisationIdentifier(this ObjectContext objectContext) => objectContext.Get(OrganisationIdentifier);

        public static void SetLearnerCriteria(this ObjectContext objectContext, bool isActiveStandard, bool hasMultipleVersions, bool withOptions, bool hasMultiStandards)
        {
            objectContext.Set(IsActiveStandard, isActiveStandard);
            objectContext.Set(HasMultipleVersions, hasMultipleVersions);
            objectContext.Set(WithOptions, withOptions);
            objectContext.Set(HasMultiStandards, hasMultiStandards);
        }

        public static void SetLearnerDetails(this ObjectContext objectContext, string uln, string standardcode, string standardname, string firstname, string lastname)
        {
            objectContext.Replace(LearnerULN, uln);
            objectContext.Replace(LearnerStandardCode, standardcode);
            objectContext.Replace(LearnerStandardName, standardname);
            objectContext.Replace(LearnerFirstName, firstname);
            objectContext.Replace(LearnerLastName, lastname);
        }

        public static string GetLearnerULN(this ObjectContext objectContext) => objectContext.Get(LearnerULN);
        public static string GetLearnerFirstName(this ObjectContext objectContext) => objectContext.Get(LearnerFirstName);
        public static string GetLearnerLastName(this ObjectContext objectContext) => objectContext.Get(LearnerLastName);
        public static string GetLearnerStandardCode(this ObjectContext objectContext) => objectContext.Get(LearnerStandardCode);
        public static string GetLearnerStandardName(this ObjectContext objectContext) => objectContext.Get(LearnerStandardName);

    }
}
