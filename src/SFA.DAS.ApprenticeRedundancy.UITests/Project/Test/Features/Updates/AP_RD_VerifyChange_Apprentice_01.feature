Feature: AP_RD_UD_01

@aprdsupport
@aprd
@regression
@aprdud01
Scenario: AP_RD_VerifyChange_Apprentice_01_ApprenticeForm
Given the apprentice Lands on confirm apprentice details page
And the apprentice can acess all the change links
When the apprentice updates the previous apprenticeship details
Then changes made are reflected on confirm apprentice details page