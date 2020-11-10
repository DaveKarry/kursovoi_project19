using SFML.Graphics;

namespace Games
{
    class Content
    {
        public const string Content_dir = "..\\Content\\";
        public static Texture textTile;
        public static Texture textSurface;
        public static Texture textSurface_720_480;
        public static Texture squadTile;
        public static Texture avatar_rogue;
        public static Texture avatar_warrior;
        public static Texture avatar_priest;
        public static Texture hp_surface;
        public static Font font;
        public static Texture chest;
        public static Texture viper;
        public static Texture drop_Button;
        public static Texture open_Button;
        public static Texture ok_Button;
        public static Texture skeleton;
        public static Texture spear;
        public static Texture skull;
        public static Texture mimic;
        public static Texture dice;
        public static Texture skeleton_warrior;
        public static Texture Golem;
        public static Texture Warlock;
        public static Texture Sword;
        public static Texture HoliLight;
        public static Texture FireBall;
        public static Texture Game_over;
        public static void Load()
        {
            textTile = new Texture(Content_dir + "tiles0.png");
            squadTile = new Texture(Content_dir + "tiles0.png");
            textSurface = new Texture(Content_dir + "surface.png");
            avatar_rogue = new Texture(Content_dir + "Rogue.png");
            avatar_warrior = new Texture(Content_dir + "warrior.png");
            avatar_priest = new Texture(Content_dir + "Priest.png");
            chest = new Texture(Content_dir + "treasure.png");
            viper = new Texture(Content_dir + "viper.png");
            drop_Button = new Texture(Content_dir + "drop_button.png");
            open_Button = new Texture(Content_dir + "open_button.png");
            skeleton = new Texture(Content_dir + "Skeleton.png");
            spear = new Texture(Content_dir + "Spear.png");
            skull = new Texture(Content_dir + "skull.png");
            mimic = new Texture(Content_dir + "Mimic.png");
            dice = new Texture(Content_dir + "dodecahedron.png");
            ok_Button = new Texture(Content_dir + "ok_button.png");
            skeleton_warrior = new Texture(Content_dir + "Skeleton_war.png");
            Golem = new Texture(Content_dir + "Golem.png");
            Warlock = new Texture(Content_dir + "Warlock.png");
            FireBall = new Texture(Content_dir + "Fireball.png");
            HoliLight = new Texture(Content_dir + "HoliLight.png");
            Sword = new Texture(Content_dir + "Sword.png");
            Game_over = new Texture(Content_dir + "Game_over.png");
            hp_surface = new Texture(Content_dir + "HP.png");
            textSurface_720_480 = new Texture(Content_dir + "surface_720_480.png");
            font = new Font(Content_dir + "CyrilicOld.ttf");
        }
    }
}
