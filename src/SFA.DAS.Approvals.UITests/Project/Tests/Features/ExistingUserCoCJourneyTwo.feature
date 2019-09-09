Feature: ExistingUserCoCJourneyTwo

A short summary of the feature

@regression
Scenario: Provider requests change of circumstance After ILR match and Employer approves
Given the Employer has approved apprentice
When the provider edits and confirm the changes after ILR match
Then the Employer can review and approve the changes

