Feature: RAA_E_DV_01

@raa	
@raaemployer
@regression
Scenario: RAA_E_DV_01 - Employer cancels creating an advert
When Employer cancels after saving the title of the advert
Then the advert is saved as a draft
