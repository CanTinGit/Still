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
        Application.runInBackground = true;
        Debug.Log(MenuScript.Instance.GetPlayerFirstTime());
        if (MenuScript.Instance.GetPlayerFirstTime() == true)
        {
            Debug.Log(MenuScript.Instance.GetPlayerFirstTime());
            StartCoroutine(PlayVideo());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void PlayIntroVideo()
    {
        StartCoroutine(PlayVideo());
    }

    //Play video
    IEnumerator PlayVideo()
    {
        videoplayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoplayer.EnableAudioTrack(0, true);
        videoplayer.SetTargetAudioSource(0, audioSource);

        bool isplayed = false;
        videoplayer.Prepare();

        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (!videoplayer.isPrepared)
        {
            Debug.Log("Preparing");
            yield return waitTime;
            break;
        }

        Debug.Log("DONE Preparing");

        //using image UI to play video
        image.texture = videoplayer.texture;

        videoplayer.Play();
        audioSource.Play();

        Debug.Log("Play Video");
        while (videoplayer.isPlaying)
        {
            isplayed = true;
            Debug.Log("Video Time: " + Mathf.FloorToInt((float)videoplayer.time));
            yield return null;
        }
        fade.SetTrigger("FadeOut");
        Invoke("Delay", 2f);
        MenuScript.Instance.SetPlayerFirstTime(false);
        Debug.Log("DONE Playing video");
    }


    public void Delay()
    {
        gameObject.SetActive(false);
    }
}
