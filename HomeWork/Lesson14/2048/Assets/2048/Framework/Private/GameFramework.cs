using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2048Framework
{
    public class GameFramework
    {
        public static GameFramework singleton = new GameFramework();
        
        private IGameInput theInput;
        private IGameCore theGameCore;
        private IGameRender theGameRender;
        private GameFramework()
        {
        }

        public void Init(IGameInput iInput, IGameCore iGameCore, IGameRender iGameRender)
        {
            theInput = iInput;
            theGameCore = iGameCore;
            theGameRender = iGameRender;

            theInput.ModuleInit();
            theGameCore.ModuleInit();
            theGameRender.ModuleInit();
        }

        public void Destroy()
        {
            theInput.ModuleDestroy();
            theGameCore.ModuleDestroy();
            theGameRender.ModuleDestroy();
        }

        public void setInput(IGameInput iInput)
        {
            theInput = iInput;
        }

        public IGameInput getInput()
        {
            return theInput;
        }

        public void setGameCore(IGameCore iGameCore)
        {
            theGameCore = iGameCore;
        }

        public IGameCore getGameCore()
        {
            return theGameCore;
        }

        public void setGameRender(IGameRender iGameRender)
        {
            theGameRender = iGameRender;
        }

        public IGameRender getGameRender()
        {
            return theGameRender;
        }

        public void Update()
        {
            theInput.ModuleUpdate();
            theGameCore.ModuleUpdate();
            theGameRender.ModuleUpdate();
        }
    }

}

