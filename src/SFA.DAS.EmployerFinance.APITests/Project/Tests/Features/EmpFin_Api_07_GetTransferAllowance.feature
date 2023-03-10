Feature: EmpFin_Api_07_GetTransferAllowance

@ignoreinpp
@api
@employerfinanceapi
@regression
@innerapi
Scenario: GetTransferAllowance
	Then endpoint api/accounts/{hashedAccountId}/transferAllowance can be accessed