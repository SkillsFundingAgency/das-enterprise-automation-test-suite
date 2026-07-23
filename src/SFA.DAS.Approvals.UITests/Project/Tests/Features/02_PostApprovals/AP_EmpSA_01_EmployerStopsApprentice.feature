Feature: AP_EmpSA_01_EmployerStopsApprentice
As an employer I can pause, resume and stop an apprentice

@postapprovals
@regression
@startdateisfewmonthsbeforenow
Scenario: AP_EmpSA_01 Employer Pauses Resumes and Stop an apprentice
	Given the Employer has approved apprentice	
	Then Employer is able to Pause/Freeze payments for that apprentice
	Then Employer is able to UnPause/UnFreeze payments for that apprentice
	Then Employer is able to Stop the apprentice
	And Employer can edit stop date to learner start date