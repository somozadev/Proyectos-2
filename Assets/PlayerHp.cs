using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public PlayerScriptable playerScriptable;
    public GameObject damage1;
    public GameObject damage2;
    public GameObject damage3;
    public GameObject damage4;
    public GameObject damageEspacio1;
    public GameObject damageEspacio2;
    public GameObject damageEspacio3;
    public GameObject damageEspacio4;
    public Rect pantalla;
    public InterdimensinalController dimens; 

    // Start is called before the first frame update
    void Start()
    {
        playerScriptable.hp = 100;
        
        dimens = dimens.GetComponent<InterdimensinalController>();
        pantalla = new Rect(0,0,Screen.width,Screen.height);

    }

    // Update is called once per frame
    void Update()
    {
        
        //if(hp <= 0)
       // SceneManager.LoadScene(1);
    }
    
    public void OnGUI()
    {
        if(dimens.Interdimensionaliced)
        {
            if(playerScriptable.hp==100)
            {
                damage1.SetActive(false);
                damage2.SetActive(false);
                damage3.SetActive(false);
                damage4.SetActive(false);

                damageEspacio1.SetActive(false);
                damageEspacio2.SetActive(false);
                damageEspacio3.SetActive(false);
                damageEspacio4.SetActive(false);
            }
            if(playerScriptable.hp <= 75)
            {
                damage1.SetActive(false);
                damage2.SetActive(false);
                damage3.SetActive(false);
                damage4.SetActive(false);

                damageEspacio1.SetActive(true);
                damageEspacio2.SetActive(false);
                damageEspacio3.SetActive(false);
                damageEspacio4.SetActive(false);
            }
            if(playerScriptable.hp <= 50)
            {
                damage1.SetActive(false);
                damage2.SetActive(false);
                damage3.SetActive(false);
                damage4.SetActive(false);

                damageEspacio1.SetActive(false);
                damageEspacio2.SetActive(true);
                damageEspacio3.SetActive(false);
                damageEspacio4.SetActive(false);
            }
            if(playerScriptable.hp <= 25)
            {
                damage1.SetActive(false);
                damage2.SetActive(false);
                damage3.SetActive(false);
                damage4.SetActive(false);

                damageEspacio1.SetActive(false);
                damageEspacio2.SetActive(false);
                damageEspacio3.SetActive(true);
                damageEspacio4.SetActive(false);
            }
            if(playerScriptable.hp <= 0)
            {
                damage1.SetActive(false);
                damage2.SetActive(false);
                damage3.SetActive(false);
                damage4.SetActive(false);

                damageEspacio1.SetActive(false);
                damageEspacio2.SetActive(false);
                damageEspacio3.SetActive(false);
                damageEspacio4.SetActive(true);
            }
        }
           if(!dimens.Interdimensionaliced)
        {
            if(playerScriptable.hp==100)
            {
                damage1.SetActive(false);
                damage2.SetActive(false);
                damage3.SetActive(false);
                damage4.SetActive(false);

                damageEspacio1.SetActive(false);
                damageEspacio2.SetActive(false);
                damageEspacio3.SetActive(false);
                damageEspacio4.SetActive(false);
            }
            if(playerScriptable.hp <= 75)
            {
                damage1.SetActive(true);
                damage2.SetActive(false);
                damage3.SetActive(false);
                damage4.SetActive(false);

                damageEspacio1.SetActive(false);
                damageEspacio2.SetActive(false);
                damageEspacio3.SetActive(false);
                damageEspacio4.SetActive(false);
            }
            if(playerScriptable.hp <= 50)
            {
                damage1.SetActive(false);
                damage2.SetActive(true);
                damage3.SetActive(false);
                damage4.SetActive(false);

                damageEspacio1.SetActive(false);
                damageEspacio2.SetActive(false);
                damageEspacio3.SetActive(false);
                damageEspacio4.SetActive(false);
            }
            if(playerScriptable.hp <= 25)
            {
                damage1.SetActive(false);
                damage2.SetActive(false);
                damage3.SetActive(true);
                damage4.SetActive(false);

                damageEspacio1.SetActive(false);
                damageEspacio2.SetActive(false);
                damageEspacio3.SetActive(false);
                damageEspacio4.SetActive(false);
            }
            if(playerScriptable.hp <= 0)
            {
                damage1.SetActive(false);
                damage2.SetActive(false);
                damage3.SetActive(false);
                damage4.SetActive(true);

                damageEspacio1.SetActive(false);
                damageEspacio2.SetActive(false);
                damageEspacio3.SetActive(false);
                damageEspacio4.SetActive(false);    
            }
        }
    }


}
