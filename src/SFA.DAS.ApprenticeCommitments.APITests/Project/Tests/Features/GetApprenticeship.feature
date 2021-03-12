Feature: GetApprenticeshipRecord


@api
@apprenticecommitmentsapi
@outerapi
@regression
@deleteuser
@ignore
Scenario: Get apprenticeship record
	Given an apprentice has created an account
	Then the apprenticeship record can be fetched
