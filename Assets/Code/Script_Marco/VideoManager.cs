using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.loopPointReached += VideoPlayer_loopPointReached;
    }

    private void VideoPlayer_loopPointReached(VideoPlayer source)
    {
        SceneManager.LoadScene("SCN_Alex");
    }
}
