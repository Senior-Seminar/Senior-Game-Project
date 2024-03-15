using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Animator myAnim;
    private Transform target;
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float maxRange = 0f;
    [SerializeField]
    private float minRange = 0f;


    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;

    }

    // Update is called once per frame
    void Update()
    {   
        //follow player if within min and max range
        if(Vector3.Distance(target.position, transform.position) < maxRange && Vector3.Distance(target.position, transform.position) > minRange)
        {
            FollowPLayer();
        }
        else
        {
            UnfollowPlayer();
        }
    }

    public void FollowPLayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        
    }

    public void UnfollowPlayer()
    {
        myAnim.SetBool("isMoving", false);
    }

}
