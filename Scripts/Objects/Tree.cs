using Godot;
using System;

public partial class Tree : Node2D
{
	[Export]
	public string clickSceneDir;

	public override void _Ready() 
	{
		var treeBody = GetNode<TreeClick>("Body");
		treeBody.HitboxClicked += OnHitboxClick;
	}

	public void OnHitboxClick() {
		GetTree().Root.GetNode("main").AddChild(ResourceLoader.Load<PackedScene>($"res://Scenes/{clickSceneDir}.tscn").Instantiate()); // Add the next scene to the main node in the root scene
		GetOwner().QueueFree();
	}
}
