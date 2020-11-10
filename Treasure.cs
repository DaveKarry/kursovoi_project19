using Games;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Game
{
    class Treasure
    {
        enum Treasure_type
        {
            None,opened,first,second,third
        }
        public static Random randomize_of_room = new Random();
        public static Random randomize_of_stat = new Random();
        static Treasure_type type_of_treasure = Treasure_type.None;
        public static Random binary_random = new Random();
        public static void Treasure_room_activate(Labirint.CELL currentCell, Game.Hero hero1, Game.Hero hero2, Game.Hero hero3)
        {
            Surface surface = new Surface(720, 480, Type_of_surface.Svitok_720_480);
            World.labir[currentCell.x, currentCell.y].Room_type = RoomType.None;
            Program.win_treasure = new RenderWindow(new VideoMode((Tile.Tile_Size + 16) * World.World_Size, Tile.Tile_Size * World.World_Size), "treasure", Styles.None);
            Program.win_treasure.SetVerticalSyncEnabled(true);
            Tile[] tiles;
            tiles = new Tile[5];
            Tile[,] tiles_2;
            tiles_2 = new Tile[5, 2];
            Text opend_treasure_alert = new Text("В комнате стоит открытый сундук!", Content.font, 20)
            {
                Position = new SFML.System.Vector2f(100, 150)
            };

            Surface chest = new Surface(100, 100, Type_of_surface.Chest)
            {
                Position = new SFML.System.Vector2f(100, 50)
            };
            Surface button = new Surface(100, 60, Type_of_surface.Open_Button)
            {
                Position = new SFML.System.Vector2f(300, 300)
            };
            int random_treasure = randomize_of_room.Next(3);
            int[] first_matrix = new int[5]; //это те самые кнопочки для сундука
            int[] first_check_matrix = new int[5]; //зеленый цвет программа не читает
            int[,] second_matrix = new int[5, 2]; /*называется коментарий кода
            он может быть двухэтажным
            трехэтажным и
            м
            н
            о
            го
            э
            т
            а
            ж
            н
            ы
            м
            )))
            лагаешь
            */
            int[,] second_check_matrix = new int[5, 2];
            
            for (int i = 0; i < 5; i++)
            {
                first_check_matrix[i] = binary_random.Next(2);
                first_matrix[i] = 0;
                tiles[i] = new Tile(TileType.treasure_0)
                {
                    Position = new SFML.System.Vector2f(i * Tile.Tile_Size + 260, 200)
                };
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    second_check_matrix[i, j] = binary_random.Next(2);
                    second_matrix[i, j] = 0;
                    tiles_2[i, j] = new Tile(TileType.treasure_0)
                    {
                        Position = new SFML.System.Vector2f(i * Tile.Tile_Size + 260, j * Tile.Tile_Size + 200)
                    };
                }
            }
            //int random_stat = randomize_of_stat.Next(5);
            Text alert = new Text("", Content.font, 20)
            {
                Position = new SFML.System.Vector2f(100, 140)
            }; ;

            Vector2f vextor = new Vector2f(100,170);
            switch (random_treasure)
            {
                case 0:
                    type_of_treasure = Treasure_type.opened;
                    int random_stat = randomize_of_stat.Next(5);

                    switch (random_stat)
                    {
                        case 0:
                            hero1.constitution += 1;
                            hero2.constitution += 1;
                            hero3.constitution += 1;
                            alert = new Text("в сундуке лежит свиток повышающий конституцию отряда", Content.font, 20)
                            {
                                Position = vextor
                            };
                            break;
                        case 1:
                            hero1.dexterity += 1;
                            hero2.dexterity += 1;
                            hero3.dexterity += 1;
                            alert = new Text("в сундуке лежит свиток повышающий ловкость отряда", Content.font, 20)
                            {
                                Position = vextor
                            };

                            break;
                        case 2:
                            hero1.intelligece += 1;
                            hero2.intelligece += 1;
                            hero3.intelligece += 1;
                            alert = new Text("в сундуке лежит свиток повышающий интеллект отряда", Content.font, 20)
                            {
                                Position = vextor
                            };

                            break;
                        case 3:
                            hero1.strength += 1;
                            hero2.strength += 1;
                            hero3.strength += 1;
                            alert = new Text("в сундуке лежит свиток повышающий силу отряда", Content.font, 20)
                            {
                                Position = vextor
                            };

                            break;
                        case 4:
                            hero1.wisdom += 1;
                            hero2.wisdom += 1;
                            hero3.wisdom += 1;
                            alert = new Text("в сундуке лежит свиток повышающий мудрость отряда", Content.font, 20)
                            {
                                Position = vextor
                            };

                            break;
                        default:
                            break;
                    }
                    hero1.hp += 3;
                    if (hero1.hp > hero1.max_hp)
                    { hero1.hp = hero1.max_hp; }
                    hero2.hp += 3;
                    if (hero2.hp > hero2.max_hp)
                    { hero2.hp = hero2.max_hp; }
                    hero3.hp += 3;
                    if (hero3.hp > hero3.max_hp)
                    { hero3.hp = hero3.max_hp; }
                    break;
                case 1:
                    int random_stat_2 = randomize_of_stat.Next(5);
                    switch (random_stat_2)
                    {
                        case 0:
                            hero1.constitution += 1;
                            hero2.constitution += 1;
                            hero3.constitution += 1;
                            alert = new Text("в сундуке лежит свиток повышающий конституцию отряда", Content.font, 20)
                            {
                                Position = vextor
                            };

                            break;
                        case 1:
                            hero1.dexterity += 1;
                            hero2.dexterity += 1;
                            hero3.dexterity += 1;
                            alert = new Text("в сундуке лежит свиток повышающий ловкость отряда", Content.font, 20)
                            {
                                Position = vextor
                            };
                            break;
                        case 2:
                            hero1.intelligece += 1;
                            hero2.intelligece += 1;
                            hero3.intelligece += 1;
                            alert = new Text("в сундуке лежит свиток повышающий интеллект отряда", Content.font, 20)
                            {
                                Position = vextor
                            };
                            break;
                        case 3:
                            hero1.strength += 1;
                            hero2.strength += 1;
                            hero3.strength += 1;
                            alert = new Text("в сундуке лежит свиток повышающий силу отряда", Content.font, 20)
                            {
                                Position = vextor
                            };
                            break;
                        case 4:
                            hero1.wisdom += 1;
                            hero2.wisdom += 1;
                            hero3.wisdom += 1;
                            alert = new Text("в сундуке лежит свиток повышающий мудрость отряда", Content.font, 20)
                            {
                                Position = vextor
                            };
                            break;
                        default:
                            break;
                    }
                    type_of_treasure = Treasure_type.first;
                    hero1.hp += 3;
                    if (hero1.hp > hero1.max_hp)
                    { hero1.hp = hero1.max_hp; }
                    hero2.hp += 3;
                    if (hero2.hp > hero2.max_hp)
                    { hero2.hp = hero2.max_hp; }
                    hero3.hp += 3;
                    if (hero3.hp > hero3.max_hp)
                    { hero3.hp = hero3.max_hp; }
                    break;
                case 2:
                    int random_stat_3 = randomize_of_stat.Next(5);
                    switch (random_stat_3)
                    {
                        case 0:
                            hero1.constitution += 1;
                            hero2.constitution += 1;
                            hero3.constitution += 1;
                            alert = new Text("в сундуке лежит свиток повышающий конституцию отряда", Content.font, 20)
                            {
                                Position = vextor
                            };
                            break;
                        case 1:
                            hero1.dexterity += 1;
                            hero2.dexterity += 1;
                            hero3.dexterity += 1;
                            alert = new Text("в сундуке лежит свиток повышающий ловкость отряда", Content.font, 20)
                            {
                                Position = vextor
                            };
                            break;
                        case 2:
                            hero1.intelligece += 1;
                            hero2.intelligece += 1;
                            hero3.intelligece += 1;
                            alert = new Text("в сундуке лежит свиток повышающий интеллект отряда", Content.font, 20)
                            {
                                Position = vextor
                            };
                            break;
                        case 3:
                            hero1.strength += 1;
                            hero2.strength += 1;
                            hero3.strength += 1;
                            alert = new Text("в сундуке лежит свиток повышающий силу отряда", Content.font, 20)
                            {
                                Position = vextor
                            };
                            break;
                        case 4:
                            hero1.wisdom += 1;
                            hero2.wisdom += 1;
                            hero3.wisdom += 1;
                            alert = new Text("в сундуке лежит свиток повышающий мудрость отряда", Content.font, 20)
                            {
                                Position = vextor
                            };
                            break;
                        default:
                            break;
                    }
                    type_of_treasure = Treasure_type.second;
                    hero1.hp += 3;
                    if (hero1.hp > hero1.max_hp)
                    { hero1.hp = hero1.max_hp; }
                    hero2.hp += 3;
                    if (hero2.hp > hero2.max_hp)
                    { hero2.hp = hero2.max_hp; }
                    hero3.hp += 3;
                    if (hero3.hp > hero3.max_hp)
                    { hero3.hp = hero3.max_hp; }
                    break;
                default:
                    break;
            }
            while (Program.win_treasure.IsOpen)
            {
                Program.win_treasure.DispatchEvents();
                Program.win_treasure.Clear(Color.Black);
                Program.win_treasure.Draw(surface);
                Program.win_treasure.Draw(alert);
                
                var mousePosition = Mouse.GetPosition(Program.win_treasure);
                if (type_of_treasure == Treasure_type.opened)
                {
                    Program.win_treasure.Draw(chest);
                    Program.win_treasure.Draw(opend_treasure_alert);
                    Program.win_treasure.Draw(button);
                    if ((mousePosition.X > button.Position.X) && (mousePosition.Y > button.Position.Y) && (mousePosition.X < 400) && (mousePosition.Y < 360))
                    {
                        button.rectShape.FillColor = Color.Red;
                        if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                        {
                            Program.win_treasure.Close();
                            Squad.Location.Room_type = RoomType.None;
                        }
                    }
                    else
                    {
                        button.rectShape.FillColor = Color.White;
                    }
                }
                if (type_of_treasure == Treasure_type.first)
                {
                    Text count = new Text(Convert.ToString(Open_chest.Get_check_number(first_matrix, first_check_matrix)), Content.font, 20)
                    {
                        Position = new SFML.System.Vector2f(150, 150)
                    };
                    if (Open_chest.Check_matrix(first_matrix, first_check_matrix))
                    {
                        Program.win_treasure.Draw(button); ///рисуем кнопку
                        if ((mousePosition.X > button.Position.X) && (mousePosition.Y > button.Position.Y) && (mousePosition.X < 400) && (mousePosition.Y < 360))
                        {
                            button.rectShape.FillColor = Color.Red;
                            if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                            {
                                Program.win_treasure.Close();
                                Squad.Location.Room_type = RoomType.None;
                            }
                        }
                        else
                        { button.rectShape.FillColor = Color.White; }
                    }
                    Open_chest.Update(first_matrix, tiles); ///апдейтим
                    for (int i = 0; i < 5; i++)
                    { Program.win_treasure.Draw(tiles[i]); }
                    Program.win_treasure.Draw(count);
                }
                if (type_of_treasure == Treasure_type.second)
                {
                    Text count = new Text(Convert.ToString(Open_chest.Get_check_number(second_matrix, second_check_matrix)), Content.font, 20)
                    {
                        Position = new SFML.System.Vector2f(150, 150)
                    };
                    if (Open_chest.Check_matrix(second_matrix, second_check_matrix))
                    {
                        Program.win_treasure.Draw(button); ///рисуем кнопку
                        if ((mousePosition.X > button.Position.X) && (mousePosition.Y > button.Position.Y) && (mousePosition.X < 400) && (mousePosition.Y < 360))
                        {
                            button.rectShape.FillColor = Color.Red;
                            if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                            {
                                Program.win_treasure.Close();
                                Squad.Location.Room_type = RoomType.None;
                            }
                        }
                        else
                        {
                            button.rectShape.FillColor = Color.White;
                        }
                    }
                    Open_chest.Update(second_matrix, tiles_2); ///апдейтим
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            Program.win_treasure.Draw(tiles_2[i, j]);                    /// рисуем тайлы
                        }
                    }
                    Program.win_treasure.Draw(count);
                }
                Program.win_treasure.Display();
            }
        }
    }
}
