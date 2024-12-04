using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] public PlayerData data;
    public float _speed;
    private float boostSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Camera _camera;
    public Coroutine boostCoroutine;

    private void Start()
    {
        _speed = data.speed;
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
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

        _rigidbody.velocity = _smoothedMovementInput * _speed;
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
            _speed = data.speed;
        }
        boostCoroutine = StartCoroutine(Boost(boostPercent, time));
    }
    private IEnumerator Boost(float boostPercent, float time)
    {
        _speed *= 1 + boostPercent;
        yield return new WaitForSeconds(time);
        _speed = data.speed;
    }
}