using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentsApiDataHelper
    {
        public string Email => $"ApprenticeAccount{DateTime.Now:ddMMMyy_HHmmss_fffff}@test.com";
    }
}