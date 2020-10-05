Feature: CA_EMP_05

@campaigns
@employer
@regression
Scenario: CA_EMP_05_Check End Point Assessments Page Details
	Given the user navigates to the end point assessments page
	Then the end point assessments sub headings are displayed
	Then the links are not broken

