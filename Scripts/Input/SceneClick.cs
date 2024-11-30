using Godot;
using System;

public partial class ClickDetection : Area2D
{
	[Export]
	public CollisionObject2D colPolygon;
	[Export]
	public int curSceneNum;
	[Export]
	public PackedScene nextScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouseButton) {
			if (mouseButton.Pressed && mouseButton.ButtonIndex == MouseButton.Left) {
				GetTree().Root.GetNode("main").AddChild(nextScene.Instantiate()); // Add the next scene to the main node in the root scene
			}
		}
    }
}
