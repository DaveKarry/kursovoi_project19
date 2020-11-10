using Games;
using SFML.Graphics;
using SFML.System;
using System;

namespace Game
{
    enum Hero_class_enum
        {
            Rogue,Warrior,Priest,Skeleton,Golem,Warlock
        }
    class Hero:Transformable,Drawable
    {
        Hero_class_enum name;
        public int hp;
        readonly public int max_hp;
        public int strength; //сила
        public int dexterity;  // ловкость
        public int constitution; // телосложение
        public int wisdom;
        public int intelligece;
        RectangleShape rect;
        public static Random randomize_of_cube = new Random();
        public Hero(Hero_class_enum name) // сама писала)
        {
            int avatar_size = 100;
            rect = new RectangleShape(new Vector2f(avatar_size,avatar_size));       
            this.name = name;
            switch (name)
            {
                case Hero_class_enum.Rogue: // ну так это просто. для своей задачи это разбойник кстати)
                    max_hp = 80;
                    hp = 80;
                    strength = 3;
                    dexterity = 7;
                    constitution = 5;
                    wisdom = 5;
                    intelligece = 5;
                    rect.Texture = Content.avatar_rogue;
                    rect.TextureRect = new IntRect(0, 0, avatar_size, avatar_size);
                    Position = new Vector2f(1000, 100);
                    break;
                case Hero_class_enum.Warrior:
                    max_hp = 100;
                    hp = 100;
                    strength = 7;
                    dexterity = 3;
                    constitution = 7;
                    wisdom = 5;
                    intelligece = 3;
                    rect.Texture = Content.avatar_warrior;
                    rect.TextureRect = new IntRect(0, 0, avatar_size, avatar_size);
                    Position = new Vector2f(1100, 100);
                    break;
                case Hero_class_enum.Priest: // я просто упорная слегка (упоротая)
                    max_hp = 75;
                    hp = 75;
                    strength = 3;
                    dexterity = 3;
                    constitution = 6;
                    wisdom = 7;
                    intelligece = 7;
                    rect.Texture = Content.avatar_priest;
                    rect.TextureRect = new IntRect(0, 0, avatar_size, avatar_size);
                    Position = new Vector2f(1200, 100);
                    break;
                case Hero_class_enum.Skeleton:
                    max_hp = 30;
                    hp = 30; //должен
          
                    strength = 1;
                    dexterity = 1;
                    constitution = 2;
                    wisdom = 1;
                    intelligece = 1;
                    rect.Texture = Content.skeleton_warrior;
                    rect.TextureRect = new IntRect(0, 0, avatar_size, avatar_size);
                    Position = new Vector2f(100, 100);
                    break;
                case Hero_class_enum.Golem:
                    max_hp = 60;
                    hp = 60;
                    strength = 5;
                    dexterity = 1;
                    constitution = 1;
                    wisdom = 1;
                    intelligece = 1;
                    rect.Texture = Content.Golem;
                    rect.TextureRect = new IntRect(0, 0, avatar_size, avatar_size);
                    Position = new Vector2f(100, 100);
                    break;
                case Hero_class_enum.Warlock:
                    max_hp = 70;
                    hp = 70;
                    strength = 5;
                    dexterity = 4;
                    constitution = 4;
                    wisdom = 8;
                    intelligece = 7;
                    rect.Texture = Content.Warlock;
                    rect.TextureRect = new IntRect(0, 0, avatar_size, avatar_size);
                    Position = new Vector2f(100, 100);
                    break;
                default:
                    break;
            }
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(rect, states);
        }
        public int Check_strength()
        {
            return randomize_of_cube.Next(12);
        }
        public int Check_dexterity()
        {
            return randomize_of_cube.Next(12);
        }
        public int Check_constitution()
        {
            return randomize_of_cube.Next(12);
        }
        public int Check_wisdom()
        {
            return randomize_of_cube.Next(12);
        }
        public int Check_intelligence()
        {
            return randomize_of_cube.Next(12);
        }
    }
}
