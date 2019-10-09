Feature: EmployeCreateCohort

A Non Levy employer can create a cohort 

@regression
Scenario: Non Levy Employer create cohort
	Given the Employer has created a reservation
	And Employer adds 2 apprentices to current cohort
	Then Employer is able to view saved cohort from Draft
	And Employer is able to edit all apprentices before approval
	And Employer is able to delete all apprentices before approval
	And Employer is able to delete the cohort before approval