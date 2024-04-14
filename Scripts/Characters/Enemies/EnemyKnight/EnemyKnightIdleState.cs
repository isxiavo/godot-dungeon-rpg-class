using Godot;
using System;

public partial class EnemyKnightIdleState : EnemyState
{
  protected override void EnterState()
  {
    characterNode.AnimPlayerNode.Play(GameConstants.ANIM_IDLE);
  }
}