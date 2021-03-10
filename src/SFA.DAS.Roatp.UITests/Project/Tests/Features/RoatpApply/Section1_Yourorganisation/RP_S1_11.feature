Feature: RP_S1_11

@rps111
@roatp
@roatpapply
@roatps1
@regression
# Organisation Type is An Rail Franchise And Insufficent progress in monitoring visits
Scenario: RP_S1_11_Soletrader - Employer - Org Rail Franchise - Exempt from FHA
    Given the provider initates an application as employer route charity
    Then the provider completes Introduction and what you'll need section for main and employer route
	And the provider completes Organisation Information section for charity
    And the provider completes Tell us who's in control section for sole trader
	And the provider completes Describe your organisation section as OrgTYpe Rail franchise
	And the provider completes Experience and Accreditations section by selecting Yes had monitoring visit for apprenticeships
	And the provider verifies Financial Section Status as not required
