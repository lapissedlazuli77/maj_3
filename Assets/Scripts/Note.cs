using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public Sprite note1;
    public Sprite note2;

    public SpriteRenderer srend;

    public string typing;

    // Start is called before the first frame update
    void Start()
    {
        srend = GetComponent<SpriteRenderer>();

        int whichnote = Random.Range(1, 3);
        if (whichnote == 2) { srend.sprite = note2; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
