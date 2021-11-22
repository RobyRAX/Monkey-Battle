using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
    }

    void OnCollisionEnter(Collision colliderInfo)
    {
        if (colliderInfo.collider.name == "monyetKiri")
        {
            int inputScore = 1;
            GameObject player = GameObject.Find("monyetKiri");
            charController charControl = player.GetComponent<charController>();

            charControl.setScore(inputScore);
            Destroy(gameObject);
        }

        if (colliderInfo.collider.name == "monyetKanan")
        {
            int inputScore = 1;
            GameObject player = GameObject.Find("monyetKanan");
            charController charControl = player.GetComponent<charController>();

            charControl.setScore(inputScore);
            Destroy(gameObject);
        }
    }

    void rotate()
    {
        transform.Rotate(0.5f, 0, 0);
    }
}
