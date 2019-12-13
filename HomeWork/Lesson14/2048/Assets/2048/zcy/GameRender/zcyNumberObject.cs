using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;
using TMPro;

namespace ZCY
{
    public class zcyNumberObject : INumberObject
    {
        private static GameObject numberGameObjPrefab;
        private GameObject numberGameObject;

        public zcyNumberObject()
        {
            if (numberGameObjPrefab == null)
            {
                numberGameObjPrefab = Resources.Load<GameObject>("CubeNumber");
            }
            numberGameObject = GameObject.Instantiate(numberGameObjPrefab);
        }

        public Vector2 GetCurrentPos()
        {
            throw new System.NotImplementedException();
        }

        public int GetNumber()
        {
            throw new System.NotImplementedException();
        }

        public void SetColor(Color color)
        {

        }

        public void SetNumber(int number)
        {
            numberGameObject.GetComponentInChildren<TextMeshPro>().SetText(number.ToString());
        }

        public void SetPosition(Vector3 pos)
        {
            numberGameObject.transform.position = pos;
        }

        public void SetPosition(Vector2 index)
        {

        }

        public void SetText(string text)
        {
            //set text
        }

        public void SetText(int number)
        {
            throw new System.NotImplementedException();
        }
        public void SetIndex(Vector2 index) { }
        public Vector2 GetIndex() { return new Vector2(); }

        public void SetLastIndex(Vector2 index)
        {
            throw new System.NotImplementedException();
        }

        public Vector2 GetLastIndex()
        {
            throw new System.NotImplementedException();
        }
    }
}
