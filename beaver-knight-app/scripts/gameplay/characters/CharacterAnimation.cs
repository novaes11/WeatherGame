using Godot;
using System;
using BeaverKnight.App.Core;
using Logger = BeaverKnight.App.Core.Logger;



namespace BeaverKnight.App.Gameplay.Characters
{
	public partial class CharacterAnimation : AnimatedSprite2D
	{

		[ExportCategory("Nós")]

		[Export] public CharacterInput CharacterInput;

		[Export] public CharacterMovement CharacterMovement;

		[ExportCategory("Animação")]

[Export] public ECharacterAnimation currentAnimation = ECharacterAnimation.idle_down;
		
		public override void _Ready()
		{
			Logger.Info("Componentes de animação do jogador carregando ...");
		}

		public void PlayAnimation(string animationType)
		{

ECharacterAnimation previousAnimation = currentAnimation;

			if (CharacterMovement.IsMoving()) return;

			switch (animationType)
			{
				case "walk":
					if(CharacterInput.Direction == Vector2.Up)
					{
						ECharacterAnimation = ECharacterAnimation.walk_up;
					}
					else if(CharacterInput.Direction == Vector2.Down)
					{
						ECharacterAnimation = ECharacterAnimation.walk_down;
					}
					else if(CharacterInput.Direction == Vector2.Left)
					{
						ECharacterAnimation = ECharacterAnimation.walk_left;
					}
					else if(CharacterInput.Direction == Vector2.Right)
					{
						ECharacterAnimation = ECharacterAnimation.walk_right;
					}
					break;
				case "idle":
					if(CharacterInput.Direction == Vector2.Up)
					{
						ECharacterAnimation = ECharacterAnimation.idle_up;
					}
					else if(CharacterInput.Direction == Vector2.Down)
					{
						ECharacterAnimation = ECharacterAnimation.idle_down;
					}
					else if(CharacterInput.Direction == Vector2.Left)
					{
currentAnimation = ECharacterAnimation.idle_left;
					}
					else if(CharacterInput.Direction == Vector2.Right)
					{
						ECharacterAnimation = ECharacterAnimation.idle_right;
					}
					break;
				case "turn":
					if(CharacterInput.Direction == Vector2.Up)
					{
						ECharacterAnimation = ECharacterAnimation.turn_up;
					}
					else if(CharacterInput.Direction == Vector2.Down)
					{
						ECharacterAnimation = ECharacterAnimation.turn_down;
					}
					else if(CharacterInput.Direction == Vector2.Left)
					{
						ECharacterAnimation = ECharacterAnimation.turn_left;
					}
					else if(CharacterInput.Direction == Vector2.Right)
					{
						ECharacterAnimation = ECharacterAnimation.turn_right;
					}
					break;
				}
				
if(previousAnimation != currentAnimation)
				{
Play(currentAnimation.ToString());
				
				}

			}
			
		}

	}


