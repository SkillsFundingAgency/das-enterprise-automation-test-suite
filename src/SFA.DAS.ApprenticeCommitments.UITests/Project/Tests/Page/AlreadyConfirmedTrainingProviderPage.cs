using SFA.DAS.ApprenticeCommitments.APITests.Project;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedTrainingProviderPage : ConfirmYourDetailsBasePage
    {
        protected override string PageTitle => "Confirm your training provider";
        private string GreenTickTextInfo => "You have confirmed this is your training provider";

        public AlreadyConfirmedTrainingProviderPage(ScenarioContext context) : base(context)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(),
                () => pageInteractionHelper.VerifyText(GreenTickText, GreenTickTextInfo),
                () => VerifyPage(ConfirmingEntityNamePageHeader, objectContext.GetProviderName()),
                () => VerifyPage(ProviderHelpSectionLink),
                () => VerifyPage(ProviderHelpSectionText)
            });
        }

        public new AlreadyConfirmedTrainingProviderPage ChangeMyAnswerAction()
        {
            base.ChangeMyAnswerAction();
            VerifyPage();
            return this;
        }
    }
}
