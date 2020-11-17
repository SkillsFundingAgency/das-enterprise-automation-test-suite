Feature: FATV2_SearchAreaWhereCourseIsNotOffered_03

@fatv2
@regression
Scenario: FATV2_SAWCINO_03_Search Training Where Course Is Not Offered
	Given the User searches a course then navigates to the provider list
	When the User selects 10004596 from the list
	And enters the location Exeter, Devon
	Then the User is presented with option to view other training providers