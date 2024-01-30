/*
 * Created by: munij
 * Project: Sandbox
 * Date created: 1/24/2024 12:07:40 AM
 */

/// <summary>
/// Interface for parametrized listeners.
/// </summary>
/// <typeparam name="T"></typeparam>

public interface IListener<T>
{
    public void OnEventRaised(T param);
}