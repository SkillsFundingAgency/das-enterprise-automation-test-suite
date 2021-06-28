using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.PayeCreation.Tests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string NoOfPayeRequested = "****NoOfPayeRequested****";
        #endregion

        public static void SetNoOfPayeRequested(this ObjectContext objectContext, int value) => objectContext.Set(NoOfPayeRequested, value);
    }
}