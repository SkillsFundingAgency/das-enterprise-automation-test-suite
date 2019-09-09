namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public abstract class RandomCourseHelper
    {
        public int RandomNumber { get; protected set; }

        private string StandardCourseOption => "34";

        private string FrameworkCourseOption => "454-3-1";

        protected string RandomCourse()
        {
            return (RandomNumber % 2 == 0) ? StandardCourseOption : FrameworkCourseOption;
        }
    }
}
