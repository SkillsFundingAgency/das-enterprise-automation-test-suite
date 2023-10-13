namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class NetworkDirectoryPage : SearchEventsBasePage
{
    protected override string PageTitle => "Network directory";

    public NetworkDirectoryPage(ScenarioContext context) : base(context) => VerifyPage();

    public new NetworkDirectoryPage FilterEventByEventRegion_London()
    {
        base.FilterEventByEventRegion_London();
        return this;
    }
    public new NetworkDirectoryPage FilterByRole_Apprentice()
    {
        base.FilterByRole_Apprentice();
        return this;
    }
    public new NetworkDirectoryPage FilterByRole_Employer()
    {
        base.FilterByRole_Employer();
        return this;
    }
    public new NetworkDirectoryPage FilterByRole_Regionalchair()
    {
        base.FilterByRole_Regionalchair();
        return this;
    }

    public new NetworkDirectoryPage ClearAllFilters()
    {
        base.ClearAllFilters();
        return this;
    }

    public new NetworkDirectoryPage VerifyEventRegion_London_Filter()
    {
        base.VerifyEventRegion_London_Filter();
        return this;
    }
    public new NetworkDirectoryPage VerifyRole_Apprentice_Filter()
    {
        base.VerifyRole_Apprentice_Filter();
        return this;
    }
    public new NetworkDirectoryPage VerifyRole_Employer_Filter()
    {
        base.VerifyRole_Employer_Filter();
        return this;
    }
    public new NetworkDirectoryPage VerifyRole_Regionalchair_Filter()
    {
        base.VerifyRole_Regionalchair_Filter();
        return this;
    }
}