Feature: RV2_EPC_01

A short summary of the feature

@tag1
Scenario: RV2_P_EPC_01 - Employer and Provider Collaboration
Given the Employer grants permission to the provider to create advert with review option
When the Provider creates a vacancy on behalf of the employer
And submits it to the employer for reviewAND Employer rejects the advert
Then the Provider should see the advert in 'Rejected vacancies' section
When Provider re-submits the advertAnd Employer approves the advertAnd the Reviewer Approves the vacancy
Then the Provider should see the advert in 'Live vacancies' section
