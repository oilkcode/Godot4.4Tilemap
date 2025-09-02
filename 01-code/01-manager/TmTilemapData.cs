using Godot;
using System;
using System.Diagnostics;

public partial class TmTilemapData : TileMapLayer
{
    public override void _Ready()
    {
        Rect2I UsedRect = GetUsedRect();
        Vector2I tilemap_size = UsedRect.End - UsedRect.Position;
        Rect2I map_rect = new Rect2I(Vector2I.Zero, tilemap_size);
        Vector2I tile_size = GetTileSet().TileSize;
        Vector2 TileSize;
        TileSize.X = tile_size.X * Scale.X;
        TileSize.Y = tile_size.Y * Scale.Y;

        GD.Print(UsedRect.ToString());
        GD.Print(TileSize.ToString());

        Vector2I _Index = new Vector2I();
        for (int _y = 0; _y < tilemap_size.Y; ++_y)
        {
            for (int _x = 0; _x < tilemap_size.X; ++_x)
            {
                _Index.X = UsedRect.Position.X + _x;
                _Index.Y = UsedRect.Position.Y + _y;
                TileData SingleTileData = GetCellTileData(_Index);
                if (SingleTileData != null)
                {
                    if (SingleTileData.HasCustomData("block_flag"))
                    {
                        int FlagValue = SingleTileData.GetCustomData("block_flag").AsInt32();
                        GD.Print(_Index.ToString() + "  " + FlagValue.ToString());
                    }
                }
            }
        }
	}
	
}

