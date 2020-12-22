Feature: EPAO_AS_RWD_01
@epao
@assessmentservice
@registerwithdrawal
@regression
Scenario: EPAO_AS_RWD_01 - Register Withdrawl 
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   starts the journey to withdraw from the register
	When  completes the Register withdrawal notification questions
	Then  application is submitted for review
	And   the admin user logs in to approve the register withdrawal application
	And   the admin user returns to view withdrawal notifications table
	And   Verify the application is moved to Approved tab