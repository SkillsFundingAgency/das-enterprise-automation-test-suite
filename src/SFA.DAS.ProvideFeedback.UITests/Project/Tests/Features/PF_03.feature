Feature: PF_03

@providefeedback
@regression
@cleardownemployerfeedbackresult
Scenario: Provide Feedback via Adhoc Journey
	Given the Employer logins into Employer Portal
	And completes the feedback journey for a training provider

@providefeedback
@regression
@cleardownemployerfeedbackresult
	Scenario: Provide Feedback via Email link
	Given the Employer logins into Employer Portal
	And completes the feedback journey for a training provider via survey code