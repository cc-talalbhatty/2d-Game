using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public DoorTrigger[] doorTriggers;
    private Animator animator;
    //public bool down;
    //public bool sticky;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetInteger("AnimState", 1);
        //down = true;

        foreach (DoorTrigger trigger in doorTriggers) 
        {
            if (trigger!=null)
            {
                trigger.toggle(true);
            }

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (sticky && down)
        //    return;

        animator.SetInteger("AnimState", 2);
        
        foreach (DoorTrigger trigger in doorTriggers)
        {
            if (trigger != null)
            {
                trigger.toggle(false);
            }

        }

    }

}
