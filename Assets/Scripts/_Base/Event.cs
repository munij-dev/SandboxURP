/*
 * Created by: munij
 * Project: Sandbox
 * Date created: 1/24/2024 12:03:30 AM
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Generic implementation for ScriptableObject events of variable types.
/// </summary>
/// <typeparam name="T">Notification parameter type.</typeparam>

[System.Serializable]
public abstract class Event<T> : ScriptableObject
{
    //______________________________________________________//  public static |
    //______________________________________________________//         public |
    //______________________________________________________// private static |
    //______________________________________________________//        private |
    
    private readonly List<IListener<T>> _listeners = new();
    private bool _isNotifying;
    
    //______________________________________________________//      protected |
    // ______________________________________________________//  constructors |
    // ______________________________________________________//       methods |
    
    public void Notify(T param)
	{
		_isNotifying = true;
	    for (int i = _listeners.Count - 1; i >= 0; i--)
	    {
		    // Notify events in reverse to avoid a self destruction event error.
		    _listeners[i].OnEventRaised(param);
	    }
	    _isNotifying = false;
	}
    
    public void SubscribeListener(IListener<T> listener)
	{
		Assert.IsFalse(_isNotifying);
	    if (!_listeners.Contains(listener))
	    {
		    _listeners.Add(listener);
	    }
	}
    
    public void UnsubscribeListener(IListener<T> listener)
	{
		Assert.IsFalse(_isNotifying);
	    if (_listeners.Contains(listener))
	    {
		    _listeners.Remove(listener);
	    }
	}
}
