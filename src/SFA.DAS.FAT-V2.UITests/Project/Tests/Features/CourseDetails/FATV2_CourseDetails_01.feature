Feature: FATV2_CourseDetails_01

@fatv2
@regression
Scenario: FAT2_CD_01 Course Details Page Content
	Given the User navigates to the Search Results page
	When the User chooses the first course from the Search Results page
	Then User is able to return to homepage