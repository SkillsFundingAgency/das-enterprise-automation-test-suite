
Feature: PC_03_AddSpecificPaye

@payecreation
@addlevyfunds
Scenario: PC_03_AddSpecificPaye
	Given I add declarations
	| EmpRef         | Duration | LevyPerMonth | NoOfLevy | NoOfNonLevy |
	| 198/QEVYVMUYLQ | 15       | 1000         | 1        | 0           |