using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : SnakeNode
{
       /*
    问题 1 : 是把脚本 挂在预制体上，还是把 要被渲染的GameObject 放在脚本里， 这个该一般来说怎么设计？  
    
    问题 2 : 碰撞检测 都需要 继承 MonoBehaviour, 如果我是在脚本里 实例化 物体 到场景中，是不是应该在脚本里 将继承 MonoBehaviour 的对象添加到物体上？

    问题 3 : 我用了 SnakeManager 的 静态单例来 管理 一条小蛇，是因为我需要在碰撞检测的时候 通过 静态单例 来调用小蛇中的方法。不知道这种做法是否合适？我不知道如何在碰撞检测的时候 不用静态变量访问的小蛇

         */

    private bool active;
    private Control controller;

    private GameObject preFab;

    private Vector3 direction;
    private Vector3 dest;
    private float moveSpan;
    private float moveWait;
    private float timer;
    private float scale;

    public SnakeNode bodyBegain;
    public SnakeNode tail;

    private int  effectbodyNum;
    private bool isEatApple;

    //三节身体小蛇
    public Snake(GameObject _prefab, Vector3 _pos, 
         Vector3 _dir, float _moveSpan, float _moveWait, float _scale, Control _controller) : base(_prefab, _pos, null, null)
    {
        active = false;
        controller = _controller;
        preFab = _prefab;

        this.direction = _dir;
        this.moveSpan = _moveSpan;
        this.moveWait = _moveWait;
        this.dest = direction * moveSpan + Position;
        this.timer = _moveWait;
        this.scale = _scale;

        this.Ob.name = "head";
        this.SetColor(new Color(0.3f, 0.1f, 0.1f));

        bodyBegain = new SnakeNode(_prefab, this.Position - this.Ob.transform.forward * _scale, this, null);
        bodyBegain.SetColor(Color.gray);
        bodyBegain.Ob.name = "bodybegain";

        tail = new SnakeNode(_prefab, bodyBegain.Ob.transform.position  - bodyBegain.Ob.transform.forward * _scale, bodyBegain, null);
        tail.Ob.name = "tail";
        tail.SetColor(new Color(0.3f, 0.0f, 0.3f));

        this.SetNext(bodyBegain);
        bodyBegain.SetNext(tail);

        //Component
        Ob.AddComponent<SnakeCollision>();

        //Bodynum & Effected
        effectbodyNum = 0;
    }

    //更新运动
    public void UpdateMove()
    {
        UpdateController();

        if (active)
        {
            moveWait -= Time.deltaTime;

            if (moveWait < 0.0f)
            {
                moveWait = timer;
                //更新目的地
                dest = this.Position + direction * moveSpan;

                MoveBody(this);

            }
        }
    }

    public void Win()
    {
        if (effectbodyNum >= 7)
        {
            Debug.Log("小蛇变成了七彩艾希，像彩虹一般出现在Hank眼前");
            controller.SetActiveState(false);

            SnakeNode current = this;

            while (current != null)
            {
                GameObject.Destroy(current.Ob);
                current = current.Next;
            }
        }
    }

    //在尾部位置添加，并将尾部后移
    public void AddBody(FRUITKIND fruitKind)
    {
        switch (fruitKind)
        {
            case FRUITKIND.Apple:

                isEatApple = true;
                effectbodyNum += 1;

                SnakeNode newTail = new SnakeNode(preFab, tail.Position, tail.Previous, tail);
                tail.Previous.SetNext(newTail);
                tail.SetPrevious(newTail);
                newTail.SetEffect(1.0f);

                tail.MoveTo(tail.Position - tail.Ob.transform.forward * scale);
                tail.SetPosInfo();
                break;
            case FRUITKIND.Mango:
                SnakeNode newTail2 = new SnakeNode(preFab, tail.Position, tail.Previous, tail);
                tail.Previous.SetNext(newTail2);
                tail.SetPrevious(newTail2);
                if (isEatApple)
                {
                    newTail2.SetEffect(1.0f);
                    effectbodyNum += 1;
                }
                else
                {
                    newTail2.SetColor(new Color(0.77f, 0.46f, 0.03f));
                }

                tail.MoveTo(tail.Position - tail.Ob.transform.forward * scale);
                tail.SetPosInfo();
                break;
            case FRUITKIND.Peach:
                SnakeNode newTail3 = new SnakeNode(preFab, tail.Position, tail.Previous, tail);
                tail.Previous.SetNext(newTail3);
                tail.SetPrevious(newTail3);

                if (isEatApple)
                {
                    newTail3.SetEffect(1.0f);
                    effectbodyNum += 1;
                }
                else
                {
                    newTail3.SetColor(new Color(0.89f, 0.51f, 0.63f));
                }

                tail.MoveTo(tail.Position - tail.Ob.transform.forward * scale);
                tail.SetPosInfo();

                break;
            case FRUITKIND.Strawberry:
                SnakeNode newTail4 = new SnakeNode(preFab, tail.Position, tail.Previous, tail);
                tail.Previous.SetNext(newTail4);
                tail.SetPrevious(newTail4);
                if (isEatApple)
                {
                    newTail4.SetEffect(1.0f);
                    effectbodyNum += 1;
                }
                else
                {
                    newTail4.SetColor(new Color(80, 0.0f, 0.23f));
                }

                tail.MoveTo(tail.Position - tail.Ob.transform.forward * scale);
                tail.SetPosInfo();
                break;
            case FRUITKIND.Watermelon:
                SnakeNode newTail5 = new SnakeNode(preFab, tail.Position, tail.Previous, tail);
                tail.Previous.SetNext(newTail5);
                tail.SetPrevious(newTail5);
                if (isEatApple)
                {
                    newTail5.SetEffect(1.0f);
                    effectbodyNum += 1;
                }
                else
                {
                    newTail5.SetColor(new Color(0.06f, 0.42f, 0.23f));
                }

                tail.MoveTo(tail.Position - tail.Ob.transform.forward * scale);
                tail.SetPosInfo();
                break;

            default:
                break;
        }

        Win();
    }

    //控制移动相关
    public void UpdateController()
    {
        controller.Update();
        SetActive(controller.GetActiveState());
        ChangeDirection(controller.GetDirection());
    }


    public void ChangeDirection(Vector3 _dir)
    {
        if (this.direction == -_dir)
        {
            return;
        }
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
            this.tail.SetPosInfo();
        }
        else
        {
            node.MoveTo(dest);
        }
        
        MoveBody(node.Next);
    }


    //状态
    public void SetActive(bool _state)
    {
        this.active = _state;
    }

    public bool IsActive()
    {
        return this.active;
    }

}
