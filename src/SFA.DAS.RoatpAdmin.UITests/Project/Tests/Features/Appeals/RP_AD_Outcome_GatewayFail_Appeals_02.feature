Feature: RP_Outcome_GateWayFail_Appeals_02


@roatp
@rpadgatewayfailappeals01
@roatpadmin
@roatpoutcome
@oldroatpadmin
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_GateWayFail_Appeals_01A Existing provider Complete Outcome of a Company type Application via Main provider route Appeal_Successful_Already_Active Journey	
Given the Main provider is already on the RoATP register as Active
And the admin navigates to the Dashboard
And the application with FAIL outcome is ready to be assessed
And verify that the admin can send the application outcome as UNSUCCESSFUL to the applicant
Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status
And verify the Application unsuccessful page is displayed 
And verify Appeal submitted page is displayed once provider submits the APPEAL 
And the admin navigates to the Dashboard
And the appeal manager approves the appeal as SUCCESSFUl Already Active
Then Verify the application is transitioned to Appeal Outcome tab with SUCCESSFUL status
And verify the provider Application determined date is not updated
And verify the Appeal successful page is displayed in Appeals tab

@roatp
@rpadgatewayfailappeals01
@roatpadmin
@roatpoutcome
@oldroatpadmin
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_GateWayFail_Appeals_01B Existing provider Complete Outcome of a Company type Application via Main provider route Appeal_Unsuccessful Journey	
Given the Main provider is already on the RoATP register as Active
And the admin navigates to the Dashboard
And the application with FAIL outcome is ready to be assessed
And verify that the admin can send the application outcome as UNSUCCESSFUL to the applicant
Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status
And verify the Application unsuccessful page is displayed 
And verify Appeal submitted page is displayed once provider submits the APPEAL 
And the admin navigates to the Dashboard
And the appeal manager approves the appeal as UNSUCCESSFUl 
Then Verify the application is transitioned to Appeal Outcome tab with UNSUCCESSFUL status
And verify the provider Application determined date is not updated
And verify the Appeal unsuccessful page is displayed in Appeals tab
And verify the Application unsuccessful page is displayed for Appealead Application

@roatp
@rpadgatewayfailappeals01
@roatpadmin
@roatpoutcome
@oldroatpadmin
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_GateWayFail_Appeals_01C Existing provider Complete Outcome of a Company type Application via Main provider route Appeal_InProgress_UnSuccessful Journey	
Given the Main provider is already on the RoATP register as Active
And the admin navigates to the Dashboard
And the application with FAIL outcome is ready to be assessed
And verify that the admin can send the application outcome as UNSUCCESSFUL to the applicant
Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status
And verify the Application unsuccessful page is displayed 
And verify Appeal submitted page is displayed once provider submits the APPEAL 
And the admin navigates to the Dashboard
And the appeal manager approves the appeal as INPROGRESS 
Then Verify the application is transitioned to Appeal Outcome tab with IN PROGRESS status
And verify the Appeal in progress page is displayed in Appeals tab
And verify the Application unsuccessful page is displayed for Appealead Application
And the admin navigates to the Dashboard
And the appeal manager approves the in progress appeal as UNSUCCESSFUl 
Then Verify the application is transitioned to Appeal Outcome tab with UNSUCCESSFUL status
And verify the provider Application determined date is not updated
And verify the Appeal unsuccessful page is displayed in Appeals tab
And verify the Application unsuccessful page is displayed for Appealead Application

@roatp
@rpadgatewayfailappeals01
@roatpadmin
@roatpoutcome
@oldroatpadmin
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_GateWayFail_Appeals_01D Existing provider Complete Outcome of a Company type Application via Main provider route Appeal_InProgress_Successful_FitnessForFunding	Journey
Given the Main provider is already on the RoATP register as Active
And the admin navigates to the Dashboard
And the application with FAIL outcome is ready to be assessed
And verify that the admin can send the application outcome as UNSUCCESSFUL to the applicant
Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status
And verify the Application unsuccessful page is displayed 
And verify Appeal submitted page is displayed once provider submits the APPEAL 
And the admin navigates to the Dashboard
And the appeal manager approves the appeal as INPROGRESS 
Then Verify the application is transitioned to Appeal Outcome tab with IN PROGRESS status
And verify the Appeal in progress page is displayed in Appeals tab
And verify the Application unsuccessful page is displayed for Appealead Application
And the admin navigates to the Dashboard
And the appeal manager approves the in progress appeal as SUCCESSFUl Fitness For Funding
Then Verify the application is transitioned to Appeal Outcome tab with SUCCESSFUL status
And verify the provider Application determined date is not updated
And verify the Appeal successful page is displayed in Appeals tab

@roatp
@rpadgatewayfailappeals01
@roatpadmin
@roatpoutcome
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_GateWayFail_Appeals_01E New Provider Complete Outcome of a Company type Application via Main provider route Appeals_Unsuccessful Journey
Given the admin lands on the Dashboard
And the application with FAIL outcome is ready to be assessed	
And verify that the admin can send the application outcome as UNSUCCESSFUL to the applicant
Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status
And verify the provider is not added to the register
And verify the Application unsuccessful page is displayed 
And verify Appeal submitted page is displayed once provider submits the APPEAL 
And the admin navigates to the Dashboard
And the appeal manager approves the appeal as UNSUCCESSFUl 
Then Verify the application is transitioned to Appeal Outcome tab with UNSUCCESSFUL status
And verify the provider is not added to the register
And verify the Appeal unsuccessful page is displayed in Appeals tab
And verify the Application unsuccessful page is displayed for Appealead Application

@roatp
@rpadgatewayfailappeals01
@roatpadmin
@roatpoutcome
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_GateWayFail_Appeals_01F New Provider Complete Outcome of a Company type Application via Main provider route Appeals_Successful Journey
Given the admin lands on the Dashboard
And the application with FAIL outcome is ready to be assessed	
And verify that the admin can send the application outcome as UNSUCCESSFUL to the applicant
Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status
And verify the provider is not added to the register
And verify the Application unsuccessful page is displayed 
And verify Appeal submitted page is displayed once provider submits the APPEAL 
And the admin navigates to the Dashboard
And the appeal manager approves the appeal as SUCCESSFUl
Then Verify the application is transitioned to Appeal Outcome tab with SUCCESSFUL status
And verify the provider is not added to the register
And verify the Appeal successful page is displayed in Appeals tab

@roatp
@rpadgatewayfailappeals01
@roatpadmin
@roatpoutcome
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_GateWayFail_Appeals_01G New Provider Complete Outcome of a Company type Application via Main provider route Appeals_Inprogress_Successful Journey
Given the admin lands on the Dashboard
And the application with FAIL outcome is ready to be assessed	
And verify that the admin can send the application outcome as UNSUCCESSFUL to the applicant
Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status
And verify the provider is not added to the register
And verify the Application unsuccessful page is displayed 
And verify Appeal submitted page is displayed once provider submits the APPEAL 
And the admin navigates to the Dashboard
And the appeal manager approves the appeal as INPROGRESS 
Then Verify the application is transitioned to Appeal Outcome tab with IN PROGRESS status
And verify the Appeal in progress page is displayed in Appeals tab
And verify the Application unsuccessful page is displayed for Appealead Application
And the admin navigates to the Dashboard
And the appeal manager approves the in progress appeal as SUCCESSFUl
Then Verify the application is transitioned to Appeal Outcome tab with SUCCESSFUL status
And verify the provider is not added to the register
And verify the Appeal successful page is displayed in Appeals tab

@roatp
@rpadgatewayfailappeals01
@roatpadmin
@roatpoutcome
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_GateWayFail_Appeals_01H New Provider Complete Outcome of a Company type Application via Main provider route Appeals_Inprogress_UnSuccessful Journey
Given the admin lands on the Dashboard
And the application with FAIL outcome is ready to be assessed	
And verify that the admin can send the application outcome as UNSUCCESSFUL to the applicant
Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status
And verify the provider is not added to the register
And verify the Application unsuccessful page is displayed 
And verify Appeal submitted page is displayed once provider submits the APPEAL 
And the admin navigates to the Dashboard
And the appeal manager approves the appeal as INPROGRESS 
Then Verify the application is transitioned to Appeal Outcome tab with IN PROGRESS status
And verify the Appeal in progress page is displayed in Appeals tab
And verify the Application unsuccessful page is displayed for Appealead Application
And the admin navigates to the Dashboard
And the appeal manager approves the in progress appeal as UNSUCCESSFUl
Then Verify the application is transitioned to Appeal Outcome tab with UNSUCCESSFUL status
And verify the provider is not added to the register
And verify the Appeal unsuccessful page is displayed in Appeals tab
And verify the Application unsuccessful page is displayed for Appealead Application