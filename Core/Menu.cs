namespace Core 
{
    class Menu
    {
        public List<string> Items {get; private set;} = new List<string>();
        public string Name {get; private set;}

        public Menu(string name)
        {
            Name = name;
        }

        public Menu(string name, List<string> items)
        {
            Name = name;
            Items = items;
        }
        public override string ToString()
        {
            return Name;
        }
        public string Choose()
        {
            string? UserOption;
            bool invalidOption = false;

            do {
                
                UserOption = Console.ReadLine();
                invalidOption =!IsValid(UserOption);
                
                if (invalidOption) 
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid guess");
                }

            } while(invalidOption);

            return String.IsNullOrEmpty(UserOption) ? String.Empty : UserOption;
        }
        public bool IsValid(string? id)
        {
            return  !String.IsNullOrEmpty(id) && Items.Contains(id);
        }
    }
}