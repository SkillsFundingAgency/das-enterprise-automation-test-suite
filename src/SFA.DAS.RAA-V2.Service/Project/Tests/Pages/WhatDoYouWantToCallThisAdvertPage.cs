using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class WhatDoYouWantToCallThisAdvertPage : BaseVacancyTitlePage
    {
        protected override string PageTitle => "What do you want to call this advert?";

        public WhatDoYouWantToCallThisAdvertPage(ScenarioContext context) : base(context) { }
    }
}
