using System.Formats.Asn1;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

// Ther is validation of the input needed, becouse now when i type wrong letter it counts as a wrong answer.


namespace foodman
{
    class Program
    {
        public static int score = 0;
        public int Point = 0;

        // int he main just reference the  void quizz
        public static void RestarauntQuizz()
        {
            // here we can modify the questions later
            string[] Questions = {"1. On average, what percentage of food purchased by restaurants ends up as food waste?: ", 
                                  "2. How can a restaurant effectively minimize food waste in its kitchen?: ", 
                                  "3. Why is it important for restaurants to track and analyze their food waste?: "};
            //the answers listed 
            string[] Answers = { 
                "A: 10%\tB: 25%\tC: 40%",
                "A: Implementing a pre-packaged menu to control portions\tB:  Donating surplus food to local charities\tC: Increasing portion sizes to meet customer expectations",
                "A: To boast about sustainable practices\tB: To identify areas for improvement and reduce costs\tC: To create an illusion of scarcity and increase demand"
           
            };

            //correct answers
            string[] CorrectAnswers = {"C", "B", "B"};  //the only correct answer is the options in front of the answer so A or B or C
             //the only correct answer is the options in front of the answer so A or B or C


            int score = 0;

            Console.WriteLine("Quizz Game");

            //run a cycle until there are questions 

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine("******************");
                Console.WriteLine(Questions[i]);          // writes the questions one by one
                Console.WriteLine(Answers[i]);           // writes the answers for the question listed above


                Console.WriteLine("Guess: ");            // takes user input f
                string? Guess = Console.ReadLine()?.ToUpper();  // checks if its a string and puts it into uppercase


                if (Guess == CorrectAnswers[i])        // if the answer is correct it gives a point if not it doesnt
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
            string[] CorrectAnswers = { "A", "A", "B" };
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


            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine("******************");
                Console.WriteLine(Questions[i]);
                Console.WriteLine(Answers[i]);

                Console.WriteLine("Guess: ");
                string? Guess = Console.ReadLine()?.ToUpper();


                if (Guess == CorrectAnswers[i])
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
            string[] CorrectAnswers = { "A", "D", "D", "D", "C" };
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


            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine("******************");
                Console.WriteLine(Questions[i]);
                Console.WriteLine(Answers[i]);

                Console.WriteLine("Guess: ");
                string? Guess = Console.ReadLine()?.ToUpper();


                if (Guess == CorrectAnswers[i])
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


        public static void GroceryStoreQuiz()
        {
            string[] CorrectAnswers = { "C", "A", "B" };
            score = 0;

            string[] Questions = {"1. Does good food get discarded in supermarkets?: ",
                                  "2. What is the most wasted food in the world?: ",
                                  "3. What is the future of food waste?: "
                                  };

            string[] Answers = {
                "A: I don't know\tB: No\tC: Yes",
                "A: Bread\tB: Cheese\tC: Apples",
                "A: It will decrease\tB: It will increase\tC: It will stagnate"
            };


            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine("******************");
                Console.WriteLine(Questions[i]);
                Console.WriteLine(Answers[i]);

                Console.WriteLine("Guess: ");
                string? Guess = Console.ReadLine()?.ToUpper();


                if (Guess == CorrectAnswers[i])
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

        public static void JunkyardQuizz()
        {
            string[] CorrectAnswers = { "C", "A", "B" };
            int score = 0;

            string[] Questions = {
                    "1. In real life, what is the major environmental consequence of improper food waste disposal?: ",
                    "2. How does reducing food waste contribute to addressing global hunger?: ",
                    "3. What is a significant health risk associated with the decomposition of food waste in landfills?: "
                };

            string[] Answers = {
                    "A: Soil pollution\tB: Increased greenhouse gas emissions\tC: Contamination of water sources",
                    "A: More land available for agriculture\tB: Reducing the demand for new food production\tC: Supporting local farmers",
                    "A: Increased risk of allergies\tB: Formation of harmful bacteria and pathogens\tC: None of the above"
                };

            score = StartQuizz(Answers, Questions, CorrectAnswers);

            Console.WriteLine("******************");
            Console.WriteLine($"Final score: {score}/{Questions.Length}");
            Console.WriteLine("******************");

            if (score == Questions.Length)
            {
                Player.AddMoney(20);
                Player.AddAndCheckXp(100);
                Location.progress[4] += 1;
                Console.WriteLine("You gained 100xp and 20$");
            }
            else
            {
                // Provide additional educational content about the consequences of food waste
                Console.WriteLine("\nEducational Content:");
                Console.WriteLine("Improper food waste disposal can contaminate water sources (Answer to Question 1).");
                Console.WriteLine("Reducing food waste helps address global hunger by decreasing the demand for new food production (Answer to Question 2).");
                Console.WriteLine("The decomposition of food waste in landfills can lead to the formation of harmful bacteria and pathogens, posing health risks (Answer to Question 3).");
            }
        }

           public static void JunkyardQuizz1()
            {
                string[] CorrectAnswers = { "C", "B", "A" };
                int score = 0;

                string[] Questions = {
                    "1. What is the most effective way for individuals to reduce household waste?: ",
                    "2. How does composting contribute to sustainable waste management?: ",
                    "3. What is a common misconception about recycling that people should be aware of?: "
                };

                string[] Answers = {
                    "A: Throwing everything in one trash bin\tB: Using disposable products\tC: Recycling and separating recyclables",
                    "A: Accelerates the decay of plastic\tB: Converts organic waste into nutrient-rich soil\tC: Increases air pollution",
                    "A: All items with recycling symbols are recyclable\tB: It's not necessary to rinse food containers before recycling\tC: Recycling is a time-consuming process"
                };

                score = StartQuizz(Answers, Questions, CorrectAnswers);

                Console.WriteLine("******************");
                Console.WriteLine($"Final score: {score}/{Questions.Length}");
                Console.WriteLine("******************");

                if (score == Questions.Length)
                {
                    Player.AddMoney(20);
                    Player.AddAndCheckXp(100);
                    Location.progress[4] += 1;
                    Console.WriteLine("You gained 100xp and 20$");
                }
                else
                {
                // Provide additional educational content about the consequences of food waste
                Console.WriteLine("Educational Content:\n Throwing everything in one trash bin is not the most effective way to reduce household waste. Recycling and separating recyclables are key practices that help prevent recyclable materials from ending up in landfills, promoting resource recovery, and reducing environmental impact.");
                Console.WriteLine("Accelerating the decay of plastic is not the purpose of composting. Composting is a sustainable waste management practice that converts organic waste into nutrient-rich soil. This process reduces the volume of organic waste in landfills, contributes to soil health, and decreases the need for chemical fertilizers.");        
                Console.WriteLine("All items with recycling symbols being recyclable is a common misconception. Recycling involves the collection and processing of materials to be used again. This reduces the demand for new raw materials, conserves energy, and minimizes environmental impact by decreasing the amount of waste sent to landfills.");
                }
            }

            static int StartQuizz(string[] Answers, string[] Questions, string[] CorrectAnswers)
            {
                int score = 0;
                Console.Clear();

                for (int i = 0; i < Questions.Length; i++)
                {
                    Console.WriteLine("******************");
                    Console.WriteLine(Questions[i]);
                    Console.WriteLine(Answers[i]);

                    string? Guess;
                    do
                    {
                        Console.Write("Guess: ");
                        Guess = Console.ReadLine()?.Trim()?.ToUpper();

                        if (string.IsNullOrEmpty(Guess) || Guess != "A" && Guess != "B" && Guess != "C")
                        {
                            Console.WriteLine("This is not a correct input. Please enter 'A', 'B', or 'C'.");
                        }
                    } while (string.IsNullOrEmpty(Guess) || Guess != "A" && Guess != "B" && Guess != "C");

                    if (Guess == CorrectAnswers[i])
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
                return score;
            }
    }
}
