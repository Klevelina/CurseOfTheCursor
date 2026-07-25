using Godot;
using System;

public partial class WindowBase : Panel
{
	private bool _dragging;
	private Vector2 _dragOffset;
	
	private Button _closeButton;
	private Button _minimizeButton;
	
	public override void _Ready()
	{
		_closeButton = GetNode<Button>("TitleBar/CloseButton");
		_minimizeButton = GetNode<Button>("TitleBar/MinimizeButton");
		
		_closeButton.Pressed += Close;
		_minimizeButton.Pressed += Minimize;
	}
	
	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.Left)
			{
				if (mouseButton.Pressed)
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
		if(_dragging)
		{
			GlobalPosition = GetGlobalMousePosition() - _dragOffset;
		}
	}
	
	public void Close()
	{
		QueueFree();
	}
	
	private void Minimize()
	{
		Hide();
	}
}
