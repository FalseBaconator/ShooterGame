using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LeaderboardControl : MonoBehaviour
{

    int currentScore;
    int heldScore1;
    int heldScore2;
    int heldScore3;
    int heldScore4;
    int heldScore5;

    string holder1;
    string holder2;
    string holder3;
    string holder4;
    string holder5;

    public TextMeshProUGUI currentScoreText;

    public TextMeshProUGUI heldScoreText1;
    public TextMeshProUGUI heldScoreText2;
    public TextMeshProUGUI heldScoreText3;
    public TextMeshProUGUI heldScoreText4;
    public TextMeshProUGUI heldScoreText5;

    public TextMeshProUGUI holderText1;
    public TextMeshProUGUI holderText2;
    public TextMeshProUGUI holderText3;
    public TextMeshProUGUI holderText4;
    public TextMeshProUGUI holderText5;

    TextMeshProUGUI playerNameText;


    public GameObject menuButton;
    public GameObject nonScoringPlayerScore;
    public TMP_InputField nameInput;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        currentScore = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<TimeScript>().score;
        currentScoreText.text = currentScore.ToString("00");

        heldScore1 = PlayerPrefs.GetInt("Score1", 0);
        heldScore2 = PlayerPrefs.GetInt("Score2", 0);
        heldScore3 = PlayerPrefs.GetInt("Score3", 0);
        heldScore4 = PlayerPrefs.GetInt("Score4", 0);
        heldScore5 = PlayerPrefs.GetInt("Score5", 0);

        holder1 = PlayerPrefs.GetString("Holder1", " ");
        holder2 = PlayerPrefs.GetString("Holder2", " ");
        holder3 = PlayerPrefs.GetString("Holder3", " ");
        holder4 = PlayerPrefs.GetString("Holder4", " ");
        holder5 = PlayerPrefs.GetString("Holder5", " ");

        playerNameText = null;

        if(currentScore >= heldScore5)
        {
            heldScore5 = currentScore;
            playerNameText = holderText5;
        }
        if (currentScore >= heldScore4)
        {
            heldScore5 = heldScore4;
            holder5 = holder4;
            heldScore4 = currentScore;
            playerNameText = holderText4;
        }
        if (currentScore >= heldScore3)
        {
            heldScore4 = heldScore3;
            holder4 = holder3;
            heldScore3 = currentScore;
            playerNameText = holderText3;
        }
        if (currentScore >= heldScore2)
        {
            heldScore3 = heldScore2;
            holder3 = holder2;
            heldScore2 = currentScore;
            playerNameText = holderText2;
        }
        if (currentScore >= heldScore1)
        {
            heldScore2 = heldScore1;
            holder2 = holder1;
            heldScore1 = currentScore;
            playerNameText = holderText1;
        }

        holderText1.text = holder1;
        holderText2.text = holder2;
        holderText3.text = holder3;
        holderText4.text = holder4;
        holderText5.text = holder5;

        heldScoreText1.text = heldScore1.ToString();
        heldScoreText2.text = heldScore2.ToString();
        heldScoreText3.text = heldScore3.ToString();
        heldScoreText4.text = heldScore4.ToString();
        heldScoreText5.text = heldScore5.ToString();

        if(playerNameText != null)
        {
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

        PlayerPrefs.SetInt("Score1", heldScore1);
        PlayerPrefs.SetInt("Score2", heldScore2);
        PlayerPrefs.SetInt("Score3", heldScore3);
        PlayerPrefs.SetInt("Score4", heldScore4);
        PlayerPrefs.SetInt("Score5", heldScore5);

        PlayerPrefs.SetString("Holder1", holder1);
        PlayerPrefs.SetString("Holder2", holder2);
        PlayerPrefs.SetString("Holder3", holder3);
        PlayerPrefs.SetString("Holder4", holder4);
        PlayerPrefs.SetString("Holder5", holder5);

        menuButton.SetActive(true);
        nonScoringPlayerScore.SetActive(true);
        nameInput.gameObject.SetActive(false);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("Score1");
        PlayerPrefs.DeleteKey("Score2");
        PlayerPrefs.DeleteKey("Score3");
        PlayerPrefs.DeleteKey("Score4");
        PlayerPrefs.DeleteKey("Score5");

        PlayerPrefs.DeleteKey("Holder1");
        PlayerPrefs.DeleteKey("Holder2");
        PlayerPrefs.DeleteKey("Holder3");
        PlayerPrefs.DeleteKey("Holder4");
        PlayerPrefs.DeleteKey("Holder5");
    }

}
