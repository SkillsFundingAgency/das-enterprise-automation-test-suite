Feature: GetPageOfAccountLegalEntities

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_10_ GetPageOfAccountLegalEntities
	Then endpoint api/accountlegalentities?pageNumber=1&pageSize=100 can be accessed