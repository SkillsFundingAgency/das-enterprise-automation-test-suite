@raa-v1
@regression
Feature: RV1_FAAV_01

@apprenticeshipvacancy
Scenario: RV1_FAAV_01 search for an existing apprenticeship vacancy
	Given an apprenticeship is live in Recruit near 'CV3 5ER'
	When an applicant is on the Find an Apprenticeship Page
	Then the apprenticeship can be found based on 'CV1 3RX','2 miles'
	And the apprenticeship can be found based on 'CV5 9AD','5 miles'
	And the apprenticeship can be found based on 'CV7 8EQ','10 miles'
	And the apprenticeship can be found based on 'EH4 3AY','England'


