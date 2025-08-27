using Godot;
using System;

public partial class TmCompInput : Node
{
	//----------------------------------------------------------------------------------------
	[Export]
	public TmCompMove MyCompMove = null;
	//当前按键输入的结果
	public Vector2 MyInputValue = new Vector2(0, 0);
	//----------------------------------------------------------------------------------------
	public override void _Process(double delta)
	{
		MyInputValue.X = 0;
		MyInputValue.Y = 0;
		if (Input.IsActionPressed("player_move_up"))
			MyInputValue.Y -= 1;
		if (Input.IsActionPressed("player_move_down"))
			MyInputValue.Y += 1;
		if (Input.IsActionPressed("player_move_left"))
			MyInputValue.X -= 1;
		if (Input.IsActionPressed("player_move_right"))
			MyInputValue.X += 1;
		Func_MakeMove();
	}
	//----------------------------------------------------------------------------------------
	protected void Func_MakeMove()
	{
		int FinalDir = EActorMoveDir.MoveDir_None;
		if (MyInputValue.Y < -0.1f)
		{
			FinalDir = EActorMoveDir.MoveDir_Up;
		}
		else if (MyInputValue.Y > 0.1f)
		{
			FinalDir = EActorMoveDir.MoveDir_Down;
		}
		else if (MyInputValue.X < -0.1f)
		{
			FinalDir = EActorMoveDir.MoveDir_Left;
		}
		else if (MyInputValue.X > 0.1f)
		{
			FinalDir = EActorMoveDir.MoveDir_Right;
		}
		//GD.Print("TmCompInput: Func_MakeMove " + FinalDir);
		MyCompMove.SetMoveDir(FinalDir);
	}
	//----------------------------------------------------------------------------------------
}
