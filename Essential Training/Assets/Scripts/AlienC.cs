using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienC : MonoBehaviour
{
    public Animator animator;
    public float attackDelay = 3f;
    public GameObject projectile;
    private GameObject instantiatedProjectile;
    private List<GameObject> instantiatedProjectiles = new List<GameObject>();

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
    void shootProjectile()
    {
       instantiatedProjectile=Instantiate(projectile, transform.position, Quaternion.identity);
       instantiatedProjectiles.Add(instantiatedProjectile);
       Invoke("DestroyProjectile", 3f);
    }
    void DestroyProjectile()
    {
        if (instantiatedProjectiles.Count > 0)
        {
            GameObject projectileToDestroy = instantiatedProjectiles[0];
            if (projectileToDestroy != null)
            {
                Destroy(projectileToDestroy);
            }
            instantiatedProjectiles.RemoveAt(0);
        }
    }

}
