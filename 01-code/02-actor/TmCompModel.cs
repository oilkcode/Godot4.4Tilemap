using Godot;
using System;

public partial class TmCompModel : Node
{
	//----------------------------------------------------------------------------------------
	[Export]
	public Sprite2D MySprite = null;
	//----------------------------------------------------------------------------------------
	public void SetFaceDir_Up()
	{
		MySprite.RotationDegrees = 0;
	}
	//----------------------------------------------------------------------------------------
	public void SetFaceDir_Down()
	{
		MySprite.RotationDegrees = 180;
	}
	//----------------------------------------------------------------------------------------
	public void SetFaceDir_Left()
	{
		MySprite.RotationDegrees = -90;
	}
	//----------------------------------------------------------------------------------------
	public void SetFaceDir_Right()
	{
		MySprite.RotationDegrees = 90;
	}
	//----------------------------------------------------------------------------------------
}
