using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRplayerController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip winSFX;
    public AudioClip loseSFX;
    
    private Rigidbody rb; 

    public GameObject winText;
    public GameObject loseText;

    public GameObject respawnPoint;
    public bool stopPaused = false;
    public bool stopReset = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Launch")
        {
            rb.AddForce(Vector3.up * 30, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinishLine")
        {
            winText.gameObject.SetActive(true);
            audioSource.PlayOneShot(winSFX);
            stopPaused = true;
        }
        if (other.gameObject.tag == "KillZone")
        {
            loseText.SetActive(true);
            StartCoroutine(WaitThenRespawn());
        }
    }

    IEnumerator WaitThenRespawn()
    {
        yield return new WaitForSeconds(3);
        loseText.SetActive(false);
        audioSource.PlayOneShot(loseSFX);
        gameObject.transform.position = respawnPoint.transform.position;
        stopReset = true;
        // stopReset = false;
    }
}
