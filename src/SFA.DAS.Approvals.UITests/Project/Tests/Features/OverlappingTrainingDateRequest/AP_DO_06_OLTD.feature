Feature: AP_DO_06_OLTD_Employer_resolves_OLTD_request_by_updating_Stopped_date

@approvals
@regression
@overlappingtrainingdaterequest
Scenario: AP_DO_06_OLTD_Employer resolves OLTD request by updating Stopped date
	Given Employer and provider approve an apprentice
	And Employer selects to stop the active apprentice
	When provider goes to its home page
	And provider creates a draft apprentice which has an overlap
	And provider decides to send stop request email from service    
	Then information is saved in the cohort
	When Employer selects to reject the overlapping training date request
	Then overlapping training date request is resolved in database with status 2 and resolutionType 8
	When provider goes to its home page
	And provider edits draft apprenitce start date which has an overlap
	And provider decides to send stop request email from service
	And Employer decides to update the stopped date
	And overlapping training date request banner is not displayed
	Then overlapping training date request is resolved in database with status 1 and resolutionType 2
	