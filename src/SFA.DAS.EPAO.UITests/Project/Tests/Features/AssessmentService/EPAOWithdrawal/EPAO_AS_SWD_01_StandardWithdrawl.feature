Feature: EPAO_AS_SWD_01

@epao
@assessmentservice
@regression
@deletestandardwithdrawal
Scenario: EPAO_AS_SWD_01A - Standard Withdrawl 
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   starts the journey to withdraw a standard
	When  completes the standard withdrawal notification questions
	Then  application is submitted for review
	And   the admin user logs in to approve the standard withdrawal application


@epao
@assessmentservice
@regression
@deletestandardwithdrawal
Scenario: EPAO_AS_SWD_01B - Your Withdrawl status notifications check
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   starts the journey to withdraw a standard
	Then  the withdrawal user returns to dashboard
	And   user verifies the different statuses of the standard withdrawl application
	And   user verifies view links navigate to the appropriate corresponding page