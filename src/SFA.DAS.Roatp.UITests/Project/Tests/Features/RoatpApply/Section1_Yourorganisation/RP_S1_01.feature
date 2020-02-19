Feature: RP_S1_01

@rps101
@roatp
@roatpapply
@roatps1
@regression
Scenario: RP_S1_01_Charity - Employer - Org-None of the above
    Given the provider initates an application as employer route charity
    Then the provider completes Introduction and what you'll need section for main and employer route
    And the provider completes Organisation Information section for charity
    And the provider completes Tell us who's in control section for charity
    And the provider completes Describe your organisation section as OrgTypeNoneOfTheAbove
    And the provider completes Experience and Accreditations section by selecting No to all
