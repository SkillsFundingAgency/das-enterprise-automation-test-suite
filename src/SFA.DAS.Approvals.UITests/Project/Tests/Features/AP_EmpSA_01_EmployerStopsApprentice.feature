Feature: AP_EmpSA_01_EmployerStopsApprentice
As an employer I can pause, resume and stop an apprentice

@approvals
@regression
@onemonthbeforecurrentacademicyearstartdate
Scenario: AP_EmpSA_01 Employer Pauses Resumes and Stop an apprentice
	Given the Employer has approved apprentice
	Then Employer is able to Pause the apprentice
	And Employer is able to Resume the apprentice
	And Employer is able to Stop the apprentice
	And Employer can edit stop date to learner start date