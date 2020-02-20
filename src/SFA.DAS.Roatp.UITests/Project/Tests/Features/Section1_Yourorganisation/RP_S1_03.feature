Feature: RP_S1_03

@rps103
@roatp
@roatps1
@regression
Scenario: RP_S1_03_SoleTraderOrNonlimitedPartnership - Supporting - Org- A Group Training Association
	Given the provider initates an application as supporting route soletrader
	Then the provider completes Introduction and what you'll need content for supporting route
	And the provider completes Organisation Information section for charity
    And the provider completes Tell us who's in control section for sole trader
    And the provider completes Describe your organisation section as OrgTypeGTA
    And the provider completes Experience and Accreditations section by selecting Yes to Subcontractor training
