using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class charController : MonoBehaviour
{
    public Joystick analog;
    public Text textScore;
    public Text textAmmo;
    public GameObject enemy;
    public GameObject projectile;
    public Transform projSpawner;

    public float forwardSpeed;
    public float rotateSpeed;
    public Vector3 projForce;

    private int score;
    private int ammo;
    Vector3 startPos;
    Quaternion startRot;

    public bool isGameStart;

    public cameraShaker camShaker;

    // Start is called before the first frame update
    void Start()
    {
        isGameStart = false;
        startPos = transform.position;
        startRot = transform.rotation;
        score = 0;
        ammo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStart)
        {
            analogMovement();
            updateUI();

            if (transform.position.y < -20) //Death
            {
                respawn();
            }
        }
        
    }

    void analogMovement()
    {
        float angle = Mathf.Atan2(analog.Horizontal, analog.Vertical) * Mathf.Rad2Deg;
        Quaternion rotationTarget = Quaternion.Euler(new Vector3(-90, angle, 0));

        if (analog.Horizontal != 0 || analog.Vertical != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget, rotateSpeed * Time.deltaTime);
            transform.Translate(0, -forwardSpeed * Time.deltaTime, 0);
        }
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int inputScore)
    {
        score += inputScore;
    }

    public void buyAmmo()
    {
        if(score >= 3)
        {
            ammo += 2;
            score -= 3;
            Debug.Log(ammo);
        }
    }

    void updateUI()
    {
        textScore.text = score.ToString();
        textAmmo.text = ammo.ToString();
    }

    void respawn()
    {
        int addEnemyScore = 5;

        transform.position = startPos;
        transform.rotation = startRot;

        charController charMusuh = enemy.GetComponent<charController>();
        charMusuh.setScore(addEnemyScore);
    }

    public void shoot()
    {
        if(ammo > 0)
        {
            ammo--;
            GameObject projClone = Instantiate(projectile, projSpawner.position, projSpawner.rotation);

            Destroy(projClone, 5f);
        }        
    }

    void OnCollisionEnter(Collision colliderInfo)
    {
        if (colliderInfo.collider.tag == "peluru")
        {
            StartCoroutine(camShaker.Shake(.15f, .4f));
        }
    }
}

