using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "My Game / Wave Data")]

public class Wave : ScriptableObject
{
    public GameObject Ennemi;
    public int count;
    public float rate;
}
