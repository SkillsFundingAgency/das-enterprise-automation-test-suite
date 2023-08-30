using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderDeleteStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;

        public ProviderDeleteStepsHelper(ScenarioContext context)
        {
            _context = context;
            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
        }

        public ProviderApproveApprenticeDetailsPage DeleteApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            var totalNoOfApprentices = _context.Get<ObjectContext>().GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                string flashMessage = providerApproveApprenticeDetailsPage
                                          .SelectEditApprentice(0)
                                          .DeleteApprentice()
                                          .ConfirmDeleteAndSubmit()
                                          .GetFlashMessage();

                Assert.IsTrue(flashMessage == "Apprentice record deleted", "validate 'Apprentice record deleted' flash message is displayed");
            }

            return providerApproveApprenticeDetailsPage;
        }

        public void DeleteCohort() => DeleteCohort(_providerCommonStepsHelper.CurrentCohortDetails());

        public void DeleteCohort(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage) => providerApproveApprenticeDetailsPage.SelectDeleteCohort().ConfirmDeleteAndSubmit();


    }
}