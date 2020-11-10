using SFML.Graphics;
using SFML.System;

namespace Games
{
    enum TileType
    {
        None,Wall,Cell,exit,treasure_0,treasure_1
    }
    class Tile : Transformable, Drawable
    {
        public const int Tile_Size = 32;
        public TileType type = TileType.Wall;
        RectangleShape rectShape;
        public Tile(TileType type)
        {
            this.type = type;
            rectShape = new RectangleShape(new Vector2f(Tile_Size,Tile_Size));
            rectShape.Texture = Content.textTile;
            switch (type)
            {
                case TileType.Wall:
                    rectShape.TextureRect = new IntRect(0, 0, Tile_Size, Tile_Size);
                    break;
                case TileType.Cell:
                    rectShape.TextureRect = new IntRect(Tile_Size, 0, Tile_Size, Tile_Size);
                    break;
                case TileType.exit:
                    rectShape.TextureRect = new IntRect(Tile_Size*3, 0, Tile_Size, Tile_Size);
                    break;
                case TileType.treasure_0:
                    rectShape.TextureRect = new IntRect(Tile_Size * 4, 0, Tile_Size, Tile_Size);
                    break;
                case TileType.treasure_1:
                    rectShape.TextureRect = new IntRect(Tile_Size * 5, 0, Tile_Size, Tile_Size);
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
