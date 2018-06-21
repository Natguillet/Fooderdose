using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour {

    // Use this for initialization
    private HSController hsController;
    [SerializeField] private TMP_Text playerScoreText;
    [SerializeField] private Button restartButton;

    void Start () {
        hsController = GetComponent<HSController>();
        StartCoroutine(hsController.GetScores());
        playerScoreText.text = "" + Player.finalScore;
        if (MainMenu.comingFromMenu) restartButton.gameObject.SetActive(false);
    }
	
    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
