using System;

namespace HelloWord
{
    struct Game
    {
        public string name;
        public string developer;
        public DateTime releaseDate;

        public Game(string name, string developer, DateTime releaseDate)
        {
            this.name = name;
            this.developer = developer;
            this.releaseDate = releaseDate;
        }

        public void GetInfo()
        {
            Console.WriteLine("游戏名称", name);
            Console.WriteLine("开发", developer);
            Console.WriteLine("上架日期", releaseDate);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Game game;



            game.name = "pokemon";
            game.developer = "Alex";
            game.releaseDate = DateTime.Today;

            game.GetInfo();

            Console.Read();
        }
    }
}
