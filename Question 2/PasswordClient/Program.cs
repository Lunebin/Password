/*
 * Program:         PasswordClient.exe
 * Module:          Program.cs
 * Author:          T. Haworth
 * Date:            Feb 16, 2023
 * Description:     A console client for a simple component application that vetts
 *                  a new password provided by the user.
 */

using PasswordLibrary;

namespace PasswordClient
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Password Selection Tool");

            // Create an instance of the Password class
            Password pwd = new();

            string passwordInput;

            do
            {

                // Ask the user to input a candidate password
                Console.Write("\nEnter a new password or ENTER to quit: ");
                passwordInput = Console.ReadLine()?.Trim() ?? "";

                if (passwordInput.Length > 0)
                {
                    // Initialize the Password object
                    pwd.SetPassword(passwordInput);

                    // Validate the new password
                    Console.WriteLine($"\nThe password '{pwd.GetPassword()}' is {(pwd.IsOk() ? "" : "not ")}accepted.\n");

                    // Report which rules (if any) the user's password fails
                    if (!pwd.IsOk())
                    {
                        Console.WriteLine("Your new password fails the following rules...");
                        Console.WriteLine(pwd.GetErrorMessage());
                    }

                }
            } while (passwordInput.Length > 0);

            Console.WriteLine("All done. Press a key to exit.");

            // dispose of the member object
            pwd.Dispose();

            Console.ReadKey();

        } // end Main()
    }
}