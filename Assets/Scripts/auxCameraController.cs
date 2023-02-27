using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auxCameraController : MonoBehaviour
{
    private Animator anim;
    public GameObject mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam.SetActive(false);
        anim = GetComponent<Animator>();
		anim.Play("Establishingcam");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            mainCam.SetActive(true);   
        }
     
    
    }
}
