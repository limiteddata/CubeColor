using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public GameObject floors;
    public AudioSource audioSource;
    public float Speed;
    public Text scoreText;
    public Text hScoreText;
    public int diffIndex;
    public int score;
    public InputMaster inputActions;

    private void Awake()
    {
        inputActions = new InputMaster();
        inputActions.Player.MovePlayer.performed += ctx => movePlayer(ctx.ReadValue<Vector2>());
    }
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Material mat = this.gameObject.GetComponent<Renderer>().material;
        if (PlayerPrefs.HasKey("color0")|| PlayerPrefs.HasKey("color1") || PlayerPrefs.HasKey("color2"))
            mat.color = new Color(PlayerPrefs.GetFloat("color0"), PlayerPrefs.GetFloat("color1"), PlayerPrefs.GetFloat("color2"));
        else
            mat.color = new Color(1,0,0);
        diffIndex = PlayerPrefs.GetInt("difficultyIndex");
        hScoreText.text = PlayerPrefs.GetInt("HighestScore" + diffIndex).ToString();

    }
    public void movePlayer(Vector2 pos)
    {
        if (Time.timeScale != 0)
        {
            transform.position += new Vector3(pos.x,0,0);
            audioSource.Play();
        }
    }
    public void androidMove(int x)
    {
        movePlayer(new Vector2(x,0));
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
            if(score > PlayerPrefs.GetInt("HighestScore"+diffIndex))
                PlayerPrefs.SetInt("HighestScore"+diffIndex, score);
            SceneManager.LoadScene("main");
            
        }
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
