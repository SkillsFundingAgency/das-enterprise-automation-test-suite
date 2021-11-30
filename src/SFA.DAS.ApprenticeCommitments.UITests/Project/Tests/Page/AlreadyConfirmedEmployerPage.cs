using SFA.DAS.ApprenticeCommitments.APITests.Project;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedEmployerPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Confirm your employer";
        private string GreenTickTextInfo => "You have confirmed this is your employer";

        public AlreadyConfirmedEmployerPage(ScenarioContext context) : base(context)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(),
                () => pageInteractionHelper.VerifyText(GreenTickText, GreenTickTextInfo),
                () => VerifyPage(ConfirmingEntityNamePageHeader, objectContext.GetEmployerName().Replace("  ", " ")),
                () => VerifyPage(EmployerHelpSectionLink),
                () => VerifyPage(EmployerHelpSectionText)
            });          
        }
    }
}
