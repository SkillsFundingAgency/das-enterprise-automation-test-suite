@approvals
Feature: AP_DO_03_OLTD_user_decides_to_contact_the_employer_themselves

@regression
@overlappingtrainingdaterequest

Scenario: AP_DO_03_OLTD User decides to contact the employer themselves
	Given Employer and provider approve an apprentice
	When provider creates a draft apprentice which has an overlap
	And provider selects all the information is correct
	And provider selects to contact the employer themselves
	And Review apprentice request page is displayed
    Then Vaidate information is not stored in database
