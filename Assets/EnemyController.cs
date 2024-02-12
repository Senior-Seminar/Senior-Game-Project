using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Animator myAnim;
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;


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
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        //yield return new WaitForSeconds(1f);
    }

    public void UnfollowPlayer()
    {
        myAnim.SetBool("isMoving", false);
    }

}
