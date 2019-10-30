Feature: EmployerStopsApprentice
As an employer I can pause, resume and stop an apprentice

@approvals
@regression
@liveapprentice
@currentacademicyearstartdate
Scenario: Employer Pauses Resumes and Stop an apprentice
	Given the Employer has approved apprentice
	Then Employer is able to Pause the apprentice
	And Employer is able to Resume the apprentice
	And Employer is able to Stop the apprentice
	And Employer can edit stop date to learner start date