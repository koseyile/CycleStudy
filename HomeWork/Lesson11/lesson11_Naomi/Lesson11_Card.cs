using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Naomi
{
    public class CardA
    {
        public GameObject CardPrefab;
        public TextMesh CardText;
        private float RotateSpeed;
        private float RotateTimer;//旋转间隔时间
        private Vector3 CardAxisX;//旋转方向
        private Quaternion CardQuaternion;//初始朝向

        private CardA SideB;

        public enum RotateState
        {
            Rotate, Pause
        }
        public RotateState CardState;

        public CardA(GameObject _cardprefab, Vector3 _pos, Quaternion _CardQuaternion)
        {
            RotateSpeed = 60.0f;
            RotateTimer = 2.0f;
            CardAxisX = new Vector3(-1, 0, 0);
            CardPrefab = GameObject.Instantiate(_cardprefab, _pos, _CardQuaternion);
            CardQuaternion = _CardQuaternion;
            CardState = RotateState.Pause;
        }

        public void Rotate(float _angle)
        {
            if (CardPrefab)
            {
                CardPrefab.transform.Rotate(CardAxisX, _angle);
                CardState = RotateState.Rotate;
            }
        }

        public void Update()
        {
            switch(CardState)
            {
                case RotateState.Pause:
                    {
                        
                    }
                    break;
                case RotateState.Rotate:
                    {
                        RotateTimer -= Time.deltaTime;
                        Rotate(RotateSpeed * Time.deltaTime);
                        if (RotateTimer < 0f)
                        {
                            RotateTimer = 0;
                            CardPrefab.transform.rotation = Quaternion.identity;
                            CardState = RotateState.Pause;
                        }
                    }break;
            }
        }

        public void GrowSideB()
        {
            if(this.SideB == null)
            {
                this.SideB = new CardA(CardPrefab, CardPrefab.transform.position, Quaternion.Euler(-90, 0, 0));
            }
            else
            {
                return;
            }
        }
    }

    public class Lesson11_Card : MonoBehaviour
    {
        public GameObject cardPrefab;

        private CardA cardA;
        // Start is called before the first frame update

        public void Click()
        {
            cardA.CardState= CardA.RotateState.Rotate;
        }

        void Start()
        {
            cardA = new CardA(cardPrefab, new Vector3(778, 470, 0), Quaternion.Euler(90, 0, 0));
            cardA.GrowSideB();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}
