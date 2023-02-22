using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Ennemi", menuName = "My Game / Ennemi Data")]
public class EnnemiData : ScriptableObject
{
    public string ennemiName;
    public string description;
    public GameObject ennemiModel;
    public int maxHealth = 10;
    public float speed = 1f;

}
