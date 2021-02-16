using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentsDataHelper
    {
        public string Email => $"CreateApprenticeship{DateTime.Now:ddMMMyyyy_HHmmss}@test.com";
    }
}