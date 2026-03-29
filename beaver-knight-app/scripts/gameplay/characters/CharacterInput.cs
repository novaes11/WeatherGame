using Godot;
using System;

namespace BeaverKnight.App.Gameplay.Characters
{
	

	public abstract partial class CharacterInput : Node
	{
		[Signal] public delegate void WalkEventHandler();

		[Signal] public delegate void TurnEventHandler();

		[ExportCategory("Inputs Comuns")]

		[Export] public Vector2 Direction = Vector2.Zero;

		[Export] public Vector2 TargetPosition = Vector2.Zero;

		
	}
}
