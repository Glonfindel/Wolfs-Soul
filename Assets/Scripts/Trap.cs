using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{

    public int damage;

    public abstract void Activate();
}
