Feature: RV2_E_CreateFirstAdvert	
	As a Levy Employer, Create First Advert
#Do not add regression or approvals tag, as these tests are meant to create data
	
Scenario Outline: RV2_E_CreateFirstAdvert Perf test data preparation
	Given the Employer creates first draft advert using '<employeremail>'

	Examples: 
	| employeremail                                  |
	| LE_Test_105_21Jul2020_14281968931@perftest.com |
	| LE_Test_106_21Jul2020_14291631026@perftest.com |
	| LE_Test_107_21Jul2020_14301310947@perftest.com |
	| LE_Test_108_21Jul2020_14310499219@perftest.com |
	| LE_Test_109_21Jul2020_14315735396@perftest.com |
	| LE_Test_110_21Jul2020_14325310844@perftest.com |
	| LE_Test_111_21Jul2020_14335127738@perftest.com |
	| LE_Test_112_21Jul2020_14344673564@perftest.com |
	| LE_Test_113_21Jul2020_14354026897@perftest.com |
	| LE_Test_114_21Jul2020_14363617104@perftest.com |
	| LE_Test_115_21Jul2020_14372801901@perftest.com |
	| LE_Test_116_21Jul2020_14381990833@perftest.com |
	| LE_Test_117_21Jul2020_14391210050@perftest.com |
	| LE_Test_118_21Jul2020_14400544260@perftest.com |
	| LE_Test_119_21Jul2020_14405803969@perftest.com |
	| LE_Test_120_21Jul2020_14414892191@perftest.com |
	| LE_Test_121_21Jul2020_14423951745@perftest.com |
	| LE_Test_122_21Jul2020_14434023208@perftest.com |
	| LE_Test_123_21Jul2020_14443431419@perftest.com |
	| LE_Test_124_21Jul2020_14452545939@perftest.com |
	| LE_Test_125_21Jul2020_14461401196@perftest.com |