using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour {

    //[SerializeField] private UnityEngine.UI.Text leaderBoardText;
    // Use this for initialization
    private HSController hsController;
    void Start () {
        hsController = GetComponent<HSController>();
        StartCoroutine(hsController.GetScores());
 
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
