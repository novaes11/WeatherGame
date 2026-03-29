using Godot;
using System;

namespace BeaverKnight.App.Gameplay{

	public partial class CharacterMovement : Node
	{

		[Signal] public delegat void AnimationEventHandler();

		[ExportCategory("Nós")]

		[Export] public Node2D Character;

		[Export] public CharacterInput CharacterInput; 	

		[ExportCategory("Movimentação")]

		[Export] public Vector2 PosicaoAlvo = Vector2.Down;

		[Export] public bool IsWalking = false;

		public override void _Ready()
		{
		}

		public override void _Process(double delta)
		{
		}


		public bool IsMoving()
		{
			return IsWalking;
		}

		public void StartWalking()
		{
			if (!IsMoving())
			{
				TargetPosition = Character.Position + CharacterInput.Direção * Global.Instance.GRID_SIZE;
				Logger.Info($"Iniciando caminhada para {TargetPosition}");
				IsWalking = true;
			}
			else
			{
				//PARAFAZER: Idle Animation
			}
		}
		public void Walk(double delta)
		{
			if (IsWalking){
				Character.Position = CharacterPosition.MoveToward(TargetPosition, (float)delta * Global.Instance.GRID_SIZE * 4);

				if(Character.Position.DistanceTo(TargetPosition) < 1f)
				{
					StopWalking();
				
				}
			}
			else
			{
				//PARAFAZER: Idle Animation
			}
		}

		public void StopWalking()
		{

			IsWalking = false;
			SnapPositionToGrid();
			
		}

		public void SnapPositionToGrid()
		{
			Character.Position = new Vector2(
				Mathf.Round(Character.Position.X / Global.Instance.GRID_SIZE) * Global.Instance.GRID_SIZE * 4,
				Mathf.Round(Character.Position.Y / Global.Instance.GRID_SIZE) * Global.Instance.GRID_SIZE * 4
			)
		}
	}
}