using System;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Text;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public static partial class PowerShellScriptWrapper
    {
        const string CreateUserScriptResourceName = "SFA.DAS.Automation.PowerShellScriptWrapper.PowerShellScripts.CreateUser.ps1";
        const string HashIdsScriptResourceName = "SFA.DAS.Automation.PowerShellScriptWrapper.PowerShellScripts.HashIds.ps1";
        const string FunctionName = "Create-TestLogin";
        public async static void CreateRegistrationsUser(CreateUserScriptConfiguration configuration)
        {
            configuration.Validate();

            var sessionState = InitialSessionState.CreateDefault();
            sessionState.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.Unrestricted;

            string userScript;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(CreateUserScriptResourceName))
            using (var streamReader = new StreamReader(stream))
            {
                userScript = streamReader.ReadToEnd();
            }

            string hashidsScript;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(HashIdsScriptResourceName))
            using (var streamReader = new StreamReader(stream))
            {
                hashidsScript = streamReader.ReadToEnd();
            }

            if (string.IsNullOrWhiteSpace(userScript) || string.IsNullOrWhiteSpace(hashidsScript))
            {
                throw new InvalidOperationException("Unable to load UserCreation Scripts or dependencies");
            }

            using (var runspace = RunspaceFactory.CreateRunspace(sessionState))
            {
                try
                {
                    runspace.Open();
                    using (var powershell = PowerShell.Create(runspace))
                    {
                        powershell.Commands.AddCommand("Import-Module").AddArgument("SqlServer");
                        powershell.AddScript(hashidsScript, false).Invoke();
                        powershell.AddScript(userScript, false).Invoke();
                        powershell.Commands.Clear();

                        powershell.AddCommand(FunctionName)
                                .AddParameter("email", configuration.Email)
                                .AddParameter("password", configuration.Password)
                                .AddParameter("apprenticeshipEmployerType", (int)configuration.ApprenticeshipEmployerType)
                                .AddParameter("privateHashString", configuration.PrivateAccountHashSalt)
                                .AddParameter("privateAllowedCharacters", configuration.PrivateAccountHashAllowedCharacters)
                                .AddParameter("publicHashString", configuration.PublichAccountHashSalt)
                                .AddParameter("publicAllowedCharacters", configuration.PublicAccountHashAllowedCharacters)
                                .AddParameter("publicAllowedAccountLegalEntityHashStringCharacters", configuration.PublicLegalEntityHashAllowedCharacters)
                                .AddParameter("publicAllowedAccountLegalEntityHashStringSalt", configuration.PublicLegalEntityHashSalt)
                                .AddParameter("agreementName", configuration.AgreementName)
                                .AddParameter("employerUsersProfilesConnectionString", configuration.EmployerUsersProfilesConnectionString)
                                .AddParameter("employerUsersConnectionString", configuration.EmployerUsersConnectionString)
                                .AddParameter("employerAccountConnectionString", configuration.EmployerAccountsConnectionString);


                        var result = await powershell.InvokeAsync();

                        if (powershell.HadErrors)
                        {
                            var errors = powershell.Streams.Error;
                            Console.ForegroundColor = ConsoleColor.Red;
                            var stringBuilder = new StringBuilder();
                            foreach (var error in powershell.Streams.Error)
                            {
                                stringBuilder.AppendLine(error.Exception.Message);
                                Console.WriteLine(error.Exception.Message);
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            var innerException = new InvalidOperationException(stringBuilder.ToString());
                            throw new InvalidOperationException("Errors occurred during Powershell Script invocation", innerException);
                        }

                        foreach (var item in result)
                        {
                            Console.WriteLine(item.BaseObject.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }

            }
        }
    }
}
