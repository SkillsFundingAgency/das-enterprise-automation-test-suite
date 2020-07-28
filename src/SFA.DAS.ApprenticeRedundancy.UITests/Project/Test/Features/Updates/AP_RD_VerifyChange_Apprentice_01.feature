Feature: AP_RD_UD_01

@aprdsupport
@aprd
@aprdupdate
@regression
@aprdud01
Scenario: AP_RD_VerifyChange_Apprentice_01_ApprenticeForm
Given the apprentice lands on check your answers apprentice details page
And the apprentice can access all the change links
When the apprentice updates the previous apprenticeship details
Then changes made are reflected on confirm apprentice details page