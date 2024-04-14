using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
  [Export] private Timer dashTimerNode;
  [Export(PropertyHint.Range, "0, 20, 0.1f")] private float dashSpeed = 15;

  public override void _Ready()
  {
    base._Ready();

    dashTimerNode.Timeout += HandleDashTimeout;
  }

  public override void _PhysicsProcess(double delta)
  {
    characterNode.MoveAndSlide();
    characterNode.FlipSprite();
  }

  protected override void EnterState()
  {
    characterNode.AnimPlayerNode.Play(GameConstants.ANIM_DASH);

    characterNode.Velocity = new(characterNode.moveDirection.X, 0, characterNode.moveDirection.Y);
    if (characterNode.Velocity == Vector3.Zero)
    {
      characterNode.Velocity = characterNode.SpriteNode.FlipH ? Vector3.Left : Vector3.Right;
    }

    characterNode.Velocity *= dashSpeed;
    dashTimerNode.Start();
  }

  private void HandleDashTimeout()
  {
    characterNode.Velocity = Vector3.Zero;
    characterNode.StateMachine.SwitchState<PlayerIdleState>();
  }
}