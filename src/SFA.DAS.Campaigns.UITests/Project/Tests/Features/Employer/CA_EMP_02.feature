Feature: CA_EMP_02

@campaigns
@apprentice
@regression
Scenario: CA_EMPP_02_Check The Benefits Of Your Organisation Page Details
	Given the user navigates to the benefits of your organisation page
	Then the links are not broken
	And the video links are not broken
