 
using Unity.Entities;
using UnityEngine;

public class BakePersonComponent : MonoBehaviour
{ 
    public float _speed = 0f;
    public GameObject _projectilePrefub;
    class Baker : Baker<BakePersonComponent>
    {
        public override void Bake(BakePersonComponent authoring)
        {
             Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new PersonMoveInput());
            AddComponent(entity, new PersonMoveSpeed
            {
                speed = authoring._speed
            }); 
        }
    }
} 
