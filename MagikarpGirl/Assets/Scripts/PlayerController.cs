using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private CharacterController _controller;
    public Animator animator;
    private Vector2 _moveInput;
    
    [Header("Player movement settings")] [SerializeField]
    private float moveSpeed = 15f;
    [SerializeField] private float turnSpeed = 90f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        Vector3 movement = transform.TransformDirection(_moveInput.x, 0, _moveInput.y);
        _controller.Move(movement * (moveSpeed * Time.deltaTime));

        
        float mouseX = Mouse.current.delta.x.ReadValue();
        transform.Rotate(Vector3.up, mouseX * turnSpeed * Time.deltaTime);

        animator.SetFloat("MoveX", _moveInput.x, 0.05f, Time.deltaTime);
        animator.SetFloat("MoveY", _moveInput.y, 0.05f, Time.deltaTime);
   
    }
    
    public void OnMove(InputValue value)
    {
        if (!animator.GetBool("isMoving"))
        {
            _moveInput = value.Get<Vector2>();
        }
    }
    
    public void OnPushUp(InputValue value)
    {
        animator.SetTrigger("PushUpTrigger");
        animator.SetBool("isMoving", false);
    }
}
