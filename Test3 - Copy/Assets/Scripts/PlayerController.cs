using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    [SerializeField] private float moveSpeed = 6.0f;
    private CharacterController characterController;
    private Animator anim;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.SimpleMove(moveDirection * moveSpeed);

        if(moveDirection == Vector3.zero){
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }

        if (Input.GetMouseButton(0))
        {
            anim.Play("DoubleChop");
        }
        if (Input.GetMouseButton(1))
        {
            anim.Play("SpinAttack");
        }

    }
}
