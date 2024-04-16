using System;
using System.Text.RegularExpressions;

namespace practice
{
    public class Validation
    {
        public Validation()
        {

        }

        public static bool Validate(string email, Action Success, Action Fail)
        {
            bool isValidated = false;
            string searchPattern = @"[a-zA-Z0-9_\.-]+\@[a-zA-Z0-9]+\.[a-zA-Z]+";
            if (Regex.IsMatch(email, searchPattern, RegexOptions.Compiled |
                                                RegexOptions.IgnoreCase |
                                                RegexOptions.Singleline))
            {
                Success();
                isValidated = true;
            }
            else
            {
                Fail();
                isValidated = false;
            }

            return isValidated;
        }

    }
}

/*
Email validation via netlibrary 16.04.2024
*/
using System;
// include .NET Standard library compiled in Windows
using TestNetStandard;
namespace testNet
{
 enum MenuActions : byte
 {
 VALIDATE =1,
 EXIT = 2
 }
 class Program
 {
 static void Main(string[] args)
 {
 while (true)
 {
 Menu();
 }
 }
 private static void Menu()
 {
 Console.WriteLine("Select action:\n1)\tValidate email;\n2)\tExit;");
 var action = (MenuActions)Convert.ToByte(Console.ReadLine());
 switch (action)
 {
 case MenuActions.VALIDATE:
 ExecValidation();
 break;
 case MenuActions.EXIT:
 Environment.Exit(0);
break;
 }
 }
 private static bool ExecValidation()
 {
 Console.WriteLine("Enter email");
 string email = Console.ReadLine();
 
 // Using Validation class from included library
 return Validation.Validate(email,
 () => { Console.WriteLine($"\n\x1b[32;1m{email} is 
validated\x1b[0m\n"); },
 () => { Console.WriteLine($"\n\x1b[31;4m{email} is not 
validated\x1b[0m\n"); });
 }}}

<Project Sdk="practic.sdk">
<PropertyGroup>
<OutputType>exe</OutputType>
<TargetFramework>netcoreapp3.1</TargetFramework>
<RuntimeIdentifiers>linux-x64</RuntimeIdentifiers>
</PropertyGroup>
<ItemGroup>
<Reference Include="TestNetStandard.dll" Version="1.0.0">
<HintPath>TestNetStandard.dll</HintPath>
</Reference >
</ItemGroup>
</Project>
