using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public GameObject floors;
    AudioSource audioSource;
    public float Speed;
    public Text scoreText;
    public Text hScoreText;
    public int score;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Material mat = this.gameObject.GetComponent<Renderer>().material;
        mat.color = new Color(PlayerPrefs.GetFloat("color0"), PlayerPrefs.GetFloat("color1"), PlayerPrefs.GetFloat("color2"));
        hScoreText.text = PlayerPrefs.GetInt("HighestScore").ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && Time.timeScale != 0)
        {
            transform.position += new Vector3(-1, 0, 0);
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.D)&&Time.timeScale != 0)
        {
            transform.position += new Vector3(1, 0, 0);
            audioSource.Play();
        }
    }
    int lastPos;
    private void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;
        floors.transform.position += transform.forward * Time.deltaTime * Speed;
        score = (int)transform.position.z;    
        scoreText.text = score.ToString();
        if(lastPos != ((int)transform.position.z / 100 % 10))
        {
            lastPos = ((int)transform.position.z / 100 % 10);
            Mathf.Lerp(Speed, Speed++, Speed);
        }
   
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "floor")
        {
            if(score > PlayerPrefs.GetInt("HighestScore"))
                PlayerPrefs.SetInt("HighestScore", score);
            SceneManager.LoadScene("main");
            
        }
    }
}
