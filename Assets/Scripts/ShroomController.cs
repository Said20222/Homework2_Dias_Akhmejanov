using System;
using UnityEngine;

public class ShroomController : MonoBehaviour, IPlayer
{
    public event Action OnDeath;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteShroom;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private KeyCode _jumpButton;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _dampingSpeed;

    private bool isFacingLeft;
    private bool isJumping;

    public void MakeDamage()
    {
        _rb.AddForce(Vector2.up * _jumpForce);
        Destroy(GetComponent<Collider2D>());
        OnDeath?.Invoke();
        enabled = false;
    }

    void Update()
    {
        if (gameObject.transform.position.y < -20) {
            MakeDamage();
        }
        ShroomMovement();
    }

    private void FixedUpdate() {
        _camera.transform.position = Vector3.Lerp(new Vector3(_camera.transform.position.x, 
            _camera.transform.position.y, -10), transform.position, Time.deltaTime * _dampingSpeed);
    }

    private void ShroomMovement()
    {
        float inputDir = Input.GetAxis("Horizontal");

        if (inputDir > 0)
        {
            isFacingLeft = false;
        }

        if (inputDir < 0)
        {
            isFacingLeft = true;
        }

        _spriteShroom.flipX = isFacingLeft;

        _animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + inputDir, 
            transform.position.y, 0), Time.deltaTime * _movementSpeed);

        if (Input.GetKeyDown(_jumpButton) && !isJumping)
        {
            _rb.AddForce(transform.up * _jumpForce);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isJumping = false;
        }
    }
}
