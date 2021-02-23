Feature: RP_ChangeRoute_01

@rpcr01
@roatp
@roatpapply
@roatpapplychangeroute
@regression
Scenario: RP_ChangeRoute01A_Company MainToEmployer and EmployerToSupporting
	Given the provider initates an application as main route company
	When the provider completes Your organisation section
	Then the  provider should be able to change route to Employer 
	And the provider should be able to verify the Employer route flow
	And the provider should be able to change route to Supporting 
	And the provider should be able to verify the Supporting route flow

@rpcr01
@roatp
@roatpapply
@roatpapplychangeroute
@regression
Scenario: RP_ChangeRoute01B_Company MainToSupporting and SupportingToEmployer
    Given the provider initates an application as main route company
	When the provider completes Your organisation section
	Then the provider should be able to change route to Supporting 
	And the provider should be able to verify the Supporting route flow
	And the  provider should be able to change route to Employer 
	And the provider should be able to verify the Employer route flow

@rpcr01
@roatp
@roatpapply
@roatpapplychangeroute
@regression
Scenario: RP_ChangeRoute01C_Company SupportingToMain 
    Given the provider initates an application as supporting route
	When the provider completes Your organisation section for supporting route org type company
	Then the provider should be able to change route to Main 
	And the provider should be able to verify the Main route flow

@rpcr01
@roatp
@roatpapply
@roatpapplychangeroute
@regression
Scenario: RP_ChangeRoute01D_Company EmployerToMain 
    Given the provider initates an application as employer route
	When the provider completes Your organisation section for FHA exemptions 
	Then the provider should be able to change route to Main 
	And the provider should be able to verify the Main route flow for route changed Employer To Main

