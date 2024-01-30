using System.Collections;
using System.Collections.Generic;
using System;

/*
 * Original script by Adam Robinson-Yu
 * GitHub: https://github.com/adamgryu/OldUnityTools/blob/master/Scripts/EventList.cs
 * Modified syntax to adhere to newer C# standards.
 */

/// <summary>
/// Create a System.Action list with Add and Remove methods that can be subscribed to.
/// </summary>
/// <typeparam name="T"></typeparam>

public class EventList<T> : IEnumerable<T>
{
    //______________________________________________________//  public static |
    
    //______________________________________________________//         public |
    
    public event Action OnModified;

    //______________________________________________________// private static |
    
    //______________________________________________________//        private |
    
    private List<T> _list;

    //______________________________________________________//      protected |
    
    // ______________________________________________________//  constructors |
    
    public EventList() {
        this._list = new List<T>();
    }

    // ______________________________________________________//       methods |
    
    public void Add(T item) {
        _list.Add(item);
        OnModified?.Invoke();
    }

    public void Remove(T item) {
        _list.Remove(item);
        OnModified?.Invoke();
    }

    public IEnumerator<T> GetEnumerator() {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return _list.GetEnumerator();
    }
}
