using Godot;
using System;

public partial class DesktopIcon : Control
{
	private bool _dragging = false;
	private Vector2 _dragOffset;
	
	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.Left)
			{
				if(mouseButton.Pressed)
				{
					_dragging = true;
					_dragOffset = mouseButton.Position;
				}
				else 
				{
					_dragging = false;
				}
			}
		}
	}
	
	public override void _Process(double delta)
	{
		if(!_dragging)
			return;
		
		GlobalPosition = GetGlobalMousePosition() - _dragOffset;
	}
	
}
