using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MengMeng
{
    public class UIManager : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

       public void OnClickButton_RotateCard()
        {
            Transform CardManager = transform.Find("/CardManager");
            CardRotater cardRotater = CardManager.GetComponentInChildren<CardRotater>();
            cardRotater.RotateState = !cardRotater.RotateState;
        }
    }
}

