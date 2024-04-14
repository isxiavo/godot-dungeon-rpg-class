using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{
  [Export(PropertyHint.Range, "0, 15, 0.1f")] private float moveSpeed = 10;

  public override void _PhysicsProcess(double delta)
  {
    if (characterNode.moveDirection == Vector2.Zero)
    {
      characterNode.StateMachine.SwitchState<PlayerIdleState>();
      return;
    }

    characterNode.Velocity = new(characterNode.moveDirection.X, 0, characterNode.moveDirection.Y);
    characterNode.Velocity *= moveSpeed;

    characterNode.MoveAndSlide();
    characterNode.FlipSprite();
  }

  public override void _Input(InputEvent @event)
  {
    if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
    {
      characterNode.StateMachine.SwitchState<PlayerDashState>();
    }
  }

  protected override void EnterState()
  {
    characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);
  }
}