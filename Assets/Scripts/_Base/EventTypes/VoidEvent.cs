/*
 * Created by: munij
 * Project: Sandbox
 * Date created: 1/26/2024 6:03:29 PM
 */

using UnityEngine;

namespace _Base.EventTypes
{
 [CreateAssetMenu(fileName = "VoidEvent", menuName = "Event/Void Event")]
 public class VoidEvent : Event<Void>
 {
  public void Notify() => Notify(new Void());
 }
}
