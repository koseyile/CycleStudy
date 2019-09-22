using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedownward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localPosition.y > 114) { 
        transform.Translate(-transform.up * Time.deltaTime*10);
            if (this.transform.localPosition.y > 114)
            {
               this.transform.localPosition= new Vector3(0,84,0);
            }
        }
    }
}
