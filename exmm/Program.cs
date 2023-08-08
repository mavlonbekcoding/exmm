using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        RegistrationService registrationService = new RegistrationService();
    shit:

        Console.WriteLine("[1] - Register\n[2] - All Users\n[0] - Exit");
        var n = Console.ReadLine();

        if (n == "1")
        {

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter email address: ");
            string email = Console.ReadLine();

            string username = registrationService.GenerateUserName(firstName, lastName);

            if (registrationService.Add(firstName, lastName, email, username))
            {
                Console.WriteLine("User added successfully!");
            }
            else
            {
                Console.WriteLine("User registration failed.");
            }
        }
        else if (n == "2")
            registrationService.Display();
        else if (n == "0")
            return;
        goto shit;
    }
}
