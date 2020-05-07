Feature: AP_Emp_01_LinksOnApprenticePage


@mytag
Scenario: Validate all links on Apprentice home page are functional
	Given Employer navigates to Apprentices home page
	Then Standard gov.uk footer should be displayed at the bottom of the page
	Then Standard cookie banner should be displayed at the top of the page
	#And the Help widget is displayed on bottom right hand corner	
	Then 'Set payment order' link should direct user to 'Set payment order' page
	And 'Report public sector apprenticeship target' link should direct user to 'Annual apprenticeship return' page
	And 'Manage your apprentices' link should direct user to 'Manage your apprentices' page
	And 'Your cohorts' link should direct user to 'Your cohort requests' page
	And 'Add an apprentice' link should direct user to 'Add an apprentice' page