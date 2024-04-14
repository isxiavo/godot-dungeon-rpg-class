using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{

  private Vector3 destination;

  public override void _Ready()
  {
    base._Ready();

    Vector3 localPos = characterNode.PathNode.Curve.GetPointPosition(0);
    Vector3 globalPos = characterNode.PathNode.GlobalPosition;
    destination = localPos + globalPos;
  }

  public override void _PhysicsProcess(double delta)
  {
    if (characterNode.GlobalPosition == destination)
    {
      GD.Print("fdfddf");
      return;
    }

    characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);
    characterNode.MoveAndSlide();
  }

  protected override void EnterState()
  {
    characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);


  }
}