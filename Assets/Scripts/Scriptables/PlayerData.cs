using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player", menuName = "My Game / Player Data")]
public class Player : ScriptableObject
{
    public string playerName;
    public string description;
    public GameObject playerModel;
    public int maxHealth = 20;
    public float speed = 1.5f;
    
}
