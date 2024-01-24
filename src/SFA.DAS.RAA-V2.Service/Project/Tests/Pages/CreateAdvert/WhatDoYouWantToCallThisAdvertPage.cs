using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class WhatDoYouWantToCallThisAdvertPage(ScenarioContext context) : BaseVacancyTitlePage(context)
    {
        protected override string PageTitle => isRaaV2Employer ? "What do you want to call this advert?" : "What do you want to call this vacancy?";
    }
}
