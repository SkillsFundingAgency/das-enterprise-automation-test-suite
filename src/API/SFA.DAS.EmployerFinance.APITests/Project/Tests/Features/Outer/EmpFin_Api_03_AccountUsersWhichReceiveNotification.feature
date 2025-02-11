Feature: EmpFin_Api_03_AccountUsersWhichReceiveNotification

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EmpFin_Api_03_AccountUsersWhichReceiveNotification
	Then endpoint /Accounts/{accountId}/users/which-receive-notifications can be accessed