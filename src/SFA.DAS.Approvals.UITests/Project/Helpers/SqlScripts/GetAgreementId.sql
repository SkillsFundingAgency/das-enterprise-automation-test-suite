
	SELECT ael.PublicHashedId 
	FROM [employer_account].[AccountLegalEntity] ael
	WHERE ael.AccountId = 
		(
			SELECT TOP 1 acc.Id
			FROM [employer_account].[Membership] msp
			INNER JOIN [employer_account].[User] usr
			ON msp.UserId = usr.Id
			INNER JOIN [employer_account].[Account] acc
			ON acc.Id = msp.AccountId
			WHERE usr.Email =  @email
			AND Name Like @name
		)

