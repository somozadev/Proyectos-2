using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FuncionSonido 
{
    //que cada clip de audio se active desde el player
    //controller, en los Crouch y run un parametro que cambie el clip
    //con ese parametro que cambie bools de un script a parte,
    //desde el que se accedera (este mismo) desde los attack,patrol,
    //pursuit etc... en funcion de eso calcular la distancia
    //entre jugador y enemigo y medirla, esa compararla con
    // diferentes valores representando el rango de escucha
    //cuando sus condiciones se cumplan, activar diferentes estados
    


    public static void PlaySonido(GameObject gameobject, AudioClip audioClip)
    {
        if(!gameobject.GetComponent<AudioSource>().isPlaying)
        {
        
        gameobject.GetComponent<AudioSource>().clip = audioClip;
        gameobject.GetComponent<AudioSource>().loop = true;
        gameobject.GetComponent<AudioSource>().PlayOneShot(audioClip);
        }
        
        
    }
    public static int ElegirSonido(bool Moviendo,bool Corriendo, bool Agachado, bool AgachadoMoviendo, bool AgachadoCorriendo)
    {
        if(Moviendo)
        return 0; 
        else if(Corriendo)
        return 1; 
        else if(Agachado)
        return 2;
        else if(AgachadoMoviendo)
        return 3;
        else if(AgachadoCorriendo)
        return 4;

        return 5; 
    }

    public static void ReproducirSonidoDeterminado(GameObject gameobject,int index, List<AudioClip> listaAudio)
    {
        PlaySonido(gameobject,listaAudio[index]);
    }
}
