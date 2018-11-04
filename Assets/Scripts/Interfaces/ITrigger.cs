using UnityEngine;

public interface ITrigger
{
    ITrigger Parent { get; set; }
    void OnTrigger(GameObject go);
    bool Check(GameObject go);

}
