using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    //Estaría bien que se agachara gradualmente. Estaría mu bien
    //Estaría bien que se agachara gradualmente. Estaría mu bien
    private CharacterController characterController;
    private Vector3 moveDirection;
    private Vector3 smoothMoveDirection;
    private Vector3 smoother;
    private Vector3 horizontalVelocity;

    public float Speed = 5f;
    public float JumpHeight = 2f;
    [Range(0.01f, 1f)]
    public float forwardJumpFactor = 0.05f;
    public float Gravity = -9.81f;
    public float DashFactor = 2f;
    public float CrouchFactor = 0.5f;
    public Vector3 Drag;
    public float smoothTime = 0.15f;
    public float crouchTime = 0.5f;

    public bool isGrounded { get { return characterController.isGrounded; } }
    public float currentSpeed { get { return horizontalVelocity.magnitude; } }
    public float currentNormalizedSpeed { get { return horizontalVelocity.normalized.magnitude; } }


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }
    
    // Update is called once per frame
    public void moveCharacter(float horizontal, float vertical, bool jump, bool dash, bool crouch)
    {

        float deltaTime = Time.deltaTime;
        float dashF = 1f;
        float crouchF = 1f;

        if (characterController.isGrounded)
        {
            moveDirection = horizontal * transform.right + vertical * transform.forward;

            if (dash) dashF = DashFactor;
            if (crouch)
            {
                crouchF = CrouchFactor;
                characterController.height = 1.0f;
            }
            else
            {
                characterController.height = 2.0f;
            }
            if (jump)
            {
                if (Mathf.Abs(moveDirection.x) > 0f && Mathf.Abs(moveDirection.z) > 0f)
                {
                    moveDirection += moveDirection.normalized * (Mathf.Sqrt(JumpHeight * forwardJumpFactor * -Gravity / 2) * dashF);
                }

                moveDirection.y = Mathf.Sqrt(JumpHeight * -Gravity);
            }
        }

        // Apply gravity
        moveDirection.y += (Gravity * deltaTime);

        //Apply Drag
        moveDirection.x /= 1 + Drag.x * deltaTime;
        moveDirection.y /= 1 + Drag.y * deltaTime;
        moveDirection.z /= 1 + Drag.z * deltaTime;

        // Smooth direction
        smoothMoveDirection = Vector3.SmoothDamp(smoothMoveDirection, moveDirection, ref smoother, smoothTime);

        // Jump is not smoothed
        smoothMoveDirection.y = moveDirection.y;

        // Apply move to the character
        characterController.Move(smoothMoveDirection * (deltaTime * Speed * dashF * crouchF));

        // Cache horizontal Speed
        horizontalVelocity.Set(characterController.velocity.x, 0, characterController.velocity.z);
    }
}
