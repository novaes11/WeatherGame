using Godot;
using System;

namespace BeaverKnight.App.Gameplay.Characters
{
	

	public partial class Input : CharacterInput
	{
		[ExportCategory("Input do Jogador")]

		[Export] public double PressaoBotao = 0.1f;

		[Export] public double TempoPressao = 0.0f;


		public override void _Ready()
		{
			Logger.Info("Carregando componente de input do jogador...");
		}

		
	}
}
