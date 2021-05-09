using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyControler : MonoBehaviour
{
    public Animator animator;
    public UnityEngine.AI.NavMeshAgent agent;

    public int health = 5;

    private Transform player;

    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(PlayerDetect());
        StartCoroutine(FindPath());
        
    }

    IEnumerator PlayerDetect()
    {
        while (true)
        {
            if (player == null)
            {
                break;
            }
            if (Vector3.Distance(transform.position, player.position) < 1f)
            {
                animator.SetBool("attack", true);
                player.SendMessage("Damage");
            }
            else
            {
                
                animator.SetBool("attack", false);
            }
            yield return new WaitForSeconds(.3f);
        }
    }

    IEnumerator FindPath()
    {
        while(true)
        {
            if (player != null)
            { 
                agent.SetDestination(player.position);

                yield return new WaitForSeconds(2f);
            }
            else break;
        }
    }

   
    // Update is called once per frame
    void Update()
    {
       
    }

    public void Damage()
    {
        if(health <=0)
        {
            StopAllCoroutines();
            agent.enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            animator.SetTrigger("Die");
            Destroy(gameObject, 5f);
            GameManager.instance.deadUnit(gameObject);
        }
        else
        {
            health--;
        }
        
    }
}
