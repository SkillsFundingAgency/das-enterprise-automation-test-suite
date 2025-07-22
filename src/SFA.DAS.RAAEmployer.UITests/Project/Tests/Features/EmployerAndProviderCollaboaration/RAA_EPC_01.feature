Feature: RAA_EPC_01

@raa
@raa-epc
@regression
Scenario: RAA_P_EPC_01 - Employer and Provider Collaboration
Given the Employer grants permission to the provider to create advert with review option
When the Provider submits a vacancy to the employer for review
Then the 'employer' receives 'employer review' email notification
When the Employer rejects the advert
Then the 'provider' receives 'rejected vacancy' email notification
And the Provider should see the advert with status: 'Rejected by employer'
When Provider re-submits the advert
And the Employer approves the advert
And the Reviewer Approves the vacancy
Then the Provider should see the advert with status: 'Live'
