
using Unity.Entities;
using UnityEngine;

public class ConvertToEntity : MonoBehaviour
{
    public float forceAmount = 10f;
    public KeyCode forwardInputKey = KeyCode.Space;
    class Baker : Baker<ConvertToEntity>
    {
        public override void Bake(ConvertToEntity authoring)
        {
             Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new PhysicsForce
            {
                forceAmount = authoring.forceAmount, 
                forwardInputKey = authoring.forwardInputKey
            });
        }
    }
}
