@approvals
Feature: AP_Pro_07_ProvideraAddsApprenticeValidationRules

@regression
Scenario: AP_Pro_07_ProvideraAddsApprenticeValidationRules Validation Rules when Provider Add an Apprentice

Given the Employer logins using existing Levy Account
When the Employer create a cohort and send to provider to add apprentices
#When the Employer create a cohort and add apprentices
When Provider add an apprentice uses details from below to create bulkupload 
 | Category					| CohortRef	| AgreementId	| ULN		| FamilyName | GivenNames | DateOfBirth | EmailAddress	| StdCode | StartDate	| EndDate	| TotalPrice | EPAOrgID | ProviderRef			| ErrorMessage |
 | CohortRef length > 20	| ABC999	| valid			| valid		| valid		 | valid	  | valid		| valid			| valid	  | valid		| valid		|valid		 | valid	| valid					| Enter a valid Cohort Ref	|
 | ULN < 10				    | valid		| valid			| 171649120 | valid      | valid      | valid       | valid			| valid   | valid		| valid		| valid      | valid    | valid					| Enter a 10-digit unique learner number |
 | ULN-9999999999			| valid		| valid			| 9999999999| valid      | valid      | valid       | valid			| valid   | valid		| valid		| valid      | valid    | valid					| The unique learner number of 9999999999 isn't valid |
 | AgreementID < 6			| valid		| MK123			| valid		| valid      | valid      | valid       | valid			| valid   | valid		| valid		| valid      | valid    | valid					| Enter a valid Agreement ID |
 | EmailAddress 			| valid		| valid			| valid		| valid      | valid      | valid       | X@Y			| valid   | valid		| valid		| valid      | valid    | valid					| Enter a valid email address | 
 | DateOfBirth < 15 		| valid		| valid			| valid		| valid      | valid      | 2021-05-09  | valid			| valid   | valid		| valid		| valid      | valid    | valid					| The apprentice's date of birth must show that they are at least 15 years old at the start of their training |  
 | DateOfBirth > 115		| valid		| valid			| valid		| valid      | valid      | 1904-05-01  | valid			| valid   | valid		| valid		| valid      | valid    | valid					| The apprentice's date of birth must show that they are not older than 115 years old at the start of their training |
 | StartDate 			    | valid		| valid			| valid		| valid      | valid      | valid       | valid			| valid   | 2017-03-03  | valid		| valid      | valid    | valid					| The start date must not be earlier than May 2017 |  
 | EndDate 			        | valid		| valid			| valid		| valid      | valid      | valid       | valid			| valid   | 2021-03-03  | 2021-02   | valid      | valid    | valid					| Enter an end date that is after the start date | 
 | EndDateFormat 			| valid		| valid			| valid		| valid      | valid      | valid       | valid			| valid   | valid		| 2021-02-02| valid      | valid    | valid					| Enter the end date using the format yyyy-mm, for example 2019-02 | 
 | TotalPriceWithPence		| valid		| valid			| valid		| valid      | valid      | valid       | valid			| valid   | valid		| valid		| 19.23      | valid    | valid					| Enter the total cost of training in whole pounds using numbers only          |
 | ProviderRef > 20			| valid		| valid			| valid		| valid		 | valid	  |valid		| valid			| valid	  | valid		| valid		| valid		 | valid	| 012345678901234567890	| The Provider Ref must not be longer than 20 characters	|
 | StdCodeInValid 			| valid		| valid			| valid		| valid      | valid      | valid       | valid			| 59ab    | valid		| valid		| valid      | valid    | valid					| Enter a valid standard code |
 | StartDateFormat		    | valid		| valid			| valid		| valid      | valid      | valid       | valid			| valid   | 2000-14		| valid		| valid      | valid    | valid					| Enter the start date using the format yyyy-mm-dd, for example 2017-09-01 |
 | CohortUlnEmailDoB 		| 9XZY99	| valid			| 171649120 | valid      | 2021-05-09 | valid		|  com@.com			| valid	  | 2021-03-03	| 2021-02   | valid		 | valid	| valid				| Enter a valid Cohort Ref\nEnter a 10-digit unique learner number\nEnter a valid email address\nEnter an end date that is after the start date|
 | GivenNameEmpty			| valid		| valid			| valid		| 			 | valid	  |valid		|valid			|valid	  |valid		|valid		| valid		 | valid	| valid					| Last name must be entered	| 
 | FamilyNameEmpty			| valid		| valid			| valid		| valid		 |			  |valid		| valid			| valid	  | valid		|valid		| valid		 | valid	| valid					| First name must be entered	|
 | GivenName > 100			| valid		| valid			| valid		| GivenNameGivenNameGivenNameGivenName GivenNameGivenNameGivenNameGivenNameGivenNames GivenNamesGivenNamesGivenNames	| valid				|valid			|valid			|valid		|valid		|valid		|valid		| valid		| valid			| Enter a last name that is not longer than 100 characters	|
 | FamilyName > 100			| valid		| valid			| valid		| FamilyNameFamilyNameFamilyNameFamily NameFamilyNameFamilyNameFamilyNameFamilyName FamilyNameFamilyNameFamilyName	| valid					|valid			|valid			|valid		|valid		|valid		|valid		| valid		| valid			| Enter a last name that is not longer than 100 characters	|	