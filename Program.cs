using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChatBot
{
    class Program
    {
        //Path to the WAV file containing the welcome audio message.
        private const string V = "C:\\Users\\Cash\\Documents\\School Stuff\\Second Year\\First Semester\\PROG\\ICE Tasks & Assignments\\Greeting_audio.wav";

        static void Main(string[] args)
        {
            PlayWelcomeAudio(); //Call the function to play the audio.

            //Simulate chatbot interaction (replace with your actual chatbot logic)
            Console.WriteLine("Chatbot Initialized. You can start typing your questions.");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    break;
                }

                string response = ProcessUserInput(userInput);
                Console.WriteLine("Chatbot: " + response);

            }
        }

        public static void PlayWelcomeAudio()
        {
            try
            {
                //Path to the WAV file.
                string audioFilePath = V;

                //Checks if the file exists.
                if (File.Exists(audioFilePath))
                {
                    //Creates a SoundPlayer object.
                    SoundPlayer player = new SoundPlayer(audioFilePath);

                    Console.WriteLine("Attempt to play audio V");

                    //Plays audio file.
                    player.PlaySync(); //Play synchronously, waiting for the sound to finish.
                    player.Dispose(); //Release resources

                    Console.WriteLine("Welcome audio played successfully.");
                }
                else
                {
                    Console.WriteLine($"Audio file not found at: {audioFilePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
        }

        public static string ProcessUserInput(string input)
        {
            //For demonstration, echo the input.
            if (input.ToLower().Contains("help"))
            {
                return "I am a cybersecurity awareness bot. Ask me about online safety.";
            }
            else if (input.ToLower().Contains("password"))
            {
                return "Use a strong, unique password for each of your accounts.";
            }
            else
            {
                return "You said: " + input;
            }
        }
    }
}