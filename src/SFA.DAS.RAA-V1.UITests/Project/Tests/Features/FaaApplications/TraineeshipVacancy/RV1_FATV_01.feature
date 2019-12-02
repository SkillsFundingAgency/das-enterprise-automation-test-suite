@raa-v1
@regression
Feature: RV1_FATV_01

Scenario: RV1_FATV_01 search for an existing traineeship vacancy
	#Given a traineeship is live in Recruit near 'CV3 5ER'
	When an applicant is on the Find an Traineeship Page
	And searched based on 'CV3 5ER'
	Then the traineeship can be found based on 'CV1 3RX','2 miles'
	And the traineeship can be found based on 'CV5 9AD','5 miles'
	And the traineeship can be found based on 'CV7 8EQ','10 miles'
	