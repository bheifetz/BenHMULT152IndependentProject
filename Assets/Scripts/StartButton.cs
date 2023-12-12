using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI controls;
    public Button startButton;
    public Image blackScreen;

    public TextMeshProUGUI line1;
    public TextMeshProUGUI line2;
    public TextMeshProUGUI line3;
    public TextMeshProUGUI line4;
    public TextMeshProUGUI line5;
    public TextMeshProUGUI line6;
    
    public void StartGame()
    {
        StartCoroutine(IntroBlurb());
    }

    IEnumerator IntroBlurb()
    {
        title.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        controls.gameObject.SetActive(false);
        blackScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        line1.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        line2.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        line3.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        line4.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        line5.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        line6.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Meateater");
    }
}
