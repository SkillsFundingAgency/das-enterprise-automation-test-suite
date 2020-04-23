using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.FAT.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string TrainingCourseNameKey = "trainingcoursenamekey";
        #endregion

        internal static void SetTrainingCourseName(this ObjectContext objectContext, string trainingName) => objectContext.Replace(TrainingCourseNameKey, trainingName);
        public static string GetTrainingCourseName(this ObjectContext objectContext) => objectContext.Get(TrainingCourseNameKey);
    }
}
