using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableStack : Stack
{
    [SerializeField] private GameObject WalkableStackPrefab;
    private void OnTriggerEnter(Collider other)
    {
        var offset = new Vector3(0, 4.24f, 0);
        if (other.CompareTag(Const.PLAYER_TAG))
        {
            var walkableStack = Instantiate(WalkableStackPrefab,transform.position  ,Quaternion.identity, gameObject.transform.parent);
            walkableStack.GetComponentInChildren<Collider>().enabled = true;
            walkableStack.tag = Const.WALKABLE_STACK_TAG;
            Destroy(gameObject);
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        //
    }
}
