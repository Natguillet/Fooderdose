using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    [SerializeField]private TMP_InputField inputPseudo;
    public static string pseudo;
    public static bool comingFromMenu = false;

    public void PlayGame() {
        pseudo = inputPseudo.text;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Leaderboard() {
        comingFromMenu = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}
