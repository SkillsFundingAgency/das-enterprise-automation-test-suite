
namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.Locations
{
    public class WhereDoYouWantToApplyForPage(ScenarioContext context): FAABasePage(context)
    {
        protected override string PageTitle => "Where do you want to apply for?";
        protected override By SubmitSectionButton => By.CssSelector("button.govuk-button[type='submit']");
        public WhereYouWantToApplyForPage SelectLocationsAndContinue()
        {
            SelectFirstTwoLocations();
            Continue();
            return new(context);
        }

        protected void SelectFirstTwoLocations()
        {
            var checkboxes = pageInteractionHelper.FindElements(By.CssSelector("#SelectedAddressIds input[type='checkbox']"));
            int count = 0;
            foreach (var checkbox in checkboxes)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
                count++;
                if (count == 2) break;
            }
        }
    }
}
