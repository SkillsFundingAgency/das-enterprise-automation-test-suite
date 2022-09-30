Feature: AC_E2E_02_PositiveE2EJourneyForPortableApp

@apprenticecommitments
@regression
@portableflexijob
Scenario: AC_E2E_02_PositiveE2EJourneyForPortableApp
	Given the Employer creates a Portable flexi-job apprenticeship and the Provider approves it
	And the apprentice creates the CMAD account
	Then the apprentice confirms all the sections and the overall Portable apprenticeship
	And the apprentice verifies the Portable apprenticeship information displayed on the fully confirmed overview page
	And the apprentice is able to navigate to the Help and Support from Home and Fully confirmed page
	And the apprentice is able to navigate to Home page back and forth from Fully confirmed Overview and Help pages
	And the apprentice is able to navigate to Roles and HYAWD pages from Fully confirmed Overview page
