Feature: EPAO_AS_WD_01

# Both the register and standard withdrawal scenarios are included in this feature because
# a register withdrawal will decline any standard withdrawals for the same organisation
# causing the logic which determins whether the current applications are shown to be
# subject to a race condition if the register and standard withdrawal scenarios are alloweed
# to run in parallel

@epao
@assessmentservice
@registerwithdrawal
@regression
@resetregisterwithdrawal
Scenario: EPAO_AS_RWD_01A - Register Withdrawl 
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   starts the journey to withdraw from the register
	When  completes the Register withdrawal notification questions
	Then  application is submitted for review
	And   the admin user logs in to approve the register withdrawal application
	And   the admin user returns to view withdrawal notifications table
	And   Verify the application is moved to Approved tab

@epao
@assessmentservice
@registerwithdrawal
@regression
@resetregisterwithdrawal
Scenario: EPAO_AS_RWD_01B - Register Withdrawl with feedback
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   starts the journey to withdraw from the register
	When  completes the Register withdrawal notification questions
	Then  application is submitted for review
	And   the admin user logs in and adds feedback to an application
	And   verify application has moved from new to feedback tab
	And   the withdrawal user returns to dashboard
	And   the withdrawal user reviews and ammends their application
	Given the admin user returns and reviews the ammended withdrawal notification
	Then  verify withdrawal from register approved and return to withdrawal applications
	Then  Verify the application is moved to Approved tab

@epao
@assessmentservice
@regression
@resetstandardwithdrawal
Scenario: EPAO_AS_SWD_01A - Standard Withdrawl 
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   starts the journey to withdraw a standard
	When  completes the standard withdrawal notification questions
	Then  application is submitted for review
	And   the admin user logs in to approve the standard withdrawal application

@epao
@assessmentservice
@regression
@resetstandardwithdrawal
Scenario: EPAO_AS_SWD_01B - Your Withdrawl status notifications check
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   starts the journey to withdraw a standard
	Then  the withdrawal user returns to dashboard
	And   user verifies the different statuses of the standard withdrawl application
	And   user verifies view links navigate to the appropriate corresponding page
