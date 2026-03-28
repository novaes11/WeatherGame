using Godot;
using System;

//Esta classe funciona como o "cérebro" acessível de qualquer lugar. Ela guarda configurações que todo o jogo precisa saber.

//Organiza o código dentro de uma "caixa" específica para evitar conflitos de nomes.
namespace BeaverKnight.App.Core
{

	public partial class Global : Node
	{	
		//É o padrão Singleton. Isso permite que você acesse Global.Instance de qualquer outro script sem precisar procurar o nó na árvore do Godot.
		public static Global Instance {get; private set;}

		[ExportCategory("Gameplay")]

		//Uma variável que aparece no Inspetor do Godot. Útil para definir o tamanho dos quadrados do seu jogo (como um movimento em grade) sem mexer no código.
		[Export] public int GRID_SIZE = 16;
		
		//Quando o jogo começa, ele salva a si mesmo na variável Instance e testa o sistema de logs enviando quatro mensagens de boas-vindas.
		public override void _Ready()
		{
			Instance = this;


			Logger.Info("Carregando Global ...");
			Logger.Debug("Carregando Global ...");
			Logger.Warning("Carregando Global ...");
			Logger.Error("Carregando Global ...");

		}
	}
}
