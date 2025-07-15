Feature: RAA_P_E2E_01F

@raa
@regression
@faa
@raaprovider
Scenario: RAA_P_FAA_01 - Submit An Application And Withdraw Application
	Given the Provider creates a foundation vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a foundation vacancy in FAA
	Then the Applicant can withdraw the application
