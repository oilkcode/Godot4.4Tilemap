using Godot;
using System;
//----------------------------------------------------------------------------------------
public class EActorMoveDir
{
    public const int MoveDir_None = 0;
    public const int MoveDir_Up = 1;
    public const int MoveDir_Down = 2;
    public const int MoveDir_Left = 3;
    public const int MoveDir_Right = 4;
}
//----------------------------------------------------------------------------------------
public partial class TmCompMove : Node
{
    [Export]
	public TmCompModel MyCompModel = null;
	//当前移动朝向
	public int CurMoveDirByInput = EActorMoveDir.MoveDir_None;
	public float MoveSpeed = 80.0f;
    private Vector2 Dir_Up = new Vector2(0, -1);
    private Vector2 Dir_Down = new Vector2(0, 1);
    private Vector2 Dir_Left = new Vector2(-1, 0);
    private Vector2 Dir_Right = new Vector2(1, 0);
	//----------------------------------------------------------------------------------------
    public void SetMoveDir(int NewDir)
    {
        CurMoveDirByInput = NewDir;
    }
	//----------------------------------------------------------------------------------------
	public override void _Process(double delta)
	{
		if (CurMoveDirByInput == EActorMoveDir.MoveDir_None)
		{
			return;
		}
		//
		float deltaFloat = (float)delta;
        Vector2 deltaPos = new Vector2(0, 0);
		if (CurMoveDirByInput == EActorMoveDir.MoveDir_Up)
		{
			MyCompModel.SetFaceDir_Up();
			deltaPos = Dir_Up * MoveSpeed * deltaFloat;
		}
		else if (CurMoveDirByInput == EActorMoveDir.MoveDir_Down)
		{
			MyCompModel.SetFaceDir_Down();
			deltaPos = Dir_Down * MoveSpeed * deltaFloat;
		}
		else if (CurMoveDirByInput == EActorMoveDir.MoveDir_Left)
		{
			MyCompModel.SetFaceDir_Left();
			deltaPos = Dir_Left * MoveSpeed * deltaFloat;
		}
		else if (CurMoveDirByInput == EActorMoveDir.MoveDir_Right)
		{
			MyCompModel.SetFaceDir_Right();
			deltaPos = Dir_Right * MoveSpeed * deltaFloat;
		}
		//
		Node2D parentNode = GetParent() as Node2D;
		parentNode.GlobalTranslate(deltaPos);
	}
	//----------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------
