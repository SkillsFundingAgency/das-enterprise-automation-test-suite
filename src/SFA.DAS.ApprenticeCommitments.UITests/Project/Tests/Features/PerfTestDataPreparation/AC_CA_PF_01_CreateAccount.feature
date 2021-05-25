Feature: AC_CA_PF_01_Create_Account

@perftest
@donottakescreenshot
@deleteuser
Scenario: AC_CA_PF_01_Create_Account
	When employer or provider submits the details to create an account
	Then the apprentice is able to create an account using the invitation