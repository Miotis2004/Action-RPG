using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSpawnPoint : NetworkBehaviour
{
    private int waitTime;
    private float spawnX, spawnY, spawnZ;
    private Vector3 playerLastPos;  //New Code Part 5

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("LastX"))
        {
            return;
        }

        spawnX = PlayerPrefs.GetFloat("LastX");
        spawnY = PlayerPrefs.GetFloat("LastY");
        spawnZ = PlayerPrefs.GetFloat("LastZ");

        transform.position = new Vector3(spawnX, spawnY, spawnZ);
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            PlayerPrefs.SetFloat("LastX", 515);
            PlayerPrefs.SetFloat("LastY", 130);
            PlayerPrefs.SetFloat("LastZ", 1450);
        }
    }

    private void FixedUpdate()
    {
        
        if (isLocalPlayer)
        {
            waitTime++;
            if (waitTime == 30)
            {
                playerLastPos = transform.position; //New Code Part 5
                waitTime = 0;
            }
            
        }

        Debug.Log(waitTime);
    }

    private void OnDisable()  //New Code Part 5
    {
        float lastX = playerLastPos.x;
        float lastY = playerLastPos.y;
        float lastZ = playerLastPos.z;

        PlayerPrefs.SetFloat("LastX", lastX);
        PlayerPrefs.SetFloat("LastY", lastY);
        PlayerPrefs.SetFloat("LastZ", lastZ);

        Debug.Log("Saved Player Position" + playerLastPos);
    }
}
