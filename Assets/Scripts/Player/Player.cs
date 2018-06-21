using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField] private float timeBeforeBlase;
    [SerializeField] private Sprite happy;
    [SerializeField] private Sprite puke;
    [SerializeField] private Sprite blase;
    [SerializeField] private Sprite angry;
    [SerializeField] private Score score;
    //[SerializeField] private GameObject leaderBoard;

    private CameraMovement cameraController;
    private string humor;
    private SpriteRenderer sRenderer;
    private Dictionary<string, int> foodEat = new Dictionary<string, int>();
    private string allergie;
    private int fail = 0;
    private float lastChangeTime = 0;
    private bool loose = false;
    private bool isStarving = false;
    private HSController hsController;

	// Use this for initialization
	void Start () {
        hsController = GetComponent<HSController>();
        cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
        sRenderer = GetComponent<SpriteRenderer>();
        ChangeHumor(null);
        Object[] ressources = Resources.LoadAll("Ingredients", typeof(Ingredient));
        foreach (var t in ressources)
        {
            foodEat.Add(t.name, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        lastChangeTime += Time.deltaTime;
        if (lastChangeTime > timeBeforeBlase)
        {
            sRenderer.sprite = blase;
            ChangeHumor("blase");
        }
    }

    public void AddCountFood(string food)
    {
        foodEat[food]++;
        ChangeAllergie(food);
    }

    public void ChangeHumor(string humor)
    {
        lastChangeTime = 0;
        switch (humor)
        {
            case "happy":
                sRenderer.sprite = happy;
                transform.position = new Vector3(transform.position.x, 0.15f, transform.position.z);
                break;
            case "puke":
                sRenderer.sprite = puke;
                transform.position = new Vector3(transform.position.x, 0.61f, transform.position.z);
                break;
            case "angry":
                sRenderer.sprite = angry;
                transform.position = new Vector3(transform.position.x, 0.61f, transform.position.z);
                break;
            default:
                sRenderer.sprite = blase;
                transform.position = new Vector3(transform.position.x, 0.45f, transform.position.z);
                break;
        }
    }

    public void ChangeAllergie(string food)
    {
        if (foodEat[food] == 3)
        {
            allergie = food;
            foodEat[food] = 0;
        }
    }

    public string GetAllergie()
    {
        return allergie;
    }

    public void AddFail()
    {
        fail++;
        if (fail == 2) cameraController.SetStarvation(true);
        if (fail == 3)
        {
            loose = true;
            EndGame();
        }
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneName);
    }
    public void EndGame()
    {
        StartCoroutine(hsController.PostScores("Dorian", score.GetScore()));
        cameraController.LaunchEndGameEffect();
        StartCoroutine(LoadScene("LeaderBoardScene"));
    }

    public void ResetFail()
    {
        fail = 0;
        cameraController.SetStarvation(false);
    }
}
