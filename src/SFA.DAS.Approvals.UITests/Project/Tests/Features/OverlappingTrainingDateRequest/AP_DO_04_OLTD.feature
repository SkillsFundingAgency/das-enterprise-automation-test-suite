@approvals
Feature: AP_DO_04_OLTD_user_decides_to_send_stop_request_email_from_service
@regression
@overlappingtrainingdaterequest

Scenario: AP_DO_04_OLTD User decides to send stop request email from service
	Given Employer and provider approve an apprentice
	When provider creates a draft apprentice which has an overlap
	And provider selects all the information is correct
	And provider decides to send stop request email from service
	And Employer is notfied to confirm changes
    Then Vaidate information is stored in database
