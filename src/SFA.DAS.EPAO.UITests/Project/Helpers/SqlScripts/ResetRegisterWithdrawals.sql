BEGIN TRANSACTION

/* find all the organisation standards for which a register withdrawal has been created by the given user */
DECLARE @WITHDRAWN_ORGANISATION_STANDARD_ID TABLE
(
	Id INT
)

INSERT INTO @WITHDRAWN_ORGANISATION_STANDARD_ID
SELECT 
	os.Id
FROM Organisations o 
	INNER JOIN Apply a ON o.Id = a.OrganisationId
	INNER JOIN OrganisationStandard os ON o.EndPointAssessorOrganisationId = os.EndPointAssessorOrganisationId
	INNER JOIN Contacts c ON c.Id = a.CreatedBy
	CROSS APPLY OPENJSON(a.ApplyData,'$.Sequences') WITH (SequenceNo INT, NotRequired BIT) sequence
WHERE 
	c.Email = '__email__'
	AND sequence.SequenceNo = 3  AND sequence.NotRequired = 0
	AND a.ApplicationStatus <> 'Declined'
    AND a.DeletedAt IS NULL
GROUP BY
	os.Id

/* revert the withdrawal by resetting the EffectiveTo date */	
UPDATE OrganisationStandard SET EffectiveTo = NULL WHERE Id IN
(
	SELECT Id FROM @WITHDRAWN_ORGANISATION_STANDARD_ID
)

UPDATE OrganisationStandardVersion SET EffectiveTo = NULL WHERE OrganisationStandardId IN
(
	SELECT Id FROM @WITHDRAWN_ORGANISATION_STANDARD_ID
)

/* remove all the register withdrawals created by the given user */
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
		AND sequence.SequenceNo = 3  AND sequence.NotRequired = 0
		AND a.ApplicationStatus <> 'Declined'
		AND a.DeletedAt IS NULL
)

COMMIT TRANSACTION