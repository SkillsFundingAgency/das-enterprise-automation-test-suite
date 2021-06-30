Feature: TesData_Cleanup

To clean up test data from emp-acc-db

@donottakescreenshot
Scenario Outline: RE_01_Cleanup_Testdata_employer_accounts
	Then the test data are cleaned up for email <email>

	Examples: 
	| email          |
	| Test%05Jan2021 |
