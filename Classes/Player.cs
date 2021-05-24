namespace ShutTheBox.Classes
{
    public class Player
    {
        public string Name { get; }
        public bool isWinner { get; set; }

        public Player(string name)
        {
            Name = name;
            isWinner = false;
        }
    }
}