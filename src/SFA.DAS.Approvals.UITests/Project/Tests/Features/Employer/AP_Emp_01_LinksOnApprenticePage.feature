Feature: AP_Emp_01_LinksOnApprenticePage


@mytag
Scenario: Validate all links on Apprentice home page are functional
	Given Employer navigates to Apprentices home page
	Then Standard gov.uk footer should be displayed at the bottom of the page
	#And the Help widget is displayed on bottom right hand corner	
	Then 'Set payment order' link should direct user to 'Set payment order' page
	And 'Report public sector apprenticeship target' link should direct user to 'Annual apprenticeship return' page