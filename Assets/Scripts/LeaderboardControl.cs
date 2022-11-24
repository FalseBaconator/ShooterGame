using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LeaderboardControl : MonoBehaviour
{
    public int PillarLevelInt;
    public int LoopLevelInt;

    int currentScore;
    int heldScore1;
    int heldScore2;
    int heldScore3;
    int heldScore4;
    int heldScore5;

    string Holder1;
    string Holder2;
    string Holder3;
    string Holder4;
    string Holder5;

    public TextMeshProUGUI currentScoreText;

    public TextMeshProUGUI heldScoreText1;
    public TextMeshProUGUI heldScoreText2;
    public TextMeshProUGUI heldScoreText3;
    public TextMeshProUGUI heldScoreText4;
    public TextMeshProUGUI heldScoreText5;

    public TextMeshProUGUI HolderText1;
    public TextMeshProUGUI HolderText2;
    public TextMeshProUGUI HolderText3;
    public TextMeshProUGUI HolderText4;
    public TextMeshProUGUI HolderText5;

    TextMeshProUGUI playerNameText;


    public GameObject menuButton;
    public GameObject nonScoringPlayerScore;
    public TMP_InputField nameInput;

    int previousScene;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        currentScore = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<TimeScript>().score;
        previousScene = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<TimeScript>().currentScene;
        currentScoreText.text = currentScore.ToString("00");

        if (previousScene == PillarLevelInt)
        {
            heldScore1 = PlayerPrefs.GetInt("PillarScore1", 0);
            heldScore2 = PlayerPrefs.GetInt("PillarScore2", 0);
            heldScore3 = PlayerPrefs.GetInt("PillarScore3", 0);
            heldScore4 = PlayerPrefs.GetInt("PillarScore4", 0);
            heldScore5 = PlayerPrefs.GetInt("PillarScore5", 0);

            Holder1 = PlayerPrefs.GetString("PillarHolder1", " ");
            Holder2 = PlayerPrefs.GetString("PillarHolder2", " ");
            Holder3 = PlayerPrefs.GetString("PillarHolder3", " ");
            Holder4 = PlayerPrefs.GetString("PillarHolder4", " ");
            Holder5 = PlayerPrefs.GetString("PillarHolder5", " ");
        }else if (previousScene == LoopLevelInt)
        {
            heldScore1 = PlayerPrefs.GetInt("LoopScore1", 0);
            heldScore2 = PlayerPrefs.GetInt("LoopScore2", 0);
            heldScore3 = PlayerPrefs.GetInt("LoopScore3", 0);
            heldScore4 = PlayerPrefs.GetInt("LoopScore4", 0);
            heldScore5 = PlayerPrefs.GetInt("LoopScore5", 0);

            Holder1 = PlayerPrefs.GetString("LoopHolder1", " ");
            Holder2 = PlayerPrefs.GetString("LoopHolder2", " ");
            Holder3 = PlayerPrefs.GetString("LoopHolder3", " ");
            Holder4 = PlayerPrefs.GetString("LoopHolder4", " ");
            Holder5 = PlayerPrefs.GetString("LoopHolder5", " ");
        }
        playerNameText = null;

        if(currentScore >= heldScore5)
        {
            heldScore5 = currentScore;
            playerNameText = HolderText5;
        }
        if (currentScore >= heldScore4)
        {
            heldScore5 = heldScore4;
            Holder5 = Holder4;
            heldScore4 = currentScore;
            playerNameText = HolderText4;
        }
        if (currentScore >= heldScore3)
        {
            heldScore4 = heldScore3;
            Holder4 = Holder3;
            heldScore3 = currentScore;
            playerNameText = HolderText3;
        }
        if (currentScore >= heldScore2)
        {
            heldScore3 = heldScore2;
            Holder3 = Holder2;
            heldScore2 = currentScore;
            playerNameText = HolderText2;
        }
        if (currentScore >= heldScore1)
        {
            heldScore2 = heldScore1;
            Holder2 = Holder1;
            heldScore1 = currentScore;
            playerNameText = HolderText1;
        }

        HolderText1.text = Holder1;
        HolderText2.text = Holder2;
        HolderText3.text = Holder3;
        HolderText4.text = Holder4;
        HolderText5.text = Holder5;

        heldScoreText1.text = heldScore1.ToString();
        heldScoreText2.text = heldScore2.ToString();
        heldScoreText3.text = heldScore3.ToString();
        heldScoreText4.text = heldScore4.ToString();
        heldScoreText5.text = heldScore5.ToString();

        if(playerNameText != null)
        {
            playerNameText.text = "ENTER NAME";
            menuButton.SetActive(false);
            nonScoringPlayerScore.SetActive(false);
            nameInput.gameObject.SetActive(true);
        }
        else
        {
            menuButton.SetActive(true);
            nonScoringPlayerScore.SetActive(true);
            nameInput.gameObject.SetActive(false);
        }

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(0);
    }

    public void updateName()
    {
        playerNameText.text = nameInput.text;
    }

    public void endInput()
    {
        playerNameText.text = nameInput.text;

        if (previousScene == PillarLevelInt)
        {
            PlayerPrefs.SetInt("PillarScore1", heldScore1);
            PlayerPrefs.SetInt("PillarScore2", heldScore2);
            PlayerPrefs.SetInt("PillarScore3", heldScore3);
            PlayerPrefs.SetInt("PillarScore4", heldScore4);
            PlayerPrefs.SetInt("PillarScore5", heldScore5);

            PlayerPrefs.SetString("PillarHolder1", HolderText1.text);
            PlayerPrefs.SetString("PillarHolder2", HolderText2.text);
            PlayerPrefs.SetString("PillarHolder3", HolderText3.text);
            PlayerPrefs.SetString("PillarHolder4", HolderText4.text);
            PlayerPrefs.SetString("PillarHolder5", HolderText5.text);
        }else if(previousScene == LoopLevelInt)
        {
            PlayerPrefs.SetInt("LoopScore1", heldScore1);
            PlayerPrefs.SetInt("LoopScore2", heldScore2);
            PlayerPrefs.SetInt("LoopScore3", heldScore3);
            PlayerPrefs.SetInt("LoopScore4", heldScore4);
            PlayerPrefs.SetInt("LoopScore5", heldScore5);

            PlayerPrefs.SetString("LoopHolder1", HolderText1.text);
            PlayerPrefs.SetString("LoopHolder2", HolderText2.text);
            PlayerPrefs.SetString("LoopHolder3", HolderText3.text);
            PlayerPrefs.SetString("LoopHolder4", HolderText4.text);
            PlayerPrefs.SetString("LoopHolder5", HolderText5.text);
        }
        menuButton.SetActive(true);
        nonScoringPlayerScore.SetActive(true);
        nameInput.gameObject.SetActive(false);
    }

    public void Reset()
    {
        if (previousScene == PillarLevelInt)
        {
            PlayerPrefs.DeleteKey("PillarScore1");
            PlayerPrefs.DeleteKey("PillarScore2");
            PlayerPrefs.DeleteKey("PillarScore3");
            PlayerPrefs.DeleteKey("PillarScore4");
            PlayerPrefs.DeleteKey("PillarScore5");

            PlayerPrefs.DeleteKey("PillarHolder1");
            PlayerPrefs.DeleteKey("PillarHolder2");
            PlayerPrefs.DeleteKey("PillarHolder3");
            PlayerPrefs.DeleteKey("PillarHolder4");
            PlayerPrefs.DeleteKey("PillarHolder5");

            heldScore1 = PlayerPrefs.GetInt("PillarScore1", 0);
            heldScore2 = PlayerPrefs.GetInt("PillarScore2", 0);
            heldScore3 = PlayerPrefs.GetInt("PillarScore3", 0);
            heldScore4 = PlayerPrefs.GetInt("PillarScore4", 0);
            heldScore5 = PlayerPrefs.GetInt("PillarScore5", 0);

            Holder1 = PlayerPrefs.GetString("PillarHolder1", " ");
            Holder2 = PlayerPrefs.GetString("PillarHolder2", " ");
            Holder3 = PlayerPrefs.GetString("PillarHolder3", " ");
            Holder4 = PlayerPrefs.GetString("PillarHolder4", " ");
            Holder5 = PlayerPrefs.GetString("PillarHolder5", " ");
        }else if (previousScene == LoopLevelInt)
        {
            PlayerPrefs.DeleteKey("LoopScore1");
            PlayerPrefs.DeleteKey("LoopScore2");
            PlayerPrefs.DeleteKey("LoopScore3");
            PlayerPrefs.DeleteKey("LoopScore4");
            PlayerPrefs.DeleteKey("LoopScore5");

            PlayerPrefs.DeleteKey("LoopHolder1");
            PlayerPrefs.DeleteKey("LoopHolder2");
            PlayerPrefs.DeleteKey("LoopHolder3");
            PlayerPrefs.DeleteKey("LoopHolder4");
            PlayerPrefs.DeleteKey("LoopHolder5");

            heldScore1 = PlayerPrefs.GetInt("LoopScore1", 0);
            heldScore2 = PlayerPrefs.GetInt("LoopScore2", 0);
            heldScore3 = PlayerPrefs.GetInt("LoopScore3", 0);
            heldScore4 = PlayerPrefs.GetInt("LoopScore4", 0);
            heldScore5 = PlayerPrefs.GetInt("LoopScore5", 0);

            Holder1 = PlayerPrefs.GetString("LoopHolder1", " ");
            Holder2 = PlayerPrefs.GetString("LoopHolder2", " ");
            Holder3 = PlayerPrefs.GetString("LoopHolder3", " ");
            Holder4 = PlayerPrefs.GetString("LoopHolder4", " ");
            Holder5 = PlayerPrefs.GetString("LoopHolder5", " ");
        }
        HolderText1.text = Holder1;
        HolderText2.text = Holder2;
        HolderText3.text = Holder3;
        HolderText4.text = Holder4;
        HolderText5.text = Holder5;

        heldScoreText1.text = heldScore1.ToString();
        heldScoreText2.text = heldScore2.ToString();
        heldScoreText3.text = heldScore3.ToString();
        heldScoreText4.text = heldScore4.ToString();
        heldScoreText5.text = heldScore5.ToString();
    }

}
