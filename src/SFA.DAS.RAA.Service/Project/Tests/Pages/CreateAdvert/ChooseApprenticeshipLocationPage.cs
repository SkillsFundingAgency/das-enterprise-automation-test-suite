using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class ChooseApprenticeshipLocationPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Where is this apprenticeship available?";
        private static string NationalLocationsSubHeading => "Add more information about where the apprentice will work";
        private static string MultipleLocationsSubHeading => "Add locations";

        private static By Postcode => By.CssSelector("#Postcode");

        private static By MenuItems => By.CssSelector(".ui-menu-item");
        private static By SingleLocationRadoButton => By.CssSelector(".govuk-radios__input");
        private static By DropDownAddressList => By.Id("SelectedLocation");
        private static By MultipleLocationsCheckboxes => By.CssSelector(".govuk-checkboxes__input");
        private static By NationalLocationTextBox => By.Id("AdditionalInformation");
        private static By NationalLocationsPageSubHeading => By.CssSelector(".govuk-heading-m label");
        private static By MultipleLocationsPageSubHeading => By.CssSelector(".govuk-heading-l");

        public CreateAnApprenticeshipAdvertOrVacancyPage ChooseAddressAndGoToCreateApprenticeshipPage(string locationType)
        {
            locationType = locationType.Trim().ToLower();

            switch (locationType)
            {
                case "national":
                    SelectRadioOptionByForAttribute("AcrossEngland");
                    Continue();

                    NationalLocationInformation();
                    break;

                case "multiple":
                    SelectRadioOptionByForAttribute("MoreThanOneLocation");
                    Continue();

                    SelectMultipleLocations();
                    break;

                case "employer":
                    SelectRadioOptionByForAttribute("OneLocation");
                    Continue();

                    formCompletionHelper.SelectRandomRadioOptionByLocator(SingleLocationRadoButton);
                    break;

                case "different":
                    DifferentLocation();
                    return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
            }

            Continue();

            //if (locationType != "national" && locationType != "multiple")
            //{
            //    formCompletionHelper.SelectRandomRadioOptionByLocator(SingleLocationRadoButton);
            //    Continue();
            //}

            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }

        private void SelectMultipleLocations()
        {
            var subHeadingText = pageInteractionHelper.GetText(MultipleLocationsPageSubHeading).Trim();
            Assert.AreEqual(MultipleLocationsSubHeading, subHeadingText);

            var detailsElements = pageInteractionHelper.FindElements(By.CssSelector("details.govuk-details")).ToList();

            if (detailsElements != null && detailsElements.Any())
            {
                foreach (var details in detailsElements)
                {
                    var summary = details.FindElement(By.CssSelector("summary.govuk-details__summary"));
                    if (summary == null)
                    {
                        throw new NullReferenceException("summary is null.");
                    }

                    var isOpen = details.GetAttribute("open");
                    if (string.IsNullOrEmpty(isOpen) || !isOpen.Equals("true", StringComparison.OrdinalIgnoreCase))
                    {
                        summary.Click();
                    }
                }
            }

            Random random = new Random();
            int numberOfLocations = random.Next(2, 11);

            var multipleLocationsCheckboxes = pageInteractionHelper.FindElements(MultipleLocationsCheckboxes).ToList();

            var selectedMultipleLocationsCheckboxes = multipleLocationsCheckboxes.OrderBy(x => random.Next()).Take(numberOfLocations);

            foreach (var checkbox in selectedMultipleLocationsCheckboxes)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }

            Continue();
        }

        private void NationalLocationInformation()
        {
            var subHeadingText = pageInteractionHelper.GetText(NationalLocationsPageSubHeading).Trim();
            Assert.AreEqual(NationalLocationsSubHeading, subHeadingText);

            formCompletionHelper.Click(NationalLocationTextBox);
            formCompletionHelper.EnterText(NationalLocationTextBox, RandomDataGenerator.GenerateRandomAlphabeticString(100));
        }

        public ImportantDatesPage ChooseAddress(bool isEmployerAddress)
        {
            if (isEmployerAddress) SelectRadioOptionByForAttribute("OtherLocation_1");
            else DifferentLocation();

            Continue();

            pageInteractionHelper.WaitforURLToChange("dates");

            return new ImportantDatesPage(context);
        }

        private void DifferentLocation()
        {
            SelectRadioOptionByForAttribute("OneLocation");
            Continue();
            
            formCompletionHelper.ClickLinkByText("Add a new location");
            formCompletionHelper.EnterText(Postcode, $"{RAADataHelper.EmployerAddress} ");
            Continue();

            formCompletionHelper.SelectRandomFromDropDownByLocator(DropDownAddressList);
            Continue();
            Continue();
        }
    }
}
