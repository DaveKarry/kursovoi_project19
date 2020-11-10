using Games;
using SFML.Window;

namespace Game
{
    class Open_chest
    {
        public static void Update(int[] curr_arr, Tile[] curr_tile)
        {
            var mousePosition = Mouse.GetPosition(Program.win_treasure);
            for (int i = 0; i < 5; i++)
            {
                if ((mousePosition.X > curr_tile[i].Position.X) && (mousePosition.Y > curr_tile[i].Position.Y) && (mousePosition.X < curr_tile[i].Position.X + Tile.Tile_Size) && (mousePosition.Y < curr_tile[i].Position.Y + Tile.Tile_Size))
                {
                    if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                    {
                        if (curr_tile[i].type == TileType.treasure_0)
                        {
                            curr_tile[i] = new Tile(TileType.treasure_1);
                            curr_tile[i].Position = new SFML.System.Vector2f(i * Tile.Tile_Size + 260, 200);
                            curr_arr[i] = 1;
                        }
                        else
                        {
                            curr_tile[i] = new Tile(TileType.treasure_0);
                            curr_tile[i].Position = new SFML.System.Vector2f(i * Tile.Tile_Size + 260, 200);
                            curr_arr[i] = 0;
                        }
                    }
                }
            }
        }
        public static void Update(int[,] curr_arr, Tile[,] curr_tile)
        {
            var mousePosition = Mouse.GetPosition(Program.win_treasure);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if ((mousePosition.X > curr_tile[i,j].Position.X) && (mousePosition.Y > curr_tile[i,j].Position.Y) && (mousePosition.X < curr_tile[i,j].Position.X + Tile.Tile_Size) && (mousePosition.Y < curr_tile[i,j].Position.Y + Tile.Tile_Size))
                    {
                        if ((Mouse.IsButtonPressed(Mouse.Button.Left)))
                        {
                            if (curr_tile[i,j].type == TileType.treasure_0)
                            {
                                curr_tile[i,j] = new Tile(TileType.treasure_1);
                                curr_tile[i,j].Position = new SFML.System.Vector2f(i * Tile.Tile_Size + 260, j * Tile.Tile_Size + 200);
                                curr_arr[i,j] = 1;
                            }
                            else
                            {
                                curr_tile[i,j] = new Tile(TileType.treasure_0);
                                curr_tile[i,j].Position = new SFML.System.Vector2f(i * Tile.Tile_Size + 260, j * Tile.Tile_Size + 200);
                                curr_arr[i,j] = 0;
                            }
                        }
                    }
                }
            }
        }
        public static bool Check_matrix(int[] curr_arr, int[] check_arr)
        {
            if ((curr_arr[1] == check_arr[1]) && (curr_arr[2] == check_arr[2]) && (curr_arr[3] == check_arr[3]) && (curr_arr[4] == check_arr[4]) && (curr_arr[0] == check_arr[0]))
            {return true;}
            else
            {return false;}      
        }
        public static bool Check_matrix(int[,] curr_arr, int[,] check_arr)
        {
            if ((curr_arr[0,0] == check_arr[0,0]) && (curr_arr[1,0] == check_arr[1,0]) && (curr_arr[2,0] == check_arr[2,0]) && (curr_arr[3,0] == check_arr[3,0]) && (curr_arr[4,0] == check_arr[4,0]) && (curr_arr[0, 1] == check_arr[0, 1]) && (curr_arr[1, 1] == check_arr[1, 1]) && (curr_arr[2, 1] == check_arr[2, 1]) && (curr_arr[3, 1] == check_arr[3, 1]) && (curr_arr[4, 1] == check_arr[4, 1]))
            {return true;}
            else
            {return false;}
        }
        public static int Get_check_number(int[] curr_arr, int[] check_arr)
        {
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                if (curr_arr[i] != check_arr[i] )
                {count++;}
            }
            return count;
        }
        public static int Get_check_number(int[,] curr_arr, int[,] check_arr)
        {
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (curr_arr[i,j] != check_arr[i,j])
                    {count++;}
                }
            }
            return count;
        }
    }
}
