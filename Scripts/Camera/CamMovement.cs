using Godot;
using System;

public partial class CamMovement : Camera2D
{
	[Export]
	public int camSpeed = 3;

	public Vector2 camVel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		MoveCamera(); // Move the camera
	}

    private void MoveCamera() {
		Vector2 inputDir = Input.GetVector("camLeft", "camRight", "camUp", "camDown"); // Get the normalised direction of input
		if (!inputDir.IsZeroApprox()) { // If there is a direction (i.e. the camera is supposed to move)...
			camVel = inputDir * camSpeed; // Set the velocity of the camera to the direction with the provided speed
			Position += camVel; // Add the velocity to the position of the camera container
			Position = new Vector2(
				Mathf.Clamp(Position.X, LimitLeft+(GetViewportRect().Size.X/Zoom.X)/2, LimitRight-(GetViewportRect().Size.X/Zoom.X)/2), 
				Mathf.Clamp(Position.Y, LimitTop+(GetViewportRect().Size.Y/Zoom.Y)/2, LimitBottom-(GetViewportRect().Size.Y/Zoom.Y)/2)
				); // Clamp the camera's position between its limits, found by also considering half the size of the camera with regard to the zoom
		}
	}
}
