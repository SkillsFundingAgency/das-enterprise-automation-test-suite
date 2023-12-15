using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ConfirmProviderDetailsHelper(ScenarioContext context)
    {
        public StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect(bool isTransferReceiverEmployer, Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> func)
        {
            var addAnApprenticePage = new ApprenticesHomePage(context).AddAnApprentice();

            AddTrainingProviderDetailsPage addTrainingProviderDetailsPage;
            if (isTransferReceiverEmployer)
            {
                addTrainingProviderDetailsPage = addAnApprenticePage.StartNowToCreateApprenticeViaTransfersFunds().SelectNoIDontWantToUseTransferFunds();
            }
            else
            {
                addTrainingProviderDetailsPage = func is null ? addAnApprenticePage.StartNowToAddTrainingProvider() : func(addAnApprenticePage);
            }

            return addTrainingProviderDetailsPage.SubmitValidUkprn().ConfirmProviderDetailsAreCorrect();
        }
    }
}