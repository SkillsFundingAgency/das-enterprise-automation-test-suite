Feature: EPAO_AS_WD_Accessibility02

# Both the register and standard withdrawal scenarios are included in this feature because
# a register withdrawal will decline any standard withdrawals for the same organisation
# causing the logic which determines whether the current applications are shown to be
# subject to a race condition if the register and standard withdrawal scenarios are allowed
# to run in parallel

@accessibility
@epao
@regression
@assessmentservice
@registerwithdrawal
@resetregisterwithdrawal
Scenario: EPAO_AS_RWD_Accessibility02A - Register Withdrawal 
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   starts the journey to withdraw from the register
	When  completes the Register withdrawal notification questions
	Then  application is submitted for review
	And   the admin user logs in to approve the register withdrawal application
	And   the admin user returns to view withdrawal notifications table
	And   Verify the application is moved to Approved tab

@accessibility
@epao
@regression
@assessmentservice
@resetstandardwithdrawal
Scenario: EPAO_AS_SWD_Accessibility02C - Standard Withdrawal 
	Given the EPAO Withdrawal User is logged into Assessment Service Application
	And   starts the journey to withdraw a standard
	When  completes the standard withdrawal notification questions
	Then  application is submitted for review
	And   the admin user logs in to approve the standard withdrawal application