Feature: RP_E2E_01


@rpe2e01
Scenario: RP_E2E_01_MainRoute-Company
Given the provider initates an application as main route company
When the provider completes Your Organisation section
And the provider completes Criminal and Compliance section
Then the provider completes Finish section
