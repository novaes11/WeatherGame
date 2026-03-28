using Godot;
using System;


namespace BeaverKnight.App.Core
{
	//Você não precisa "criar" um logger; basta chamar Logger.Info().
	public static class Logger
	{

		//Coração do Sistema.
		public static void Log(Loglevel level, params object[] messagge)
		{
			var dateTime = DateTime.Now; //Carimba o horário exato da mensagem.
			string timeStamp = $"[{dateTime:yyyy-MM-dd HH:mm:ss}]";
			var callingMethod = new System.Diagnostics.StackTrace().GetFrame(2).GetMethod();//Descobre automaticamente qual classe e qual método chamou o log. Isso poupa você de escrever "Erro no script X" manualmente.			
			string logMessage = $"{timeStamp} [{level}] [{callingMethod.DeclaringType.Name}] [{callingMethod.Name}]";
			

			string color = "CYAN";
			
			//Escolhe a cor da mensagem (Branco para Debug, Ciano para Info, Amarelo para Aviso e Vermelho para Erro).
			switch (level)
			{
				case Loglevel.DEBUG:
				color = "WHITE";
					break;
				case Loglevel.INFO:
				color = "CYAN";
					break;
				case Loglevel.WARNING:
				color = "YELLOW";
					break;
				case Loglevel.ERROR:
				color = "RED";
					break;
				default:
					break;
			}		

			//Usa o sistema de formatação do Godot para imprimir o texto com as cores definidas.
			GD.PrintRich([$"[color={color.Trim()}]{logMessage}[/color]", .. messagge]);
			
		}
		//Métodos abaixo - Facilitam o uso no dia a dia, enviando o nível correto para a função principal de log.
		public static void Debug(params object[] messagge)
		{
			Log(Loglevel.DEBUG, messagge);
		}

		public static void Info(params object[] messagge)
		{
			Log(Loglevel.INFO, messagge);
		}

		public static void Warning(params object[] messagge)
		{
			Log(Loglevel.WARNING, messagge);
		}

		public static void Error(params object[] messagge)
		{
			Log(Loglevel.ERROR, messagge);
			
		}
	}
}
