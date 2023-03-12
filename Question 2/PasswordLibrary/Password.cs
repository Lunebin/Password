/*
 * Program:         PasswordLibrary.dll
 * Module:          Password.cs
 * Author:          T. Haworth
 * Date:            Feb 16, 2023
 * Description:     Defines a Password class that validates a user's new password.
 */

using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;
using Microsoft.Office;


namespace PasswordLibrary
{
    [Serializable]
    public class Password
    {
        // -------------- Password validation constants --------------
		
        private const int MinimumLength = 8, MaximumLength = 12;

        // ---------------- Private Member variables -----------------

        private string password = "";
        private bool ok = false;
        private readonly StringBuilder errors = new();

        // member variable
        Application member = new Application();

        // --------------------- Public Methods ----------------------

        public void SetPassword(string word)
        {
            password = word;
            ok = Test(word);
        } // end SetPassword()

        public string GetPassword()
        {
            return password;
        }// end GetPassword()

        public bool IsOk()
        {
            return ok;
        } // end IsOk()

        public string GetErrorMessage()
        {
            return errors.ToString();
        } // end GetErrorMessage()

        // dispose function
        public void Dispose()
        {
            member.Quit();
        }

        // ---------------------- Helper Methods ----------------------

        private bool Test(string word)
        {
            bool passes = true;
            errors.Clear();

            // Test password length
            if (word.Length < MinimumLength)
            {
                errors.Append(String.Format($"\n- Must be at least {MinimumLength} characters in length"));
                passes = false;
            }
            else if (word.Length > MaximumLength)
            {
                errors.Append(String.Format($"\n- Must be no longer than {MaximumLength} characters"));
                passes = false;
            }

            // Test for both upper and lower case letters
            if (!Regex.IsMatch(word, "[A-Z]") || !Regex.IsMatch(word, "[a-z]"))
            {
                errors.Append(String.Format($"\n- Must contain both upper and lower case letters"));
                passes = false;
            }

            // Test for a digit 
            if (!Regex.IsMatch(word, "[0-9]"))
            {
                errors.Append(String.Format($"\n- Must contain at least one digit"));
                passes = false;
            }

            // Test for a non-alphanumeric character
            if (Regex.IsMatch(word, "^[a-zA-Z0-9]+$"))
            {
                errors.Append(String.Format($"\n- Must contain at least one non-alphanumeric character"));
                passes = false;
            }

            if (errors.Length > 0)
            {
                // Remove first '\n'
                _ = errors.Remove(0, 1);
            }

            return passes;
        } // end Test()

    }
}