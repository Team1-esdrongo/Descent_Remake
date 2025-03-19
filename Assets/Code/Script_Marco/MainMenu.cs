using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Button playBTN;
    [SerializeField] private Button quitBTN;
    private float lengthOfTime = 4.5f;

    public void OnPlayButton()
    {
        title.gameObject.SetActive(false);
        playBTN.gameObject.SetActive(false);
        quitBTN.gameObject.SetActive(false);
        SceneManager.LoadScene("SCN_Loading");
        //StartCoroutine(NextScene());
    }

    public void OnQuitButton()
    {
        Application.Quit();
        Debug.LogWarning("Game has been closed");
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(lengthOfTime);
        SceneManager.LoadScene(1);
    }
}
