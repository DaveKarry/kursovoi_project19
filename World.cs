using SFML.Graphics;
using SFML.System;
namespace Games
{
    class World : Transformable,Drawable
    {
        public const int World_Size = 15; // 
        Tile[][] tiles;
        Labirint.CELL[,] cellMaze = new Labirint.CELL[World_Size, World_Size];
        public static Labirint.CELL[,] labir = new Labirint.CELL[World_Size, World_Size];
        public static Labirint.CELL exit_cell = new Labirint.CELL();
        public World()
        {//да
            tiles = new Tile[World_Size][];
            for (int i = 0; i < World_Size; i++)
            {tiles[i] = new Tile[World_Size];}
            labir = Labirint.Get_New_labirint(World_Size, World_Size);
            exit_cell = Labirint.GetLongWay(labir, World_Size, World_Size);
            for (int x = 0; x < World_Size; x++)
            {
                for (int y = 0; y < World_Size; y++)
                {
                    if (labir[x, y].type == "0")
                    { SetTile(TileType.Wall, x, y); }
                    if (labir[x, y].type == " ")
                    { SetTile(TileType.Cell, x, y); }
                    if (labir[x, y].Way_count == exit_cell.Way_count)
                    { SetTile(TileType.exit, x, y); }
                }
            }
        }
        public void SetTile(TileType type, int x, int y)
        {
            tiles[x][y] = new Tile(type)
            {
                Position = new Vector2f(x * Tile.Tile_Size, y * Tile.Tile_Size)
            };
        }
        public Labirint.CELL GetCell(int x, int y)
        {
            Labirint.CELL current_cell = new Labirint.CELL();
            return current_cell;
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            for (int x = 0; x < World_Size; x++)
            {
                for (int y = 0; y < World_Size; y++)
                {
                    if (tiles[x][y] == null) continue;
                    target.Draw(tiles[x][y], states);
                }
            }
        }
    }
}
