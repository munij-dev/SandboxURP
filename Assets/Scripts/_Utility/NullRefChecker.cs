/*
 * Created by: munij
 * Project: Sandbox
 * Date created: 1/25/2024 5:05:46 PM
 */

using UnityEngine;
using System.Reflection;
using System.Runtime.InteropServices;

/// <summary>
/// Original utility script by Thomas Jacobsen
/// Source: https://github.com/UnityTechnologies/PaddleGameSO/blob/main/Assets/Core/Utilities/Scripts/NullRefChecker.cs
/// Changed null check to switch statement.
/// </summary>


public static class NullRefChecker
{
	public static void Validate(object instance)
	{
		// Cache all non-static fields both public and private
		FieldInfo[] fields = instance.GetType().GetFields(
			BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public);
		
		foreach (FieldInfo field in fields)
		{
			// If non-serialized or optional, do nothing
			if (!field.IsDefined(typeof(SerializeField), true) ||
			    field.IsDefined(typeof(OptionalAttribute), true))
			{
				continue;
			}

			// If null, log error depending on instance type
			if (field.GetValue(instance) == null)
			{
				switch (instance)
				{
					case MonoBehaviour monoBehaviour:
					{
						GameObject gameObject = monoBehaviour.gameObject;
						Debug.LogError(
							$"Missing assignment for field: {field.Name} in component: {instance.GetType().Name} on GameObject: " +
							$"{gameObject}", gameObject);
						break;
					}
					case ScriptableObject scriptableObject:
						Debug.LogError(
							$"Missing assignment for field: {field.Name} on ScriptableObject:  " +
							$"{scriptableObject.name} ({instance.GetType().Name})");
						break;
					default:
						Debug.LogError(
							$"Missing assignment for field: {field.Name} in object: {instance.GetType().Name}");
						break;
				}
			}
		}
	}
}