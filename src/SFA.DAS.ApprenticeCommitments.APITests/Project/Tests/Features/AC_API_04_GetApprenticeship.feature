Feature: GetApprenticeshipRecord

@api
@apprenticecommitmentsapi
@outerapi
@regression
@deleteuser
Scenario: AC_API_04_Get apprenticeship record
	Given an apprentice has created an account
	Then the apprenticeship record can be fetched