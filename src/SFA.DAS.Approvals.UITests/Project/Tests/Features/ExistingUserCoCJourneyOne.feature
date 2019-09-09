Feature: ExistingUserCoCJourneyOne

A short summary of the feature

@regression
Scenario: Employer requests change of circumstance After ILR match and Provider approves
Given the Employer has approved apprentice
When the Employer edits Dob and Reference and confirm the changes after ILR match
Then the provider can review and approve the changes



