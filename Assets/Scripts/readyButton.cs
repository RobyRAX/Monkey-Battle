using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class readyButton : MonoBehaviour
{
    private bool isPlayerReady;
    public float outSpeed;

    public GameObject gameHandler;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        outScreen();
    }

    public void playerReady()
    {
        isPlayerReady = true;

        gameManager gm = gameHandler.GetComponent<gameManager>();
        gm.setReady();
    }

    void outScreen()
    {
        if(isPlayerReady == true)
            transform.Translate(outSpeed * Time.deltaTime, 0, 0);
    }
}
