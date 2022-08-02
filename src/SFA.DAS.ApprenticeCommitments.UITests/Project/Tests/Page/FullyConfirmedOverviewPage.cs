using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public partial class FullyConfirmedOverviewPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "My apprenticeship";
        private static By RolesSectionHeaderLink => By.XPath("//a[contains(text(),'Roles and responsibilities')]");
        private static By RolesSectionSubText => By.XPath("//a[contains(text(),'Roles and responsibilities')]/..//following-sibling::p");
        private static By HYAWDSectionHeaderLink => By.XPath("//a[contains(text(),'How your apprenticeship will be delivered')]");
        private static By HYAWDSectionSubText => By.XPath("//a[contains(text(),'How your apprenticeship will be delivered')]/..//following-sibling::p");

        public FullyConfirmedOverviewPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(TopBlueBannerHeader, $"Welcome, {objectContext.GetFirstName()} {objectContext.GetLastName()}"),
                () => VerifyPage(RolesSectionHeaderLink),
                () => VerifyPage(RolesSectionSubText, StatusHelper.FullyConfirmedOverviewRolesSubText),
                () => VerifyPage(HYAWDSectionHeaderLink),
                () => VerifyPage(HYAWDSectionSubText, StatusHelper.FullyConfirmedOverviewHYAWDSubText)
            });
        }

        public AlreadyConfirmedRolesAndResponsibilitiesPage GoToConfirmedRolesPage()
        {
            formCompletionHelper.Click(RolesSectionHeaderLink);
            return new AlreadyConfirmedRolesAndResponsibilitiesPage(context);
        }

        public AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage GoToConfirmedHowYourApprenticeshipWillBeDeliveredPage()
        {
            formCompletionHelper.Click(HYAWDSectionHeaderLink);
            return new AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage(context);
        }
    }
}
