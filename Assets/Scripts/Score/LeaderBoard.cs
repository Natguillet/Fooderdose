using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour {

    [SerializeField] private UnityEngine.UI.Text leaderBoardText;
    public int[] highScores = new int[10];
    string highScoreKey = "";
	// Use this for initialization
	void Start () {
    
        /*for (int i = 0; i < highScores.Length; i++)
        {
            highScoreKey = "HighScore" + (i + 1).ToString();
            highScores[i] = PlayerPrefs.GetInt(highScoreKey, 0);
            leaderBoardText.text = leaderBoardText.text + "\n" + i.ToString() + ". " + highScores[i].ToString();
        }*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
