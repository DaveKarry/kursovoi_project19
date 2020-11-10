using Game;
using SFML.Graphics;
using SFML.System;
using System;

namespace Games
{
    public class Game
    {
        World world;
        Squad squad;
        Surface surface;
        Surface hp_surface_1;
        Surface hp_surface_2;
        Surface hp_surface_3;
        public static Text hpbarRogue;
        public static Text hpbarWarrior;
        public static Text hpbarPriest;
        Hero Rogue;
        Hero Warrior;
        Hero Priest;
        public Game()
        {
            world = new World();
            squad = new Squad(world);
            surface = new Surface(1920, 1080, Type_of_surface.Svitok)
            {
                Position = new Vector2f(0, 0)
            };
            hp_surface_1 = new Surface(32, 32, Type_of_surface.hp_surface)
            {
                Position = new Vector2f(1042, 200)
            };
            hp_surface_2 = new Surface(32, 32, Type_of_surface.hp_surface)
            {
                Position = new Vector2f(1142, 200)
            };
            hp_surface_3 = new Surface(32, 32, Type_of_surface.hp_surface)
            {
                Position = new Vector2f(1242, 200)
            };
            squad.StartPosition = new Vector2f(Tile.Tile_Size, Tile.Tile_Size);
            squad.Spawn();
            Rogue = new Hero(Hero_class_enum.Rogue);
            Warrior = new Hero(Hero_class_enum.Warrior);
            Priest = new Hero(Hero_class_enum.Priest);
        }
        public void Update()
        {
            squad.Move();
            Squad.RoomActivate(Rogue, Warrior, Priest);
            hpbarRogue = new Text(Convert.ToString(Rogue.hp), Content.font, 15);
            hpbarWarrior = new Text(Convert.ToString(Warrior.hp), Content.font, 15);
            hpbarPriest = new Text(Convert.ToString(Priest.hp), Content.font, 15);
            hpbarWarrior.Color = Color.Black;
            hpbarRogue.Color = Color.Black;
            hpbarPriest.Color = Color.Black;
            hpbarRogue.Position = new Vector2f(1050, 205);
            hpbarWarrior.Position = new Vector2f(1150, 205);
            hpbarPriest.Position = new Vector2f(1250, 205);
        }
        public void Draw()
        {
            Program.Window.Draw(surface);
            Program.Window.Draw(hp_surface_1);
            Program.Window.Draw(hp_surface_2);
            Program.Window.Draw(hp_surface_3);
            Program.Window.Draw(world);
            Program.Window.Draw(squad);
            Program.Window.Draw(Rogue);
            Program.Window.Draw(Warrior);
            Program.Window.Draw(Priest);
            Program.Window.Draw(hpbarRogue);
            Program.Window.Draw(hpbarWarrior);
            Program.Window.Draw(hpbarPriest);
        }
    }
}
