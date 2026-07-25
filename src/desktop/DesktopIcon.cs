using Godot;
using System;

public partial class DesktopIcon : Control
{
	[Export]
	public PackedScene ApplicationScene;
	
	private bool _dragging = false;
	private Vector2 _dragOffset;
	private DesktopManager _desktopManager;
	private Vector2 _startPosition;
	private bool _selected;
	
	public override void _Ready()
	{
		_desktopManager = GetParent().GetParent<DesktopManager>();
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

					_startPosition = Position;
				}
				else 
				{
					_dragging = false;
					Position = _desktopManager.SnapToGrid(Position, this, _startPosition);
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
	
	public void Select()
	{
		_selected = true;
	}
	
	public void Deselect()
	{
		_selected = false;
	}
	
}
