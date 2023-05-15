

namespace Minecraft_Clone
{
    public class Program
    {
        static void Main(string[] args)
        {
            using(Game game = new Game(1280,720))
            {
                game.Run();
            }
        }
    }
}