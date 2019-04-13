using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class StreamVideo : MonoBehaviour
{
    /// <summary>
    /// A reference to the RawImage m_rawImage.
    /// </summary>
    [SerializeField]
    private RawImage m_rawImage;

    /// <summary>
    /// A reference to the Videolip m_videoToPlay.
    /// </summary>
    [SerializeField]
    private VideoClip m_videoToPlay;

    /// <summary>
    /// A reference to the VideoPlayer m_videoPlayer.
    /// </summary>
    private VideoPlayer m_videoPlayer;

    /// <summary>
    /// A reference to the VideoSource m_videoSource.
    /// </summary>
    private VideoSource m_videoSource;

    /// <summary>
    /// A reference to the AudioSource m_audioSource.
    /// </summary>
    private AudioSource m_audioSource;

    /// <summary>
    /// A reference to the button text, m_text.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_text;

    /// <summary>
    /// Sprite to display when video is paused.
    /// </summary>
    [SerializeField]
    private Sprite m_playButtonSprite = null;

    /// <summary>
    /// Sprite to display when is playing.
    /// </summary>
    [SerializeField]
    private Sprite m_pauseButtonSprite = null;

    /// <summary>
    /// Image displayed on the PlayPause button.
    /// </summary>
    [SerializeField]
    private Image m_playPauseButtonImage = null;

    /// <summary>
    /// Starts when the application is run and plays a coroutine to play the video.
    /// </summary>
    private void Start()
    {
        Application.runInBackground = true;

        StartCoroutine(playVideo()); 
    }

    /// <summary>
    /// An update method that is called every frame, checking if the video is currently playing.
    /// </summary>
    private void Update()
    { 
        if (!m_videoPlayer.isPlaying)
        {
            m_text.text = "Play";
        }
        else
        {
            m_text.text = "Pause";
        }

        if (m_videoPlayer.frame == (long)m_videoPlayer.frameCount)
        {
            /// Video has finished playing.
            m_videoPlayer.Pause();
        }
    }

    /// <summary>
    /// Toggles the displayed sprite on the PlayPause button.
    /// </summary>
    public void TogglePlayPauseButtonSprite()
    {
        /// If the Play sprite is currently displayed, swap it for the Pause sprite.
        if (m_playPauseButtonImage.sprite == m_playButtonSprite)
        {
            m_playPauseButtonImage.sprite = m_pauseButtonSprite;
        }
        /// If the Pause sprite is currently displayed, swap it for the Play sprite.
        else if (m_playPauseButtonImage.sprite == m_pauseButtonSprite)
        {
            m_playPauseButtonImage.sprite = m_playButtonSprite;
        }
    }

    /// <summary>
    /// Plays the video through the RawImage component.
    /// </summary>
    /// <returns>WaitForSeconds instance.</returns>
    private IEnumerator playVideo()
    {
        /// Add a videoplayer to the gameObject.
        m_videoPlayer = gameObject.AddComponent<VideoPlayer>();

        /// Add an audioSource to the gameObject.
        m_audioSource = gameObject.AddComponent<AudioSource>();

        /// Disable play on awake for video/audio.
        m_videoPlayer.playOnAwake = false;

        m_audioSource.playOnAwake = false;

        m_audioSource.Pause();

        /// Playing from file not from url.
        m_videoPlayer.source = VideoSource.VideoClip;

        /// Set audio output mode.
        m_videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        /// Assign the Audio from Video to AudioSource.
        m_videoPlayer.EnableAudioTrack(0, true);

        m_videoPlayer.SetTargetAudioSource(0, m_audioSource);

        /// Set video to play then prepare audiio to prevent buffering.
        m_videoPlayer.clip = m_videoToPlay;

        m_videoPlayer.Prepare();

        /// Wait until video is prepared.
        WaitForSeconds waitTime = new WaitForSeconds(1);

        while (!m_videoPlayer.isPrepared)
        {
            /// Prepare/wait for 1 seconds.
            yield return waitTime;

            /// Break after 1 seconds.
            break;
        }

        m_videoPlayer.isLooping = true;
    }

    /// <summary>
    /// Plays or pauses the video when fired.
    /// </summary>
    public void PlayAndPause()
    {
        /// Assign the texture from video to rawimage to be displayed.
        m_rawImage.texture = m_videoPlayer.texture;

        /// Changes the video state to playing.
        if (!m_videoPlayer.isPlaying)
        {
            /// Play video.
            m_videoPlayer.Play();
            /// Play sound.
            m_audioSource.Play();
        }
        else
        {
            /// A reference to the PauseOnClose method.
            PauseOnClose();
        }
    }

    public void PauseOnClose()
    {
        /// If video is playing, changes its state to paused.
        if (m_videoPlayer.isPlaying)
        {
            /// Pause video.
            m_videoPlayer.Pause();
            /// Pause sound.
            m_audioSource.Pause();

            TogglePlayPauseButtonSprite();
        }
    }
}
