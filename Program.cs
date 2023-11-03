using System.Formats.Asn1;

namespace projectquizz
{
    class Program
    {
       
        // int he main just reference the  void quizz
        public static void Quizz()
        {
            // here we can modify the questions later
            string[] Questions = {"1. What is 2+2?: ", 
                                  "2. What is 3+3?: ", 
                                  "3. What is 4+4?: "};
            //the answers listed 
            string[] Answers = { 
                "A: 4\nB: 5\nC: 6",
                "A: 5\nB: 6\nC: 7",
                "A:6\nB: 7\nC: 8"
            };

            
            //correct answers
            string[] CorrectAnswers = {"A", "B", "C"};  //the only correct answer is the options in front of the answer so A or B or C

            
            int score = 0;

            Console.WriteLine("Quizz Game");

            //run a cycle until there are questions 

            for(int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine("******************");
                Console.WriteLine(Questions[i]);          // writes the questions one by one
                Console.WriteLine(Answers[i]);           // writes the answers for the question listed above
                

                Console.WriteLine("Guess: ");            // takes user input f
                string? Guess = Console.ReadLine()?.ToUpper();  // checks if its a string and puts it into uppercase
                

                if(Guess == CorrectAnswers[i])        // if the answer is correct it gives a point if not it doesnt
                {
                    Console.WriteLine("Correct");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect");
                }
                Console.WriteLine("******************");
                
            }
            //writes out final score 
            Console.WriteLine("******************");
            Console.WriteLine($"Final score: {score}/{Questions.Length}");
            Console.WriteLine("******************");
            
        }

       
        public static void Main()
        {
            Quizz();
        }
    }
}