using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readyForPool : MonoBehaviour
{
    public bool reusable;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "B_wall")
        {
            reusable = true;
            gameObject.SetActive(false);
        }

    }
}
