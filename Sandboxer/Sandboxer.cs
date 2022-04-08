using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sandboxer
{
    public class Sandboxer : MarshalByRefObject
    {
        static string pathToUntrusted = "";
        static string untrustedAssembly = "";
        private static string[] parameters = { };
        private static string[] selectedPerms = { };
        static PermissionSet permSet;

        //SETTERS FOR UI
        public static void SetParameters(string[] para) { parameters = para; }
        public static void SetSelectedPerms(string[] perms) { selectedPerms = perms; }
        public static void SetPathToUntrusted(string path) { pathToUntrusted = path ; }
        public static void SetUntrustedAssembly(string asm) { untrustedAssembly = asm; }
        [STAThread]
        static void Main(string[] args)
        {
            if (VerifyArguments(args))
            {
                HandleArguments(args);
            }
            else {
                Console.WriteLine("Error in input, please check the manual for correct format.");
            }
        }
        public static void Begin() {
            //This method, along with ExecuteUntrustedCode is based on code on "How to run partially trusted code in a sandbox"
            //https://docs.microsoft.com/en-us/previous-versions/dotnet/framework/code-access-security/how-to-run-partially-trusted-code-in-a-sandbox?redirectedfrom=MSDN
            permSet = new PermissionSet(PermissionState.None);
            permSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            PermissionSelection(selectedPerms);

            AppDomainSetup adSetup = new AppDomainSetup();
            adSetup.ApplicationBase = Path.GetFullPath(pathToUntrusted);
            StrongName fullTrustAssembly = typeof(Sandboxer).Assembly.Evidence.GetHostEvidence<StrongName>();
            AppDomain newDomain = AppDomain.CreateDomain("Sandbox", null, adSetup, permSet, fullTrustAssembly);

            ObjectHandle handle = Activator.CreateInstanceFrom(
                newDomain, typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName,
                typeof(Sandboxer).FullName
                );
            
            Sandboxer newDomainInstance = (Sandboxer)handle.Unwrap();
            try
            {
                newDomainInstance.ExecuteUntrustedCode(untrustedAssembly, parameters);
            }
            catch (Exception e) { Console.WriteLine("Error\n" + e.Message); }

        }

        public void ExecuteUntrustedCode(string assemblyName, string[] parameters)
        {
            MethodInfo targetMethod = Assembly.Load(assemblyName).EntryPoint;
            try
            {
                var testing = targetMethod.Invoke(null, new object[] { parameters });
                //reset the parameters and permissions, allows reruns of programs with altered paramters and permissions when using the UI 
                parameters = new string[] { };
                selectedPerms = new string[]{ }; 
            }
            catch (Exception ex)
            {
                new PermissionSet(PermissionState.Unrestricted).Assert();
                Console.WriteLine("-------------------------\nException caught:\n{0}\n\n", ex.ToString());
                CodeAccessPermission.RevertAssert();
            }
        }
        public static string[] PathSeparate(string path) {
            //this method takes a full file path and separates the file name from its directory
            for (int i = path.Length - 1; i > 0; i--) {
                //looping backward until a '\' is found, suggesting before and after that point is the dir and the filename
                if (path[i].Equals('\\')) {
                    string pathSplit = path.Substring(0, i);
                    string assemblySplit = path.Substring(i + 1, (path.Length - pathSplit.Length) - 1);
                    if (assemblySplit.Contains(".exe")) {
                        assemblySplit = Path.GetFileNameWithoutExtension(assemblySplit);
                    }
                    return new string[2] { pathSplit, assemblySplit };
                }
            }
            return null;
        }

        public static void HandleArguments(string[] args) {

            if (args.Length == 0) 
            {
                //no arguments, run UI
                Application.Run(new SandboxerUI());
                Console.SetOut(new TextBoxWriter(SandboxerUI.OutputTextBox));

            }
            else
            {
                //with arguments, the first has to be the file path
                pathToUntrusted = args[0];
                if (args.Length > 1)
                {  //more than just the file path in the args, including >=1 parameter(s)
                    List<string> tempArgs = new List<string>();
                    List<string> tempPermArgs = new List<string>();
                    for (int i = 1; i < args.Length; i++)
                    {
                        if (args[i].StartsWith("--"))
                        {
                            tempPermArgs.Add(args[i]);
                        }
                        else
                        {
                            tempArgs.Add(args[i]);
                        }
                    }
                    selectedPerms = tempPermArgs.ToArray();
                    parameters = tempArgs.ToArray();

                    string[] pathAndAssembly = PathSeparate(pathToUntrusted);
                    pathToUntrusted = pathAndAssembly[0];
                    untrustedAssembly = pathAndAssembly[1];

                    Begin();
                }
            }
        }

        public static bool VerifyArguments(string[] args) {
            if (args.Length == 0) {
                //0 arguments, nothing to verify, return true and run UI
                return true;
            }
            if (File.Exists(args[0])) {
                if (args.Length == 1) { 
                    //only 1 argument and the file at the path exists.
                    return true; 
                }
                Regex acceptedInput = new Regex(@"^[a-zA-Z0-9-' ]+$");
                //match the remaining arguments to a regular expression. special characters for the most part are not allowed
                //allowed enough for most english names
                for (int i = 1; i < args.Length; i++) 
                {
                    if (!acceptedInput.IsMatch(args[i])) 
                    {
                        Console.WriteLine(args[i] + " is not a valid input.");
                        return false; 
                    }
                }
                return true;
            }
            return false;
        }

        public static void PermissionSelection(string[] selectedPerms) {

            foreach (string perm in selectedPerms) {
                switch (perm.ToLower().Replace("--","")) {
                    case "io":
                        permSet.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
                        break;
                    case "filedialog":
                        permSet.AddPermission(new FileDialogPermission(PermissionState.Unrestricted));
                        break;
                    case "reflection":
                        permSet.AddPermission(new ReflectionPermission(PermissionState.Unrestricted));
                        break;
                    case "registry":
                        permSet.AddPermission(new RegistryPermission(PermissionState.Unrestricted));
                        break;
                    case "ui":
                        permSet.AddPermission(new UIPermission(PermissionState.Unrestricted));
                        break;
                    case "environment":
                        permSet.AddPermission(new EnvironmentPermission(PermissionState.Unrestricted));
                        break;
                    case "unrestricted":
                        permSet = new PermissionSet(PermissionState.Unrestricted);
                        break;
                    case "security":
                        permSet.AddPermission(new SecurityPermission(PermissionState.Unrestricted));
                        break;
                    default:
                        Console.WriteLine("Permission " + perm + " is not a valid permission, check the manual for acceptable permissions.");
                        break;
                }
            }

        }

    }
}
