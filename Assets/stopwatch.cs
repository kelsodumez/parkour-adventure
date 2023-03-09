using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class stopwatch : MonoBehaviour
{
    private bool paused;
    private float timer;
    private bool reset;
    public TextMeshProUGUI stopwatchText;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {   
        stopwatchText = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        //PlayerController playerController = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerController.stopPaused == false)
        {

            timer += Time.deltaTime;
            TimeSpan t = TimeSpan.FromSeconds(timer);
            stopwatchText.text = t.ToString(@"mm\:ss\:ff");
        }

        if (playerController.stopReset == true)
        {
            timer = 0f;
            playerController.stopReset = false;
        }

    }
}
