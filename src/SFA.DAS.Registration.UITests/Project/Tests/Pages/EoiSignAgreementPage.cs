using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EoiSignAgreementPage : SignAgreementPage
    {
        protected override string PageTitle => "Memorandum of Understanding";

        public EoiSignAgreementPage(ScenarioContext context) : base(context)
        {

        }
    }
}