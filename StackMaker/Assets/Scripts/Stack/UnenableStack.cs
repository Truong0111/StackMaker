using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnenableStack : Stack
{
    public override void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(Const.PLAYER_TAG))
        {
            gameObject.tag = Const.WALKABLE_STACK_TAG;
        }
    }
}
