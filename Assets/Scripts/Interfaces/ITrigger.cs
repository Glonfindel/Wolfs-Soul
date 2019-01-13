using UnityEngine;

public interface ITrigger
{

    bool Complete { get; set; }
    ITrigger Parent { get; set; }
    GameObject GameObject { get; }
    void OnTrigger(GameObject go);
    bool Check(GameObject go);

}
