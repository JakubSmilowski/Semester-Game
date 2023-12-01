using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;

// Ther is validation of the input needed, becouse now when i type wrong letter it counts as a wrong answer.


namespace foodman
{
    class Program
    {
        public static int score = 0;
        public int Point = 0;

        // int he main just reference the  void quizz
        public static void Quizz()
        {
            // here we can modify the questions later
            string[] Questions = {"1. What is 2+2?: ", 
                                  "2. What is 3+3?: ", 
                                  "3. What is 4+4?: "};
            //the answers listed 
            string[] Answers = { 
                "A: 4\tB: 5\tC: 6",
                "A: 5\tB: 6\tC: 7",
                "A:6\tB: 7\tC: 8"
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
            public static void FactoryQuiz()
            {
            string[] CorrectAnswers = {"A", "A", "B"};
            score = 0;

            string[] Questions = {"1. How much food is wasted globally?: ", 
                                  "2. How much food is wasted in Denmark?: ", 
                                  "3. Which country wastes the most food?: "
                                  };
            
            string[] Answers = { 
                "A: 1.3 billion tons\tB: 10.5 billion tons\tC: 5.7 billion tons",
                "A: 700.000 tons\tB: 9.000.000 tons\tC: 50.000 tons",
                "A:India\tB: China\tC: USA"
            };
            

            for(int i = 0; i < Questions.Length ; i++)
            {
                 Console.WriteLine("******************");
                Console.WriteLine(Questions[i]);          
                Console.WriteLine(Answers[i]); 

             Console.WriteLine("Guess: ");            
                string? Guess = Console.ReadLine()?.ToUpper();  
                

                if(Guess == CorrectAnswers[i])
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
                Console.WriteLine("******************");
                Console.WriteLine($"Final score: {score}/{Questions.Length}");
                Console.WriteLine("******************");
            }
            public static void House()
            {
            string[] CorrectAnswers = {"A", "D", "D", "D", "C"};
            score = 0;

            string[] Questions = {"1. How much of the total food available at the consumption stage of the supply chain is overally wasted in households?: ", 
                                  "2. How to minimize wasting food on a daily basis?: ", 
                                  "3. What are some alternatives to throwing away food, that is not so fresh anymore?: ",
                                  "4. What should you do with food that is past its expiration date but appears and smells fine?",
                                  "5. What is the FIFO(First In, First Out) method used for in the context of food storage?"
                                  };
            
            string[] Answers = { 
                "A: 11%\tB: 7%\tC: 5%\tD: 2%",
                "A: By buying things according to the list of products needed for the planned weekly menu;\nB: By using whole foods, for instance, orange peel can be a nutritious add-on to your tea;\nC: By donating the excess food to, for instance, foodbanks;\nD: All of the above;",
                "A: Composting it, providing a great and nutrition-dense soil for plants when it expires; \nB:Repurposing it; for instance, using soft fruits or wilted vegetables for soups or smoothies;  \nC: Freezing leftovers, as this will enable you to enjoy them for a little bit longer; \nD: All of the above;",
                "A: Consume it without any concerns; \nB: Compost it immediately;  \nC: Donate it to a local food bank;  \nD: Inspect it for signs of spoilage before consuming;",
                "A: Creating shopping lists; \nB: Organizing your pantry alphabetically; \nC: Storing food in the order it was purchased or prepared; \nD: Determining food expiration dates;"
            };
            

            for(int i = 0; i < Questions.Length ; i++)
            {
                 Console.WriteLine("******************");
                Console.WriteLine(Questions[i]);          
                Console.WriteLine(Answers[i]); 

             Console.WriteLine("Guess: ");            
                string? Guess = Console.ReadLine()?.ToUpper();  
                

                if(Guess == CorrectAnswers[i])
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
                Console.WriteLine("******************");
                Console.WriteLine($"Final score: {score}/{Questions.Length}");
                Console.WriteLine("******************");
            }
    }
}