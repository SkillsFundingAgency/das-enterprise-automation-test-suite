Feature: RP_S1_01


@rps101
@roatp
@regression
@ignore
Scenario: RP_S1_01_Charity - Employer - Org-None of the above
	Given the provider initates an application as employer route charity
	Then the provider completes Introduction and what you'll need sub section for main and employer route
    And the provider completes Organisation Information sub section for charity
    And the provider completes Tell us who's in control sub section for charity
    And the provider completes Describe your organisation sub section as OrgTypeNoneOfTheAbove
    And the provider completes Experience and Accreditations section by selecting No to all

