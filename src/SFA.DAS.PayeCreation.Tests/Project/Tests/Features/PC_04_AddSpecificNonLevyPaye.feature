Feature: PC_04_AddSpecificNonLevyPaye

@payecreation
Scenario Outline: PC_04_AddSpecificNonLevyPaye
	Given I add non levy declarations
	| EmpRef   | NoOfNonLevy |
	| <EmpRef> | 1           |

	Examples: 
	| EmpRef         | 
	| 198/QEVYVMUYLR | 