Feature: RP_S1_10

@rps110
@roatp
@roatpapply
@roatps1
@regression
# Organisation Type is Higher Education Institute 
Scenario: RP_S1_10_Soletrader - Employer - Org HEI - Exempt from FHA
    Given the provider initates an application as employer route charity
    Then the provider completes Introduction and what you'll need section for main and employer route
	And the provider completes Organisation Information section for charity
    And the provider completes Tell us who's in control section for sole trader
    And the provider completes Describe your organisation section as OrgTypeAEI Employer Route
    And the provider completes Experience and Accreditations section by selecting GradeTypeRequiresImprovement
	And the provider verifies Financial Section Status as not required
	