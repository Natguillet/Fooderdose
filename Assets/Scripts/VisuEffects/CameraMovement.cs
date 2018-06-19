using System.Collections;
using System.Collections.Generic;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private bool end = false;
    [SerializeField] private bool updateBloom = false;
    [SerializeField] private bool starve = false;
    [SerializeField] private int multiplier;

    [SerializeField] private float moveRadius;  //radius of the camera circular movement
    [SerializeField] private float moveAngle;
    [SerializeField] private float moveTime;//duration of the camera movement

    [SerializeField] private float bloomOffset; //softknee offset between 0 and 1
    [SerializeField] private float bloomTransitionTime;

    [SerializeField] private float chromFreq;

    private PostProcessingController postProcessing;
    private int currentBloomFactor;
    private bool isBlooming;
    private bool isStarving;
    
    //PostProcessingProfile profile;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position;
        postProcessing = GetComponent<PostProcessingController>();
        if (postProcessing != null)
            InitializeVisuEffect();
    }

    public void InitializeVisuEffect()
    {
        //enabling motion blur
        postProcessing.enableMotionBlur = true;
        postProcessing.controlMotionBlur = true;
        //tuning settings
        MotionBlurModel.Settings blurSettings = new MotionBlurModel.Settings();
        blurSettings.shutterAngle = 2f;
        blurSettings.sampleCount = 15;
        blurSettings.frameBlending = 0.7f;
        postProcessing.motionBlur = blurSettings;

        //enable vignette effect
        postProcessing.enableVignette = true;
        postProcessing.controlVignette = true;
        //tuning settings
        VignetteModel.Settings vignetteSettings = new VignetteModel.Settings();
        vignetteSettings.intensity = 0f;
        vignetteSettings.smoothness = 0.3f;
        vignetteSettings.roundness = 1;
        vignetteSettings.center = new Vector2(0.5f, 0.5f);
        postProcessing.vignette = vignetteSettings;

        //enable bloom effect
        postProcessing.enableBloom = true;
        postProcessing.controlBloom = true;
        //tuning settings;
        BloomModel.Settings bloomSettings = new BloomModel.Settings();
        bloomSettings.bloom.intensity = 1.2f;
        bloomSettings.bloom.threshold = 1.1f;
        bloomSettings.bloom.radius = 4f;
        bloomSettings.bloom.softKnee = bloomOffset;
        postProcessing.bloom = bloomSettings;
        currentBloomFactor = 0;
        isBlooming = false;

        //enable chromatic aberration effect
        postProcessing.enableChromaticAberration = true;
        postProcessing.controlChromaticAberration = true;
        //tuning settings
        ChromaticAberrationModel.Settings chromaSettings = new ChromaticAberrationModel.Settings();
        chromaSettings.intensity = 0;
        isStarving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            end = false;
            LaunchEndGameEffect();
        }
        if (updateBloom)
        {
            updateBloom = false;
            UpdateBloomEffect(multiplier);
        }
        if (starve)
        {
            isStarving = !isStarving;
            starve = false;
            SetStarvation(isStarving);
        }
        
        
    }

    public void SetStarvation(bool starve)
    {
        isStarving = starve;
        if (isStarving)
            StartCoroutine(StartStarvation());
        else
            StartCoroutine(EndStarvation());
    }

    private IEnumerator StartStarvation()
    {
        float time = 0;
        while (isStarving)
        {
            time += Time.deltaTime;
            postProcessing.chromaticAberration.intensity = Mathf.Abs(Mathf.Sin(time * 2 * Mathf.PI / chromFreq));
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator EndStarvation()
    {
        float offset = postProcessing.chromaticAberration.intensity;
        float time = 0;
        while(time < chromFreq)
        {
            postProcessing.chromaticAberration.intensity = offset * (1 - time / chromFreq);
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }
    }

    public void UpdateBloomEffect(int multiplier)
    {
        if (!isBlooming)
        {
            isBlooming = true;
            StartCoroutine(BloomUpdate(bloomOffset, currentBloomFactor, multiplier - 1, bloomTransitionTime));
        }
        currentBloomFactor = multiplier - 1;
    }

    private IEnumerator BloomUpdate(float offset, int prevFactor, int nextFactor, float transitionTime)
    {
        float bloomFactor = (1 - bloomOffset) / 4;
        float time = 0;
        while(time < transitionTime)
        {
            time += Time.deltaTime;
            postProcessing.bloom.bloom.softKnee = offset + prevFactor * bloomFactor + (nextFactor - prevFactor) * bloomFactor * time / transitionTime;
            yield return new WaitForEndOfFrame();
        }
        isBlooming = false;
    }

    public void LaunchEndGameEffect()
    {
        //setup two circular movements to give a "sick" feeling
        StartCoroutine(CameraCircle());
        StartCoroutine(ClosingEyeEffect());
    }
    

    private IEnumerator ClosingEyeEffect()
    {
        float time = 0;
        while (time < moveTime)
        {
            postProcessing.vignette.intensity = 0.3f + (time / moveTime) * 1.7f;
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }
    }

    private IEnumerator CameraCircle()
    {
        float currentAngle;

        float time = 0;
        Vector3 leftCenter = offset - new Vector3(moveRadius, 0, 0);
        //first circle (left)
        while (time < moveTime / 2)
        {
            currentAngle = 4 * Mathf.PI * (time / moveTime);
            transform.position = leftCenter + new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle), 0) * moveRadius;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, moveAngle * Mathf.Sin(2 * Mathf.PI * time / moveTime)));
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }

        //second circle (right)
        time = 0;
        Vector3 rightCenter = offset + new Vector3(moveRadius, 0, 0);
        while (time < moveTime / 2)
        {
            currentAngle = Mathf.PI - 4 * Mathf.PI * (time / moveTime);
            transform.position = rightCenter + new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle), 0) * moveRadius;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, moveAngle * Mathf.Sin(2 * Mathf.PI * (time + moveTime / 2) / moveTime)));
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }

        //prevent small perturbation from origin
        transform.position = offset;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
