Feature: SC_Ma_Search_01

@regression
@supportconsole
@masupportconsole
Scenario: SC_Ma_Search_01 Search By Hashed account id, account name or PAYE scheme
	Given the User is logged into Support Console
	Then the user can search by Hashed account id, account name or PAYE scheme