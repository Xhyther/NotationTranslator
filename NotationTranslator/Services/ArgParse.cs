using NotationTranslator.Tree;
using NotationTranslator.Enums;
using NotationTranslator.Models;

namespace NotationTranslator.Services
{
    /// The ArgParse class is responsible for parsing command line arguments and options.
    // It validates the input, checks for required options, and sets the appropriate values for conversion.
    /// It also handles the conversion process by calling the Translator class.
    public class ArgParse
    {
        private readonly string[] _args; // The command line arguments passed to the program

        private bool Isfrom; // Indicates if the 'from' option has been set
        private bool Istofix; // Indicates if the 'to' option has been set

        private int OptionCounter; // Counter for the number of options provided

        private string? expr; // The expression to be converted
        private Notation fromNotation; // The input notation
        private Notation toNotation; // The output notation

        public ArgParse(string[] args) // Constructor to initialize the ArgParse object with command line arguments
        {
            _args = args;
            Isfrom = false;
            Istofix = false; 
            OptionCounter = 0;
        }


        public void Parse() // Method to parse the command line arguments
        {
            if (_args.Length == 0) //
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

        //Helper Methods
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


        // The Sethandler method is responsible for calling the Translator class to perform the conversion.
        public void Sethandler(Notation from, Notation to, string expr)
        {
           Translator translator = new Translator();
           translator.Translate(expr, from, to);
        }

   
    }
}
