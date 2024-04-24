 
using Unity.Entities; 
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]  
public partial class GetInputSystem : SystemBase
{
    private InputActions inputActions;
    private Entity _entityPerson;
    protected override void OnCreate()
    {
        RequireForUpdate<PersonTag>();
        RequireForUpdate<PersonMoveInput>();
        inputActions = new InputActions();
    }
    protected override void OnStartRunning()
    {
        inputActions.Enable();
        _entityPerson = SystemAPI.GetSingletonEntity<PersonTag>();
    }
    protected override void OnStopRunning()
    {
        inputActions.Disable();
        _entityPerson = Entity.Null;
    }
    protected override void OnUpdate()
    {
        Vector2 currenMoveInput = inputActions.MoveMaps.PlayerMovement.ReadValue<Vector2>();
        SystemAPI.SetSingleton(new PersonMoveInput { direction = currenMoveInput });
    }
} 
