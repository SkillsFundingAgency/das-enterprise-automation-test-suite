Feature: RAA_P_E2E_03F

@raa
@raaprovider
@raae2e
@raaprovidere2e
@regression
Scenario: RAA_P_E2E_03F - Create foundation vacancy by entering data for Optional fields, Approve, Apply, make Application Unsuccessful and receive email notification
	Given the Provider creates a foundation vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a foundation vacancy in FAA
	Then Provider can make the application unsuccessful
	And the status of the Application is shown as 'unsuccessful' in FAA
	And the 'applicant' receives 'unsuccessful application' email notification