/*
 * Created by: munij
 * Project: Sandbox
 * Date created: 1/23/2024 9:09:06 PM
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Input listener for InputAction events.
/// Subscribes to input actions directly.
/// </summary>

public class InputReader : ScriptableObject, CharacterControls.IPlayerActions
{
	//______________________________________________________//  public static |
	
	public static bool IsPaused = false;
	
	//______________________________________________________//         public |
	
	public event UnityAction<float> Move = delegate { };
	public event UnityAction<bool> Jump = delegate { };
	public event UnityAction<bool> Interact = delegate { };
	public event UnityAction<Vector2> Look = delegate { };
	public event UnityAction<bool> Pause = delegate { };
	
	//______________________________________________________// private static |
	//______________________________________________________//        private |
	
	private CharacterControls _characterControls;
	private CharacterControls.PlayerActions _playerActions;
	
	//______________________________________________________//      protected |
	//_______________________________________________________//  constructors |
	//_______________________________________________________//       methods |
	
	// Handle subscriptions
	/*
	 * 1. Instance input action collection.
	 * 2. Iterate and Enable action maps in input action collection.
	 * 3. Iterate action maps, add actions to event buffer, and subscribe to them.
	 */
	private void OnEnable()
	{
		_characterControls = new CharacterControls();
		_playerActions = _characterControls.Player;
		_playerActions.Enable();
		_playerActions.SetCallbacks(this);
		_playerActions.Interact.performed += OnInteract;
		_playerActions.Jump.performed += OnJump;
		_playerActions.Move.performed += OnMove;
		_playerActions.Look.performed += OnLook;
		_playerActions.Pause.performed += OnPause;
	}
	
	private void OnDisable()
	{
		_playerActions.Interact.performed -= OnInteract;
		_playerActions.Jump.performed -= OnJump;
		_playerActions.Move.performed -= OnMove;
		_playerActions.Look.performed -= OnLook;
		_playerActions.Pause.performed -= OnPause;
	}
	
	public void OnInteract(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			
		}
	}
	
	public void OnJump(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			
		}
	}
	
	public void OnMove(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			
		}
	}
	
	public void OnLook(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			
		}
	}

	public void OnPause(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
		{
			if (IsPaused) ResumeGame();
			else PauseGame();
		}
	}

	public void ResumeGame()
	{
		
	}

	public void PauseGame()
	{
		
	}
}