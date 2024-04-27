
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Extensions;
using UnityEngine;

[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public partial class AddForceSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<PhysicsForce>();


    }
    protected override void OnUpdate()
    {
        Debug.Log("System updating...");
        float deltaTime = SystemAPI.Time.DeltaTime;
        Entities.ForEach((Entity sphere, ref PhysicsVelocity physicsVelocity, ref PhysicsMass physicsMass, in PhysicsForce physicsForce) =>
        {
            if (Input.GetKey(physicsForce.forwardInputKey))
            {
                Debug.Log("Key pressed and force applied.");
                float3 forceVector = new float3(0, 0, physicsForce.forceAmount * deltaTime); // Assuming Z-forward in local space
                physicsVelocity.ApplyLinearImpulse(physicsMass, forceVector);
            }
            else
            {
                Debug.Log("Key not pressed.");
            }
        }).Run();
    }
}
