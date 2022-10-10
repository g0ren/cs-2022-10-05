using System;

public enum LegalMove
{
    ROCK = 0,
    PAPER = 1,
    SCISSORS = 2
}

interface IMove
{
    public LegalMove Move();
    public string ToString();
}

class Rock : IMove
{
    public LegalMove Move()
    {
        return LegalMove.ROCK;
    }
    public override string ToString()
    {
        return "Rock";
    }
}

class Paper : IMove
{
    public LegalMove Move()
    {
        return LegalMove.PAPER;
    }
    public override string ToString() 
    {
        return "Paper";
    }
}

class Scissors : IMove
{
    public LegalMove Move()
    {
        return LegalMove.SCISSORS;
    }
    public override string ToString()
    {
        return "Scissors";
    }
}

interface IPlayer
{
    public string Name
    {
        get;
    }
    public IMove MakeMove();
}

class Player : IPlayer
{
    public string Name
    {
        get;
        private set;
    }
    public Player()
    {
        this.Name = "Human player";
    }
    public IMove MakeMove()
    {
        while (true)
        {
            int c;
            Console.WriteLine("Choose your move");
            Console.WriteLine("1 - Rock");
            Console.WriteLine("2 - Paper");
            Console.WriteLine("3 - Scissors");
            c = Convert.ToInt32(Console.ReadLine());
            if (c == 1)
            {
                return new Rock();
            }
            if (c == 2)
            {
                return new Paper();
            }
            if (c == 3)
            {
                return new Scissors();
            }
            Console.WriteLine("Wrong move!");
        }
    }
}

class Bot : IPlayer
{
    public string Name
    {
        get;
        private set;
    }
    public Bot()
    {
        this.Name = "Random bot player";
    }
    public IMove MakeMove()
    {
        Random r = new Random();
        int c = (r.Next() % 3);
        if (c == 0)
        {
            return new Rock();
        }
        else if (c == 1)
        {
            return new Paper();
        }
        else
        {
            return new Scissors();
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Player player = new Player();
        Bot bot = new Bot();
        while (true)
        {
            var t1 = player.MakeMove();
            var t2 = bot.MakeMove();
            Console.WriteLine($"{player.Name}: {t1}, {bot.Name}: {t2}");
        }
    }
}