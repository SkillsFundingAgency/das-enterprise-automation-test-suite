Feature: AC_E2E_01_PositiveE2EJourneyForRegularApp

@apprenticecommitments
@regression
@waitingtostartapprentice
Scenario: AC_E2E_01_PositiveE2EJourneyForRegularApp
	Given the Employer creates an apprenticeship and the Provider approves it
	And the apprentice creates the CMAD account
	Then the apprentice confirms all the sections and the overall apprenticeship
	And the apprentice is able to navigate to the Help and Support from Home and Fully confirmed page
	And the apprentice is able to navigate to Home page back and forth from Fully confirmed Overview and Help pages
	And the apprentice is able to navigate to Roles and HYAWD pages from Fully confirmed Overview page
	And the apprentice is able to logout from the service