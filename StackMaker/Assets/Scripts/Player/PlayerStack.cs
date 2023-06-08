using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{
    public Animator anim;
    private string ACTION_ANIM = "Action";

    public GameObject standStackPrefabs;

    public Transform stackContainer;
    public Transform playerStack;

    public bool IsWin { get; set; }

    private Stack<GameObject> _Stack;

    private int animState = 0;

    private float stackHeight = 0.3f;

    #region Instance
    //private TreasureManager treasureManager;
    #endregion

    #region Singleton
    public static PlayerStack Ins;
    private void Awake()
    {
        Ins = this;
    }
    #endregion

    void Start()
    {
        //treasureManager = TreasureManager.Ins;

        _Stack = new Stack<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.ENABLE_STACK_TAG))
        {
            PushToStack();
            SetAnimState(1);
            Invoke(nameof(SetIdleAnim), 0.1f);
        }

        if (other.CompareTag(Const.UNENABLE_STACK_TAG))
        {
            PopFromStack(other.transform.position + Vector3.down * stackHeight);
        }

        if (other.CompareTag(Const.WIN_POS_TAG))
        {
            SetAnimState(2);
            IsWin = true;
            //treasureManager.WaitToOpenTreasure(1f);
        }
    }

    public void SetAnimState(int state)
    {
        animState = state;
        anim.SetInteger(ACTION_ANIM, animState);
    }

    public void SetIdleAnim()
    {
        SetAnimState(0);
    }


    private void PushToStack()
    {
        GameObject stack = Instantiate(standStackPrefabs, transform.position, Quaternion.identity, stackContainer);
        _Stack.Push(stack);

        stack.transform.localPosition = new Vector3(0, (_Stack.Count - 1) * stackHeight, 0);
        playerStack.localPosition = new Vector3(0, _Stack.Count * stackHeight, 0);
    }

    private void PopFromStack(Vector3 popedPosition)
    {
        GameObject stack = _Stack.Pop();
        stack.transform.parent = null;
        stack.transform.position = popedPosition + Vector3.up * 0.1f;
        stack.tag = Const.WALKABLE_STACK_TAG;
        playerStack.localPosition = new Vector3(0, _Stack.Count * stackHeight, 0);
    }


}
