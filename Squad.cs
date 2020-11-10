using Games;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace Game
{
    class Squad:Transformable,Drawable
    {
        public Vector2f StartPosition;
        RectangleShape rect;        
        World world;
        public static Labirint.CELL Location;
        public Squad(World world)
        {
            rect = new RectangleShape(new Vector2f(Tile.Tile_Size, Tile.Tile_Size))
            {
                Texture = Content.squadTile,
                TextureRect = new IntRect(2 * Tile.Tile_Size, 0, Tile.Tile_Size, Tile.Tile_Size)
            };
            this.world = world;
            Location = GetCell(Position.X, Position.Y, World.labir);
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(rect, states);        
        }
        public static  Labirint.CELL GetCell(float x, float y, Labirint.CELL[,] c1)
        {
            int i = (int)(x / Tile.Tile_Size);
            int j = (int)(y / Tile.Tile_Size);
            return c1[i, j];
        }
        public void Move()
        {
            var mousePosition = Mouse.GetPosition(Program.Window);
            if (mousePosition.X > 0 && mousePosition.Y > 0 && mousePosition.X < World.World_Size*Tile.Tile_Size && mousePosition.Y < World.World_Size*Tile.Tile_Size)
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    Labirint.CELL Mouse_cell = GetCell(mousePosition.X, mousePosition.Y, World.labir);
                    Labirint.CELL Curent_cell = GetCell(Position.X, Position.Y, World.labir);
                    Location = Curent_cell;
                    List<Labirint.CELL> list_cell = Labirint.GetNeighbours(World.labir, Curent_cell, World.World_Size, World.World_Size);
                    if (list_cell.Contains(Mouse_cell))
                    {
                        Position = new Vector2f(Tile.Tile_Size*Mouse_cell.x, Tile.Tile_Size*Mouse_cell.y);                      
                        Curent_cell = GetCell(Position.X, Position.Y, World.labir);
                    }
                    if ((Curent_cell.x == World.exit_cell.x) && (Curent_cell.y == World.exit_cell.y))
                    {
                        Program.win_end_game = new RenderWindow(new VideoMode((Tile.Tile_Size + 16) * World.World_Size, Tile.Tile_Size * World.World_Size), "endgame", Styles.None);
                        Program.win_end_game.SetVerticalSyncEnabled(true);
                        Surface game_over = new Surface(720, 480, Type_of_surface.Game_over);
                        while (Program.win_end_game.IsOpen)
                        {
                            Program.win_end_game.DispatchEvents();
                            Program.win_end_game.Clear();
                            Program.win_end_game.Draw(game_over);
                            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                            {
                                Program.win_end_game.Close();
                                Program.win.Close();
                            }
                            Program.win_end_game.Display();
                        }
                    }
                }
            }
        }
        public void Spawn()
        {
            Position = StartPosition;
        }
        public static void RoomActivate(Game.Hero hero1, Game.Hero hero2, Game.Hero hero3 )
        {
            Labirint.CELL currentCell = Location;
            switch (Location.Room_type)
            {
                case RoomType.None:
                    break;
                case RoomType.Trap:
                    Trap.Trap_room_activate(currentCell, hero1, hero2, hero3);                    
                    break;
                case RoomType.Enemy:
                    Enemy.Enemy_room_activate(currentCell, hero1, hero2, hero3);                    
                    break;
                case RoomType.Treasure:
                    Treasure.Treasure_room_activate(currentCell, hero1, hero2, hero3);
                    break;
                default:
                    break;
            }
        }
    }
}
