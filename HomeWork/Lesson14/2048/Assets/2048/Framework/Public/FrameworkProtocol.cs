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
        Click,    //mengmeng:当玩家触发点击事件时，IGameInput.GetInputData必须返回此值
    }
    //------------------------------------------------------------Input protocol end



    //------------------------------------------------------------Render protocol begin
    public enum RenderProtocol
    {
        //--------------------------------------------------------游戏显示元素对象 begin
        None,
        CreateNumberObject,      //zcy:当传入此参数至IGameRender.CreateObject时，必须返回INumberObject
        CreateCheckBoardObject,  //wup:当传入此参数至IGameRender.CreateObject时，必须返回ICheckBoardObject,表示创建一个棋盘对象
        CreateUIObject,          //wup:当传入此参数至IGameObject.CreateObject时，必须返回IUIObject,表示创建一个UI
        //--------------------------------------------------------游戏显示元素对象 end
    }




    public interface INumberObject : IRenderBase //create by zcy
    {
        void SetPosition(Vector3 pos);
        void SetText(string text);
        void SetColor(Color color);
    }

    //wup: GameRender模块在接受RenderProtocol中的CreateCheckObject时，会创建一个ICheckBoardObject对象
    public interface ICheckBoardObject : IRenderBase  
    {
        void SetPos(Vector3 pos);
        void SetColor(Color color);
        void SetScale(Vector3 scale);
    }

    public interface IUIObject : IRenderBase
    {
        void SetPos(Vector3 pos);
        void SetText(string text);
    }



    //------------------------------------------------------------Render protocol end
}
