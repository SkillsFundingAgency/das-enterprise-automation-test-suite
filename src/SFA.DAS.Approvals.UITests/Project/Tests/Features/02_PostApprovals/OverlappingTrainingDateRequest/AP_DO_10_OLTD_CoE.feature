Feature: AP_DO_10_OLTD_CoE


@postapprovals
@regression
@overlappingtrainingdaterequest
Scenario: AP_DO_10_OLTD_CoE raise zendesk ticket after 2 weeks
	Given Employer and provider approve an apprentice
	And Employer selects to stop the active apprentice
	When provider starts CoE journey which leads to an overlap for stopped apprenticeship
	And provider decides to send stop request email from service for Change Of Employer Overlapping Training Dates
	And One week has passed
	Then send a reminder email to the old employer
	And old employer has not taken any action yet
	When One more week has passed
	Then System automatically raises a ZenDesk ticket
	Then check that the Overlapping Training Date Request is NOT resolved