Feature: TesData_Cleanup

To clean up test data from emp-acc-db

@donottakescreenshot
Scenario Outline: RE_01_Cleanup_Testdata_employer_accounts
	Then the test data are cleaned up for email <email>

	Examples: 
	| email                                       |
	| AP_Test_120_30Sep2019_23075545181@gmail.com |
