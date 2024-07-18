using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Animator animator;

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
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetInteger("AnimState", 2);
            
    }

}
