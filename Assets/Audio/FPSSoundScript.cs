using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class FPSSoundScript : MonoBehaviour
{
   
    public AudioMixer mainMix; 
    public GameObject player; 
    public GameObject enemy; 
    public List<AudioClip> Ambientes;  

public float calmDistance = 8f;
public float alertDistance = 5f; 
public float dangerDistance = 4f; 
private bool inCalmZone = true;
private bool inAlertZone = false; 
private bool inDangerZone = false; 


void Start () 
{
    //fade in and start playing music
    SoundManagerScript.AddTracks(2,gameObject);
    SoundManagerScript.TrackSettings(0,mainMix, "Music",0.5f, true);
    //SoundManagerScript.PlayMusic(0, Ambientes[0]);
    //si quisiera tener random , de otra lista: 
    //SoundManagerScript.PlayMusic(1,null,listAudioClip,0,4);
 //   SoundManagerScript.PlayMusic(gameObject, Ambientes[0]);

}
void Update()
{
    //calmZone
    if(Vector3.Distance (enemy.transform.position, player.transform.position) > calmDistance && !inCalmZone) 
    {
        Debug.Log("CalmZone..");
        inCalmZone = true;
        inAlertZone = false; 
        inDangerZone = false; 
        SoundManagerScript.PlayMusic(0,null,Ambientes,0,3);
        //SoundManagerScript.PlayMusic(gameObject, Ambientes[0]);
    } 
    //alertZone
    if(Vector3.Distance (enemy.transform.position, player.transform.position) <= calmDistance 
    && Vector3.Distance(enemy.transform.position, player.transform.position) >alertDistance && !inAlertZone) 
    {
        Debug.Log("alertZone..");
        inCalmZone = false;
        inAlertZone = true; 
        inDangerZone = false; 
        //SoundManagerScript.PlayMusic(gameObject, Ambientes[1]);
        //SoundManagerScript.PlayMusic(1,null,Ambientes,0,3);
    }
     //dangerZone
    if(Vector3.Distance (enemy.transform.position, player.transform.position) <= alertDistance && !inDangerZone) 
    {
        Debug.Log("dangerZone..");
        inCalmZone = false;
        inAlertZone = false; 
        inDangerZone = true; 
       //SoundManagerScript.PlayMusic(2,null,Ambientes,0,3);
        //SoundManagerScript.PlayMusic(gameObject, Ambientes[2]);
    }
}


}
