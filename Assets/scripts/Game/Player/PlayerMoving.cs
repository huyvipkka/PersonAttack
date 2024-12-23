using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoving : MonoBehaviour
{
    PlayerController controller;
    private Camera _camera;
    public Coroutine boostCoroutine;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Vector2 _movementInput;

    private void Start()
    {
        controller = PlayerController.Instance;
        _camera = Camera.main;
        if (controller == null)
        {
            Debug.LogError("PlayerController instance is null!");
            return;
        }
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
                    _smoothedMovementInput,
                    _movementInput,
                    ref _movementInputSmoothVelocity,
                    0.1f);

        controller.rb.velocity = _smoothedMovementInput * controller.speed;
    }

    private void RotateInDirectionOfInput()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mousePos = _camera.ScreenToWorldPoint(mouseScreenPos);
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    public void BoostSpeed(float boostPercent, float time)
    {
        if (boostCoroutine != null)
        {
            StopCoroutine(boostCoroutine);
            controller.speed = controller.data.speed;
        }
        boostCoroutine = StartCoroutine(Boost(boostPercent, time));
    }
    private IEnumerator Boost(float boostPercent, float time)
    {
        controller.speed *= 1 + boostPercent;
        yield return new WaitForSeconds(time);
        controller.speed = controller.data.speed;
    }
}