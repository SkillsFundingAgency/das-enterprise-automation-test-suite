# ToBeMigrated to PlayWright under APPMAN-1764
#
#
#Feature: AP_NL_E2E_04_NonLevyE2EMaxReservationsLimitReached
#
#@approvals
#@regression
#@non-levy
#@reservation
#Scenario: AP_NL_E2E_04 Block users to add apprentice when max reservation limit is reached
#	Given the Employer logins using an existing NonLevy Account which has reached it max reservations limit
#	When user tries to create an apprenticeship request (cohort)
#	Then the Employer is blocked with a shutter page
#	When the Employer tries to add an apprentice to an existing cohort
#	Then the Employer is blocked with a shutter page for existing cohort
#	When the Provider with create reservation permission logs in
#	Then the Provider with suitable permissions tries to create reservation on behalf of this employer
#	Then the Provider is blocked with a shutter page
