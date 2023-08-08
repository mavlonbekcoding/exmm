using System.Collections.Generic;
using System.Text.RegularExpressions;

class RegistrationService
{
    private List<User> Users = new List<User>();

    public bool CheckName(string firstName, string lastName, string middleName)
    {
        const string regexName = "^[a-zA-Z'-]+$";
        Regex regex = new Regex(regexName);
        if (!regex.IsMatch(firstName))
        {
            
        }
        if (!regex.IsMatch(lastName))
        {

        }
        if (!regex.IsMatch(middleName))
        {

        }
        // Name validation logic
        return !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);
    }

    public bool CheckEmailAddress(string email)
    {
        // Email validation logic
        return !string.IsNullOrEmpty(email) && email.Contains("@");
    }

    public string GenerateUserName(string firstName, string lastName)
    {
        // Generate a unique username logic
        return (firstName + lastName).ToLower();
    }

    public bool Add(string firstName, string lastName, string email, string username)
    {

        if (!CheckName(firstName, lastName, ""))
        {
            Console.WriteLine("Invalid first name or last name.");
            return false;
        }

        if (!CheckEmailAddress(email))
        {
            Console.WriteLine("Invalid email address.");
            return false;
        }

        if (Users.Exists(u => u.Email == email))
        {
            Console.WriteLine("Email address is already registered.");
            return false;
        }

        if (Users.Exists(u => u.Username == username))
        {
            Console.WriteLine("Username is already taken.");
            username = GenerateUserName(firstName, lastName);
        }

        var newUser = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Username = username,
            IsActive = false
        };

        Users.Add(newUser);
        SendEmail(email);
        return true;
    }

    public void Register(string firstName, string lastName, string email, string username)
    {
        if (Add(firstName, lastName, email, username))
        {
            SendEmail(email);
            var user = Users.Find(u => u.Email == email);
            if (user != null)
            {
                user.IsActive = true;
            }
        }
    }

    public bool SendEmail(string receiverAddress)
    {
        try
        {
            // Send email logic
            EmailService emailService = new EmailService("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
            emailService.SendEmail(receiverAddress);
            Console.WriteLine($"Email sent to {receiverAddress}");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
            return false;
        }
    }

    public void Display()
    {
        foreach (var user in Users)
        {
            Console.WriteLine($"Name: {user.FirstName} {user.LastName}, \nEmail: {user.Email}, \nUsername: {user.Username}, \nActive: {user.IsActive}\n");
        }
    }
}
