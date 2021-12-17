Feature: EFD_HomePage_01

@employerfrontdoor
@regression
Scenario: EmployerFrontDoor_HomePage_01 Check Home Page
	Given the user navigates to Home page and verifies the content and accept the cookie
	Then the links are not broken