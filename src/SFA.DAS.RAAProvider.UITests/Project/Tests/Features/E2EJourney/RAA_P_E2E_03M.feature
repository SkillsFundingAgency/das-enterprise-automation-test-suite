Feature: RAA_P_E2E_03M

@raa
@raaprovider
@raae2e
@raaprovidere2e
@regression
Scenario: RAA_P_E2E_03M - Create vacancy by entering data for Optional fields, Approve, Apply and make Multiple Applications Unsuccessful
	Given the Provider creates a vacancy with "multiple" work locations by entering all the Optional fields and "second" additional questions
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a multiple locations Vacancy in FAA with "second" additional questions
	Then Provider can make the application unsuccessful
