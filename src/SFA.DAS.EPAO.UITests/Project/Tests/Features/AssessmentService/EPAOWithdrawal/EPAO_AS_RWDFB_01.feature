Feature: EPAO_AS_RWDFB_01
@epao
@assessmentservice
@registerwithdrawal
@regression
Scenario: EPAO_AS_RWDFB_01 - Register Withdrawl with feedback
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   starts the journey to withdraw from the register
	When  completes the Register withdrawal notification questions
	Then  application is submitted for review
	And   the admin user logs in and adds feedback to an application
	#And   the application is moved from the new to feedback tab
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   the withdrawal user reviews and ammends their application
	And   the admin users logs in and reviews the ammended withdrawal notification
	Then  verify withdrawal from register approved and return to withdrawal applications
	Then  Verify the application is moved to Approved tab