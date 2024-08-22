Feature: AP_DO_08_OLTD_Automatically_stop_the_record_after_2_weeks

@postapprovals
@regression
@overlappingtrainingdaterequest
Scenario: AP_DO_08_OLTD_Automatically stop the record after 2 weeks	
	Given Employer and provider approve an apprentice
	When provider creates a draft apprentice which has an overlap
	And provider decides to send stop request email from service
	And One week has passed
	Then send a reminder email to the old employer
	And old employer has not taken any action yet
	When One more week has passed
	Then Automatically stop the record with stopDate = NewStartDate
	Then overlapping training date request is resolved in database with status 1 and resolutionType 3
