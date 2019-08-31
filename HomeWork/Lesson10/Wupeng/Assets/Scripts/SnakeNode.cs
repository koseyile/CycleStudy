using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNode
{
    private GameObject ob;

    private Vector3 position;

    private SnakeNode previous;

    private SnakeNode next;

    public GameObject Ob
    {
        get { return this.ob; }
    }

    public Vector3 Position
    {
        get { return this.position; }
    }

    public SnakeNode Previous
    {
        get { return this.previous; }
    }

    public SnakeNode Next
    {
        get { return this.next; }
    }

    public SnakeNode(GameObject _prefab, Vector3 _pos, SnakeNode _pre, SnakeNode _next)
    {
        this.position = _pos;
        this.previous = _pre;
        this.next = _next;

        ob = GameObject.Instantiate(_prefab, this.position, Quaternion.identity);
        ob.transform.GetComponent<Renderer>().material.SetFloat("_Effect", 0.0f);
    }


    //移动和更新位置信息分开，为了让下一个节点可以访问
    public void MoveTo(Vector3 _dest)
    {
        ob.transform.position = _dest;
    }

    public void SetPosInfo()
    {
        this.position = this.Ob.transform.position;
    }

    public void SetNext(SnakeNode _next)
    {
        this.next = _next;
    }

    //表现
    public void SetColor(Color _color)
    {
        ob.transform.GetComponent<Renderer>().material.SetColor("_Color", _color);
    }
}
