using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public Animator animator;
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 _moveInput;
    
    void Update()
    {
        Vector3 movement = new Vector3(_moveInput.x, 0f, _moveInput.y);
        transform.Translate(movement * (moveSpeed * Time.deltaTime), Space.World);
        
        animator.SetFloat("MoveX", movement.magnitude);
        animator.SetFloat("MoveY", movement.magnitude);
    }


    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
    
}
