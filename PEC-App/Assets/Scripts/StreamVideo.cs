using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class StreamVideo : MonoBehaviour
{
    [SerializeField]
    private RawImage m_rawImage;

    [SerializeField]
    private VideoClip m_videoToPlay;

    private VideoPlayer m_videoPlayer;

    private VideoSource m_videoSource;

    private AudioSource m_audioSource;

    [SerializeField]
    private TextMeshProUGUI m_text;

    private void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }

    IEnumerator playVideo()
    {
        
        m_videoPlayer = gameObject.AddComponent<VideoPlayer>();


        m_audioSource = gameObject.AddComponent<AudioSource>();

        ///Disable play on awake for video/audio
        m_videoPlayer.playOnAwake = false;
        m_audioSource.playOnAwake = false;
        m_audioSource.Pause();

        ///Playing from file not from url
        m_videoPlayer.source = VideoSource.VideoClip;

        ///set audio output mode
        m_videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        ///Assign the Audio from Video to AudioSource
        m_videoPlayer.EnableAudioTrack(0, true);
        m_videoPlayer.SetTargetAudioSource(0, m_audioSource);

        ///Set video to play then prepare audiio to prevent buffering
        m_videoPlayer.clip = m_videoToPlay;
        m_videoPlayer.Prepare();


        ///Wait until video is prepared
        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (!m_videoPlayer.isPrepared)
        {
            //Prepare/wait for 5 seconds
            yield return waitTime;

            //break after 5 seconds
            break;
        }


     


    }
    /// <summary>
    /// Plays or pauses the video when fired
    /// </summary>
    public void PlayPause()
    {
        ///Assign the texture from video to rawimage to be displayed
        m_rawImage.texture = m_videoPlayer.texture;
        if (!m_videoPlayer.isPlaying)
        {

            m_text.text = "Pause";
            ///play video
            m_videoPlayer.Play();
            ///play sound
            m_audioSource.Play();
        }
        else
        {
            m_text.text = "Play";
            m_videoPlayer.Pause();

            m_audioSource.Pause();

        }
    }

}
