namespace Core 
{
    class MenuItem
    {
        public string label {get; private set;}
        public string id {get; private set;}

        public override string ToString()
        {
            return label;
        }
    }
}