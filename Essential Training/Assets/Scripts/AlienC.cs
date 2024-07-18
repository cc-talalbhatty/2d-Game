using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienC : MonoBehaviour
{
    public Animator animator;
    public float attackDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackDelay);
            animator.SetTrigger("Attack");
        }
    }
}
