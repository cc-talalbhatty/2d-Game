using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private string resourceName;
    // Start is called before the first frame update
    void Start()
    {
        if (resourceName !=" ") 
        {
            sprites=Resources.LoadAll<Sprite>(resourceName);
            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
