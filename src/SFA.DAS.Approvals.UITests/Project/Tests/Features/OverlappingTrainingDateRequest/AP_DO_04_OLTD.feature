@approvals
Feature: AP_DO_04_OLTD_user_decides_to_send_stop_request_email_from_service


@regression
@overlappingtrainingdaterequest
Scenario: AP_DO_04_OLTD User decides to send stop request email from service
	Given Employer and provider approve an apprentice
	When provider creates a draft apprentice which has an overlap
	And provider decides to send stop request email from service    
	Then information is saved in the cohort
	When Employer selects to edit the active apprentice
	Then overlapping training date request banner is displayed
	And the apprenticeship record is locked for edit
