Feature: AP_DO_07_OLTD_Employer_resolves_OLTD_request_by_updating_End_date_Of_Completed_Record

@postapprovals
@regression
@overlappingtrainingdaterequest
Scenario: AP_DO_07_OLTD_Employer resolves OLTD request by updating End date of completed record
	Given Employer and provider approve an apprentice
	And Completed event is received for the apprentice
	When provider creates a draft apprentice which has an overlap
	And provider decides to send stop request email from service    
	Then information is saved in the cohort
	When Employer decides to update end date
	And overlapping training date request banner is not displayed when training date is changed
	Then overlapping training date request is resolved in database with status 1 and resolutionType 7	