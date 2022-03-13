using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedApprenticeshipDetailsPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Confirm the details of your apprenticeship";
        private string GreenTickTextInfo => "You have confirmed these are the details of your apprenticeship";

        public AlreadyConfirmedApprenticeshipDetailsPage(ScenarioContext context) : base(context)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(),
                () => VerifyPage(GreenTickText, GreenTickTextInfo) 
            });
        }

        public new AlreadyConfirmedApprenticeshipDetailsPage ChangeMyAnswerAction()
        {
            base.ChangeMyAnswerAction();
            VerifyPage();
            return this;
        }
    }
}
