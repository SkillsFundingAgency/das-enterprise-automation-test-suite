@regression
@registration
@addnonlevyfunds
Feature: RE_AORN_05

Scenario: RE_AORN_05_Validate AORN route account lockup and using GG route to complete registration
	Given an User Account is created
	When the User is on the 'Add a PAYE Scheme' page
	Then choosing to enter AORN and PAYE details in the right format but non existing ones for 3 times displays 'Sorry Account disabled' Page
	And Employer is able to complete registration through GG route