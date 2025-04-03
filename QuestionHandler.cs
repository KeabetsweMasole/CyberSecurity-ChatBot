using System.Collections.Generic;
using System.Collections;
using System;

namespace POE
{
    //This class will handle users questions and provide appropriate answers.
    public class QuestionHandler
    {
        //List to store the replies that the CyberBot will give.
        private List<string> replies = new List<string>();
        private List<string> ignore = new List<string>();

        //Constructor for the QuestionHandler
        public QuestionHandler()
        {
            StoreIgnore();
            StoreReplies();
        } //End of Constructor

        //This method will handle user questions.
        public void HandleQuestions(string userName)
        {
            while (true)
            {
                //Prompts the user to enter a question.
                Console.WriteLine("CSB AI: Enter your question (or 'exit' to go back to the main menu):");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(userName + " -> ");
                string question = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;

                //Checking if the user wants to exit.
                if (question?.ToLower() == "exit")
                {
                    Console.WriteLine("Goodbye! " + userName);
                    return;
                }

                //Splitting the question into words.
                string[] words = question.Split(' ');
                ArrayList filteredWords = new ArrayList();

                //Filtering out common words.
                foreach (string word in words)
                {
                    if (!ignore.Contains(word.ToLower()))
                    {
                        filteredWords.Add(word);
                    }
                }

                //Checking if the words are in the replies.
                bool found = false;
                string message = string.Empty;

                foreach (string word in filteredWords)
                {
                    foreach (string reply in replies)
                    {
                        if (reply.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            message += reply + "\n";
                            found = true;
                        }
                    }
                }

                //Displays the appropriate responses.
                if (found)
                {
                    Console.WriteLine("Chat AI -> " + message);
                }
                else
                {
                    Console.WriteLine("Chat AI -> I'm only allowed to provide information about cybersecurity. Please ask a cybersecurity-related question.");
                }
            }//End of while loop.

        } //End of HandleQuestions method

        //This method stores predefined replies related to cybersecurity questions.
        private void StoreReplies()
        {
            replies.Add("Here's what I found about 'password' -> Always use strong passwords with a mix of letters, numbers, and symbols.");
            replies.Add("Here's what I found about 'phishing' -> Be cautious of emails or messages asking for personal details; verify the sender.");
            replies.Add("Here's what I found about 'malware' -> Avoid downloading files from unknown sources to prevent malware infections.");
            replies.Add("Here's what I found about 'firewall' -> Firewalls help block unauthorized access to your network.");
            replies.Add("Here's what I found about a 'vpn' -> A VPN encrypts your internet traffic, keeping your online activity private.");
            replies.Add("Here's what I found about 'encryption' -> Encryption helps protect your sensitive data from unauthorized access.");
            replies.Add("Here's what I found about a '2fa' -> Two-Factor Authentication adds an extra layer of security to your accounts.");
            replies.Add("Here's what I found about 'ransomware' -> Never open suspicious attachments, and always back up your important files.");
            replies.Add("Here's what I found about 'antivirus' -> Keep your antivirus software updated to protect against threats.");
            replies.Add("Here's what I found about 'social engineering' -> Cybercriminals use manipulation to steal confidential information, stay alert.");
            replies.Add("Here's what I found about 'cybersecurity' -> Cybersecurity is the practice of protecting systems and data from digital attacks.");
            replies.Add("Here's what I found about 'hacking' -> Ethical hackers help organizations secure their systems, but illegal hacking is a crime.");
            replies.Add("Here's what I found about 'data breach' -> A data breach is a security incident where sensitive information is exposed.");

        } //End of StoreReplies method

        //Stores common words that should be ignored during question processing.
        private void StoreIgnore()
        {
            //Common words to ignore.
            ignore.AddRange(new List<string>
            {
                "is", "the", "a", "an", "what", "how", "there", "why", "when", "where", "does", "do", "tell",
                "are", "can", "could", "should", "would", "i", "me", "my", "you", "your", "we", "our", "about",
                "is", "the", "a", "an", "what", "how", "there", "why", "when", "where", "does", "do",
                "are", "can", "could", "should", "would", "i", "me", "my", "you", "your", "we", "our",
                "it", "to", "this", "that", "these", "those", "has", "have", "had", "was", "were",
                "and", "or", "but", "so", "on", "at", "with", "by", "from", "in", "of", "for", "about"
            });

        } // End of StoreIgnore method.

    } // End of QuestionHandler class.

} // End of namespace.