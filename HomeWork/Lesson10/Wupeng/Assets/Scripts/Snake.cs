using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : SnakeNode
{
    //问题： 类内部自己的方法内部，修改该对象的属性时，它是怎么访问数据的。访问外部数据时（比如一个静态类的变量），又是怎么样访问的？
    //问题： 为了时时移动到一个新位置，我一开始在更新函数里时时实例化新的位置变量，然后将物体位置添加这个位置变量。
    //       我觉得每一帧实例化位置变量会有问题的吧，然后我就在初始化的时候创建这个变量，更新函数只是修改这个变量，不知道这个做法是不是正确的？？
    //问题： 是把脚本挂在预制体上，还是把预制体放在脚本里？？（我觉得后一种方法比较容易递归，不知道是不是这样）

    private bool active;
    private Control controller;
    private bool canBeControl;

    private Vector3 direction;
    private Vector3 dest;
    private float moveSpan;
    private float moveWait;
    private float timer;
    private float scale;

    public SnakeNode bodyBegain;
    public SnakeNode tail;

    //三节身体小蛇
    public Snake(GameObject _prefab, Vector3 _pos, 
         Vector3 _dir, float _moveSpan, float _moveWait, float _scale, Control _controller) : base(_prefab, _pos, null, null)
    {
        active = false;
        canBeControl = false;
        controller = _controller;

        this.direction = _dir;
        this.moveSpan = _moveSpan;
        this.moveWait = _moveWait;
        this.dest = direction * moveSpan + Position;
        this.timer = _moveWait;
        this.scale = _scale;

        this.Ob.name = "head";
        this.SetColor(Color.red);

        bodyBegain = new SnakeNode(_prefab, this.Position - this.Ob.transform.forward * _scale, this, null);
        bodyBegain.SetColor(Color.gray);
        bodyBegain.Ob.name = "bodybegain";

        tail = new SnakeNode(_prefab, bodyBegain.Ob.transform.position  - bodyBegain.Ob.transform.forward * _scale, bodyBegain, null);
        tail.Ob.name = "tail";
        tail.SetColor(Color.blue);

        this.SetNext(bodyBegain);
        bodyBegain.SetNext(tail);
    }

    //更新运动
    public void UpdateMove(Control controler)
    {
        if (active)
        {
            moveWait -= Time.deltaTime;

            if (canBeControl)
            {
                controler.Update();

            }

            if (moveWait < 0.0f)
            {
                moveWait = timer;
                //更新目的地
                dest = this.Position + direction * moveSpan;

                MoveBody(this);
                canBeControl = true;
            }
        }
    }


    //在尾部位置添加，并将尾部后移
    public void AddBody(GameObject _body)
    {

    }

    //移动相关
    public void ChangeDirection(Vector3 _dir)
    {
        this.direction = _dir;
    }

    public void ChangeSpeed(float _wait)
    {
        this.moveWait = _wait;
    }

    public void ChangeSpan(float _span)
    {
        this.moveSpan = _span;
    }

    /*移动完子节点位置后，才更新自己*/
    public void MoveBody(SnakeNode node)
    {
        if (node == null)
        {
            return;
        }
        
        if (node.Previous != null)
        {
            node.MoveTo(node.Previous.Position);
            node.Previous.SetPosInfo();
        }
        else
        {
            node.MoveTo(dest);
        }
        
        MoveBody(node.Next);
    }


    //状态
    public void Act(bool _state)
    {
        this.active = _state;
    }

    public bool IsActive()
    {
        return this.active;
    }

}
