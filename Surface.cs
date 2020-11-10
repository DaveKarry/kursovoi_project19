using Games;
using SFML.Graphics;
using SFML.System;

namespace Game
{
    enum Type_of_surface
    {
        Svitok,hp_surface,Svitok_720_480,Viper,Drop_Button,Open_Button,Skeleton,Spear,Skull,Mimic,Chest,Dice,Ok_Button,Sword,FireBall,HoliLight,Game_over
    }
    class Surface:Transformable,Drawable
    {
        public static int dlina;
        public static int visota;
        public RectangleShape rectShape;
        readonly Type_of_surface type;
        public Surface(int x, int y, Type_of_surface s)
        {
            dlina = x; // 1920
            visota = y;// 1080
            rectShape = new RectangleShape(new Vector2f(dlina, visota))
            {
                TextureRect = new IntRect(0, 0, dlina, visota)
            };
            this.type = s;
            switch (type)
            {
                case Type_of_surface.Svitok:
                    rectShape.Texture = Content.textSurface;
                    break;
                case Type_of_surface.hp_surface:
                    rectShape.Texture = Content.hp_surface;
                    break;
                case Type_of_surface.Svitok_720_480:
                    rectShape.Texture = Content.textSurface_720_480;
                    break;
                case Type_of_surface.Viper:
                    rectShape.Texture = Content.viper;
                    break;
                case Type_of_surface.Drop_Button:
                    rectShape.Texture = Content.drop_Button;
                    break;
                case Type_of_surface.Open_Button:
                    rectShape.Texture = Content.open_Button;
                    break;
                case Type_of_surface.Skeleton:
                    rectShape.Texture = Content.skeleton;
                    break;
                case Type_of_surface.Spear:
                    rectShape.Texture = Content.spear;
                    break;
                case Type_of_surface.Skull:
                    rectShape.Texture = Content.skull;
                    break;
                case Type_of_surface.Mimic:
                    rectShape.Texture = Content.mimic;
                    break;
                case Type_of_surface.Chest:
                    rectShape.Texture = Content.chest;
                    break;
                case Type_of_surface.Dice:
                    rectShape.Texture = Content.dice;
                    break;
                case Type_of_surface.Ok_Button:
                    rectShape.Texture = Content.ok_Button;
                    break;
                case Type_of_surface.Sword:
                    rectShape.Texture = Content.Sword;
                    break;
                case Type_of_surface.FireBall:
                    rectShape.Texture = Content.FireBall;
                    break;
                case Type_of_surface.HoliLight:
                    rectShape.Texture = Content.HoliLight;
                    break;
                case Type_of_surface.Game_over:
                    rectShape.Texture = Content.Game_over;
                    break;
                default:
                    break;
            }
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(rectShape, states);
        }
    }
}
