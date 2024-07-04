Feature: RV2_EPC_01

@raa-v2
@raa-v2-epc
@regression
Scenario: RV2_P_EPC_01 - Employer and Provider Collaboration
Given the Employer grants permission to the provider to create advert with review option
When the Provider submits a vacancy to the employer for review
And the Employer rejects the advert
Then the Provider should see the advert with status: 'Rejected by employer'
When Provider re-submits the advert
And the Employer approves the advert
And the Reviewer Approves the vacancy
Then the Provider should see the advert with status: 'Live'
