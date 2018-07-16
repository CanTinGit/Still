using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    public RawImage image;
    public VideoPlayer videoplayer;
    private VideoSource videoSource;

    public AudioSource audioSource;
    public Animator fade;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(PlayVideo());
        MenuScript.Instance.gamePaused = true;
        MenuScript.Instance.pausePlayerNum = 5;
    }

    void Update()
    {
        if(Input.GetButtonDown("Start1")|| Input.GetButtonDown("Start2")|| Input.GetButtonDown("Start3") || Input.GetButtonDown("Start4"))
        {
            fade.SetTrigger("FadeOut");
            Invoke("Delay", 2f);

        }
    }

    //Play video
    IEnumerator PlayVideo()
    {
        Application.runInBackground = true;
        videoplayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoplayer.EnableAudioTrack(0, true);
        videoplayer.SetTargetAudioSource(0, audioSource);

        videoplayer.Prepare();

        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (!videoplayer.isPrepared)
        {
            yield return waitTime;
            break;
        }

        //using image UI to play video
        image.texture = videoplayer.texture;

        videoplayer.Play();
        audioSource.Play();

        while (videoplayer.isPlaying)
        {
            yield return null;
        }
        fade.SetTrigger("FadeOut");
        Invoke("Delay", 2f);
    }


    public void Delay()
    {
        gameObject.SetActive(false);
        MenuScript.Instance.gamePaused = false;
        MenuScript.Instance.pausePlayerNum = 0;
    }
}
