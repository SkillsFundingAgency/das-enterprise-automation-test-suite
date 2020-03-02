@raa-v1
@regression
Feature: RV1_FAAV_01

@raa-v1
@apprenticeshipvacancy
@regression
Scenario: RV1_FAAV_01 search for an existing apprenticeship vacancy
	Given the apprenticeship vacancy is Live in Recruit near 'CV1 2NJ'
	When an applicant is on the Find an Apprenticeship Page
	Then the apprenticeship can be found based on 'CV1 2WT','2 miles'
	And the apprenticeship can be found based on 'CV3 1DP','5 miles'
	And the apprenticeship can be found based on 'CV7 9HZ','10 miles'
	And the apprenticeship can be found based on 'EH4 3AY','England'