using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerScript : MonoBehaviour
{
 
 private static float clipLength; 
 public static List<TrackClass> trackList = new List<TrackClass>();
 static public void AddTracks (int numberOfTracks, GameObject gameObj)
 {
    for(int i = 0; i < numberOfTracks ; i++)
    {
       TrackClass track = new TrackClass{id = i, AudioSource = gameObj.AddComponent<AudioSource>() }; 
       trackList.Add(track);
    }
 }
 static public void PlayMusic (int track, AudioClip audioPassed, List<AudioClip> listAudioClip = null, int min = -2, int max = -2 )
{
   //gameObj.GetComponent<AudioSource>().PlayOneShot(audioPassed);
   if(audioPassed != null && listAudioClip == null && trackList[track].AudioSource.isPlaying == false)
   trackList[track].AudioSource.PlayOneShot(audioPassed, trackList[track].trackVolume);
   if(trackList[track].loop)
   {
      clipLength = audioPassed.length;
   }
   if(audioPassed == null && listAudioClip != null && trackList[track].AudioSource.isPlaying == false)
   {
      int index = Random.Range(min,max);
      if(index == -1){
         //nosound
         Debug.Log("No Sound");
      }
      else{
         Debug.Log("Playing: " + listAudioClip[index]);
         trackList[track].AudioSource.PlayOneShot(listAudioClip[index], trackList[track].trackVolume);
         clipLength = listAudioClip[index].length;
      }
       if(trackList[track].loop)
      {
            //loop
      }
   }
}
static public void TrackSettings(int track, AudioMixer mainMix, string audioGroup, float trackVolume, bool loop = false)
 {
    trackList[track].AudioSource.outputAudioMixerGroup = mainMix.FindMatchingGroups(audioGroup)[0];
    trackList[track].trackVolume = trackVolume;
    trackList[track].loop = loop; 
    
 }
}
