Feature: FATSearchAreaWhereCourseIsNotOffered_03

@fat
@regression
Scenario: FATSAWCINO_03_Search Training Where Course Is Not Offered
	Given the User searches a course then navigates to the provider list
	When the User selects 10005124 from the list
	And enters the location Exeter, Devon
	Then training options displayed