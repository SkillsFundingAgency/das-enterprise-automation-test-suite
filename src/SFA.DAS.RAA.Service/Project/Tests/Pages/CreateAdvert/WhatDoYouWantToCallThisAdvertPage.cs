using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class WhatDoYouWantToCallThisAdvertPage(ScenarioContext context) : BaseVacancyTitlePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "What do you want to call this advert?" : "What do you want to call this vacancy?";
    }
}
