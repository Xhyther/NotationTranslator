

namespace NotationTranslator.Cmd
{
    public class Subcommand
    {
        public string Name { get; }
        public string Description { get; }

        public List<Option> Options { get; } = new();
        public List<Arguments> Arguments { get; } = new();

        public Subcommand(string name, string description)
        {
            Name = name;
            Description = description;
        }


        public void AddOption(Option option)
        {
            Options.Add(option);
        }

        public void AddArgument(Arguments argument)
        {
            Arguments.Add(argument);
        }

    }
}
