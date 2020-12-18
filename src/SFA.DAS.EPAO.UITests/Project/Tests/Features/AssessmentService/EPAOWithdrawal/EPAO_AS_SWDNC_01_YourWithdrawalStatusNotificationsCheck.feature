Feature: EPAO_AS_SWDNC_01

@epao
@assessmentservice
@regression
@standardwithdrawal
Scenario: EPAO_AS_SWDNC_01 - Your Withdrawl status notifications check
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   user verifies the different statuses of the standard withdrawl application
	And   user verifies view links navigate to the appropriate corresponding page