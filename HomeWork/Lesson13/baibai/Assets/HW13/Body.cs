using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBBB;
using System;

namespace BBBB {

    public abstract class BodyPart { }

    public class Head : BodyPart {
    }

    public class UpperBody : BodyPart
    {
    }

    public class LowerBody : BodyPart
    {
    }

    public class Body {
        public BodyPart head;
    }

    public class Outfit
    {
        public Clothing headwear;
        public Clothing top;
        public Clothing bottom;

        public Clothing GetWearing(BodyPart b) {
            if (b is Head)
            {
                return headwear;
            }
            else if (b is UpperBody)
            {
                return top;
            }
            else if (b is LowerBody)
            {
                return bottom;
            }
            else {

                Debug.Log("Bodypart is not found.");
                return null;
            }
        }

        public void Wear(Clothing cloth)
        {

            if (cloth.bodyPart == "Head")
            {

                headwear = cloth;
                Debug.Log(cloth + " is on the head.");
            }
            else {
                Debug.Log("No place to wear.");
            }
        }
    }
}