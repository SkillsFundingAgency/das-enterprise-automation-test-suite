Feature: ApiGetEmployerUserByUserRef

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_14_ApiGetEmployerUserByUserRef
	Then endpoint /api/user/{userRef}/accounts can be accessed