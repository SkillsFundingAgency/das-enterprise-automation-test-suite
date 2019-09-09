Feature: CocJourneyThree

A short summary of the feature

@regression
@Ignore
#Scenario ignored awaiting responce from Approvals QA
Scenario: Employer requests changes to cost and course After ILR match and Provider approves
Given the Employer has approved apprentice
When the Employer edits cost and course and confirm the changes after ILR match
Then the provider can review and approve the changes

@regression
Scenario: Employer requests changes to cost and course Before ILR match and Provider approves
Given the Employer has approved apprentice
When the Employer edits cost and course and confirm the changes before ILR match
Then the provider can review and approve the changes

