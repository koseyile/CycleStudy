using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wupeng
{
    
public enum FRUITKIND
{
    Watermelon,
    Peach,
    Apple,
    Mango,
    Strawberry,

    Unknow
}

public class Fruit
{
    private string name;
    private Vector3 position;
    private GameObject ob;

    public Fruit(string _name, GameObject _prefab, Vector3 _position)
    {
        this.name = _name;
        ob = GameObject.Instantiate(_prefab, _position, Quaternion.identity);
        ob.name = _name;
        ob.tag = "food";
    }

    public void Destroy()
    {
        GameObject.Destroy(ob);
    }
}

}