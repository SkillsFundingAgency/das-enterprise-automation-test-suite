using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.FAT_V2.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string TrainingCourseNameKey = "trainingcoursenamekey";
        private const string ProviderNameKey = "providernamekey";
        #endregion

        public static void SetTrainingCourseName(this ObjectContext objectContext, string trainingName) => objectContext.Replace(TrainingCourseNameKey, trainingName);
        public static string GetTrainingCourseName(this ObjectContext objectContext) => objectContext.Get(TrainingCourseNameKey);
        public static void SetProviderName(this ObjectContext objectContext, string providerName) => objectContext.Replace(ProviderNameKey, providerName);
        public static string GetProviderName(this ObjectContext objectContext) => objectContext.Get(ProviderNameKey);
    }
}
