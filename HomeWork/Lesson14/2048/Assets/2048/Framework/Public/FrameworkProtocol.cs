using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game2048Framework
{
    //============================================================Input protocol begin
    public enum InputProtocol
    {
        None,
        MoveRight,   //zcy:当玩家触发键盘右键抬起事件时，IGameInput.GetInputData必须返回此值
        MoveLeft,    //mengmeng:当玩家触发键盘左键抬起事件时，IGameInput.GetInputData必须返回此值
        MoveUp,      //mengmeng:当玩家触发键盘上键抬起事件时，IGameInput.GetInputData必须返回此值
        MoveDown,    //mengmeng:当玩家触发键盘下键抬起事件时，IGameInput.GetInputData必须返回此值
        Click,       //mengmeng:当玩家触发点击事件时，IGameInput.GetInputData必须返回此值
    }
    //============================================================Input protocol end


    //===========================================================Render protocol begin
    public enum RenderProtocol
    {
        //-------------------------------------------------------游戏显示元素对象 begin
        None,
        CreateNumberObject,      //zcy:当传入此参数至IGameRender.CreateObject时，必须返回INumberObject
        //-------------------------------------------------------游戏显示元素对象 end

        //-------------------------------------------------------游戏格式
        X44,
        X66,
        //-------------------------------------------------------游戏格式结束
    }

    public interface INumberObject : IRenderBase //wup：InumberObject 对象接口
    {
        void SetPosition(Vector2 index);         //wup: 设置位置
        Vector2 GetCurrentPos();                 //wup: 获取Number位置
        void SetLastIndex(Vector2 index);        //wup: 设置上一个索引
        Vector2 GetLastIndex();                  //wup: 获取上一个索引

        void SetNumber(int number);              //wup: 设置Number数字
        int GetNumber();                         //wup: 获取Number数字
        void SetColor(Color color);              //wup: 设置Number颜色 

        void SetDestNum(int num);

        int GetDestNum();

        //void SetTargetIndex(Vector2 index);      //mengm：设置Number接下来要移动到的目标位置索引 （这个接口有需要的同学实现就好）
        //Vector2 GetTargetIndex();                //mengm:获取Number接下来要移动到的目标位置索引
        void SetIndex(Vector2 index);              //mengm: 设置位置索引
        Vector2 GetIndex();                        //mengm:获取位置索引
    }
    //==========================================================Render protocol end
}
