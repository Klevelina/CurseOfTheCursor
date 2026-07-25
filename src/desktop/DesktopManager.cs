using Godot;
using System.Collections.Generic;

public partial class DesktopManager : Control
{
	[Export]
	public Vector2I GridSize = new(64, 64);
	
	private readonly List<DesktopIcon> _icons = new();
	private DesktopIcon _selectedIcon;
	
	public override void _Ready()
	{
		foreach (Node child in GetNode("DesktopSurface").GetChildren())
		{
			if (child is DesktopIcon icon)
			{
				_icons.Add(icon);
			}
		}
	}
	
	public Vector2 SnapToGrid(Vector2 position, DesktopIcon currentIcon, Vector2 originalPosition)
	{
		Vector2 snapped = new Vector2(
			Mathf.Round(position.X / GridSize.X) * GridSize.X,
			Mathf.Round(position.Y / GridSize.Y) * GridSize.Y
		);

		if (IsPositionOccupied(snapped, currentIcon))
		{
			return originalPosition;
		}

		return snapped;
	}
	
	private bool IsPositionOccupied(Vector2 position, DesktopIcon currentIcon)
	{
		foreach (DesktopIcon icon in _icons)
		{
			if (icon == currentIcon)
				continue;

			if (icon.Position.DistanceTo(position) < 10)
				return true;
		}

		return false;
	}
	
	public void SelectIcon(DesktopIcon icon)
	{
		if (_selectedIcon != null)
			_selectedIcon.Deselect();
		
		_selectedIcon = icon;
		icon.Select();
	}
}
