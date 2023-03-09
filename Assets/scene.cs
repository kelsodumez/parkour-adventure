using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene : MonoBehaviour
{
    Color lerpedColor = Color.white;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        lerpedColor = Color.Lerp(Color.magenta, Color.green, Mathf.PingPong(Time.time* timer * .02f, 1) );
        Debug.Log(lerpedColor);
        RenderSettings.ambientLight = lerpedColor;
    }
}
