Feature: NewUserAccountE2EJourneyOne

@addpayedetails
@addlevyfunds
@e2escenarios
Scenario: NewE2E1 Create Employer send an approved cohort then provider approves the cohort
	Given the User creates Employer account and sign an agreement
	When the Employer approves 2 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts