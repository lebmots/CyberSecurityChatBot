using System;
using System.Media;
using System.Threading;
using System.Collections.Generic;


namespace CyberSecurityChatBot
{
    public class Chatbot
    {
        // List to store predefined responses and keywords
        private List<string> responses;
        private List<string> keywords;

        // Constructor to initialize responses and keywords
        public Chatbot()
        {
            responses = new List<string>()
            {
            // 1. General Responses
            "How are you? I'm doing great, thanks for asking!",
            "I am a cybersecurity awareness bot. My purpose is to help you stay safe online.",
            "You can ask me about password safety, phishing, or safe browsing.",
            "I'm here to assist you with cybersecurity tips. What would you like to know?",
            "I didn't quite understand that. Could you rephrase?",

            // 2. Password Safety Topics
            "To create a strong password, use a mix of uppercase and lowercase letters, numbers, and symbols. Avoid using easily guessable patterns.",
            "Make your passwords at least 12-16 characters long to improve security.",
            "Reusing passwords across multiple sites increases your vulnerability. Always use a unique password for each account.",
            "Consider using a password manager to store and generate secure passwords for all your accounts.",
            "Enable Two-Factor Authentication (2FA) to add an extra layer of security to your accounts.",
            "Biometric authentication (like fingerprints or facial recognition) can make your login more secure.",
            "Always set up password recovery options (like email or phone number) to regain access to your account in case you forget your password.",
            "Avoid managing passwords or logging into sensitive accounts on public Wi-Fi as it can expose your data to hackers.",
            "When answering security questions, avoid using information that is easily guessable, like your mother’s maiden name or your pet’s name.",
            "Test the strength of your passwords with an online password strength checker to ensure they are not too weak.",
            "Changing your passwords regularly can help reduce the risk of long-term exposure in case of a breach.",
            "Never share your passwords with others or write them down in an insecure location.",
            "Encrypting your password storage is crucial for protecting your sensitive login information.",
            "Avoid using predictable passwords like '123456' or 'password'. These can be easily guessed or cracked.",
            "Single Sign-On (SSO) allows you to use a single login for multiple services, but ensure the service is secure before using it.",

            // 3. Phishing Topics
            "Phishing is a fraudulent attempt to steal sensitive information such as usernames, passwords, or credit card details by pretending to be a trustworthy entity.",
            "Phishing emails often look like legitimate messages from well-known companies. Always double-check the sender’s email address and the website's URL before clicking on links.",
            "Never open email attachments or click on links from unknown senders. These could contain malware or lead to phishing sites.",
            "If you receive an email asking for sensitive information like your password, contact the company directly to verify its legitimacy before responding.",
            "Phishing attempts can occur over phone calls (vishing) or text messages (smishing). Be cautious of unsolicited communications asking for your personal information.",
            "Look for signs of phishing in websites, like misspelled URLs or insecure 'http' instead of 'https' in the address bar.",
            "If you think you've fallen for a phishing attack, change your passwords immediately and notify the company or website involved.",
            "Phishing scams can even use social engineering, where attackers impersonate someone you know, to trick you into giving away personal information.",
            "Always verify any suspicious requests for financial transactions, especially if they come through email or messaging apps.",
            "Phishing sites often mimic the look and feel of legitimate websites. Check the URL carefully and look for any discrepancies in the design or language used on the site.",

            // 4. Safe Browsing Topics
            "When browsing online, always ensure that websites are secure by checking for 'https' in the URL and a padlock icon.",
            "Avoid clicking on pop-up ads as they may lead to malicious websites or install unwanted software.",
            "Use a reputable antivirus program to protect your computer from malicious software and phishing attempts.",
            "Keep your browser and operating system up-to-date to ensure you have the latest security patches.",
            "Use an ad blocker or anti-tracking software to protect your privacy when browsing the internet.",
            "Clear your browser history and cache regularly to remove tracking data and reduce the risk of personal information exposure.",
            "Be cautious when downloading files from the internet. Only download from trusted websites to avoid malware infections.",
            "Enable 'Do Not Track' in your browser settings to minimize tracking by third-party advertisers.",
            "Be mindful of phishing websites disguised as popular social media platforms. Always verify the URL before logging in.",
            "Use Virtual Private Networks (VPNs) when browsing on public Wi-Fi networks to ensure your connection is encrypted and secure."
        };

            keywords = new List<string>()
            {
            "password", "strong password", "password manager", "two-factor authentication", "biometric", "password recovery",
            "public Wi-Fi", "security question", "password strength", "password change", "password sharing", "password encryption",
            "predictable password", "single sign-on", "phishing", "email phishing", "vishing", "smishing", "phishing websites",
            "malware", "phishing attacks", "phishing scam", "phishing prevention", "phishing link", "phishing email",
            "safe browsing", "https", "browser security", "ad blocker", "VPN", "safe downloads"
        };
    }

            // Play voice greeting
            public void PlayGreeting()
                {
                    try
                    {
                        SoundPlayer player = new SoundPlayer("text2voice.wav");
                        player.PlaySync(); 
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error playing greeting: " + ex.Message);
                    }
                }

                // Display ASCII Art
                public void DisplayAsciiArt()
                {
                    string asciiArt = @"
________ ________ ________ ________ ________
|\ __ \ |\ __ \ |\ __ \ |\ __ \ |\ __ \
\ \ \|\ \\ \ \|\ \\ \ \|\ \\ \ \|\ \\ \ \|\ \
\ \ ____\\ \ __ \\ \ \\\ \\ \ __ \\ \ __ \
\ \ \___| \ \ \ \ \\ \ \\\ \\ \ \ \ \\ \ \ \ \
\ \__\ \ \__\ \__\\ \_______\\ \__\ \__\\ \__\ \__\
\|__| \|__|\|__| \|_______| \|__|\|__| \|__|\|__|
";
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(asciiArt);
    Console.ResetColor();
                }

                // Ask the user for their name and personalize the greeting
                public string GreetUser()
                {
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Hello {name}, welcome to the Cybersecurity Awareness Bot!");
                    return name;
                }

                // Handle user input and provide responses based on predefined keywords or questions
                public void HandleUserInput(string input)
                {
                    bool responseGiven = false;
                    foreach (var keyword in keywords)
                    {
                        if (input.Contains(keyword))
                        {
                            int index = keywords.IndexOf(keyword);
                            Console.WriteLine(responses[index]);
                            responseGiven = true;
                            break;
                        }
                    }

                    if (!responseGiven)
                    {
                        Console.WriteLine(responses[4]); // Default response
                    }
                }

                // Main chatbot functionality to interact with the user
                public void StartChat()
                {
                    string userInput;
                    Console.WriteLine("What can I help you with? Or press X to exit.");
                    while (true)
                    {
                        userInput = Console.ReadLine();
                        if (userInput.ToLower() == "x")
                        {
                            Console.WriteLine("Goodbye! Stay safe online.");
                            break;
                        }
                        HandleUserInput(userInput.ToLower());
                    }
                }
            }
        }

