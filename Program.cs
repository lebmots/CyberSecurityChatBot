using System;
namespace CyberSecurityChatBot
{ 
class Program
{

    static void Main(string[] args)
    {
        Chatbot bot = new Chatbot();


        //Play greeting and display ASCII art
        bot.PlayGreeting();
        bot.DisplayAsciiArt();

        //Greet user and start chat
        string userName = bot.GreetUser();

        bot.StartChat();

        Console.WriteLine($"\nGoodbye, {userName}! Stay safe online.");
    }
}
}





