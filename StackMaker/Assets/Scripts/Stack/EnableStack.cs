using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableStack : Stack
{
    public GameObject Stack;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Const.PLAYER_TAG))
        {
            Destroy(Stack);
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Const.PLAYER_TAG))
        {
            gameObject.tag = Const.WALKABLE_STACK_TAG;
        }
    }
}
