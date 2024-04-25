 
using Unity.Entities; 
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]  
public partial class GetInputSystem : SystemBase
{
    private InputActions inputActions;
    protected override void OnCreate()
    {
        RequireForUpdate<PersonMoveInput>();
        inputActions = new InputActions();
    }
    protected override void OnStartRunning()
    {
        inputActions.Enable();
    }
    protected override void OnStopRunning()
    {
        inputActions.Disable();
    }
    protected override void OnUpdate()
    {
        Vector2 currenMoveInput = inputActions.MoveMaps.PlayerMovement.ReadValue<Vector2>();
        SystemAPI.SetSingleton(new PersonMoveInput { direction = currenMoveInput });
    }
} 
