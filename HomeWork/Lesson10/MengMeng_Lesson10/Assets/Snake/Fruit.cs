using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace MengMeng
{
    //[ScriptableObject]
    public class Fruit : ScriptableObject
    {
        public string Name;
        private string colorname;
        private Vector3 pos;
        private GameObject FruitObj;

        public Fruit(string _name, string _colorname, Vector3 _pos, GameObject _Object)
        {
            Name = _name;
            colorname = _colorname;
            pos = _pos;
            FruitObj = GameObject.Instantiate(_Object, _pos, Quaternion.identity);
            MeshRenderer renderer = FruitObj.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                switch (colorname)
                {
                    case "colorful":
                        renderer.sharedMaterial.color = new Color32(214, 213, 27, 1);
                        break;
                    case "red":
                        renderer.sharedMaterial.color = new Color(0.5f, 0, 0);
                        break;
                    case "yellow":
                        renderer.sharedMaterial.color = new Color(0.5f, 0, 0.5f);
                        break;
                    case "green":
                        renderer.sharedMaterial.color = new Color(0, 0, 0.5f);
                        break;
                    case "pink":
                        renderer.sharedMaterial.color = new Color32(214, 21, 179,1);
                        break;
                    default:
                        renderer.sharedMaterial.color = Color.gray;
                        break;

                }
            }
        }

        public void DestroyFruit()
        {
            Destroy(FruitObj);
        }
    }
}
