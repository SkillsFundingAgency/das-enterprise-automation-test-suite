Feature: TesData_Cleanup

To clean up test data from emp-acc-db

@donottakescreenshot
Scenario: RE_01_Cleanup_Testdata_employer_accounts
	Then the test data are cleaned up for email 120@performancetest.com
	Then the test data are cleaned up for email 123@performancetest.com
	Then the test data are cleaned up for email 124@performancetest.com
