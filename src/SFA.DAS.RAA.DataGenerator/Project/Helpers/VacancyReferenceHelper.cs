using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.RAA.DataGenerator
{
    public class VacancyReferenceHelper(PageInteractionHelper pageInteractionHelper, ObjectContext objectContext)
    {
        public void SetVacancyReference(By vacancyReferenceNumber)
        {
            var referenceNumber = pageInteractionHelper.GetText(vacancyReferenceNumber);

            objectContext.SetVacancyReference(RegexHelper.GetVacancyReference(referenceNumber));
        }
    }
}
