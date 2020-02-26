using UnityEngine;

public class destroyscript : MonoBehaviour {

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
