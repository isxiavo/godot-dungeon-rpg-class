using Godot;
using System;

public abstract partial class Character : CharacterBody3D
{
  [ExportGroup("Required Nodes")]
  [Export] public AnimationPlayer AnimPlayerNode { get; private set; }
  [Export] public Sprite3D SpriteNode { get; private set; }
  [Export] public StateMachine StateMachine { get; private set; }

  [ExportGroup("AI Nodes")]
  [Export] public Path3D PathNode { get; private set; }

  public Vector2 moveDirection = new();

  public void FlipSprite()
  {
    if (Velocity.X == 0)
      return;

    bool isMovingLeft = Velocity.X < 0;
    SpriteNode.FlipH = isMovingLeft;
  }
}