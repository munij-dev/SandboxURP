/*
 * Created by: munij
 * Project: Sandbox
 * Date created: 1/26/2024 12:53:38 AM
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject which adds a description field.
/// </summary>

public class Description : ScriptableObject
{
 [TextArea(5, 20)]
 [SerializeField] protected string description;
}

