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
    [SerializeField] private ScoreHUD score;
    [SerializeField] private AudioClip goodFoodSound;
    [SerializeField] private AudioClip badFoodSound;
    [SerializeField] private GameObject gameOver;

    private CameraMovement cameraController;
    private AudioSource mSource;
    private string humor;
    private SpriteRenderer sRenderer;
    private Dictionary<string, int> foodEat = new Dictionary<string, int>();
    private string allergie;
    private int fail = 0;
    private float lastChangeTime = 0;
    private bool loose = false;
    private bool isStarving = false;
    private HSController hsController;
    static public int finalScore = 0;

	// Use this for initialization
	void Start () {
        hsController = GetComponent<HSController>();
        mSource = GetComponent<AudioSource>();
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
                mSource.PlayOneShot(goodFoodSound);
                transform.position = new Vector3(transform.position.x, 0.15f, transform.position.z);
                break;
            case "puke":
                sRenderer.sprite = puke;
                mSource.PlayOneShot(badFoodSound);
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

    IEnumerator End()
    {
        yield return new WaitForSeconds(2);
        gameOver.SetActive(true);
        yield return new WaitForSeconds(2);
        MainMenu.comingFromMenu = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void EndGame()
    {
        finalScore = score.GetScore();
        StartCoroutine(hsController.PostScores(MainMenu.pseudo, score.GetScore()));
        cameraController.LaunchEndGameEffect();
        StartCoroutine(End());
    }

    public void ResetFail()
    {
        fail = 0;
        cameraController.SetStarvation(false);
    }
}
