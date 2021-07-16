DELETE FROM Apply WHERE ApplicationId IN (
SELECT a.ApplicationId
    FROM Contacts c
    INNER JOIN Apply a ON a.OrganisationId = c.OrganisationId
    INNER JOIN Organisations o ON a.OrganisationId = o.Id
    INNER JOIN Contacts c1 ON c1.Id = a.CreatedBy
    CROSS APPLY OPENJSON(ApplyData,'$.Sequences') WITH (SequenceNo INT, NotRequired BIT) sequence
    WHERE 1=1 
	AND c1.Email = '__email__'
    AND sequence.SequenceNo = 4  AND sequence.NotRequired = 0
    GROUP BY 
    a.ApplicationId )