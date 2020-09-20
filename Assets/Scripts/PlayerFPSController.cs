using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerFPSController : MonoBehaviour
{
    private CharacterMovement characterMovement;
    private InputData input;
    private MouseLook mouseLook;

    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
        mouseLook = GetComponent<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        //Cogiendo el input del player
        input.getInput();
        //Movimiento
        characterMovement.moveCharacter(input.hMovement, input.vMovement, input.jump, input.dash, input.crouch);
        //Rotación
        mouseLook.verticalAxis = input.verticalMouse;
        mouseLook.horizontalAxis = input.horizontalMouse;
    }
    public struct InputData
    {
        // Basic Movement
        public float hMovement;
        public float vMovement;

        // Mouse rotation
        public float verticalMouse;
        public float horizontalMouse;

        // Extra movement
        public bool dash;
        public bool jump;
        public bool crouch;

        // Aiming
        public bool aimButtonDown;
        public bool aimButtonUp;

        // Firing
        public bool fireButton;
        public bool reload;

        public void getInput()
        {
            // Basic Movement
            hMovement = Input.GetAxisRaw("Horizontal");
            vMovement = Input.GetAxisRaw("Vertical");

            // Mouse rotation
            verticalMouse = Input.GetAxis("Mouse Y");
            horizontalMouse = Input.GetAxis("Mouse X");

            // Extra movement
            dash = Input.GetButton("Dash");
            jump = Input.GetButtonDown("Jump");
            crouch = Input.GetButton("Crouch");

            // Aiming
            aimButtonDown = Input.GetButtonDown("Fire2");
            aimButtonUp = Input.GetButtonUp("Fire2");

            // Firing
            fireButton = Input.GetButton("Fire1");
            // reload = Input.GetButtonDown("Reload");
        }
    }
}