using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{
    public Animator anim;
    public GameObject standStackPrefabs;
    public Transform stackContainer;
    public Transform playerStack;
    public bool IsWin { get; private set; }
    private Stack<GameObject> _stack;
    private const float StackHeight = 0.3f;
    private static readonly int Win = Animator.StringToHash("isWin");
    
    #region Singleton
    public static PlayerStack Ins;
    private void Awake()
    {
        Ins = this;
        IsWin = false;
    }
    #endregion

    private void Start()
    {
        _stack = new Stack<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.WIN_POS_TAG))
        {
            IsWin = true;
            Pref.Coin += 50;
            RunAnim(true);
            SfxController.Ins.PlaySfx(SfxType.LevelComplete);
            TreasureManager.Ins.OpenTreasure();
            SfxController.Ins.PlaySfx(SfxType.OpenChest);
        }
        else if (other.CompareTag(Const.ENABLE_STACK_TAG))
        {
            SfxController.Ins.PlaySfx(SfxType.PushStack);
            PushToStack();
        }
        else if (other.CompareTag(Const.UNENABLE_STACK_TAG))
        {
            SfxController.Ins.PlaySfx(SfxType.PopStack);
            PopFromStack(other.transform.position + Vector3.down * StackHeight);
        }
    }

    private void RunAnim(bool isWin)
    {
        anim.SetBool(Win, isWin);
    }

    private void PushToStack()
    {
        var stack = Instantiate(standStackPrefabs, stackContainer.position, Quaternion.identity, stackContainer);
        _stack.Push(stack);

        stack.transform.localPosition = new Vector3(0, (_stack.Count - 1) * StackHeight, 0);
        playerStack.localPosition = new Vector3(0, _stack.Count * StackHeight, 0);
    }

    private void PopFromStack(Vector3 poppedPosition )
    {
        var stack = _stack.Pop();
        stack.transform.parent = GameObject.FindGameObjectWithTag("Level").transform;
        stack.transform.position = poppedPosition  + Vector3.up * 0.1f;
        stack.tag = Const.WALKABLE_STACK_TAG;
        playerStack.localPosition = new Vector3(0, _stack.Count * StackHeight, 0);
    }


}
