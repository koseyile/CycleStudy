using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBBB;

namespace BBBB {

    public class Product {
        public string name;
        public string[] parts;
    }

    public class Episode : Product {

        public Episode(string n, int p) {
            name = n;
            parts = new string[p];
        }
    }
}

