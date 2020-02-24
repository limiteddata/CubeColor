using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MenuScript
{
    public Slider volumeSlider;
    public GameObject player;
    public Slider[] colorSlider;
    public Text difficultyText;

    private int difficulty = 0;
    public int Difficulty
    {
        get { return difficulty; }
        set
        {       
            switch (value)
            {
                case 0:
                    difficultyText.text = "Play (very easy)";
                    PlayerPrefs.SetInt("difficultyLevel", 80);
                    difficulty = value;
                    break;
                case 1:
                    difficultyText.text = "Play (easy)";
                    PlayerPrefs.SetInt("difficultyLevel", 70);
                    difficulty = value;
                    break;
                case 2:
                    difficultyText.text = "Play (normal)";
                    PlayerPrefs.SetInt("difficultyLevel", 50);
                    difficulty = value;
                    break;
                case 3:
                    difficultyText.text = "Play (hard)";
                    PlayerPrefs.SetInt("difficultyLevel", 35);
                    difficulty = value;
                    break;
                case 4:
                    difficultyText.text = "Play (very hard)";
                    PlayerPrefs.SetInt("difficultyLevel", 25);
                    difficulty = value;
                    break;
                default:
                    break;
            }
            PlayerPrefs.SetInt("difficultyIndex",difficulty);
        }
    }


    void Start()
    {
        Difficulty = PlayerPrefs.GetInt("difficultyIndex");
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
        for (int i=0; i<3; i++)
            colorSlider[i].value = PlayerPrefs.GetFloat("color"+i);
    }

    public void SetColor(float color)
    {
        Material mat = player.GetComponent<Renderer>().material;
        mat.color = new Color(colorSlider[0].value, colorSlider[1].value, colorSlider[2].value);
        for (int i = 0; i < 3; i++)
            PlayerPrefs.SetFloat("color" + i, colorSlider[i].value);
    }
    public void selectDifficulty(int x)
    {
       Difficulty += x;
    }
}
