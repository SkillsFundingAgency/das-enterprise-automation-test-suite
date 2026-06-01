using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ConfirmProviderDetailsHelper(ScenarioContext context)
    {
        public StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect(bool isTransferReceiverEmployer, Func<AddOrSendLearnerRequestPage, ChooseYourMainTrainingProviderPage> func)
        {
            var addAnApprenticePage = new LearnerHomePage(context).ClickAddALearnerLink();

            ChooseYourMainTrainingProviderPage addTrainingProviderDetailsPage;
            /*if (isTransferReceiverEmployer)
            {
                addTrainingProviderDetailsPage = addAnApprenticePage.StartNowToSelectFunding().SelectFundingType(FundingType.CurrentLevyFunds);
            }
            else
            {
                addTrainingProviderDetailsPage = func is null ? addAnApprenticePage.StartNowToAddTrainingProvider() : func(addAnApprenticePage);
            }*/

            addTrainingProviderDetailsPage = func is null ? addAnApprenticePage.StartNowToAddTrainingProvider() : func(addAnApprenticePage);

            return addTrainingProviderDetailsPage.SubmitValidUkprn().ConfirmProviderDetailsAreCorrect();
        }

    }
}