Feature: TM_09_SameRecieverApplyForMultiplePledge

@regression
@transfermatching
Scenario: TM_09_Same Reciever Apply For Multiple Pledge
	Given the levy employer creates a pledge
	Then the non levy employer can apply for the pledge
	Given the another levy employer creates a pledge
	Then the non levy employer can apply for the pledge