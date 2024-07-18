using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public const int idle = 0;
    public const int opening = 1;
    public const int open = 2;
    public const int closing = 3;
    
    private int state= idle;
    private Animator animator;
    [SerializeField]
    private int closeDelay;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void onOpenstar()
   {
        state = opening;
   }

    public void onOpenEnd()
    {
        state = open;
    }
    
    public void onCloseStart()
    {
        state = closing;
    }

    public void onCloseEnd()
    {
        state = idle;
    }

    public void Open()
    {
        animator.SetInteger("AnimState",1);
    }

    public void Close()
    {
        StartCoroutine(closeNow());

    }
    private IEnumerator closeNow()
    {
        yield return new WaitForSeconds(closeDelay);
        animator.SetInteger("AnimState", 2);
    }
}
