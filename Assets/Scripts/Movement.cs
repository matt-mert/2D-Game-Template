using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1000.0f;

    private PlayerInput playerInput;
    private Rigidbody2D playerRb;
    private InputAction moveAction;
    private Vector2 movementVector;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody2D>();
        moveAction = playerInput.actions["Move"];
    }

    private void FixedUpdate()
    {
        Vector2 movement = movementVector * movementSpeed * Time.fixedDeltaTime;
        playerRb.velocity = movement;
    }

    private void OnMove()
    {
        movementVector = moveAction.ReadValue<Vector2>();
    }
}
