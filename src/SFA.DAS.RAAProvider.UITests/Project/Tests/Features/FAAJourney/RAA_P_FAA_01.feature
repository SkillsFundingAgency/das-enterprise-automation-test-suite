Feature: RAA_P_FAA_01

@raa
@regression
@faa
@raaprovider
Scenario: RAA_P_FAA_01 - Submit An Application And Withdraw Application
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then the Applicant can withdraw the application
	And Provider can see the withdrawn application
	And the 'applicant' receives 'withdrawn application' email notification