using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public bool hasKey;
    public WinLoseHandler winLoseHandler;
    private bool isRunning;
    private bool isOnAction;
    private bool hasIdleMovementProcess;
    private float mouseRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Idle animation process
        switch (isOnAction)
        {
            case true:
                //Stop the IdleMovement function from processing
                StopCoroutine(IdleMovement());
                hasIdleMovementProcess = false;
                break;
            case false:
                //Start function that will trigger different idle animation when there is no action for too long
                if(hasIdleMovementProcess == false){
                    hasIdleMovementProcess = true;
                    StartCoroutine(IdleMovement());
                }
                break;
        }

        /*CONTROLS*/
        /***********************************/
        //Player Rotation
        MouseLook();
        //Move Forward
        if (Input.GetKey(PlayerSettings.keyboardControls.forward))
        {
            isOnAction = true;
            MoveForward();
            anim.SetBool("isWalking", true);
        }else{
            isOnAction = false;
            anim.SetBool("isWalking", false);
        }

        //Move Backward
        if(Input.GetKey(PlayerSettings.keyboardControls.backward)){

            isOnAction = true;
            anim.SetBool("isStepBack", true);
            MoveBackward();
        }else{
            isOnAction = false;
            anim.SetBool("isStepBack", false);
        }

        //Move Left Right
        if(Input.GetKey(PlayerSettings.keyboardControls.left)){
            MoveSides(1);
        }
        if(Input.GetKey(PlayerSettings.keyboardControls.right)){
            MoveSides(-1);
        }
        if(Input.GetKey(PlayerSettings.keyboardControls.left) == false && 
        Input.GetKey(PlayerSettings.keyboardControls.right) == false){
            anim.SetInteger("direction", 0);
        }

        //Run (Hold)
        if(Input.GetKey(PlayerSettings.keyboardControls.runHold)){
            isRunning = true;
        }else{
            isRunning = false;
        }
        anim.SetBool("isRunning", isRunning);
        Run();

        /***********************************/
    }

    //hide cursor toggle function
    public void ToggleHideCursor(bool turnOn){
        switch (turnOn)
        {
            case false:
            Cursor.lockState = CursorLockMode.None;
            break;
            case true:
            Cursor.lockState = CursorLockMode.Locked;
            break;
        }
    }

    void MouseLook(){
        //Rotate player and camera view horizontally with mouse
        if(Time.timeScale != 0){
            mouseRot += Input.GetAxis("Mouse X") * 5f;
            transform.localRotation = Quaternion.Euler(0, mouseRot, 0);
        }
    }

    void Run(){
        switch (isRunning)
        {
            case true:
                speedMultiplier = 2.5f;
                break;
            case false:
                speedMultiplier = 1f;
                break;
        }
    }

    void MoveForward(){
        transform.Translate(Vector3.forward * speed * speedMultiplier * Time.deltaTime);
    }
    void MoveBackward(){
        transform.Translate(Vector3.forward * speed * -0.5f * Time.deltaTime);
    }

    void MoveSides(int direction){
        //Move left and right depend on direction parameter
        anim.SetInteger("direction", direction);
        transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
    }
    IEnumerator IdleMovement(){
        //Trigger different idle animation when wait for too long
        yield return new WaitForSeconds(120);
        anim.SetInteger("idleAnimType", Random.Range(1, 3));
        anim.SetTrigger("idleMovement");
        hasIdleMovementProcess = false;
    }


}
