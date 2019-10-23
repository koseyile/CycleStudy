using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBBB;

namespace BBBB {

    public class Director {
        public string name;
        public Product proj;
        public bool projDone;
        public Developer[] developers;

        public Director(string n, Product p) {
            name = n;
            proj = p;
        }

        public Product ConstructProduct() {

            Product newP = new Product();
            developers = new Developer[proj.parts.Length];
            SetDevelopers();

            Debug.Log(proj.name + " is completed.");
            return newP;
        }


        public void SetDevelopers() {
            for (int i = 0; i < developers.Length; i++) {
                developers[i] = new Developer(proj);
                developers[i].partAssinged = proj.parts[i];
                developers[i].BuildP();
            }
        }

        public void Deliver(Product p, Client c) {
            Debug.Log(name + " is proposing " + proj.name + " to the client.");
            c.Accept(p);
        }
    }


    public class Developer {
        public string name;
        public Product workOn;
        public string partAssinged;

        public Developer(Product p) {
            workOn = p;
        }

        public void BuildP() {
            Debug.Log("Working on " + partAssinged);
            Debug.Log(partAssinged + " is done.");
        }
    }

    public class Client {
        public Product productDemand;

        public void Order(Product p) {
            Debug.Log("Client want a product: " + p.name );
        }

        public void Accept(Product p) {

            Debug.Log(p.name + " is accepted by the client.");
        }
    }

}