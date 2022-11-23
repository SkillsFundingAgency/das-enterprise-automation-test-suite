Feature: AP_DO_05_OLTD_Employer_resolves_OLTD_request_by_Stopping_a_LIVE_record

@approvals
@regression
@overlappingtrainingdaterequest
Scenario: AP_DO_05_OLTD_Employer resolves OLTD request by Stopping a LIVE record
	Given Employer and provider approve an apprentice
	When provider creates a draft apprentice which has an overlap
	And provider decides to send stop request email from service    
	Then information is saved in the cohort
	When provider selects to edit the draft apprenticeship 
	And provider deletes start and end date from Draft cohort
	Then overlapping training date request is resolved in database with status 1 and resolutionType 4
	When provider updates the draft apprentice which creates an overlap
	And provider decides to send stop request email from service 
	Then information is saved in the cohort
	When Employer selects to stop the active apprentice
	And overlapping training date request banner is not displayed
	Then overlapping training date request is resolved in database with status 1 and resolutionType 3
