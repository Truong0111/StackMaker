using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{
    public Animator anim;
    
    public GameObject standStackPrefabs;

    public Transform stackContainer;
    public Transform playerStack;

    public bool IsWin { get; set; }

    private Stack<GameObject> _Stack;

    private float stackHeight = 0.3f;

    #region Singleton
    public static PlayerStack Ins;
    private void Awake()
    {
        Ins = this;
    }
    #endregion

    void Start()
    {
        _Stack = new Stack<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.WIN_POS_TAG))
        {
            IsWin = true;
            RunAnim(true);
            SfxController.Ins.PlayLevelCompleteSfx();
            TreasureManager.Ins.OpenTreasure();
            SfxController.Ins.PlayOpenChestSfx();
        }
        if (other.CompareTag(Const.ENABLE_STACK_TAG))
        {
            SfxController.Ins.PlayPushStackSfx();
            PushToStack();
        }
        if (other.CompareTag(Const.UNENABLE_STACK_TAG))
        {
            SfxController.Ins.PlayPopStackSfx();
            PopFromStack(other.transform.position + Vector3.down * stackHeight);
        }
    }

    public void RunAnim(bool isWin)
    {
        anim.SetBool("isWin", isWin);
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
