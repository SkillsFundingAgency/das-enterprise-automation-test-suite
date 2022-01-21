using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AccountHomePage : HomePage

    {
        protected override string PageTitle => objectContext.GetOrganisationName();
        public AccountHomePage(ScenarioContext context) : base(context) { }



        public MyTransferPledgesPage ClickTask()
        {
            formCompletionHelper.ClickLinkByText("View applications");
            return new MyTransferPledgesPage(context);
        }
    }



}

