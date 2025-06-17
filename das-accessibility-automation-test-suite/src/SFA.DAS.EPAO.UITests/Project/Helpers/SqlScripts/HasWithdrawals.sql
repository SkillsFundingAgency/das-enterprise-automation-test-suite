SELECT CASE WHEN EXISTS
(
	SELECT 
		a.ApplicationId
	FROM Apply a
		INNER JOIN Organisations o ON a.OrganisationId = o.Id
		INNER JOIN Contacts c ON c.Id = a.CreatedBy
		CROSS APPLY OPENJSON(ApplyData,'$.Sequences') WITH (SequenceNo INT, NotRequired BIT) sequence
    WHERE 
		c.Email = '__email__'
		AND sequence.SequenceNo IN (3, 4)  AND sequence.NotRequired = 0
		AND a.ApplicationStatus <> 'Declined'
		AND a.DeletedAt IS NULL
) THEN 1 ELSE 0 END HasWithdrawals
