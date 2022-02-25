@approvals
Feature: AP_BU_05_ValidationRules

@regression
@newBUJourney
Scenario: AP_BU_05_Validation Rules
	Given the Employer logins using existing Levy Account
	And the Employer create a cohort and send to provider to add apprentices
	When Provider add an apprentice uses details from below to create bulkupload 
 Category						| CohortRef				|AgreementID	|ULN	|FamilyName	|GivenNames	|DateOfBirth	|EmailAddress	|StdCode	|StartDate	|EndDate	|TotalPrice	|EPAOrgID	|ProviderRef	| Error Message
 HappyPath						| valid					|valid			|valid	|valid		|valid		|valid			|valid			|valid		|valid		|valid		|valid		| valid		| valid			| 
 CohortRef length > 20			| MKRK7VMKRK7VMKRK7VPJ1	|valid			|valid	|valid		|valid		|valid			|valid			|valid		|valid		|valid		|valid		| valid		| valid			| You must enter a valid Cohort Ref
 Value does not map to a cohort	|

