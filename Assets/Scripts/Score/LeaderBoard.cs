using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour {

    // Use this for initialization
    private HSController hsController;
    [SerializeField] private UnityEngine.UI.Text playerScoreText;

    void Start () {
        hsController = GetComponent<HSController>();
        StartCoroutine(hsController.GetScores());
        Debug.Log(Player.finalScore);
        playerScoreText.text = "Your score : " + Player.finalScore;
    }
	
    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
