Feature: RP_Outcome_GateWayReject_ReApply_01


@roatp
@rpadgatewayrejectreapplications01
@roatpadmin
@oldroatpadmin
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_GateWayReject_ReApply_01 Reapplication of GatewayRejected Application 
Given the Main provider is already on the RoATP register as Active
Then verify the Application rejected page is displayed with External Reject Comments for the applicant
And verify provider able to request new invitation to Reapply
Then the provider initates an application as Main Provider Route For Existing Provider 
