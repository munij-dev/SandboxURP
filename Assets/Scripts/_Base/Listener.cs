/*
 * Created by: munij
 * Project: Sandbox
 * Date created: 1/24/2024 12:32:30 AM
 */

using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Generic implementation for MonoBehaviour observers.
/// </summary>
/// <typeparam name="T">Event parameter data.</typeparam>
/// <typeparam name="TEvent">ScriptableObject event.</typeparam>
/// <typeparam name="TUnityEvent">Event notification invoker.</typeparam>

public abstract class Listener<T, TEvent, TUnityEvent> : MonoBehaviour,
	IListener<T> where TEvent : Event<T> where TUnityEvent : UnityEvent<T> 
{	
    //______________________________________________________//  public static |
    //______________________________________________________//         public |
    
	public TEvent Event
	{
		get => _event;
		set => _event = value;
	}
	
    //______________________________________________________// private static |
    //______________________________________________________//        private |
    
    [SerializeField] private TEvent _event;
    [SerializeField] private TUnityEvent _unityEventResponse;
    
    //______________________________________________________//      protected |
    //_______________________________________________________//  constructors |
    //_______________________________________________________//       methods |
    
    // Handle subscription to events
    private void OnEnable()
    {
	    if (_event == null) {return;}
	    Event.SubscribeListener(this);
	    
    }

    private void OnDisable()
    {
	    if (_event == null){ return;}
	    Event.UnsubscribeListener(this);
    }
	
    // Invoke event upon notification from it
	public void OnNotify(T param) => _unityEventResponse?.Invoke(param);
}