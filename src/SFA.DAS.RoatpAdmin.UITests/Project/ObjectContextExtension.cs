using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.RoatpAdmin.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string ClarificationJourney = "clarificationjourney";
        #endregion

        internal static void SetClarificationJourney(this ObjectContext objectContext) => objectContext.Set(ClarificationJourney, true);

        internal static bool IsClarificationJourney(this ObjectContext objectContext) => objectContext.KeyExists<bool>(ClarificationJourney);
    }
}
