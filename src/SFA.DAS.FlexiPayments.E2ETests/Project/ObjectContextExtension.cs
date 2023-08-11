using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FlexiPayments.E2ETests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string ULNKeyInformation = "ulnkeyinformation";
        #endregion

        internal static void SetTestDataList(this ObjectContext objectContext)
        {
            objectContext.SetULNKeyInformations();
        }

        private static void SetULNKeyInformations(this ObjectContext objectContext) => objectContext.Set(ULNKeyInformation, new FrameworkList<(int key, string uln)>());

        internal static void SetULNKeyInformation(this ObjectContext objectContext, (int key, string uln) value) => objectContext.GetULNKeyInformations().Add(value);

        internal static FrameworkList<(int key, string uln)> GetULNKeyInformations(this ObjectContext objectContext) => objectContext.Get<FrameworkList<(int key, string uln)>>(ULNKeyInformation);
    }
}
