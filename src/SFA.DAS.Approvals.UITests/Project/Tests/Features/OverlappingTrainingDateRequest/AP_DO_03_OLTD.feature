Feature: AP_DO_03_OLTD_user_decides_to_contact_the_employer_themselves

@approvals
@regression
@overlappingtrainingdaterequest
Scenario: AP_DO_03_OLTD User decides to contact the employer themselves
	Given Employer and provider approve an apprentice
	When provider creates a draft apprentice which has an overlap
	And provider selects to contact the employer themselves
	Then information is saved in the cohort
	When provider selects to edit the price
	And provider selects to add apprentice details later
    Then price update information is not stored in the cohort
