using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEyeOpen : MonoBehaviour
{
    Animator animator;
  

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    public void OpenEye()
    {
        animator.SetBool("Open", true);
    }
}
