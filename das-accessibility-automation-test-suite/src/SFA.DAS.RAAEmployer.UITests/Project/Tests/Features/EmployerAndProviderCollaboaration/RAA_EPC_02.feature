Feature: RAA_EPC_02

@raa
@raa-epc
@regression
Scenario: RAA_P_EPC_02 - Employer and Provider Collaboration Both Yes Permissions
Given the Employer grants permission to the provider to create advert with review option set as Yes
When the Provider submits a vacancy to the employer for review
And the Employer rejects the advert
Then the Provider should see the advert with status: 'Rejected by employer'
When Provider re-submits the advert
And the Employer approves the advert
And the Reviewer Approves the vacancy
Then the Provider should see the advert with status: 'Live'