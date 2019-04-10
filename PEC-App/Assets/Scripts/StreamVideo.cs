using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class StreamVideo : MonoBehaviour
{/// <summary>
/// A reference to the RawImage m_rawImage
/// </summary>
    [SerializeField]
    private RawImage m_rawImage;
/// <summary>
/// A reference to the Videolip m_videoToPlay
/// </summary>
    [SerializeField]
    private VideoClip m_videoToPlay;
/// <summary>
/// a reference to the VideoPlayer m_videoPlayer
/// </summary>
    private VideoPlayer m_videoPlayer;
/// <summary>
/// a reference to the VideoSource m_videoSource
/// </summary>
    private VideoSource m_videoSource;
/// <summary>
/// a reference to the AudioSource m_audioSource
/// </summary>
    private AudioSource m_audioSource;
/// <summary>
/// a reference to the button text, m_text
/// </summary>
    [SerializeField]
    private TextMeshProUGUI m_text;
/// <summary>
/// Starts when the application is run and plays a coroutine to play the video
/// </summary>
    private void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }
/// <summary>
/// plays the video through the RawImage component
/// </summary>
/// <returns></returns>
    IEnumerator playVideo()
    {
        ///Add a videoplayer to the gameObject    
        m_videoPlayer = gameObject.AddComponent<VideoPlayer>();

        ///Add an audioSource to the gameObject
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
            //Prepare/wait for 1 seconds
            yield return waitTime;

            //break after 1 seconds
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
            ///changes the button text to Pause
            m_text.text = "Pause";
            ///play video
            m_videoPlayer.Play();
            ///play sound
            m_audioSource.Play();
        }
        else
        { //changes the button text to Play
            m_text.text = "Play";
            ///pause video
            m_videoPlayer.Pause();
            ///pause sound
            m_audioSource.Pause();

        }
    }

}
