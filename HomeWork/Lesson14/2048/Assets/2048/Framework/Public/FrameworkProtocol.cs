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
    }

    public struct NumberIndex
    {
        public int x;
        public int y;

        public NumberIndex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public interface INumberObject : IRenderBase //wup
    {
        void SetPosition(NumberIndex pos);
        void Move(NumberIndex des);
        void SetNumber(int number);
        int GetNumber();
        void SetColor(Color color);
        NumberIndex GetPos();
    }



    //==========================================================Render protocol end
}
