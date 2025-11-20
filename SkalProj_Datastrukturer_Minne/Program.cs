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
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. Check Parenthesis"
                    + "\n5. Check Recursive And Iterative functions"
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
                    case '5':
                        CheckRecursiveAndIterative();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        private static void CheckRecursiveAndIterative()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Say a number! (Below 40 to keep sane, 0 to Go back)");
                string input = Console.ReadLine() ?? string.Empty;
                Console.Clear();

                if (!int.TryParse(input, out int number))
                {
                    continue;
                }

                if (number == 0)
                {
                    break;
                }

                Console.WriteLine($"RecursiveEven({number}) = {RecursiveEven(number)}");
                Console.WriteLine($"RecursiveFibonacci({number}) = {RecursiveFibonacci(number)}");
                Console.WriteLine($"IterativeEven({number}) = {IterativeEven(number)}");
                Console.WriteLine($"IterativeFibonacci({number}) = {IterativeFibonacci(number)}");
                Console.WriteLine();
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
        /// <summary>
        /// Reverse stringToReverse using a stack
        /// </summary>
        /// <param name="stringToReverse"></param>
        /// <returns></returns>
        private static string ReverseString(string stringToReverse)
        {
            Stack<char> stack = new();
            foreach (char c in stringToReverse)
            {
                stack.Push(c);
            }
            return string.Join("", stack.Select(c => c).ToArray());
        }

        /// <summary>
        /// Handle the checking of brackets
        /// </summary>
        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.Clear();
            BracketsParser parser = new BracketsParser();
            while (true)
            {

                Console.WriteLine("Enter a string to check for parenthesis. (0 to go back)\n");
                string s = Console.ReadLine() ?? string.Empty;
                if (s == "0")
                {
                    Console.WriteLine("  _____\r\n /     \\\r\n| () () |\r\n \\  ^  /\r\n  |||||\r\n  |||||\n");
                    break;
                }

                parser.String = s;
                Console.Clear();
                Console.WriteLine(s + "\n");
                try
                {
                    List<BracketMatch> result = parser.Parse();
                    Console.WriteLine($"Your string is well formatted!");
                    Console.WriteLine("Do you want to see it parsed? y/n");
                    string seeParsed = Console.ReadLine() ?? "n";
                    if (seeParsed == "y")
                    {
                        Console.Clear();
                        Console.WriteLine(s);
                        Console.WriteLine(string.Join("\n", result));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Your string is not well formatted:");
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine();


            }

        }

        public static int RecursiveEven(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            return RecursiveEven(n - 1) + 2;
        }

        public static int RecursiveFibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 1;
            }
            return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
        }

        public static int IterativeEven(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            int result = 0;
            for (int i = 0; i < n; i++)
            {
                result += 2;
            }
            return result;
        }

        public static int IterativeFibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 1;
            }
            int prev = 1;
            int result = 1;
            for (int i = 3; i <= n; i++)
            {
                int temp = prev;
                prev = result;
                result += temp;
            }
            return result;
        }
    }

}

