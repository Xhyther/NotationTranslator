using NotationTranslator.Enums;

namespace NotationTranslator.Models
{
    //The Option class is used to represent an option in the command line arguments.
    //It contains the name of the option and its corresponding notation.

    public class Option
    {
        public string Name { get; set; } // The name of the option

        public Notation Notation { get; set; } // The notation associated with the option


        public Option(string name, Notation notation) // Constructor to initialize the option with a name and notation
        {
            Name = name;
            Notation = notation;
        }

        public void SetOptName(string name) // Method to set the name of the option
        {
            Name = name;
        }

        public void SetNotation(Notation notation) // Method to set the notation of the option
        {
            Notation = notation;
        }

        public override string ToString() // Override the ToString method to provide a string representation of the option
        {
            return $"Option: {Name}, Notation: {Notation}";
        }
    }
}
