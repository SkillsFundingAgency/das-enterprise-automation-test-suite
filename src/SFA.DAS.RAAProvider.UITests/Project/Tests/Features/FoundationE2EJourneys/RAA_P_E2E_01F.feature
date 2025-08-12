Feature: RAA_P_E2E_01F

@raa
@regression
@faa
@raaprovider
Scenario: RAA_P_FAA_01F - Submit An Application And Withdraw Application for foundation vacancy
	Given the Provider creates a foundation vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a foundation vacancy in FAA
	Then the Applicant can withdraw the application
