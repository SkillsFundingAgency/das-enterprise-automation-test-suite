Feature: SC_BUSuspendAndReinstateAccount


@supportconsole
@approvalssupportconsole
@BulkUtility
Scenario: SC_Bulk Suspend and Reinstate Employer User Accounts
	Given the employer user can login to EAS
	When that account is suspended using bulk utility
	Then the employer user cannot login to EAS
	When that account is reinstated using bulk utility
	Then the employer user can login to EAS
