/*
 * Created by: munij
 * Project: Sandbox
 * Date created: 1/24/2024 1:41:23 AM
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An collection of quick extension methods I've gathered from my own projects.
/// </summary>

public static class ExtensionMethods
{
	/// <summary>
	/// Skews input by point multiplying player input vector with isometric rotation matrix.
	/// </summary>
	/// <param name="vector">Vector3</param>
	/// <returns>Matrix4x4</returns>
	public static Vector3 ToIsometric(this Vector3 vector)
	{
		Matrix4x4 isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
		return isometricMatrix.MultiplyPoint3x4(vector);
	}
}
