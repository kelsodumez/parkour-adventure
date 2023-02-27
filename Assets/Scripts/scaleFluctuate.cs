using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleFluctuate : MonoBehaviour
{
    public float scaleSize;
    private float absSin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        absSin = Mathf.Abs(scaleSize * Mathf.Sin(Time.time));
        Vector3 vec = new Vector3(absSin, absSin, absSin);
 
        transform.localScale = vec;    
    }
}
