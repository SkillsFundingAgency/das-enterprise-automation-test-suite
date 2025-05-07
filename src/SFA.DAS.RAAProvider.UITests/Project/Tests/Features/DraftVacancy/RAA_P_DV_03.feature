Feature: RAA_P_DV_03

@raa	
@raaprovider
@regression
Scenario: RAA_P_DV_03 - Delete draft vacancy
Given the Provider creates Draft advert
When the Provider completes the Draft advert to cancel deleting the draft
Then the Provider is able to delete the draft vacancy
