Feature: RAA_E_DV_03

@raa	
@raaemployer
@regression
Scenario: RAA_E_DV_03 - Delete draft vacancy
Given the Employer creates Draft advert
When the Employer completes the Draft advert to cancel deleting the draft
Then the Employer is able to delete the draft vacancy
