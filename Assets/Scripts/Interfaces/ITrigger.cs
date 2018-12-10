using UnityEngine;

public interface ITrigger
{
    ITrigger Parent { get; set; }
    GameObject GameObject { get; }
    void OnTrigger(GameObject go);
    bool Check(GameObject go);

}
