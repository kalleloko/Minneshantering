namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            Console.Clear();
            List<string> theList = new List<string>();
            while (true)
            {
                Console.WriteLine("+[item]. Add [item]"
                    + "\n-[item]. Remove [item] if it exists"
                    + "\n0. Go back");
                string input = Console.ReadLine()!;
                Console.Clear();
                char nav = input[0];
                string value = input.Substring(1);
                string action = string.Empty;
                bool quit = false;


                switch (nav)
                {
                    case '-':
                        theList.Remove(value);
                        action = "removed";
                        break;
                    case '+':
                        theList.Add(value);
                        action = "added";
                        break;
                    case '0':
                        Console.Clear();
                        Console.WriteLine("See ya...(i know you'll be back)\n");
                        quit = true;
                        break;
                    default:
                        break;
                }
                if (quit)
                {
                    break;
                }
                if (string.IsNullOrEmpty(action))
                {
                    Console.WriteLine("Nothing was added or removed...");
                }
                else
                {
                    Console.WriteLine($"\"{value}\" {action}!");
                }
                Console.WriteLine($"List count: {theList.Count}. List capacity: {theList.Capacity}\n");
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Console.Clear();
            Queue<string> theQueue = new();
            while (true)
            {
                Console.WriteLine("[item]. Enqueue [item]"
                    + "\n-. Dequeue next item"
                    + "\n0. Go back");
                string input = Console.ReadLine()!;
                Console.Clear();
                bool quit = false;


                switch (input)
                {
                    case "-":
                        bool success = theQueue.TryDequeue(out string? dequeued);
                        Console.WriteLine(success ? $"{dequeued} was dequeued" : "Could not dequeue anything more");
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Bye!\n");
                        quit = true;
                        break;
                    default:
                        theQueue.Enqueue(input);
                        Console.WriteLine($"\"{input}\" was enqueued");
                        break;
                }
                if (quit)
                {
                    break;
                }
                Console.WriteLine(string.Join("\n", theQueue.Select((el, i) => $"{i + 1}. {el}")));
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Console.Clear();
            Stack<string> theStack = new();
            while (true)
            {
                Console.WriteLine("[item]. Add [item]"
                    + "\n-. Take next item"
                    + "\nR. Reverse a text"
                    + "\n0. Go back");
                string input = Console.ReadLine()!;
                Console.Clear();
                bool quit = false;


                switch (input)
                {
                    case "-":
                        bool success = theStack.TryPop(out string? dequeued);
                        Console.WriteLine(success ? $"\"{dequeued}\" was taken" : "Could not take anything more");
                        break;
                    case "r":
                    case "R":
                        Console.Clear();
                        Console.WriteLine("Enter text:");
                        string stringToReverse = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine(ReverseString(stringToReverse));
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("So long cowboy\n");
                        quit = true;
                        break;
                    default:
                        theStack.Push(input);
                        Console.WriteLine($"\"{input}\" was added");
                        break;
                }
                if (quit)
                {
                    break;
                }
                Console.WriteLine(string.Join("\n", theStack.Select((el, i) => $"{i + 1}. {el}")));
                Console.WriteLine();
            }
        }

        private static string ReverseString(string stringToReverse)
        {
            Stack<char> stack = new();
            foreach (char c in stringToReverse)
            {
                stack.Push(c);
            }
            return string.Join("", stack.Select(c => c).ToArray());
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

