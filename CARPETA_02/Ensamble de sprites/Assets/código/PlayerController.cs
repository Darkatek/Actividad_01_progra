using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour  {

       public float JumpForce;
       public float Speed;

       private Rigidbody2D Character;
       private Animator Animator;
       private float Horizontal;
       private bool Grounded;


    
    void Start() {

      Character = GetComponent<Rigidbody2D> ();
      Animator = GetComponent<Animator> ();
        
    }

   
    void Update() {

     Horizontal = Input.GetAxisRaw ("Horizontal");

     if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.56f, 1.49f, 1.0f);
     else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.56f, 1.49f, 1.0f); 

     Animator.SetBool ("Walking", Horizontal != 0.0f);


     if (Physics2D.Raycast (transform.position, Vector3.down, 0.1f)) {
         Grounded = true;
         Animator.SetBool ("Grounded", true);

    } else {
             Grounded = false;
             Animator.SetBool ("Grounded", false);
        
    }



      if.(Input.GetKey (KeyCode.Space) && Grounded) {
          Jump();

          Animator.SetBool("Shoot", true);
   } else
          Animator.SetBool("Shoot", false);



}


private void Jump ()

{
    Character.AddForce (Vector2.up * JumpForce);
}

private void FixedUpdate ()

{
    Character.velocity = new Vector2 (Horizontal * Speed, Character.velocity.y);
}



}
