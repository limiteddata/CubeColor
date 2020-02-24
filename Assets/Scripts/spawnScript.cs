using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    Material mat;
    public GameObject spawnObject;
    public GameObject end;
    public int x=10;
    public int len;
    public int diff;
    void Start()
    {
        diff = PlayerPrefs.GetInt("difficultyLevel");
        mat = this.GetComponent<Renderer>().material;
        mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    void Update()
    {
        while (x < (int)end.transform.position.z)
        {
            x = Random.Range(x+1, x + diff);
            spawnObject.GetComponent<Renderer>().material = mat;
            Instantiate(spawnObject, new Vector3(transform.position.x, 0, x), Quaternion.identity);
        }
    }
}
