using Godot;
using System;

public partial class TmTilemapData : TileMapLayer
{
	public AStarGrid2D astar = new AStarGrid2D();

    public override void _Ready()
    {
        Rect2i UsedRect = get_used_rect();
        Vector2i tilemap_size = UsedRect.end - UsedRect.position;
        Rect2i map_rect = new Rect2i(Vector2i.ZERO, tilemap_size);
        Vector2i tile_size = get_tile_set().tile_size;

        astar.region = map_rect;
        astar.cell_size = tile_size;
	}
	
}

