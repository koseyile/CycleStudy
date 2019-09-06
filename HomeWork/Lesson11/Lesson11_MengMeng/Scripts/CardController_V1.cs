using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MengMeng
{

    public class CardController_V1 : MonoBehaviour
    {
        protected GameObject Card;
        public float RotationSpeed;
        public enum CardState { wait, Rotate };
        public CardState cardstate = CardState.wait;


        // Use this for initialization
        void Start()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            CardStateMachine();
        }

        protected virtual void Initialize()
        {
            Card = this.gameObject;
            RotationSpeed = -2;
        }

        public virtual void RotateCard()
        {
            Card.transform.Rotate(new Vector3(RotationSpeed, 0, 0));
        }

        protected virtual void CardStateMachine()
        {
            switch (cardstate)
            {
                case CardState.wait:
                    break;
                case CardState.Rotate:
                    RotateCard();
                    break;
            }
        }

        public void SetFrontNumber(string text)
        {
            Card.transform.Find("FrontSide").GetComponent<TextMesh>().text = text;
        }
        public void SetBackNumber(string text)
        {
            Card.transform.Find("BackSide").GetComponent<TextMesh>().text = text;
        }
    }

    public class CardController_V2 : CardController_V1
    {
        public float RotateInterval;
        float timeCount = 0;
        protected float RotatedAngle = 0;
        protected bool Changed = false;
        int RotateCount = 0;

        protected override void Initialize()
        {
            base.Initialize();
        }
        public override void RotateCard()
        {
            base.RotateCard();
            RotateChangeNumber();
        }
        public virtual void RotateChangeNumber()
        {
            RotatedAngle += RotationSpeed;
            if (!Changed)
            {
                if (Mathf.Abs(RotatedAngle) > 90)
                {
                    Changed = true;
                    RotatedAngle = 0;
                    SetFrontNumber(Random.Range(0, 10).ToString());
                    SetBackNumber(Random.Range(0, 10).ToString());
                }
            }
            else
            {
                if (Mathf.Abs(RotatedAngle) > 180)
                {
                    RotatedAngle = 0;
                    SetFrontNumber(Random.Range(0, 10).ToString());
                    SetBackNumber(Random.Range(0, 10).ToString());
                }
            }
        }
        protected override void CardStateMachine()
        {
            switch (cardstate)
            {
                case CardState.wait:
                    SetRotateState();
                    break;
                case CardState.Rotate:
                    RotateCard();
                    if (++RotateCount >= 180 / Mathf.Abs(RotationSpeed))
                    {
                        cardstate = CardState.wait;
                        RotateCount = 0;
                    }
                    break;
            }
        }

        void SetRotateState()
        {
            if (RotateInterval < 1)
            {
                cardstate = CardState.Rotate;
                RotationSpeed = -20;
            }
            else
            {
                timeCount += Time.deltaTime;
                if (timeCount >= RotateInterval)
                {
                    timeCount = 0;
                    cardstate = CardState.Rotate;
                }
            }
        }

    }

    public class CardController_V3 : CardController_V2
    {

        int CardNum = 0;
        public override void RotateChangeNumber()
        {
            RotatedAngle += RotationSpeed;
            if (!Changed)
            {
                if (Mathf.Abs(RotatedAngle) > 90)
                {
                    Changed = true;
                    RotatedAngle = 0;
                    SetFrontNumber((++CardNum).ToString());
                    SetBackNumber(CardNum.ToString());
                }
            }
            else
            {
                if (Mathf.Abs(RotatedAngle) > 180)
                {
                    RotatedAngle = 0;
                    SetFrontNumber((++CardNum).ToString());
                    SetBackNumber(CardNum.ToString());
                }
            }
        }
    }
}

