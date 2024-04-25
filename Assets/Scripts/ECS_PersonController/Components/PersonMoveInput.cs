
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
