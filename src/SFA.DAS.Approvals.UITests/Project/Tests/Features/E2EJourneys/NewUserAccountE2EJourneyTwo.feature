Feature: NewUserAccountE2EJourneyTwo

@addpayedetails
@addlevyfunds
@e2escenarios
Scenario: NewE2E2 Create Employer send cohort to provider for review then provider approves then employer approves
	Given the User creates Employer account and sign an agreement
	When the Employer approves 2 cohort and sends to provider
	And the provider adds Ulns and approves the cohorts and sends to employer
	Then the Employer approves the cohorts