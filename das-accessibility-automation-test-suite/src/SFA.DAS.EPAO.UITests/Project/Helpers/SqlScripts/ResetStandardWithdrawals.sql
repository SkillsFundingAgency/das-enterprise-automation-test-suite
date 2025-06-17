BEGIN TRANSACTION

/* find all the organisation standards for which a standard withdrawal has been created by the given user */
DECLARE @WITHDRAWN_ORGANISATION_STANDARD_ID TABLE
(
	Id INT
);

INSERT INTO @WITHDRAWN_ORGANISATION_STANDARD_ID
SELECT
	os.Id
FROM OrganisationStandard os INNER JOIN
(
	SELECT 
		o.EndPointAssessorOrganisationId, JSON_VALUE(JSON_QUERY(a.ApplyData, '$.Apply'), '$.StandardCode') StandardCode
	FROM Organisations o 
		INNER JOIN Apply a ON o.Id = a.OrganisationId
		INNER JOIN Contacts c ON c.Id = a.CreatedBy
		CROSS APPLY OPENJSON(ApplyData,'$.Sequences') WITH (SequenceNo INT, NotRequired BIT) sequence
	WHERE 
		c.Email = '__email__'
		AND sequence.SequenceNo = 4  AND sequence.NotRequired = 0
		AND a.ApplicationStatus <> 'Declined'
		AND a.DeletedAt IS NULL
) [OrganisationStandardsForStandardWithdrawls] ON os.EndPointAssessorOrganisationId = [OrganisationStandardsForStandardWithdrawls].EndPointAssessorOrganisationId
WHERE
	os.StandardCode = [OrganisationStandardsForStandardWithdrawls].StandardCode;

/* revert the withdrawal by resetting the EffectiveTo date */
UPDATE OrganisationStandard SET EffectiveTo = NULL WHERE Id IN
(
	SELECT Id FROM @WITHDRAWN_ORGANISATION_STANDARD_ID
);

UPDATE OrganisationStandardVersion SET EffectiveTo = NULL WHERE OrganisationStandardId IN
(
	SELECT Id FROM @WITHDRAWN_ORGANISATION_STANDARD_ID
);

/* remove all the standard withdrawals created by the given user */
DELETE FROM Apply WHERE ApplicationId IN 
(
	SELECT 
		a.ApplicationId
	FROM Apply a
		INNER JOIN Organisations o ON a.OrganisationId = o.Id
		INNER JOIN Contacts c ON c.Id = a.CreatedBy
		CROSS APPLY OPENJSON(ApplyData,'$.Sequences') WITH (SequenceNo INT, NotRequired BIT) sequence
    WHERE 
		c.Email = '__email__'
		AND sequence.SequenceNo = 4  AND sequence.NotRequired = 0
		AND a.ApplicationStatus <> 'Declined'
		AND a.DeletedAt IS NULL
);

COMMIT TRANSACTION
