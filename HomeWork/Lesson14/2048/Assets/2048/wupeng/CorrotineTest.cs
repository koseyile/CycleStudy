using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrotineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CorrotineA");
        StartCoroutine("CorrtineB");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator CorrotineA()
    {
        while (true)
        {
            Debug.Log("A");
            yield return this;          
        }
    }

    IEnumerator CorrtineB()
    {
        while (true)
        {
            Debug.Log("B");
            yield return this;
        }
    }
}
