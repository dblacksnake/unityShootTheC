using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerMovement : MonoBehaviour
{
    //Variable
    public bool isGroundedPlayer;
    public float playerSpeed = 15.0f;
    public Camera camera;
    public GameObject projectiles;
    public GameObject firePoint;

    private float x,y;
    private Vector3 rotateValue;
    private CharacterController player;
    private Vector3 playerVelocity;
    private Vector3 move = Vector3.zero;
    private float jumpHeight = 2.5f;
    private float gravityValue = -9.81f;

    // Start is called before the first frame update
    private void Start()
    {
        player = gameObject.AddComponent<CharacterController>();
        //camera = gameObject.AddComponent<Camera>();
        //player.height = 2.1f;
        //print(player.Move());
    }
    // Update is called once per frame
    void Update()
    {
        playerRotationControler();
        playerMove();
        playerShoot(projectiles);
       

    }

    void playerMove(){
        isGroundedPlayer = player.isGrounded;

        //Camera Player angle
        x = Input.GetAxis("Mouse Y");
        y = Input.GetAxis("Mouse X");
        //Camera turn
        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue * 5;
        if(isGroundedPlayer){
              //Move the player
        move = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        //Change the X,Y,Z world direction
        move = transform.TransformDirection(move.x,0,move.z);

            if(Input.GetButtonDown("Jump")){
                move.y = jumpHeight ;
            }
        }
      
        //transform.Translate(Vector3.forward * Time.deltaTime);
        //move.y = 0;
        move.y += gravityValue * Time.deltaTime;
        player.Move(move * Time.deltaTime * playerSpeed);
    }

    void playerRotationControler()
 {
    // if(player.transform.rotation.y)

 }

 void playerShoot(GameObject projectiles){
     Vector3 firePointPosition = firePoint.transform.position;
     firePointPosition = firePoint.transform.TransformDirection(firePointPosition);
     if(Input.GetButtonDown("Fire1")){
         Instantiate(this.projectiles,firePointPosition,Quaternion.Euler(0,90,90));
     }
 }
}
