using Games;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace Game
{
    enum Monster_type
    {
        Skeleton,Golem,Warlock
    }
    enum Monster_squad_type
    {
        Skeleton,Skeleton_2,Skeleton_3,Skeleton_2_Warlock,Golem,Golem_2,Golem_Warlock
    }
    class Enemy
    {
        public static Random randomize_of_room = new Random();
        public static void Enemy_room_activate(Labirint.CELL currentCell, Game.Hero hero1, Game.Hero hero2, Game.Hero hero3)
        {
            World.labir[currentCell.x, currentCell.y].Room_type = RoomType.None;
            Program.win_enemy = new RenderWindow(new VideoMode((Tile.Tile_Size + 16) * World.World_Size, Tile.Tile_Size * World.World_Size), "Enemy", Styles.None);
            Program.win_enemy.SetVerticalSyncEnabled(true);
            Program.win_enemy.Closed += Program.Win_enemy_Closed;
            Program.win_enemy.Resized += Program.Win_enemy_Resized;
            Surface surface = new Surface(720, 480, Type_of_surface.Svitok_720_480);/// 720.480
            List<Hero> Enemy_squad = new List<Hero>();
            List<Hero> Hero_squad = new List<Hero>
            {
                hero1,hero2,hero3
            };
            int random_enemy_squad = randomize_of_room.Next(0, 6);
            Hero skeleton1, skeleton2, skeleton3, Warlock, Golem1, Golem2;
            Text Hp_bar_enemy_1 = new Text("", Content.font, 20);
            Text Hp_bar_enemy_2 = new Text("", Content.font, 20);
            Text Hp_bar_enemy_3 = new Text("", Content.font, 20);
            
            switch (random_enemy_squad)
            {
                case 0:
                    skeleton1 = new Hero(Hero_class_enum.Skeleton)
                    {
                        Position = new Vector2f(360, 100)
                    };
                    Hp_bar_enemy_1 = new Text(Convert.ToString(skeleton1.hp), Content.font, 20)
                    {
                        Position = new Vector2f(360, 90)
                    };
                    Enemy_squad.Add(skeleton1);
                    break;
                case 1:
                    skeleton1 = new Hero(Hero_class_enum.Skeleton)
                    {
                        Position = new Vector2f(240, 100)
                    };
                    Hp_bar_enemy_1 = new Text(Convert.ToString(skeleton1.hp), Content.font, 20)
                    {
                        Position = new Vector2f(240, 90)
                    };
                    skeleton2 = new Hero(Hero_class_enum.Skeleton)
                    {
                        Position = new Vector2f(480, 100)
                    };
                    Hp_bar_enemy_2 = new Text(Convert.ToString(skeleton2.hp), Content.font, 20)
                    {
                        Position = new Vector2f(480, 90)
                    };
                    Enemy_squad.Add(skeleton1);
                    Enemy_squad.Add(skeleton2);
                    break;
                case 2:
                    skeleton1 = new Hero(Hero_class_enum.Skeleton)
                    {
                        Position = new Vector2f(180, 100)
                    };
                    Hp_bar_enemy_1 = new Text(Convert.ToString(skeleton1.hp), Content.font, 20)
                    {
                        Position = new Vector2f(180, 90)
                    };
                    skeleton2 = new Hero(Hero_class_enum.Skeleton)
                    {
                        Position = new Vector2f(360, 100)
                    };
                    Hp_bar_enemy_2 = new Text(Convert.ToString(skeleton2.hp), Content.font, 20)
                    {
                        Position = new Vector2f(360, 90)
                    };
                    skeleton3 = new Hero(Hero_class_enum.Skeleton)
                    {
                        Position = new Vector2f(540, 100)
                    };
                    Hp_bar_enemy_3 = new Text(Convert.ToString(skeleton3.hp), Content.font, 20)
                    {
                        Position = new Vector2f(540, 90)
                    };
                    Enemy_squad.Add(skeleton1);
                    Enemy_squad.Add(skeleton2);
                    Enemy_squad.Add(skeleton3);
                    break;
                case 3:
                    skeleton1 = new Hero(Hero_class_enum.Skeleton)
                    {
                        Position = new Vector2f(180, 100)
                    };
                    Hp_bar_enemy_1 = new Text(Convert.ToString(skeleton1.hp), Content.font, 20)
                    {
                        Position = new Vector2f(180, 90)
                    };
                    skeleton2 = new Hero(Hero_class_enum.Skeleton)
                    {
                        Position = new Vector2f(540, 100)
                    };
                    Hp_bar_enemy_2 = new Text(Convert.ToString(skeleton2.hp), Content.font, 20)
                    {
                        Position = new Vector2f(540, 90)
                    };
                    Warlock = new Hero(Hero_class_enum.Warlock)
                    {
                        Position = new Vector2f(360, 100)
                    };
                    Hp_bar_enemy_3 = new Text(Convert.ToString(Warlock.hp), Content.font, 20)
                    {
                        Position = new Vector2f(360, 85)
                    };
                    Enemy_squad.Add(skeleton1);
                    Enemy_squad.Add(skeleton2);
                    Enemy_squad.Add(Warlock);
                    break;
                case 4:
                    Golem1 = new Hero(Hero_class_enum.Golem)
                    {
                        Position = new Vector2f(360, 100)
                    };
                    Hp_bar_enemy_1 = new Text(Convert.ToString(Golem1.hp), Content.font, 20)
                    {
                        Position = new Vector2f(360, 90)
                    };
                    Enemy_squad.Add(Golem1);
                    break;
                case 5:
                    Golem1 = new Hero(Hero_class_enum.Golem)
                    {
                        Position = new Vector2f(240, 100)
                    };
                    Hp_bar_enemy_1 = new Text(Convert.ToString(Golem1.hp), Content.font, 20)
                    {
                        Position = new Vector2f(240, 90)
                    };
                    Golem2 = new Hero(Hero_class_enum.Golem)
                    {
                        Position = new Vector2f(480, 100)
                    };
                    Hp_bar_enemy_2 = new Text(Convert.ToString(Golem2.hp), Content.font, 20)
                    {
                        Position = new Vector2f(480, 90)
                    };
                    Enemy_squad.Add(Golem1);
                    Enemy_squad.Add(Golem2);
                    break;
                case 6:
                    Golem1 = new Hero(Hero_class_enum.Golem)
                    {
                        Position = new Vector2f(240, 100)
                    };
                    Hp_bar_enemy_1 = new Text(Convert.ToString(Golem1.hp), Content.font, 20)
                    {
                        Position = new Vector2f(240, 90)
                    };
                    Warlock = new Hero(Hero_class_enum.Warlock)
                    {
                        Position = new Vector2f(480, 100)
                    };
                    Hp_bar_enemy_2 = new Text(Convert.ToString(Warlock.hp), Content.font, 20)
                    {
                        Position = new Vector2f(480, 85)
                    };
                    Enemy_squad.Add(Golem1);
                    Enemy_squad.Add(Warlock);
                    break;
                default:
                    break;
            }
            Surface Sword = new Surface(100, 100, Type_of_surface.Sword)
            {
                Position = new SFML.System.Vector2f(360, 300)
            };
            Surface FireBall = new Surface(100, 100, Type_of_surface.FireBall)
            {
                Position = new SFML.System.Vector2f(180, 300)
            };
            Surface HoliLight = new Surface(100, 100, Type_of_surface.HoliLight)
            {
                Position = new SFML.System.Vector2f(540, 300)
            };
            bool war_atack = false;
            bool priest_atack = false;
            bool rogue_atack = false;
            while (Program.win_enemy.IsOpen)
            {
                Program.win_enemy.DispatchEvents();
                Program.win_enemy.Clear(Color.Black);
                Program.win_enemy.Draw(surface);
                Program.win_enemy.Draw(Sword);
                Program.win_enemy.Draw(HoliLight);
                Program.win_enemy.Draw(FireBall);
                foreach (Hero item in Enemy_squad)
                {
                    Program.win_enemy.Draw(item);
                    Text text = new Text(Convert.ToString(item.hp), Content.font, 20)
                    {
                        Position = new Vector2f(item.Position.X, item.Position.Y - 10)
                    };
                    Program.win_enemy.Draw(text);
                }
                
                for (int i = 0; i < Hero_squad.Count; i++)
                {
                    Text text = new Text(Convert.ToString(Hero_squad[i].hp), Content.font, 20)
                    {
                        Position = new Vector2f(i*160+250, 290)
                    };
                    Program.win_enemy.Draw(text);
                }
                var mousePosition = Mouse.GetPosition(Program.win_enemy);
                if ((mousePosition.X > Sword.Position.X) && (mousePosition.Y > Sword.Position.Y) && (mousePosition.X < Sword.Position.X+100) && (mousePosition.Y < Sword.Position.Y + 100) && (!priest_atack))
                {
                    if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                    {
                        war_atack = true;
                        priest_atack = false;
                        rogue_atack = false;
                    }
                }
                if ((mousePosition.X > FireBall.Position.X) && (mousePosition.Y > FireBall.Position.Y) && (mousePosition.X < FireBall.Position.X+100) && (mousePosition.Y < FireBall.Position.Y +100) && (!priest_atack))
                {
                    if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                    {
                        rogue_atack = true;
                        war_atack = false;
                        priest_atack = false;
                    }
                }
                if ((mousePosition.X > HoliLight.Position.X) && (mousePosition.Y > HoliLight.Position.Y) && (mousePosition.X < HoliLight.Position.X+100) && (mousePosition.Y < HoliLight.Position.Y+100))
                {
                    if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                    {
                        priest_atack = true;
                        war_atack = false;
                        rogue_atack = false;
                    }
                }
                if (Enemy_squad.Count != 0)
                {
                    for (int i = 0; i < Enemy_squad.Count; i++)
                    {
                        if ((war_atack) && (mousePosition.X > Enemy_squad[i].Position.X) && (mousePosition.Y > Enemy_squad[i].Position.Y) && (mousePosition.X < Enemy_squad[i].Position.X + 100) && (mousePosition.Y < Enemy_squad[i].Position.Y + 100))
                        {
                            if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                            {
                                Enemy_squad[i].hp -= 30;
                                hero2.hp -= 10;
                                Console.WriteLine(Enemy_squad[i].hp);
                                if (Enemy_squad[i].hp <= 0)
                                {
                                    Enemy_squad.Remove(Enemy_squad[i]);
                                }
                                war_atack = false;
                            }
                        }
                        if ((rogue_atack) && (mousePosition.X > Enemy_squad[i].Position.X) && (mousePosition.Y > Enemy_squad[i].Position.Y) && (mousePosition.X < Enemy_squad[i].Position.X + 100) && (mousePosition.Y < Enemy_squad[i].Position.Y + 100))
                        {
                            if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                            {
                                Enemy_squad[i].hp -= 30;
                                Console.WriteLine(Enemy_squad[i].hp);
                                hero1.hp -= 20;
                                if (Enemy_squad[i].hp <= 0)
                                {
                                    Enemy_squad.Remove(Enemy_squad[i]);
                                }
                                rogue_atack = false;
                            }
                        }
                        if (priest_atack)
                        {
                            if ((mousePosition.X > Enemy_squad[i].Position.X) && (mousePosition.Y > Enemy_squad[i].Position.Y) && (mousePosition.X < Enemy_squad[i].Position.X + 100) && (mousePosition.Y < Enemy_squad[i].Position.Y + 100))
                            {
                                if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                                {
                                    Enemy_squad[i].hp -= 30;
                                    Console.WriteLine(Enemy_squad[i].hp);
                                    hero3.hp -= 20;
                                    if (Enemy_squad[i].hp <= 0)
                                    {
                                        Enemy_squad.Remove(Enemy_squad[i]);
                                    }
                                    priest_atack = false;
                                    war_atack = false;
                                    rogue_atack = false;
                                }
                            }
                            if ((mousePosition.X > Sword.Position.X) && (mousePosition.Y > Sword.Position.Y) && (mousePosition.X < Sword.Position.X + 100) && (mousePosition.Y < Sword.Position.Y + 100))
                            {
                                if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                                {
                                    hero2.hp += 30;
                                    if (hero2.hp > hero2.max_hp)
                                    { hero2.hp = hero2.max_hp; }
                                    priest_atack = false;
                                    war_atack = false;
                                    rogue_atack = false;

                                }
                            }
                            if ((mousePosition.X > HoliLight.Position.X) && (mousePosition.Y > HoliLight.Position.Y) && (mousePosition.X < HoliLight.Position.X + 100) && (mousePosition.Y < HoliLight.Position.Y + 100))
                            {
                                if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                                {
                                    hero3.hp += 30;
                                    if (hero3.hp > hero3.max_hp)
                                    { hero3.hp = hero3.max_hp; }
                                    war_atack = false;
                                    rogue_atack = false;
                                }
                            }
                            if ((mousePosition.X > FireBall.Position.X) && (mousePosition.Y > FireBall.Position.Y) && (mousePosition.X < FireBall.Position.X + 100) && (mousePosition.Y < FireBall.Position.Y + 100))
                            {
                                if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                                {
                                    hero1.hp += 30;
                                    if (hero1.hp > hero1.max_hp)
                                    { hero1.hp = hero1.max_hp; }
                                    priest_atack = false;
                                    war_atack = false;
                                    rogue_atack = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Program.win_enemy.Close();
                    Squad.Location.Room_type = RoomType.None;
                }
                if ((hero1.hp < 0) || (hero2.hp < 0) || (hero3.hp < 0))
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
                Console.WriteLine(priest_atack + "priest");
                Console.WriteLine(rogue_atack + "rogue");
                Console.WriteLine(war_atack + "war");
                Program.win_enemy.Display();
            }
        }
    }
}
