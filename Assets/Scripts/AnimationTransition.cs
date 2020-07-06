using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTransition : MonoBehaviour
{
    [SerializeField] AnimeStatusManager animeStatusManager;
    Animator animator;

    private void Start()
    {
       
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       
        
        if (animeStatusManager.animeStatus == AnimeStatus.put)
        {
            animator.SetTrigger("ToPut");
        }
        if(animeStatusManager.animeStatus == AnimeStatus.walk)
        {
            animator.SetTrigger("ToWalk");
        }
        if (animeStatusManager.animeStatus == AnimeStatus.walkanddraw)
        {
            animator.SetTrigger("ToWalkAndDraw");
        }
     
    }
}
