using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBBB;

namespace BBBB {

    public class Animal {
        public float runSpeed;
        public string favoriteFood;

    }

    public class Bird : Animal {
        public string wingColor;
        public float flySpeed;

        public Bird(float s, string col, string f)
        {
            flySpeed = s;
            wingColor = col;
            favoriteFood = f;
        }
    }

    public class Seagull : Bird {
        public Seagull(float s, string col, string f): base(s,col,f)
        {
            flySpeed = s;
            wingColor = col;
            favoriteFood = f;
        }
    }

    public class Petrel : Bird {
        public Petrel(float s, string col, string f) : base(s, col, f)
        {
            flySpeed = s;
            wingColor = col;
            favoriteFood = f;
        }
    }

    public class Ostrich : Animal {
        public string wingColor;

        public Ostrich(float s, string col, string f)
        {
            runSpeed = s;
            wingColor = col;
            favoriteFood = f;
        }

    }

}

