using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player1 : MonoBehaviour
{
    private CustomInput input = null;
    private Vector2 moveVector= Vector2.zero;
    private Rigidbody2D rb = null;
    private float moveSpeed = 10;

    private void Awake()
    {
        input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.PlayerInput.Movement.performed += OnMovementPerformed;
        input.PlayerInput.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.PlayerInput.Movement.performed-= OnMovementPerformed;
        input.PlayerInput.Movement.canceled -= OnMovementCancelled;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector= Vector2.zero;
    }

}
