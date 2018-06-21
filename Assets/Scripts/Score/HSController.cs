using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HSController : MonoBehaviour {

    [SerializeField] private TMP_Text leaderBoardText;
    private string secretKey = "CarlosPowa"; // Edit this value and make sure it's the same as the one stored on the server
    public string addScoreURL = "http://35.237.11.130:8080/addscore.php?"; //be sure to add a ? to your url
    public string highscoreURL = "http://35.237.11.130:8080/display.php";


    // Use this for initialization
    void Start () {
        //StartCoroutine(GetScores());	
	}
	
	public IEnumerator PostScores(string name, int score)
    {
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.
        string hash = MD5Test.Md5Sum(name + score + secretKey);

        string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
        Debug.Log("name " + WWW.EscapeURL(name));
        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }

    public IEnumerator GetScores()
    {
        leaderBoardText.text = "Loading Scores";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            leaderBoardText.text = " High Scores : " + "\n" + hs_get.text; // this is a GUIText that will display the scores in game.
        }
    }
}
