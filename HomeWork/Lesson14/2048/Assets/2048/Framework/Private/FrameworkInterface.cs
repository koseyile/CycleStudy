using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2048Framework
{
    public interface IModule
    {
        void ModuleInit();
        void ModuleDestroy();
        void ModuleUpdate();
    }

    public interface IGameInput : IModule
    {
        InputProtocol GetInputData();
    }

    public interface IGameCore : IModule
    {

    }

    public interface IRenderBase
    {
    }

    public interface IGameRender : IModule
    {
        //创建渲染对象
        IRenderBase CreateObject(RenderProtocol renderProtocol);

        //销毁渲染对象
        void DestroyObject(IRenderBase iRenderBase);
    }
}