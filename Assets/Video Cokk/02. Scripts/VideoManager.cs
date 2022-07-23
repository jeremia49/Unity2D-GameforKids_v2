using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Events;
using TMPro;

public class VideoManager : MonoBehaviour
{
    public UnityEvent events = null;

    public bool isLoop = false;

    public RectTransform videoPanel = null;
    public RectTransform scrollPanel = null;

    private Coroutine runningCoroutine = null;

    [SerializeField] private Animator anim = null;
    [SerializeField] private Button playButton = null;
    [SerializeField] private Button pauseButton = null;
    //[SerializeField] private Button exitButton = null;
    [SerializeField] private Button muteButton = null;
    [SerializeField] private Button unMuteButton = null;

    public VideoPlayer vp = null;

    public Scrollbar scrollbar = null;
    public Image scrollImage = null;
    public TMP_Text currentTimeText = null;
    public TMP_Text endTimeText = null;

    [Range(0.1f, 2f)]
    [SerializeField] private float fadeSpeed = 1f;

    private int hours, mins, secs = 0;

    void Awake()
    {
        ButtonAddListener();
    }

    void OnEnable()
    {
        currentTimeText.text = "00:00:00";
        endTimeText.text = "00:00:00";
        if (isLoop)
            vp.isLooping = true;
        else
            vp.isLooping = false;

        runningCoroutine = StartCoroutine(PlayCorotuine());
    }

    IEnumerator PlayCorotuine()
    {
        vp.Prepare();

        while (!vp.isPrepared)
        {
            yield return new WaitForSeconds(1.0f);
        }

        vp.Play();

        endTimeText.text = GetTextTime(vp.length);
        OnFadeAnimation("Fade");
    }

    void OnDisable()
    {
        OnFadeAnimation("Exit");
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);

        StopCoroutine(runningCoroutine);
    }

    void Update()
    {
        currentTimeText.text = GetTextTime(vp.clockTime);

        VideoPanel();
        ScrollPanel();
        UpdateVideo();
    }

    private void ButtonAddListener()
    {
        playButton.onClick.AddListener(() => PlayButton());
        pauseButton.onClick.AddListener(() => PauseButton());
        //exitButton.onClick.AddListener(() => ExitButton());
        muteButton.onClick.AddListener(() => MuteButton());
        unMuteButton.onClick.AddListener(() => UnMuteButton());
    }

    public void OnFadeAnimation(string _text)
    {
        anim.SetTrigger("Exit");
        anim.Rebind();

        if (_text == "Fade")
            anim.SetTrigger("Fade");
    }

    private void PlayButton()
    {
        vp.Play();
    }

    private void PauseButton()
    {
        vp.Pause();
    }

    private void ExitButton()
    {

    }

    private void MuteButton()
    {
        vp.SetDirectAudioVolume(0, 0);
        unMuteButton.gameObject.SetActive(true);
        muteButton.gameObject.SetActive(false);
    }

    private void UnMuteButton()
    {
        vp.SetDirectAudioVolume(0, 1);
        muteButton.gameObject.SetActive(true);
        unMuteButton.gameObject.SetActive(false);
    }

    private void UpdateVideo()
    {
        if (scrollbar != null)
        {
            scrollbar.value = (float)(vp.clockTime / vp.length);

            if (scrollImage != null)
                scrollImage.fillAmount = scrollbar.value;

            if (vp.isPlaying && endTimeText.text != "00:00" && currentTimeText.text == endTimeText.text
                    && (float)vp.clockTime >= vp.length - 0.01f)
            {
                if (isLoop)
                {
                    vp.Stop();
                    vp.Play();
                }
                else
                {
                    vp.Pause();

                    playButton.gameObject.SetActive(true);
                    //pauseButton.gameObject.SetActive(false);
                }

                events.Invoke();
            }
        }
    }

    public void VideoPanel()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(videoPanel, Input.mousePosition))
        {
            if (Input.GetMouseButtonUp(0))
            {
                OnFadeAnimation("Fade");
            }
        }
    }

    public void ScrollPanel()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(scrollPanel, Input.mousePosition))
        {
            if (Input.GetMouseButton(0))
            {
                var xValue = (Input.mousePosition.x - 170f) / (Screen.width - 170f - 250f);

                scrollbar.value = xValue;

                scrollImage.fillAmount = scrollbar.value;
                vp.time = (float)vp.length * scrollbar.value;
            }
        }
    }

    public string GetTextTime(double _time)
    {
        int time = Mathf.FloorToInt((float)_time);

        hours = time / 3600;

        mins = (time % 3600) / 60;

        secs = (time % 3600) % 60;


        string secsStr = string.Format("{0:00}", secs);
        string minsStr = string.Format("{0:00}", mins);
        string hoursStr = string.Format("{0:00}", hours);

        string textTime = string.Format("{0}:{1}:{2}", hoursStr, minsStr, secsStr);

        return textTime;
    }

}
