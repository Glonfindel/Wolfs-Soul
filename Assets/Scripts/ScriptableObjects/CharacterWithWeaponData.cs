using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterWithWeapon", menuName = "Data/Character/WithWeapon")]
public class CharacterWithWeaponData : CharacterData {

    [Header("Models")]
    public GameObject mainHand;
    public GameObject offHand;
	
}
