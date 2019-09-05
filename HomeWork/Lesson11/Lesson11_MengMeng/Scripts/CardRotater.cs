using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MengMeng
{
    public class CardRotater : MonoBehaviour
    {
        GameObject Card;
        public float RotationSpeed;
        bool bRotateState = false;
        public bool RotateState { get { return bRotateState; } set { bRotateState = value; } }
        

        // Use this for initialization
        void Start()
        {
            Card = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Card"),this.transform);
        }

        // Update is called once per frame
        void Update()
        {
           if(bRotateState)
            {
                RotateCard();
            }
        }

        void RotateCard()
        {
            Card.transform.Rotate(new Vector3(RotationSpeed, 0, 0));
        }

        
    }
}

