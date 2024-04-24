
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms; 

[UpdateBefore(typeof(TransformSystemGroup))]    
public partial struct MoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float _deltaTime = SystemAPI.Time.DeltaTime;
        MoveJob moveJob = new MoveJob()
        {
            deltaTime = _deltaTime
        };
        moveJob.ScheduleParallel();
    }
}
[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float deltaTime;
    [BurstCompile]
    public void Execute(ref LocalTransform transform, in  PersonMoveInput inputAxis, PersonMoveSpeed value)
    {
        transform.Position.xz += inputAxis.direction * value.speed * deltaTime;
        if(math.lengthsq(inputAxis.direction) > float.Epsilon)
        {
            float3 direction = new float3(inputAxis.direction.x, 0f, inputAxis.direction.y);
            transform.Rotation = quaternion.LookRotation(direction, math.up());
        }
    }
}
