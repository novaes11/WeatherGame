using Godot;
using System;

public enum Loglevel
{
	DEBUG, //Informações técnicas para o desenvolvedor.

	INFO, //Avisos gerais sobre o que está acontecendo (ex: "Fase carregada").

	WARNING, //Algo estranho aconteceu, mas o jogo ainda funciona.

	ERROR //Algo deu errado e precisa de atenção imediata.
}
