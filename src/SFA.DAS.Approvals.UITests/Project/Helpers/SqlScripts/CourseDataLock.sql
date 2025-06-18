DECLARE @DatalockEventId int = @MaxDataLockEventId + 1
DECLARE @DataLockEventDatetime datetime = GETDATE()
DECLARE @PriceEpisodeIdentifier nvarchar(25) = '454-20-1-01-01-2018'
DECLARE @ApprenticeshipId int = @CurrentApprenticeshipId
DECLARE @IlrTrainingCourseCode nvarchar(25) = '454-20-1'
DECLARE @IlType int = 1
DECLARE @IlrActualStartDate datetime = @StartDate
DECLARE @IlrEffectiveFromDate datetime = @StartDate
DECLARE @IlrEffectiveToDate datetime = NULL
DECLARE @IlrTotalCost decimal = @TrainingPrice
DECLARE @ErrorCode int = 8
DECLARE @Status int = 2
DECLARE @TriageStatus int = 0
DECLARE @ApprenticeshipUpdateId int = NULL
DECLARE @IsResolved int = 0
DECLARE @EventStatus int = 1
DECLARE @IsExpired int = 0
DECLARE @Expired datetime = NULL

INSERT INTO [dbo].[DataLockStatus]
           ([DataLockEventId]
           ,[DataLockEventDatetime]
           ,[PriceEpisodeIdentifier]
           ,[ApprenticeshipId]
           ,[IlrTrainingCourseCode]
           ,[IlrTrainingType]
           ,[IlrActualStartDate]
           ,[IlrEffectiveFromDate]
           ,[IlrPriceEffectiveToDate]
           ,[IlrTotalCost]
           ,[ErrorCode]
           ,[Status]
           ,[TriageStatus]
           ,[ApprenticeshipUpdateId]
           ,[IsResolved]
           ,[EventStatus]
           ,[IsExpired]
           ,[Expired])
     VALUES
           (@DatalockEventId
           ,@DataLockEventDatetime
           ,@PriceEpisodeIdentifier
           ,@ApprenticeshipId
           ,@IlrTrainingCourseCode
           ,@IlType
           ,@IlrActualStartDate
           ,@IlrEffectiveFromDate
           ,@IlrEffectiveToDate
           ,@IlrTotalCost
           ,@ErrorCode
           ,@Status
           ,@TriageStatus
           ,@ApprenticeshipUpdateId
           ,@IsResolved
           ,@EventStatus
           ,@IsExpired
           ,@Expired)