using Godot;
using System;

public partial class WindowBase : Panel
{
	private bool _dragging;
	private Vector2 _dragOffset;
	
	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.Left)
			{
				if (mouseButton.Pressed)
				{
					_dragging = mouse.Pressed;
					_dragOffset = mouseButton.Position;
				}
			}
		}
	}
	
	public override void _Process(double delta)
	{
		if(!_dragging)
		{
			GlobalPosition = GetGlobalMousePosition() - _dragOffset;
		}
		
		
	}
	
	public void Close()
	{
		QueueFree();
		CloseButton.Pressed += Close;
	}
}
