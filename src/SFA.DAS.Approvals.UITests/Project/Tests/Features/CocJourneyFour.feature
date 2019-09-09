Feature: CocJourneyFour

A short summary of the feature

@regression
Scenario: Provider requests changes to cost and course Before ILR match and Employer approves
Given the Employer has approved apprentice
When the provider edits cost and course and confirm the changes before ILR match
Then the Employer can review and approve the changes

