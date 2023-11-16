using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SecreteryBird : MonoBehaviour, IBossInterface
{
    public Boss boss; //the interface attached
    public Apple eggplant; //the eggplant object
    public Snake snake; //the player
    public Transform projectilePrefab; //feather prefab
    public int feathersUntilStomp; //counts down every time a feather launched. At 0, triggers stomp attack
    public Transform stompPrefab; //Stomp Hitbox prefab
    public Transform shadowPrefab; //Shadow sprite prefab
    public Transform stompObject; //The existing stomp hitbox
    public Transform shadowObject; //the existing shadow
    public bool leftAttack; //animator controls
    public bool rightAttack; //
    public bool stomp; //
    public bool isHit; //end animator controls
    public Transform stompBird; //descending and ascending bird object
    public float stompSpeed; //how fast the bird goes down
    public bool isStomping; //to set stuff up before stomp attack
    public bool isAscending; //to control ascension
    public float targetX;
    public float targetY; //The Y coordinate of the eggplant for stomp attacks
    private float targetZ;
    public float flySpeed; //Speed bird flies up after stomp
   // public float startBirdEggplantDY; // The distance from stomp bird to eggplant before and after stomp attack.
    public bool risingUp;// animation flag for end of stomp attack as main bird rises out of ground.
    private bool stompDeleted; //flag for when stomp hitbox removed.
    public float stompY;
    public int frameLock;
    public bool shadowExists;
    public int framesToShadowBase;
    public int framesToShadow;
    public bool featherLocked;
    public bool readyToFeatherAttack;
    public float stompBaseHeight;
    public float ascensionSpeed;

    // Start is called before the first frame update
    void Start()
    {
        feathersUntilStomp = Random.Range(5, 10);
        boss.bossAI = this;
        stompDeleted = false;
        shadowExists = false;
        framesToShadow = framesToShadowBase;
        featherLocked = true;
        readyToFeatherAttack = true;
    }

    // Fixed Update is called once per fixed-frame-rate frame
    void FixedUpdate()
    {
        if(isStomping == false && stompBird.transform.position.y <= stompBaseHeight)
        {
            stompBird.transform.Translate(0, ascensionSpeed, 0);
        }
        if (leftAttack == false)
        {
            GetComponent<Animator>().SetBool("leftAttack", false);
        }
        if (rightAttack == false)
        { //I commented my code
            GetComponent<Animator>().SetBool("rightAttack", false);
        }
        if (stomp == false)
        {
            GetComponent<Animator>().SetBool("Stomp", false);
        }
        if (isHit == false)
        {
            GetComponent<Animator>().SetBool("Hit", false);
        }
        //when the bird is stomping down
        if (isStomping && !isAscending)
        {
            //lock boss frames
            boss.baseFramesBetweenAttacks = frameLock;
            Debug.Log("IS STOMPING");
            //move the stomping bird down by stompSpeed every tick
          stompBird.transform.position = new Vector3(stompBird.transform.position.x, stompBird.transform.position.y - stompSpeed * Time.deltaTime, stompBird.transform.position.z);
            //Debug.Log("Coordinates");
            //Debug.Log("Bird Y: "+ stompBird.transform.position.y);
            // Debug.Log("TargetY: " + targetY);

            //spawn shadow on the ground where eggplant is
            if (shadowExists == false)
            {
                if (framesToShadow <= 0)
                {
                    shadowObject = Instantiate(shadowPrefab, new Vector3(targetX, targetY, targetZ), new Quaternion());
                    shadowExists = true;
                }
                else
                {
                    framesToShadow--;
                }
            }

            if (stompBird.gameObject.transform.position.y <= targetY) //Has the bird reached its target?
            {
                Debug.Log("Bird Reached Target, and bought overpriced clothes");
                isStomping = false;
                //call a method to:
                // - make a hitbox at the stomp location
                stompObject = Instantiate(stompPrefab, new Vector3(targetX, targetY, targetZ), new Quaternion());
                // - start the bird's ascent
                isAscending = true;
                // - possibly heal the bird if the eggplant was still there
                  //(Handled in StompHitbox.cs)
            }
        }
        //once the bird is ascending
        if (isAscending)
        {
            //lock boss frames
            boss.baseFramesBetweenAttacks = frameLock;
            Debug.Log("isAscending");

            //disable stomp hitbox
            if (stompDeleted == false)
            {
                //store y value of stomp
                stompY = stompObject.transform.position.y;
                if (stompBird.transform.position.y >= stompObject.position.y + 5)
                {
                    Destroy(stompObject.gameObject);
                    stompDeleted = true;
                }
            }
            //move the bird up by flySpeed every tick

            stompBird.transform.position = new Vector3(stompBird.transform.position.x, stompBird.transform.position.y + flySpeed * Time.deltaTime, stompBird.transform.position.z);
            //once it has reached "the top of the screen", call a method to:
            if (stompBird.transform.position.y >= stompBaseHeight)
            {
                //riiisse up
                Debug.Log("John Laurens");
                Destroy(shadowObject.gameObject);
                // - slide the bird up out of the ground into its original position
                risingUp = true;
                shadowExists = false;
                framesToShadow = framesToShadowBase;
                isAscending = false;
                isStomping = false;
                // - renable its hitbox
                GetComponent<BoxCollider2D>().enabled = true;
                // - start feather attacks again}
                //covered by Boss.cs
                GetComponent<Animator>().SetBool("Rising", true);
                stomp = false;
            }


        }

        if (featherLocked == false)
        {//it isnt seeing this feather. Fix this now
            Feather featherAI = FindObjectOfType<Feather>();
            featherAI.locked = false;
            Debug.Log("Feather Unlocked by Bird");
        }
    }
        public void Attack()
    {

        GetComponent<Animator>().SetBool("Rising", false);
        isHit = false;
        leftAttack = false;
        rightAttack = false;
        stomp = false;
        if (feathersUntilStomp > 0)
        {
            featherAttack(getAttackParams());
            Debug.Log("FEATHER ATTACK");
            featherLocked = true;
        }
        else
        {
            Debug.Log("STOMP ATTACK");
            stompAttack();
            feathersUntilStomp = Random.Range(5, 10);
        }

    }
    public void featherAttack(int headPos)
    {

        if (readyToFeatherAttack == false)
        {
            return;
        }
        readyToFeatherAttack = false;
        bool direction = (feathersUntilStomp % 2 == 1); //true = left, false = right
        if (direction)
        {
            //play animation based on direction
            GetComponent<Animator>().SetBool("leftAttack", true);
            
            leftAttack = true;
            rightAttack = false;
            stomp = false;
        }
        else
        {
            //play animation based on direction
            GetComponent<Animator>().SetBool("rightAttack", true);

            rightAttack = true;
            leftAttack = false;
            stomp = false;
        }
        //create a feather, give it the correct direction of travel, put it WAAYY off screen, and start it moving
        Transform feather = Instantiate(projectilePrefab);
        float x = direction ? -180f : 180f;
        feather.GetComponent<Feather>().direction = direction;
        feather.position = new Vector3(x, snake.GetComponent<Transform>().position.y, 0f);
        feathersUntilStomp--;
    }
    public void stompAttack()
    {
        readyToFeatherAttack = false;
        //lock boss script from attacking during attack
        frameLock = boss.baseFramesBetweenAttacks;
        //start the takeoff animation
        GetComponent<Animator>().SetBool("Stomp", true);
        stompDeleted = false;
        stomp = true;
        leftAttack = false;
        rightAttack = false;
       //Old broken line of code
       // stompObject.gameObject.transform.position = new Vector3(eggplant.transform.position.x,eggplant.gameObject.transform.position.y, eggplant.gameObject.transform.position.z);

        //set targetY based on eggplant Y
        targetY = eggplant.transform.position.y;
        targetX = eggplant.transform.position.x;
        targetZ = eggplant.transform.position.z;
        //spawn descending bird sprite at the top of the screen above the eggplant's x pos
        stompBird.transform.position = new Vector3(targetX, stompBird.transform.position.y, stompBird.transform.position.z);


        //disable hitbox for secretery bird
        GetComponent<BoxCollider2D>().enabled = false;
    }
    public int getAttackParams()
    {
        return Mathf.FloorToInt(snake.transform.position.x);
    }
    public void hit()
    {
        Debug.Log("Bird Hit");
        GetComponent<Animator>().SetBool("Hit", true);
        isHit = true;
        boss.health--;
        if (boss.health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Ouro_Splash");
        }
    }
}
