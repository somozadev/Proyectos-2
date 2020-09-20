using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerFPSController : MonoBehaviour
{
    public  List<AudioClip> listaAudio = new List<AudioClip>();
    private CharacterMovement characterMovement;
    private InputData input;
    private MouseLook mouseLook;
    int i = 5; 

 #region VariablesCondicionalesSonido
   
    public  bool Moviendo = false;
   
    public  bool Corriendo = false;
   
    public  bool Agachado = false;
       
    public  bool AgachadoMoviendo = false;
       
    public  bool AgachadoCorriendo = false;
    #endregion
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
        //Booleanas para sonido
        #region MazoDeIfs
        if(input.dash && input.crouch && (input.hMovement >0 || input.vMovement >0 || input.hMovement <0 || input.vMovement<0))
        {
            AgachadoCorriendo = true; 
            //
            Moviendo = false; 
            Corriendo = false;
            Agachado = false; 
            AgachadoMoviendo = false; 
            //
        }
        else if(input.crouch && (input.hMovement >0 || input.vMovement >0 || input.hMovement <0 || input.vMovement<0))
        {
            AgachadoMoviendo = true;
             //
            Moviendo = false; 
            Corriendo = false;
            Agachado = false; 
            AgachadoCorriendo = false; 
            //
        }
        else if(!input.crouch && !input.dash && (input.hMovement >0 || input.vMovement >0 || input.hMovement <0 || input.vMovement<0))
        {
            Moviendo = true; 
             // 
            Corriendo = false;
            Agachado = false; 
            AgachadoMoviendo = false; 
            AgachadoCorriendo = false; 
            //
        }
        else if(!input.crouch && input.dash && (input.hMovement >0 || input.vMovement >0 || input.hMovement <0 || input.vMovement<0))
        {
            Corriendo = true; 
             //
            Moviendo = false; 
            Agachado = false; 
            AgachadoMoviendo = false; 
            AgachadoCorriendo = false; 
            //
        }
        else if(!input.crouch && !input.dash &&(input.hMovement ==0 || input.vMovement ==0))
        {
            Moviendo = false; 
             //
            Corriendo = false; 
            Agachado = false; 
            AgachadoMoviendo = false; 
            AgachadoCorriendo = false; 
            //
        }
        else if(input.crouch && !input.dash && (input.hMovement ==0 || input.vMovement ==0))
        {
           
            Agachado = true;
            //
            Corriendo = false; 
            Moviendo = false;
            AgachadoMoviendo = false; 
            AgachadoCorriendo = false; 
        }
        #endregion

        i = FuncionSonido.ElegirSonido(Moviendo,Corriendo,Agachado,AgachadoMoviendo,AgachadoCorriendo);
        Debug.Log(i + ": VALOR SONIDO");
        if(i!=5)
        FuncionSonido.ReproducirSonidoDeterminado(gameObject,i,listaAudio);
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