using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animStateController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private int isWinHash;
    private void Start()
    {
        init();
    }
    private void init()
    {
        animator = GetComponent<Animator>();
        isWinHash = Animator.StringToHash("isWin");
    }

    private void Update()
    {
        bool isWin = animator.GetBool(isWinHash);
        if(isWin)
        {
            animator.SetBool(isWinHash, true);
        }
    }
}
