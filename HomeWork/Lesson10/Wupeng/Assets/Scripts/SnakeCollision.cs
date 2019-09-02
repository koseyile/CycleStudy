using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wupeng
{

public class SnakeCollision : MonoBehaviour
{
    private Snake snake;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            SnakeManager.Manager.EatFood(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
}