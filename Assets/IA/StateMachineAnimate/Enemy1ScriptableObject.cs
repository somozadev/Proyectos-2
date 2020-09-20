using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "VariablesEnemies", menuName = "IApropia/EnemyIA", order = 1)]
public class Enemy1ScriptableObject : ScriptableObject
{

    public float searchRange = 7.5f;
    public float proximRange = 1.0f;
    public float rangeDetection = 7.5f;
    //public int hp = 100; //esto habira que movelo a un scriptable propio de cosas del jugador (es hp del player)
    public Vector3 direccionAgente;
    public Transform[] points;
    public bool agent; //true usare para enemy1 y false para enemy2
    
}
