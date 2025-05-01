using NotationTranslator.Tree;
using NotationTranslator.Enums;
using NotationTranslator.Models;

namespace NotationTranslator.Services
{
    public class ArgParse
    {
        private readonly string[] _args;

        private bool Isfrom;
        private bool Istofix;

        private int OptionCounter;

        private string? expr;
        private Notation fromNotation;
        private Notation toNotation;

        public ArgParse(string[] args)
        {
            _args = args;
            Isfrom = false;
            Istofix = false; 
            OptionCounter = 0;
        }


        public void Parse()
        {
            if (_args.Length == 0)
            {
                Helper.PrintHelpMain();
                throw new ArgumentException("No arguments provided.");

            }
            var Command = _args.Length > 0 ? _args[0] : null;

            if (Command == null)
                throw new ArgumentException("No command provided.");

            if (IsValidCommand(Command))
            {
                var options = new List<Option>();
                for (int i = 1; i < _args.Length; i++)
                {
                    try
                    {

                        if (_args[i] == "--help" || _args[i] == "--h")
                        {
                            Helper.printHelpConvert();
                            return;
                        }

                        if (_args[i].StartsWith("--"))
                        {
                            if (i + 1 >= _args.Length)
                                throw new ArgumentException($"Missing value for option '{_args[i]}'.");

                            if (_args[i + 1].EndsWith('x'))
                            {
                                options.Add(new Option(_args[i++], GetNotation(_args[i])));
                                if (Isfrom == false)
                                    Isfrom = FromParseI(options[OptionCounter]);
                                if (Istofix == false)
                                    Istofix = ToParseI(options[OptionCounter]);
                                OptionCounter++;
                            }
                        }
                        else
                            expr = _args[i];

                    }
                    catch (ArgumentException ex)
                    {
                        throw new ArgumentException($"Error parsing option: {ex.Message}");

                    }
                }


            
                ValidOptions();

                if (ArgumentExists())
                    Sethandler(fromNotation, toNotation, expr!);
                else
                    throw new ArgumentException("No expression provided.");
            }

            else if (Command == "--help" || Command == "--h")
                Helper.PrintHelpMain();
            else if (Command == "--guide" || Command == "--g")
                Helper.printGuide();
            else
                throw new ArgumentException("Invalid command provided.");


        }


        public bool IsValidCommand(string command)
        {
            return command == "convert";
        }


        public bool FromParseI(Option opt)
        {
            string name = opt.Name.Substring(2);
            bool x = name == "from" || name == "f";

            if (x)
                FromValue(opt.Notation);

            return x;
        }

        public void FromValue(Notation notation)
        {
            fromNotation = notation;
        }

        public bool ToParseI(Option opt)
        {
            string name = opt.Name.Substring(2);
            bool y = name == "to" || name == "t";
            if (y)
                ToValue(opt.Notation);

            return y;
        }

        public void ToValue(Notation notation)
        {
            toNotation = notation;
        }


        public void ValidOptions()
        {
            if (OptionCounter > 2)
                throw new ArgumentException("Too many options provided.");
            if (OptionCounter == 0)     
                throw new ArgumentException("No options provided.");
            //throw errorsss
            if (!Isfrom)
                throw new ArgumentException("Option '--from' is required.");
            if (!Istofix)
                throw new ArgumentException("Option '--to' is required.");
    
        }

        public bool ArgumentExists()
        {
            if (expr == null)
                throw new ArgumentException("No expression provided.");
            return true;
        }

        public Notation GetNotation(string notation)
        {
            return notation switch
            {
                "infix" => Notation.infix,
                "prefix" => Notation.prefix,
                "postfix" => Notation.postfix,
                _ => throw new ArgumentException("Invalid notation type")
            };
        }


        public void Sethandler(Notation from, Notation to, string expr)
        {
            Console.WriteLine();
            var tokens = Tokenizer.Tokenize(expr);
            var trees = new Trees();

            var root = new Node();
            Console.WriteLine($"Original Expression: {expr} of {from} notation");
            switch (from)
            {
                case Notation.prefix:
                     root = trees.BuildTreeFromPrefix(expr);
                    break;
                case Notation.infix:
                     root = trees.BuildTreeFromInfix(expr);
                    break;
                case Notation.postfix:
                    root = trees.BuildTreeFromPostfix(expr);
                    break;

            }
            Console.ForegroundColor = ConsoleColor.Green;
            switch (to)
            {
                case Notation.prefix:
                    Console.Write("Converted Expression: ");
                    trees.Preorder(root);
                    Console.WriteLine($" of {to} notation");
                    Console.WriteLine();
                    break;
                case Notation.infix:
                    Console.Write("Converted Expression: ");
                    trees.Inorder(root);
                    Console.WriteLine($" of {to} notation");
                    Console.WriteLine();
                    break;
                case Notation.postfix:
                    Console.Write("Converted Expression: ");
                    trees.Postorder(root);
                    Console.WriteLine($" of {to} notation");
                    Console.WriteLine();
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintArgs(string Command, List<Option> opt, string exp)
        {
            Console.WriteLine($"Command: {Command}");
            foreach (var item in opt)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine($"Argument: {exp}");

        }
    }
}
