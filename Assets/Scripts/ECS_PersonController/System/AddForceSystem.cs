 
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
        float deltaTime = SystemAPI.Time.DeltaTime;
        Entities.ForEach((Entity sphere,ref PhysicsVelocity physicsVelocity, ref PhysicsMass physicsMass, in PhysicsForce physicsForce) =>
        {
            if(Input.GetKey(physicsForce.forwardInputKey)) 
            { 
                float3 forceVector = Vector3.forward * physicsForce.forceAmount * deltaTime;
                physicsVelocity.ApplyAngularImpulse(physicsMass, forceVector);  
            }
        }).Run();
    }
}
       