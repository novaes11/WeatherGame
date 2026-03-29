using Godot;
using System.Collections.Generic;

namespace Game.Utilities
{
	public partial class StateMachine : Node
	{
		[Export] public Node Customer { get; set; }
		[Export] public State CurrentState { get; set; }

	public override void _Ready()
	{
		foreach (Node child in GetChildren())
	{
			if (child is State state)
			{
				state.StateOwner = Customer;
				state.SetProcess(false);
			}
	}

		if (CurrentState != null)
			{
				ChangeState(CurrentState);
			}
		}

		public string GetCurrentStateName()
		{
			return CurrentState.GetType().Name;
		}

		public void ChangeState(State newState)
		{
			CurrentState?.ExitState();
			CurrentState = newState;
			CurrentState.EnterState();

			foreach (Node child in GetChildren())
			{
				if (child is State state)
				{
				state.SetProcess(state == CurrentState);
				}
			}
		}
	}
}