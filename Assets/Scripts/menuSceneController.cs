using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuSceneController : MonoBehaviour
{
    public GameObject panelButton;
    public GameObject creditButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButton()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void creditsButton()
    {
        panelButton.SetActive(false);
        creditButton.SetActive(true);
    }

    public void backCredit()
    {
        panelButton.SetActive(true);
        creditButton.SetActive(false);
    }
}
