Feature: PC_03_AddSpecificLevyPaye

@payecreation
Scenario Outline: PC_03_AddSpecificLevyPaye
	Given I add levy declarations
	| EmpRef   | Duration   | LevyPerMonth   | NoOfLevy |
	| <EmpRef> | <Duration> | <LevyPerMonth> | 1        |

	Examples: 
	| EmpRef         | Duration | LevyPerMonth |
	| 198/QEVYVMUYLQ | 15       | 1000         |