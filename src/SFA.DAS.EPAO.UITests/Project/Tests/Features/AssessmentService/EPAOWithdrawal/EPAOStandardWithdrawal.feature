Feature: EPAO_AS_SWD_01

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_SWD_01 - Standard Withdrawl 
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   starts the journey to withdraw a standard
	When  completes the standard withdrawal notification questions
	Then  application is submitted for review
	