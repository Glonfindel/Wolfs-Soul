using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterWithoutWeapon",menuName ="Data/Character/WithoutWeapon")]
public class CharacterData : ScriptableObject {

    [Header("Combat stats")]
    public int hp;
    public int damage;
    public float attackSpeed;
    [Header("Movement stats")]
    public float movementSpeed;
    public float rotateSpeed;
    public float jumpPower;

}
