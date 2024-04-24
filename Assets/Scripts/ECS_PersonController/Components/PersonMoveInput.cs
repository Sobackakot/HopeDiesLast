
using Unity.Entities;
using Unity.Mathematics; 

public struct PersonMoveInput : IComponentData
{
    public float2 direction;
} 
public struct PersonMoveSpeed: IComponentData
{
    public float speed;
}
public struct PersonTag: IComponentData { }
public struct FireProjectileTag : IComponentData, IEnableableComponent { }
public struct ProjectilePrefub : IComponentData
{
    public Entity entity;
}