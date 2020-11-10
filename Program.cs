using Game;
using SFML.Graphics;
using SFML.Window;
using System;

namespace Games //это пространство имен. так можно указать где искать программе части кода
{
    class Program
    {
        public static RenderWindow win;
        public static RenderWindow win_trap;
        public static RenderWindow win_enemy;
        public static RenderWindow win_treasure;
        public static RenderWindow win_end_game;
        public static RenderWindow Window { get{ return win; } }
        public static RenderWindow Window_trap { get { return win_trap; } }
        public static RenderWindow Window_enemy { get { return win_enemy; } }
        public static RenderWindow Window_treasure { get { return win_treasure; } }
        public static RenderWindow Window_end_game { get { return win_end_game; } }
        public static Game Game { private set; get; }
        static void Main()
        {//какой там формат экранов? 1900 на 1860? 
            win = new RenderWindow(new VideoMode(1920, 1080), "<3");
        //кстати, вот это тоже движок
            win.SetVerticalSyncEnabled(true);
            Content.Load();
            Game = new Game();
            while (win.IsOpen)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                { win.Close(); }
                win.DispatchEvents();
                Game.Update();
                win.Clear(Color.Black);
                Game.Draw();
                win.Display();
            }
        }
        public static void Win_enemy_Resized(object sender, SizeEventArgs e)
        {
            win_enemy.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }
        public static void Win_enemy_Closed(object sender, EventArgs e)
        {
            win_enemy.Close();
            Squad.Location.Room_type = RoomType.None;
        }
    }
}
