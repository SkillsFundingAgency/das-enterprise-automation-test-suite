Feature: RAT2_P_E2E_02

@rat-p
@regression
Scenario: RAT2_P_E2E_02 - Create vacancy by entering data for Optional fields, Approve, Apply and make Application Unsuccessful
	Given the Provider creates a traineeship vacancy by entering all the Optional fields
	And the Reviewer Approves the vacancy
	When the Applicant can apply for the Vacancy in FAT
	Then Provider can make the application unsuccessful
	And the status of the Application is shown as 'unsuccessful' in FAA
