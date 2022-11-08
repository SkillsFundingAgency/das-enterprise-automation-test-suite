Feature: GetStatistics

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_12_ GetStatistics
	Then endpoint /api/statistics from legacy accounts can be accessed