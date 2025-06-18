Feature: RAA_P_DV_01

@raa	
@raaprovider
@regression
Scenario: RAA_P_DV_01 - Provider cancels creating an advert
Given Provider cancels after saving the title of the advert
Then the advert is saved as a draft
