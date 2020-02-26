using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    Material mat;
    public GameObject end;
    public int x=10;
    public int len;
    public int diff;

    public GameObject spawnObject;
    public List<GameObject> queueObjects = new List<GameObject>();
    public List<GameObject> allObjects = new List<GameObject>();

    void Start()
    {
        diff = PlayerPrefs.GetInt("difficultyLevel");
        mat = this.GetComponent<Renderer>().material;
        mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    void Update()
    {
        foreach (var Object in allObjects)
            if (Object.GetComponent<readyForPool>().reusable && !queueObjects.Contains(Object))
                queueObjects.Add(Object);

        while (x < (int)end.transform.position.z)
        {
            x = Random.Range(x+1, x + diff);
            Vector3 pos = new Vector3(transform.position.x, 0, x);

            if(queueObjects.Count > 0)
            {
                queueObjects[0].GetComponent<readyForPool>().reusable = false;
                queueObjects[0].transform.position = pos;
                queueObjects[0].SetActive(true);
                queueObjects.RemoveAt(0);
            }
            else
            {
                spawnObject.GetComponent<Renderer>().material = mat;
                allObjects.Add(Instantiate(spawnObject, pos, Quaternion.identity));
            }
        }
    }
}
