using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LeaderBoard : MonoBehaviour {

    // Use this for initialization
    private HSController hsController;
    [SerializeField] private TMP_Text playerScoreText;

    void Start () {
        hsController = GetComponent<HSController>();
        StartCoroutine(hsController.GetScores());
        playerScoreText.text = "" + Player.finalScore;
    }
	
    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
