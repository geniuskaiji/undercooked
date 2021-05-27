using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{

    public Animator animator;
    public BoxCollider2D collider;
    private int stage = 0;
    private bool debounce = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (stage == 0 & debounce == false)
        {
            StartCoroutine(stageZero());
        }
        if (stage == 1 & debounce == false)
        {
            StartCoroutine(stageOne());
        }
        if (stage == 2 & debounce == false)
        {
            StartCoroutine(stageTwo());
        }
        IEnumerator stageZero()
        {
            animator.SetTrigger("open");
            yield return new WaitForSeconds(1);
            stage = 1;
        }
        IEnumerator stageOne()
        {
            animator.SetTrigger("spill");
            yield return new WaitForSeconds(1);
            stage = 2;
        }
        IEnumerator stageTwo()
        {
            animator.SetTrigger("clean");
            yield return new WaitForSeconds(1);
            stage = 0;
        }
    }
}
