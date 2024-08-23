Feature: AP_DO_09_OLTD_CoE

@postapprovals
@regression
@overlappingtrainingdaterequest
Scenario: AP_DO_09_OLTD_CoE Automatically stop the record after 2 weeks
	Given Employer and provider approve an apprentice
	When provider starts CoE journey which leads to an overlap 
	And provider decides to send stop request email from service for Change Of Employer Overlapping Training Dates
	And One week has passed
	Then send a reminder email to the old employer
	And old employer has not taken any action yet
	When One more week has passed	
	Then Automatically stop the record with stopDate = NewStartDate
	Then overlapping training date request is resolved in database with status 1 and resolutionType 3
