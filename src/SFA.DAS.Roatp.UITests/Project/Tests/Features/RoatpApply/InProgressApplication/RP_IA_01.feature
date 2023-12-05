Feature: RP_IA_01


@roatpapplyinprogressapplication
@roatp
@regression
@rpip01
@govloginapplytests
Scenario: RP_IA_01_InProgress_Application
	When a user with in progress application login
	Then the user will be directed to their current application
