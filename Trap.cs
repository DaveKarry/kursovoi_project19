using Games;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Game
{
    class Trap
    {
        enum Trap_type
        {
            None, spear, viper, skeleton, skull, mimic
        }
        public static Random randomize_of_room = new Random();
        static Trap_type type_of_trap = Trap_type.None;
        public static void Trap_room_activate(Labirint.CELL currentCell, Game.Hero hero1, Game.Hero hero2, Game.Hero hero3)
        {
            Surface surface = new Surface(720, 480, Type_of_surface.Svitok_720_480);/// 720.480
            World.labir[currentCell.x, currentCell.y].Room_type = RoomType.None;
            Program.win_trap = new RenderWindow(new VideoMode((Tile.Tile_Size + 16) * World.World_Size, Tile.Tile_Size * World.World_Size), "trap", Styles.None);
            Program.win_trap.SetVerticalSyncEnabled(true);
            Surface viper_alert = new Surface(100, 57, Type_of_surface.Viper)
            {
                Position = new SFML.System.Vector2f(100, 50)
            };
            Surface skeleton_alert = new Surface(100, 88, Type_of_surface.Skeleton)
            {
                Position = new SFML.System.Vector2f(100, 50)
            };
            Surface spear_alert = new Surface(100, 100, Type_of_surface.Spear)
            {
                Position = new SFML.System.Vector2f(100, 50)
            };
            Surface skull_alert = new Surface(47, 99, Type_of_surface.Skull)
            {
                Position = new SFML.System.Vector2f(100, 35)
            };
            Surface mimic_alert = new Surface(100, 97, Type_of_surface.Mimic)
            {
                Position = new SFML.System.Vector2f(100, 35)
            };
            Surface button = new Surface(100, 60, Type_of_surface.Drop_Button)
            {
                Position = new SFML.System.Vector2f(300, 300)
            };
            Surface ok_button = new Surface(100, 60, Type_of_surface.Ok_Button)
            {
                Position = new SFML.System.Vector2f(450, 300)
            };
            Surface dice_1 = new Surface(170, 120, Type_of_surface.Dice)
            {
                Position = new SFML.System.Vector2f(200, 35),
                Scale = new SFML.System.Vector2f(0.5f, 0.5f)
            };
            Surface dice_2 = new Surface(170, 120, Type_of_surface.Dice)
            {
                Position = new SFML.System.Vector2f(300, 35),
                Scale = new SFML.System.Vector2f(0.5f, 0.5f)
            };
            Surface dice_3 = new Surface(170, 120, Type_of_surface.Dice)
            {
                Position = new SFML.System.Vector2f(400, 35),
                Scale = new SFML.System.Vector2f(0.5f, 0.5f)
            };
            Text viper_text1_alert;
            Text viper_text2_alert;
            Text viper_text3_alert;
            viper_text1_alert = new Text("Сработала ловушка со змеями! ", Content.font, 20);
            viper_text2_alert = new Text("Все члены отряда были укушены!", Content.font, 20);
            viper_text3_alert = new Text("Бросок на телосложение чтобы избежать яда!", Content.font, 20);
            Text spear_text1_alert;
            Text spear_text2_alert;
            Text spear_text3_alert;
            spear_text1_alert = new Text("Сработала ловушка с копьями! ", Content.font, 20);
            spear_text2_alert = new Text("Все члены отряда находятся в зоне поражения!", Content.font, 20);
            spear_text3_alert = new Text("Бросок на ловкость, чтобы уклониться от стрел!", Content.font, 20);
            Text skeleton_text1_alert;
            Text skeleton_text2_alert;
            Text skeleton_text3_alert;
            skeleton_text1_alert = new Text("Сработала ловушка, и скелеты вокруг ожили! ", Content.font, 20);
            skeleton_text2_alert = new Text("Все члены отряда находятся в зоне поражения!", Content.font, 20);
            skeleton_text3_alert = new Text("Бросок на силу, чтобы победить скелетов и не получить \nповреждений!", Content.font, 20);
            Text skull_text1_alert;
            Text skull_text2_alert;
            Text skull_text3_alert;
            skull_text1_alert = new Text("Перед вами повис огненный череп!", Content.font, 20);
            skull_text2_alert = new Text("Он медленно произносит загадку!", Content.font, 20);
            skull_text3_alert = new Text("Бросок на интеллект, чтобы решить загадку \nи не быть укушенным черепом!", Content.font, 20);
            Text mimic_text1_alert;
            Text mimic_text2_alert;
            Text mimic_text3_alert;
            mimic_text1_alert = new Text("В комнате стоит подозрительный сундук!", Content.font, 20);
            mimic_text2_alert = new Text("Отряд обсуждает стоит ли его открывать!", Content.font, 20);
            mimic_text3_alert = new Text("Бросок на мудрость, чтобы распознать мимика!", Content.font, 20);
            viper_text1_alert.Position = new Vector2f(100, 150);
            viper_text2_alert.Position = new Vector2f(100, 170);
            viper_text3_alert.Position = new Vector2f(100, 190);
            spear_text1_alert.Position = new SFML.System.Vector2f(100, 150);
            spear_text2_alert.Position = new SFML.System.Vector2f(100, 170);
            spear_text3_alert.Position = new SFML.System.Vector2f(100, 190);
            skeleton_text1_alert.Position = new SFML.System.Vector2f(100, 150);
            skeleton_text2_alert.Position = new SFML.System.Vector2f(100, 170);
            skeleton_text3_alert.Position = new SFML.System.Vector2f(100, 190);
            skull_text1_alert.Position = new SFML.System.Vector2f(100, 150);
            skull_text2_alert.Position = new SFML.System.Vector2f(100, 170);
            skull_text3_alert.Position = new SFML.System.Vector2f(100, 190);
            mimic_text1_alert.Position = new SFML.System.Vector2f(100, 150);
            mimic_text2_alert.Position = new SFML.System.Vector2f(100, 170);
            mimic_text3_alert.Position = new SFML.System.Vector2f(100, 190);
            int random_trap = randomize_of_room.Next(5);
            int check1 = 0;
            int check2 = 0;
            int check3 = 0;
            int need_dice_type_value_1 = 0;
            int need_dice_type_value_2 = 0;
            int need_dice_type_value_3 = 0;
            switch (random_trap)
            {
                case 0:
                    type_of_trap = Trap_type.viper;
                    need_dice_type_value_1 = hero1.constitution;
                    need_dice_type_value_2 = hero2.constitution;
                    need_dice_type_value_3 = hero3.constitution;
                    check1 = hero1.Check_constitution();
                    if (hero1.constitution < check1)
                    { hero1.hp -= 10; }
                    check2 = hero2.Check_constitution();
                    if (hero2.constitution < check2)
                    { hero2.hp -= 10; }
                    check3 = hero1.Check_constitution();
                    if (hero3.constitution < check3)
                    { hero3.hp -= 10; }
                    break;
                case 1:
                    type_of_trap = Trap_type.spear;
                    need_dice_type_value_1 = hero1.dexterity;
                    need_dice_type_value_2 = hero2.dexterity;
                    need_dice_type_value_3 = hero3.dexterity;
                    check1 = hero1.Check_dexterity();
                    if (hero1.dexterity < check1)
                    { hero1.hp -= 10; }
                    check2 = hero2.Check_dexterity();
                    if (hero2.dexterity < check2)
                    { hero2.hp -= 10; }
                    check3 = hero3.Check_dexterity();
                    if (hero3.dexterity < check3)
                    { hero3.hp -= 10; }
                    break;
                case 2:
                    type_of_trap = Trap_type.skeleton;
                    need_dice_type_value_1 = hero1.strength;
                    need_dice_type_value_2 = hero2.strength;
                    need_dice_type_value_3 = hero3.strength;
                    check1 = hero1.Check_strength();
                    if (hero1.strength < check1)
                    { hero1.hp -= 10; }
                    check2 = hero2.Check_strength();
                    if (hero2.strength < check2)
                    { hero2.hp -= 10; }
                    check3 = hero3.Check_strength();
                    if (hero3.strength < check3)
                    { hero3.hp -= 10; }
                    break;
                case 3:
                    type_of_trap = Trap_type.skull;
                    need_dice_type_value_1 = hero1.intelligece;
                    need_dice_type_value_2 = hero2.intelligece;
                    need_dice_type_value_3 = hero3.intelligece;
                    check1 = hero1.Check_intelligence();
                    if (hero1.intelligece < check1)
                    { hero1.hp -= 10; }
                    check2 = hero2.Check_intelligence();
                    if (hero2.intelligece < check2)
                    { hero2.hp -= 10; }
                    check3 = hero3.Check_intelligence();
                    if (hero3.intelligece < check3)
                    { hero3.hp -= 10; }
                    break;
                case 4:
                    type_of_trap = Trap_type.mimic;
                    need_dice_type_value_1 = hero1.wisdom;
                    need_dice_type_value_2 = hero2.wisdom;
                    need_dice_type_value_3 = hero3.wisdom;
                    check1 = hero1.Check_wisdom();
                    if (hero1.wisdom < check1)
                    { hero1.hp -= 10; }
                    check2 = hero2.Check_wisdom();
                    if (hero2.wisdom < check2)
                    { hero2.hp -= 10; }
                    check3 = hero3.Check_wisdom();
                    if (hero3.wisdom < check3)
                    { hero3.hp -= 10; }
                    break;
                default:
                    break;
            }
            bool dostup = false;
            Text dice_bar_1 = new Text(Convert.ToString(check1), Content.font, 25)
            {
                Position = new Vector2f(230, 45)
            };
            Text dice_bar_2 = new Text(Convert.ToString(check2), Content.font, 25)
            {
                Position = new Vector2f(330, 45)
            };
            Text dice_bar_3 = new Text(Convert.ToString(check3), Content.font, 25)
            {
                Position = new Vector2f(430, 45)
            };
            Text need_dice_1 = new Text(Convert.ToString(need_dice_type_value_1), Content.font, 25)
            {
                Position = new Vector2f(230, 95)
            };
            Text need_dice_2 = new Text(Convert.ToString(need_dice_type_value_2), Content.font, 25)
            {
                Position = new Vector2f(330, 95)
            };
            Text need_dice_3 = new Text(Convert.ToString(need_dice_type_value_3), Content.font, 25)
            {
                Position = new Vector2f(430, 95)
            };
            while (Program.win_trap.IsOpen)
            {
                Program.win_trap.DispatchEvents();
                Program.win_trap.Clear(Color.Black);
                Program.win_trap.Draw(surface);
                Program.win_trap.Draw(button);
                Program.win_trap.Draw(dice_1);
                Program.win_trap.Draw(dice_2);
                Program.win_trap.Draw(dice_3);
                Program.win_trap.Draw(need_dice_1);
                Program.win_trap.Draw(need_dice_2);
                Program.win_trap.Draw(need_dice_3);
                var mousePosition = Mouse.GetPosition(Program.win_trap);
                if (type_of_trap == Trap_type.viper)
                {
                    Program.win_trap.Draw(viper_alert);
                    Program.win_trap.Draw(viper_text1_alert);
                    Program.win_trap.Draw(viper_text2_alert);
                    Program.win_trap.Draw(viper_text3_alert);
                }
                if (type_of_trap == Trap_type.spear)
                {
                    Program.win_trap.Draw(spear_alert);
                    Program.win_trap.Draw(spear_text1_alert);
                    Program.win_trap.Draw(spear_text2_alert);
                    Program.win_trap.Draw(spear_text3_alert);
                }
                if (type_of_trap == Trap_type.skeleton)
                {
                    Program.win_trap.Draw(skeleton_alert);
                    Program.win_trap.Draw(skeleton_text1_alert);
                    Program.win_trap.Draw(skeleton_text2_alert);
                    Program.win_trap.Draw(skeleton_text3_alert);
                }
                if (type_of_trap == Trap_type.skull)
                {
                    Program.win_trap.Draw(skull_alert);
                    Program.win_trap.Draw(skull_text1_alert);
                    Program.win_trap.Draw(skull_text2_alert);
                    Program.win_trap.Draw(skull_text3_alert);
                }
                if (type_of_trap == Trap_type.mimic)
                {
                    Program.win_trap.Draw(mimic_alert);
                    Program.win_trap.Draw(mimic_text1_alert);
                    Program.win_trap.Draw(mimic_text2_alert);
                    Program.win_trap.Draw(mimic_text3_alert);
                }
                if ((mousePosition.X > button.Position.X) && (mousePosition.Y > button.Position.Y) && (mousePosition.X < 400) && (mousePosition.Y < 360))
                {
                    button.rectShape.FillColor = Color.Red;
                    if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                    {
                        dostup = true;
                    }
                }
                if (dostup)
                {
                    Program.win_trap.Draw(ok_button);
                    Program.win_trap.Draw(dice_bar_1);
                    Program.win_trap.Draw(dice_bar_2);
                    Program.win_trap.Draw(dice_bar_3);
                    if ((mousePosition.X > ok_button.Position.X) && (mousePosition.Y > ok_button.Position.Y) && (mousePosition.X < 550) && (mousePosition.Y < 360))
                    {
                        ok_button.rectShape.FillColor = Color.Red;
                        if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                        {
                            Program.win_trap.Close();
                            Squad.Location.Room_type = RoomType.None;
                        }
                    }
                }
                else
                {
                    button.rectShape.FillColor = Color.White;
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
                Program.win_trap.Display();
            }
        }
    }
}
