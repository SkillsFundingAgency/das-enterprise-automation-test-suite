using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;
using System;

namespace SFA.DAS.RoatpAdmin.Service.Project.Helpers;

public abstract class RoatpAdminStepsHelper(ScenarioContext context)
{
    protected readonly ScenarioContext context = context;

    public RoatpAdminMiniHomePage InitatesAnApplication(string providerType)
    {
        // Step 1: initial pages
        var dashboard = GoToRoatpAdminHomePage()
            .GoTOMiniDashBoardPage()
            .AddANewTrainingProvider()
            .EnterUkprn()
            .ConfirmOrganisationsDetails();

        // Step 2: Submit provider type 
        dashboard.SubmitProviderType(providerType);

        // Step 3: Branch by provider type
        if (providerType.Equals("Supporting provider", StringComparison.OrdinalIgnoreCase))
        {
            // Supporting provider skips apprenticeship, goes directly to organisation type
            var orgPage = new TypeOrganisationsPage(context); // <-- actual page class
            return orgPage
                .SubmitOrganisationType()
                .ConfirmOrganisationsDetails()
                .VerifyNewProviderHasBeenAdded()
                .ReturnToDahsboard();
        }
        else
        {
            // Main / Employer provider: go through apprenticeship flow
            var offerPage = new OfferApprenticeshipPage(context); // <-- actual page class
            offerPage
                .ConfirmOfferApprenticeships()
                .ConfirmOfferApprenticeshipsUnits_NO_AddJourney();

            // Now move explicitly to organisation type page
            var orgPage = new TypeOrganisationsPage(context); // <-- actual page class
            return orgPage
                .SubmitOrganisationType()
                .ConfirmOrganisationsDetails()
                .VerifyNewProviderHasBeenAdded()
                .ReturnToDahsboard();
        }
    }


    public RoatpAdminHomePage GoToRoatpAdminHomePage()
    {
        new DfeAdminLoginStepsHelper(context).NavigateAndLoginToASAdmin();

        return new RoatpAdminHomePage(context);
    }
}
