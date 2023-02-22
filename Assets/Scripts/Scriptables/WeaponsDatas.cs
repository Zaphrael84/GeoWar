using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapons", menuName = "My Game / Weapons Data")]

public class WeaponsDatas : ScriptableObject
{
    public string weaponName;
    public string description;
    public GameObject weaponModel;
    public int damage = 5;
    public float reload = 1f;

}
