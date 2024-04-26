
using Unity.Entities;
using UnityEngine;
public struct PhysicsForce : IComponentData
{
    public float forceAmount;
    public KeyCode forwardInputKey;
}