# Uncomment this line when running locally
# . "$PSScriptRoot\Hashids.ps1"

function LogMessage{
    param(
        [string] $msg
    )
    Write-Host $msg
}

function GenerateRandomString{
        param(
            [int] $length
        )

        return -join ((65..90) + (97..122) | Get-Random -Count $length | % {[char]$_})
    }

class User {
    [string] $id
    [string] $firstName
    [string] $lastName 
    [string] $email
}

class TestUser {
    [string] $id
    [string] $firstName
    [string] $lastName 
    [string] $email
    [string] $password
    [string] $salt
}

function Create-EmployerUser{   
    param(
        [string] $email,
        [string] $password,
        [string] $employerUsersProfilesConnectionString,
        [string] $employerUsersConnectionString
    )        

    function SecurePassword{
        param(
            [string] $plainTextPassword,
            [System.Byte[]] $salt,
            [string] $profileKey,
            [int] $profileWorkFactor,
            [int] $profileStorageLength
        )
        
        $saltedPassword = $salt + [Text.Encoding]::Unicode.GetBytes($plainTextPassword) 


        $hmacsha = New-Object System.Security.Cryptography.HMACSHA256
        $hmacsha.key =[Convert]::FromBase64String($profileKey)


        $hash = $hmacsha.ComputeHash($saltedPassword)

        $hashString = [Convert]::ToBase64String($hash)
        $pbkdf2 = New-Object  System.Security.Cryptography.Rfc2898DeriveBytes($hashString,$salt,$profileWorkFactor)
        $password = $pbkdf2.GetBytes($profileStorageLength)

        return [Convert]::ToBase64String($password)   
    }

    function GetPasswordProfile {
        param(
            [string] $connectionString 
        )
        
        try {
            return Invoke-Sqlcmd -query "SELECT TOP 1 * FROM PasswordProfile" -ConnectionString $connectionString
        } catch {            
            LogMessage "-----------------New error--------------" 
            LogMessage $([Environment]::UserName)
            #LogMessage $($env:PSModulePath)
            LogMessage $_    
            LogMessage (Get-Module -FullyQualifiedName 'SqlServer' -ListAvailable).Name
            LogMessage (Get-Module -FullyQualifiedName 'SQLPS' -ListAvailable).Name
            LogMessage "remove"
            Remove-Module -Name SQLPS -Verbose -Force
            LogMessage "removed"
            LogMessage $remove            
            LogMessage (Get-Module -FullyQualifiedName 'SQLPS' -ListAvailable).Name
            $import = Import-Module SqlServer -Verbose -Force
            LogMessage $import
        }
    }

    function SaveUser {
        param(
            [string] $connectionString,
            [string] $id, 
            [string] $firstName,
            [string] $lastName,
            [string] $email,
            [string] $password,
            [string] $salt,
            [string] $passwordProfileId                
          )        

        $connection = new-object system.data.SqlClient.SQLConnection($connectionString)
        $command = new-object system.data.sqlclient.sqlcommand
        $command.Connection = $connection
        $command.CommandText = 'CreateUser'
        $command.CommandType = [System.Data.CommandType]::StoredProcedure
    
        $command.Parameters.AddWithValue('@Id', $id)        
        $command.Parameters.AddWithValue('@FirstName', $firstName)        
        $command.Parameters.AddWithValue('@LastName', $lastName)
        $command.Parameters.AddWithValue('@Email', $email)
        $command.Parameters.AddWithValue('@Password', $password)
        $command.Parameters.AddWithValue('@Salt',  $salt)
        $command.Parameters.AddWithValue('@PasswordProfileId', $passwordProfileId)
        $command.Parameters.AddWithValue('@IsActive', 1)
        $command.Parameters.AddWithValue('@FailedLoginAttempts', 0)
        $command.Parameters.AddWithValue('@IsLocked', 0)
        
        $connection.Open()

        $result = $command.ExecuteNonQuery()   
        $connection.Close()
    
        $connection.Dispose()
        $command.Dispose()

        #return $result
    }



    function CreateSalt{    
        param(
            [int] $length
        )

        $salt = [System.Byte[]]::new($length)
        $Random = [System.Random]::new()
        $Random.NextBytes($salt)
        return $salt
    }


    #get password profile     
    
    $passwordProfile = GetPasswordProfile -connectionString $employerUsersProfilesConnectionString
    
    $salt = CreateSalt -length $passwordProfile.SaltLength

    $hasedPassword = SecurePassword -plainTextPassword $password -salt $salt -profileKey $passwordProfile.Key -profileWorkFactor $passwordProfile.WorkFactor -profileStorageLength $passwordProfile.StorageLength

    Write-Host 'Email:'
    $email

    Write-host 'Salt:'
    [Convert]::ToBase64String($salt)

    Write-host 'Password hash'
    $hasedPassword
    
    $id = New-Guid
    $firstName = GenerateRandomString 20
    $lastName = GenerateRandomString 35
    $saltString = [Convert]::ToBase64String($salt)    
    $saveResult = SaveUser -connectionString $employerUsersConnectionString -id $id -firstName $firstName -lastName $lastName -email $email -password $hasedPassword -passwordProfileId $passwordProfile.Id -salt $saltString

    

    $user= [TestUser]@{ Id=$id; FirstName=$firstName; LastName=$lastName; Email=$email;Password=$hasedPassword;Salt=$saltString}
    return $user    
}

function Create-Account{
    param(
        $user,
        [int]    $apprenticeshipEmployerType,
        [string] $agreementName,
        [string] $employerAccountConnectionString,
        [string] $privateHashString,
        [string] $privateAllowedCharacters,
        [string] $publicHashString,
        [string] $publicAllowedCharacters,
        [string] $publicAllowedAccountLegalEntityCharacters,
        [string] $publicAllowedAccountLegalEntityHashSalt
    )

    function UpsertUser{
        param(
            [string] $connectionString,
            [string] $userRef, 
            [string] $firstName,
            [string] $lastName,
            [string] $email                        
          )        
                  
        $connection = new-object system.data.SqlClient.SQLConnection($connectionString)
        $command = new-object system.data.sqlclient.sqlcommand
        $command.Connection = $connection
        $command.CommandText = 'employer_account.UpsertUser'
        $command.CommandType = [System.Data.CommandType]::StoredProcedure
    
        $command.Parameters.AddWithValue('@userRef', $userRef)        
        $command.Parameters.AddWithValue('@firstName', $firstName)        
        $command.Parameters.AddWithValue('@lastName', $lastName)
        $command.Parameters.AddWithValue('@email', $email)
        $command.Parameters.AddWithValue('@correlationId', [DBNull]::Value)               
        
        $connection.Open()

        $result = $command.ExecuteNonQuery()   
        $connection.Close()
    
        $connection.Dispose()
        $command.Dispose()
    }

    function GetUserId{
        param(
            [string] $userRef, 
            [string] $employerAccountConnectionString
        )
        $query = "SELECT Id FROM [employer_account].[User] WHERE UserRef = '$userRef'"
        $user = Invoke-Sqlcmd -query $query -ConnectionString $employerAccountConnectionString
        return $user.Id
    }

    function CreateHashids{
        param(
            [string] $hashString,
            [string] $allowedCharacters,
            [string] $raw
        )
        
        $tmp = EncodeValue -salt $hashString -minHashLength 6 -alphabet $allowedCharacters -numbers $raw
        Write-Host $tmp
        
        return $tmp
    }


    function CreateEmployerAccount{
        param(            
            [string] $legalEntityName,
            [string] $employerAccountConnectionString,
            [int]    $apprenticeshipEmployerType
        )

        $query = "
        INSERT INTO [employer_account].[Account] (Name, CreatedDate, ApprenticeshipEmployerType)
		VALUES ('$legalEntityName', GETDATE(), $apprenticeshipEmployerType)
        GO
        SELECT SCOPE_IDENTITY() as Id 
        "

        $account = Invoke-Sqlcmd -Query $query -ConnectionString $employerAccountConnectionString
        return $account.Id
    }

    function UpdateEmployerAccountHashIds{
        param(
            [int] $accountId,
            [string] $accountHashedId,
            [string] $accountPublicHashedId,
            [string] $employerAccountConnectionString
            )

        $query = "UPDATE [employer_account].[Account] SET HashedId = '$accountHashedId', PublicHashedId = '$accountPublicHashedId' WHERE Id = $accountId"
        Invoke-Sqlcmd -Query $query -ConnectionString $employerAccountConnectionString            
    }
    

    function CreateMemebership{
        param(
            [int] $accountId,
            [int] $userId,
            [string] $employerAccountConnectionString
        )
        $query= "
            INSERT INTO [employer_account].[Membership] (AccountId, UserId, [Role])
		    VALUES ($accountId, $userId, 1)
        "
        Invoke-Sqlcmd -query $query -ConnectionString $employerAccountConnectionString
    }

    function GetEmployerAgreementTemplateByName{
        param(
            [string] $agreementName
        )
        $query = "SELECT AgreementType FROM [employer_account].[EmployerAgreementTemplate] WHERE PartialViewName = '$agreementName'"
        $agreementTemplate = Invoke-Sqlcmd -query $query -ConnectionString $employerAccountConnectionString
        return $agreementTemplate
    }

    function CreateLegalEntityWithAgreement{ 
        param(            
            [string] $accountId,
            #[string] $legalEntityCode, 
            #[string] $legalEntityName,
            #[string] $legalEntityRegisteredAddress,
            #[string] $legalEntityDateOfIncorporation,
            #[string] $legalEntityStatus, 
            #[string] $legalEntitySource,                   
            [string] $employerAccountConnectionString,
            [int]    $agreementType
          ) 
          
        Write-Debug $("Start CreateLegalEntityWithAgreement for accountId: $accountId")        
                  
        $connection = new-object system.data.SqlClient.SQLConnection($employerAccountConnectionString)
        $command = new-object system.data.sqlclient.sqlcommand
        $command.Connection = $connection
        $command.CommandText = '[employer_account].[CreateLegalEntityWithAgreement]'
        $command.CommandType = [System.Data.CommandType]::StoredProcedure        
        
        $command.Parameters.AddWithValue('@accountId',$accountId)
		$command.Parameters.AddWithValue('@companyNumber', '123456789') #  $legalEntityCode) 
        $command.Parameters.AddWithValue('@companyName', 'Auto Test Ltd') # $legalEntityName) 
		$command.Parameters.AddWithValue('@companyAddress', '1 High Street, Coventry, CV1 1HF') # $legalEntityRegisteredAddress)
		$command.Parameters.AddWithValue('@companyDateOfIncorporation', '2020-06-28 00:00:00.000')  #$legalEntityDateOfIncorporation)
		$command.Parameters.AddWithValue('@status', 'active') # $legalEntityStatus) 
		$command.Parameters.AddWithValue('@source', 1) #$legalEntitySource)
		$command.Parameters.AddWithValue('@publicSectorDataSource', [DBNull]::Value ) 
        $command.Parameters.AddWithValue('@agreementType', $agreementType) 
        $command.Parameters.AddWithValue('@sector', [DBNull]::Value )
			
        $outParameter = new-object System.Data.SqlClient.SqlParameter
        $outParameter.ParameterName = "@legalEntityId"
        $outParameter.Direction = [System.Data.ParameterDirection]'Output'
        $outParameter.Size = 8
        $command.Parameters.Add($outParameter) >> $null

        $outParameter2 = new-object System.Data.SqlClient.SqlParameter
        $outParameter2.ParameterName = "@employerAgreementId"
        $outParameter2.Direction = [System.Data.ParameterDirection]'Output'
        $outParameter2.Size = 8
        $command.Parameters.Add($outParameter2) >> $null		
        		
        $outParameter3 = new-object System.Data.SqlClient.SqlParameter
        $outParameter3.ParameterName = "@accountLegalEntityId"
        $outParameter3.Direction = [System.Data.ParameterDirection]'Output'
        $outParameter3.Size = 8
        $command.Parameters.Add($outParameter3) >> $null
		        
        $outParameter4 = new-object System.Data.SqlClient.SqlParameter
        $outParameter4.ParameterName = "@accountLegalEntityCreated"
        $outParameter4.Direction = [System.Data.ParameterDirection]'Output'
        $outParameter4.Size = 8
        $command.Parameters.Add($outParameter4) >> $null        

        $outParameter5 = new-object System.Data.SqlClient.SqlParameter
        $outParameter5.ParameterName = "@agreementVersion"
        $outParameter5.Direction = [System.Data.ParameterDirection]'Output'
        $outParameter5.Size = 4
        $command.Parameters.Add($outParameter5) >> $null        

        $connection.Open()
        try{

        $result = $command.ExecuteNonQuery()   

        }catch{
            LogMessage $_ #todo
        }

        $legalEntityId = $command.Parameters["@legalEntityId"].Value
        $employerAgreementId = $command.Parameters["@employerAgreementId"].Value
        $accountLegalEntityId = $command.Parameters["@accountLegalEntityId"].Value
        $accountLegalEntityCreated = $command.Parameters["@accountLegalEntityCreated"].Value
        $agreeentVersion = $command.Parameters["@agreementVersion"].Value
        
        $legalEntity = @{ legalEntityId=$legalEntityId; employerAgreementId=$employerAgreementId; accountLegalEntityId=$accountLegalEntityId; accountLegalEntityCreated=$accountLegalEntityCreated; agreementVersion=$agreeentVersion }
        return $legalEntity    

        $connection.Close()
    
        $connection.Dispose()
        $command.Dispose()        
    }

    function UpdateAccountLegalEntity_SetPublicHashedId{
        param(
         [string] $accountLegalEntityId,
         [string] $publicHashedId,
         [string] $employerAccountConnectionString
        )
        $query= "
           EXEC [Employer_account].[UpdateAccountLegalEntity_SetPublicHashedId] @accountLegalEntityId=$accountLegalEntityId, @PublicHashedId='$publicHashedId'
        "
        Invoke-Sqlcmd -query $query -ConnectionString $employerAccountConnectionString
    }

    function SignEmployerAgreement{
       param(
         [string] $employerAgreementId,
         [string] $userId,
         [string] $employerAccountConnectionString
        )
        $query= "
           DECLARE @now DATETIME = GETDATE()
           EXEC [employer_account].[SignEmployerAgreement] $employerAgreementId, $userId, 'Automated Test User', @now
        "
        Invoke-Sqlcmd -query $query -ConnectionString $employerAccountConnectionString
    }

    function UpdateAccountLegalEntity_SetSignedAgreement{
        param(
         [string] $accountLegalEntityId,
         [int] $signedAgreementVersion,
         [int] $signedAgreementId,
         [string] $employerAccountConnectionString
        )
        $query= "
           UPDATE [Employer_account].[AccountLegalEntity] SET SignedAgreementVersion = $signedAgreementVersion, SignedAgreementId=$signedAgreementId
           WHERE Id = $accountLegalEntityId
        "
        Invoke-Sqlcmd -query $query -ConnectionString $employerAccountConnectionString
    }

    function CreatePaye{
         param(
         [string] $payeRef,
         [string] $payeName,
         [string] $employerAccountConnectionString
        )
        $query= "
           EXEC [employer_account].[CreatePaye] '$payeRef', 'accessToken', 'refreshToken', '$payeName', null
        "
        Invoke-Sqlcmd -query $query -ConnectionString $employerAccountConnectionString
    }

    function CreateAccountHistory {
        param(
         [string] $accountId,
         [string] $payeRef,       
         [string] $employerAccountConnectionString
        )
        $query= "
           DECLARE @now DATETIME = GETDATE()
           EXEC [employer_account].[CreateAccountHistory] $accountId, '$payeRef', @now
        "
        Invoke-Sqlcmd -query $query -ConnectionString $employerAccountConnectionString
    }


    $employerUser = UpsertUser -connectionString $employerAccountConnectionString -userRef $user.Id -firstName $user.FirstName -lastName $user.LastName -email $user.Email 
    $userId = GetUserId -userRef $user.Id -employerAccountConnectionString $employerAccountConnectionString
    $userId
   
    $accountId = CreateEmployerAccount -accountHashedId $privateId -accountPublicHashedId $publicId -legalEntityName "testltd" -apprenticeshipEmployerType $apprenticeshipEmployerType -employerAccountConnectionString $employerAccountConnectionString 
    $accountId

    $privateId = CreateHashids -hashString $privateHashString -allowedCharacters $privateAllowedCharacters -raw $accountId
    $publicId = CreateHashids -hashString $publicHashString -allowedCharacters $publicAllowedCharacters -raw $accountId
    
    UpdateEmployerAccountHashIds -accountId $accountId -accountHashedId $privateId -accountPublicHashedId $publicId -employerAccountConnectionString $employerAccountConnectionString         

    CreateMemebership -accountId $accountId -userId $userId -employerAccountConnectionString $employerAccountConnectionString

    $agreementTemplate = GetEmployerAgreementTemplateByName -agreementName $agreementName

    $legalEntity = CreateLegalEntityWithAgreement -accountId $accountId -employerAccountConnectionString $employerAccountConnectionString -agreementType $agreementTemplate.AgreementType
    
    $publicLegalEntityHashId = CreateHashids -hashString $publicAllowedAccountLegalEntityHashSalt -allowedCharacters $publicAllowedAccountLegalEntityCharacters -raw $legalEntity.accountLegalEntityId

    UpdateAccountLegalEntity_SetPublicHashedId -accountLegalEntityId $legalEntity.accountLegalEntityId -publicHashedId $publicLegalEntityHashId -employerAccountConnectionString $employerAccountConnectionString

    SignEmployerAgreement -employerAgreementId $legalEntity.employerAgreementId -userId $userId -employerAccountConnectionString $employerAccountConnectionString

    UpdateAccountLegalEntity_SetSignedAgreement -accountLegalEntityId $legalEntity.accountLegalEntityId -signedAgreementVersion $legalEntity.agreementVersion -signedAgreementId $legalEntity.employerAgreementId -employerAccountConnectionString $employerAccountConnectionString
    
    $payerRef = GenerateRandomString(16) #'111/AB00001'
    CreatePaye -payeRef $payerRef -payeName "NA" -employerAccountConnectionString $employerAccountConnectionString
    CreateAccountHistory -accountId $accountId -payeRef $payerRef -employerAccountConnectionString $employerAccountConnectionString
}

function Create-TestLogin{
    param(
        [string] $email= "$(GenerateRandomString 10)@test.com",
        [string] $password= "test",
        [string] $employerUsersProfilesConnectionString = "Data Source=.; Integrated Security=SSPI; Initial Catalog=SFA.DAS.EmployerUsers.Profiles",
        [string] $employerUsersConnectionString = "Data Source=.; Integrated Security=SSPI; Initial Catalog=SFA.DAS.EmployerUsers.Users",
        [int]    $apprenticeshipEmployerType = 0,   #0 is NonLevy, 1 is Levy, 2 is Unknown
        [string] $employerAccountConnectionString = "Data Source=.; Integrated Security=SSPI; Initial Catalog=SFA.DAS.EAS.Employer_Account.Database",
        [string] $privateHashString = '',
        [string] $privateAllowedCharacters = '',
        [string] $publicHashString = '',
        [string] $publicAllowedCharacters = '',
        [string] $publicAllowedAccountLegalEntityHashStringCharacters = '',
        [string] $publicAllowedAccountLegalEntityHashStringSalt = '',
        [string] $agreementName = '_Agreement_V3'
    )

    $user = Create-EmployerUser -email $email -password $password -employerUsersProfilesConnectionString $employerUsersProfilesConnectionString -employerUsersConnectionString $employerUsersConnectionString 
    Create-Account -user $user -apprenticeshipEmployerType $apprenticeshipEmployerType -agreementName $agreementName -employerAccountConnectionString $employerAccountConnectionString -privateHashString $privateHashString -privateAllowedCharacters $privateAllowedCharacters -publicHashString $publicHashString -publicAllowedCharacters $publicAllowedCharacters -publicAllowedAccountLegalEntityCharacters $publicAllowedAccountLegalEntityHashStringCharacters -publicAllowedAccountLegalEntityHashSalt $publicAllowedAccountLegalEntityHashStringSalt

    # Need to return email, password, account id user id?
}