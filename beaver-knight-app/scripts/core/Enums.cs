using Godot;
using System;

namespace BeaverKnight.App.Core
{
	public enum Loglevel
	{
		DEBUG, //Informações técnicas para o desenvolvedor.

		INFO, //Avisos gerais sobre o que está acontecendo (ex: "Fase carregada").

		WARNING, //Algo estranho aconteceu, mas o jogo ainda funciona.

		ERROR //Algo deu errado e precisa de atenção imediata.
	}


	public enum ECharacterAnimation
	{
		idle_up,

		idle_down,

		idle_left,

		idle_right,

		walk_up,

		walk_down,

		walk_left,

		walk_right,

		turn_up,

		turn_down,

		turn_left,

		turn_right
	}

}
