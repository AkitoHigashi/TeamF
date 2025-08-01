using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
[DefaultExecutionOrder(-1000)]

public class InputBuffer : MonoBehaviour
{
    private const string MOVE_ACTION = "Move";
    private const string SPRINT_ACTION = "Sprint";
    private const string CARRY_ACTION = "Carry";
    private const string THROW_ACTION = "Throw";
    private const string CROUCH_ACTION = "Crouch";

    public InputAction MoveAction => _moveAction;
    public InputAction SprintAction => _sprintAction;
    public InputAction CarryAction => _carryAction;
    public InputAction ThrowAction => _throwAction;
    public InputAction CrouthAction => _crouchAction;

    private InputAction _moveAction;
    private InputAction _sprintAction;
    private InputAction _carryAction;
    private InputAction _throwAction;
    private InputAction _crouchAction;

    private void Awake()
    {
        if (TryGetComponent<PlayerInput>(out var playerInput))
        {
            _moveAction = playerInput.actions[MOVE_ACTION];
            _sprintAction = playerInput.actions[SPRINT_ACTION];
            _carryAction = playerInput.actions[CARRY_ACTION];
            _throwAction = playerInput.actions[THROW_ACTION];
            _crouchAction = playerInput.actions[CROUCH_ACTION];
        }
    }
}
