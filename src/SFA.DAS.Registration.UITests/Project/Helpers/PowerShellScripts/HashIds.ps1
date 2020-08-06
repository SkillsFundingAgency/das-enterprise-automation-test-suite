function EncodeValue {
    param (
        $alphabet,
        $seps,
        $minHashLength,
        $salt,
        $numbers
    )

    $LOG_ENABLED = $false
    $SEP_DIV = 3.5;
    $GUARD_DIV = 12.0;
    $DEFAULT_ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    $DEFAULT_SEPS = "cfhistuCFHISTU";
    $MIN_ALPHABET_LENGTH = 16;

   # $guardsRegex;
   # $sepsRegex;

    $global:guards = $null
    $global:alphabet = $alphabet
    $global:seps = $seps
    $global:minHashLength = $minHashLength
    $global:salt = $salt

    # <summary>
    # 
    # </summary>
    # <param name="alphabet"></param>
    # <param name="salt"></param>
    # <returns></returns>
    function ConsistentShuffle {
        param($alphabet, $salt)

        log("alphabet from Shuffle: " + $alphabet)
        log("salt from Shuffle: " + $salt)

        if ([string]::IsNullOrWhiteSpace($salt)) {
            return $alphabet;
        }

        $n;
        $letters = $alphabet.ToCharArray();

        $i = $letters.Length - 1
        $v = 0
        $p = 0

        for (; $i -gt 0; $i--, $v++)
        {
            $v %= $salt.Length;
            $p += ($n = [byte][char]$salt[$v]) # get the ascii value not the char at position
            $j = ($n + $v + $p) % $i;

            # swap characters at positions i and j
            
            $temp = $letters[$j];
            $letters[$j] = $letters[$i];
            $letters[$i] = $temp;        
        }

        log("Letters from Shuffle: >" + $letters + "<")

        return $letters;
    }

    function SetupSeps() {
        
        # seps should contain only characters present in alphabet; 
        $global:seps = -join [System.Linq.Enumerable]::Intersect($global:seps, $global:alphabet)

        log ("Seps in alphabet: " + $global:seps)
        log ("Alphabet " + $global:alphabet)

        # alphabet should not contain seps.
        $global:alphabet = -join [System.Linq.Enumerable]::Except($global:alphabet.ToCharArray(), $global:seps.ToCharArray())
        log ("Alphabet without seps " + $global:alphabet)

        $global:seps = ConsistentShuffle -alphabet $global:seps -salt $global:salt;
        $global:seps = -join $global:seps

        log ("Shuffled Seps: >" + $global:seps + "<")
        log("SEP_DIV: " + $SEP_DIV)
        log("global:alphabet.Length: " + $global:alphabet.Length)
        log("global:seps.Length: " + $global:seps.Length)
        log("div: " + [Math]::Floor($global:alphabet.Length / $global:seps.Length))

        if ($global:seps.Length -eq 0 -or [Math]::Floor($global:alphabet.Length / $global:seps.Length) -gt $SEP_DIV)
        {
            $sepsLength = [int][Math]::Ceiling($global:alphabet.Length / $SEP_DIV)

            log("sepsLength: " + $sepsLength)
            log("seps.Length: " + $global:seps.Length)
            
            if ($sepsLength -eq 1) {
                $sepsLength = 2;
            }

            if ($sepsLength -gt $global:seps.Length) {
                $diff = $sepsLength - $global:seps.Length
                $global:seps += $global:alphabet.Substring(0, $diff)
                $global:alphabet = $global:alphabet.Substring($diff)
            }

            else {
                $global:seps = $global:seps.Substring(0, $sepsLength)
            }
        }
       
        log ("SetupSeps Seps: " + $global:seps)
        log ("SetupSeps Alpha " + $global:alphabet)

        log ("Salt: " + $global:salt);
        $global:alphabet = ConsistentShuffle -alphabet $global:alphabet -salt $global:salt
        $global:alphabet = -join $global:alphabet

        log ("Shuffled Alphabet " + $global:alphabet)

        #return New-Object -TypeName System.Text.RegularExpressions.RegEx -ArgumentList ([string]::Concat("[", $global:seps, "]"))
    }

    function SetupGuards() {

        $guardCount = [int][Math]::Ceiling($global:alphabet.Length / $GUARD_DIV);

        log("guardCount " + $guardCount)
        log("SetupGuards alphabet " + $global:alphabet)

        if ($global:alphabet.Length -lt 3) {
            $global:guards = $global:seps.Substring(0, $guardCount);
            $global:seps = $global:seps.Substring($guardCount);
        }

        else {        
            $global:guards = $global:alphabet.Substring(0, $guardCount);
            $global:alphabet = $global:alphabet.Substring($guardCount); 
        }

        log("SetupGuards alphabet " + $global:alphabet)

        #return New-Object -TypeName System.Text.RegularExpressions.RegEx -ArgumentList ([string]::Concat("[", $global:guards, "]"))
    }

    function Hash([long]$inp) {
        $hash = ""
        $len = $global:alphabet.Length

        log("len " + $len)

        do {
            $ins = $global:alphabet[[int]($inp % $len)]
            $hash = $ins + $hash
            $inp = [Math]::Floor($inp / $len) # PowerShell rounds up, C# rounds down when casting to int
        } while ($inp -gt 0)

        return $hash
    }

    # <summary>
    # Internal function that does the work of creating the hash
    # </summary>
    # <param name="numbers"></param>
    # <returns></returns>
    function GenerateHashFrom($numbers) {

        if ($null -eq $numbers -or $numbers.Length -eq 0) {
            return [string]::Empty
        }

        $ret = New-Object -TypeName System.Text.StringBuilder

        $numbersHashInt = 0;
        for ($i = 0; $i -lt $numbers.Length; $i++) {
            $numbersHashInt += [int]($numbers[$i] % ($i + 100))
        }

        $lottery = $global:alphabet[[int]($numbersHashInt % $global:alphabet.Length)]

        $ret.Append($lottery.ToString()) | Out-Null 

        for ($i = 0; $i -lt $numbers.Length; $i++) {

            $number = $numbers[$i];
            $buffer = $lottery + $salt + $alphabet;

            $global:alphabet = ConsistentShuffle -alphabet $global:alphabet -salt $buffer.Substring(0, $global:alphabet.Length)
            $global:alphabet = -join $global:alphabet
            
            log("GenerateTheHashFrom >" + $global:alphabet + "<")
            log("number " + $number)

            $last = Hash -inp $number

            log ("last >" + $last + "<")

            $ret.Append($last) | Out-Null 

            if ($i + 1 -lt $numbers.Length) {
                $number %= ([int]$last[0] + $i)
                $sepsIndex = ([int]$number % $global:seps.Length)
                $ret.Append($global:seps[$sepsIndex]) | Out-Null 
            }
        }

        if ($ret.Length -lt $minHashLength) {
            $guardIndex = ([int]($numbersHashInt + [int]$ret[0]) % $global:guards.Length)
            $guard = $global:guards[$guardIndex]

            log ("Guard:" + $guard)

            $ret.Insert(0, $guard) | Out-Null 

            if ($ret.Length -lt $minHashLength) {
                $guardIndex = ([int]($numbersHashInt + [int]$ret[2]) % $global:guards.Length)
                $guard = $global:guards[$guardIndex]
                $ret.Append($guard) | Out-Null 
            }
        }

        $halfLength = [int]($global:alphabet.Length / 2)
        while ($ret.Length -lt $minHashLength) {

            $global:alphabet = ConsistentShuffle -alphabet $global:alphabet -salt $global:alphabet
            $global:alphabet = -join $global:alphabet
            
            log ("Alpha " + $global:alphabet)
            log ("halfLength " + $halfLength)
            log ("ret " + $ret)
            log ("retLength " + $ret.Length)
    
            $ret.Insert(0, $global:alphabet.Substring($halfLength)) | Out-Null 
            $ret.Append($global:alphabet.Substring(0, $halfLength)) | Out-Null 

            $excess = $ret.Length - $minHashLength
            log ("excess " + $excess)

            if ($excess -gt 0) {
                log ("rnd " + ($excess / 2))
                $ret.Remove(0, [int][Math]::Floor($excess / 2)) | Out-Null  # rounding up, orig rounds down
                $ret.Remove($minHashLength, ($ret.Length - $minHashLength)) | Out-Null 
            }
        }

        return $ret.ToString()
    }

    # <summary>
    # Encodes the provided numbers into a hashed string
    # </summary>
    # <param name="numbers">the numbers to encode</param>
    # <returns>the hashed string</returns>
    function Encode($numbers) {
        return GenerateHashFrom $numbers    
    }


    function log($message) {
        if ($LOG_ENABLED -eq $true) {
            Write-Host "Log Message: " $message
        }
    }

    # main

    if( [string]::IsNullOrEmpty($global:alphabet) ) {
        $global:alphabet = $DEFAULT_ALPHABET
    }

    if( [string]::IsNullOrEmpty($global:seps) ) {
        $global:seps = $DEFAULT_SEPS
    }

    if( $null -eq $global:salt ) {
        $global:salt = ""
    }

    if( [int]$numbers -lt 0 ) {
        return ""
    }

    $global:alphabet = -join [System.Linq.Enumerable]::Distinct($global:alphabet.ToCharArray())

    log ("Salt: " + $salt)
    log ("Distinct Alphabet: " + $global:alphabet)
    log( $global:alphabet.Length)
    log("Numbers: " + $numbers)

    try {

        if ($global:alphabet.Length -lt $MIN_ALPHABET_LENGTH) {
            throw "alphabet must contain atleast $MIN_ALPHABET_LENGTH unique characters."
        }

        SetupSeps
        SetupGuards

        [int[]]$numArray = $numbers # Encode expects an array of numbers but I only pass one

        return Encode($numArray)

    } catch {
        Write-Error "An Error occurred:  $PSItem.Exception.Message"
    }
}