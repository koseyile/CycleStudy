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
        IRenderBase CreateObject(RenderProtocol renderProtocol);
        void DestroyObject(IRenderBase iRenderBase);
    }
}