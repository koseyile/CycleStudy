using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zzlesson13
{
    public class zzlesson13Q6 : MonoBehaviour
    {

        public class Director
        {
            public string name;
            public Video video;
            public Developer developer;
            public void Direct(Video video)
            {
                
            }
        }

        public class Developer
        {
            public string name;
            public Video video;

            public void Create()
            {
                
            }

        }

        public class Video
        {
            public string script;
            public string character;
            public string scene;
            public string animation;
            public string music;
            public string VO;
        }

        public class Audience
        {
            public string name;
            public void WatchingVideo()
            {

            }
        }


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

