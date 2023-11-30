using System.Collections.Generic;
using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class EventPreviewPage : AanAdminBasePage
{
    private static By EventTag => By.CssSelector(".govuk-tag.app-tag");

    protected override string PageTitle => aanAdminDatahelper.EventTitle;

    public EventPreviewPage(ScenarioContext context, EventFormat eventFormat) : base(context, false)
    {
        MultipleVerifyPage(new List<Func<bool>> 
        {
            () => VerifyPage(),
            () => VerifyPage(EventTag, eventFormat.ToString())
        });
    }

    public CheckYourEventPage GoToCheckYourEventPage()
    {
        formCompletionHelper.ClickLinkByText("back to event page");

        return new CheckYourEventPage(context);
    }
}
