using UnityEngine;

public class dontdestroyonload : MonoBehaviour {

    public void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

}
