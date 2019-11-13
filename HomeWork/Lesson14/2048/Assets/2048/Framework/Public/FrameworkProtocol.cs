using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game2048Framework
{
    //------------------------------------------------------------Input protocol begin
    public enum InputProtocol
    {
        None,
        MoveRight,   //zcy:当玩家触发键盘右键抬起事件时，IGameInput.GetInputData必须返回此值
        MoveLeft,   //mengmeng:当玩家触发键盘左键抬起事件时，IGameInput.GetInputData必须返回此值
        MoveUp,   //mengmeng:当玩家触发键盘上键抬起事件时，IGameInput.GetInputData必须返回此值
        MoveDown,   //mengmeng:当玩家触发键盘下键抬起事件时，IGameInput.GetInputData必须返回此值
        Click,    //mengmeng:当玩家触发鼠标左键抬起事件时，IGameInput.GetInputData必须返回此值
    }
    //------------------------------------------------------------Input protocol end



    //------------------------------------------------------------Render protocol begin
    public enum RenderProtocol
    {
        //--------------------------------------------------------游戏显示元素对象 begin
        None,
        CreateNumberObject,      //zcy:当传入此参数至IGameRender.CreateObject时，需创建一个INumberObject
        CreateBackImgObject,     //wup:当传入此参数至IGameRender.CreateObject时，
        CreateCheckBoardObject,  //wup:当传入此参数至IGameRender.CreateObject时，需创建一个ICheckBoardObject
        CreateUIObject,          //wup:当传入此参数至IGameObject.CreateObject时，需创建一个IUIObject,表示创建一个UI
        CreateButtonObject,      //wup:当传入此参数至IGameObject.CreateObject时，需创建一个
        //--------------------------------------------------------游戏显示元素对象 end
    }

    public struct NumberIndex           //mengm:数字所在格子的位置，我们约定左下角是[0,0]，右上角是[4,4]
    {
        public int x;
        public int y;
        public NumberIndex(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }

    public interface INumberObject : IRenderBase
    {

        void SetNumberIndex(NumberIndex index);   //mengm: 设置数字所在格子的位置
        void SetText(int number);
        void SetColor(Color color);

        NumberIndex GetNumberIndex();               //mengm: 获取数字所在格子的位置
        int GetNumber();
        void MoveToIndex(NumberIndex NumIndex);     //mengm: 把一个数字移动到某一个格子
    }

    public interface IBackImgObject : IRenderBase
    {
        void SetScore(); //设置显示分数
        void SetHighScore(); //设置最高分数
    }

    public interface ICheckBoardObject : IRenderBase
    {
        void SetPos(Vector2 pos);
        void SetColor(Color color);
        void SetScale(Vector2 scale);
    }

    public interface IUIObject : IRenderBase
    {
        void SetPos(Vector2 pos);
        void SetText(string text);
    }

    public interface IButtonObject : IRenderBase
    {
        void SetPos(Vector2 pos);
        void SetText(string text);
        void SetColor(Color color);
    }
    //------------------------------------------------------------Render protocol end
}
