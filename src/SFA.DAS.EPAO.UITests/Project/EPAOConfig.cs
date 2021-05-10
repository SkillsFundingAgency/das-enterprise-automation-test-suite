namespace SFA.DAS.EPAO.UITests.Project
{
    public class EPAOConfig
    {
        public static string AssessmentOpportunityFinderPath => "/find-an-assessment-opportunity";
        public string ApprenticeNameWithSingleStandard { get; set; }
        public string ApprenticeUlnWithSingleStandard { get; set; }
        public string ApprenticeNameDeleteWithAStandardHavingLearningOption { get; set; }
        public string ApprenticeUlnDeleteWithAStandardHavingLearningOption { get; set; }
        public string ApprenticeNameWithMultipleStandards { get; set; }
        public string ApprenticeUlnWithMultipleStandards { get; set; }
        public string ApprenticeNameWithAStandardHavingLearningOption { get; set; }
        public string ApprenticeUlnWithAStandardHavingLearningOption { get; set; }
        public string PrivatelyFundedApprenticeLastName { get; set; }
        public string PrivatelyFundedApprenticeUln { get; set; }
        public string PrivatelyFundedApprenticeGivenName { get; set; }
        public string PrivatelyFundedUkprn { get; set; }
        public string AlreadyAssessedApprenticeName { get; set; }
        public string AlreadyAssessedApprenticeUln { get; set; }
        public string EPAOStageTwoStandardCancelUser { get; set; }
        public string ApprenticeNameWithAStandardHavingVersionsAndLearningOptions { get; set; }
        public string ApprenticeUlnWithAStandardHavingVersionsAndLearningOptions { get; set; }
    }
}