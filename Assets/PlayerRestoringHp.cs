using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestoringHp : MonoBehaviour
{
   public PlayerScriptable playerScriptable;
   public float restoreTime = 10f;
    int restoreHp = 25;
    
    void Update()
    {
        restoreTime -= Time.deltaTime;

        if(restoreTime <= 0 && playerScriptable.hp < 100)
        {
            restoreTime = 10f;
            playerScriptable.hp += restoreHp;
        }

    }
}
