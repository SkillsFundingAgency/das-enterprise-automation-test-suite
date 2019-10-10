Feature: EmployeCreateCohort

A Non Levy employer can create a cohort 

@regression
Scenario: Non Levy Employer create cohort
	Given the Employer has created a reservation
	When Employer adds the full apprentice
	Then The apprenticeship record is created using the reservation