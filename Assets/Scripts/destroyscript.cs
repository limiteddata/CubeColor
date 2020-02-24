using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyscript : MonoBehaviour {
    void OnCollisionExit(Collision other)
    { 
        Destroy(this);
    }   
}
