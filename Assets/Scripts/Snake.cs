using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Vector2 direction = Vector2.up;
    private bool directionChanged;
    public string gameOverSceneName;
    public Apple apple;
    public List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;
   // public Score score;
    public Sprite tailSprite;
    public Sprite straightSprite;
    public Sprite cornerSprite;
    public controlsManager manager;
    public AudioClip deathSound;
    public Transform SnakeProjectilePrefab;
    public bool isPaused;
    public int konamiCode;
    public bool debugImortality;
    //Start is called before the first frame update
    void Start()
    {
        Debug.Log("Snake Started");
       // score = FindObjectOfType<Score>();
        ResetState();
        manager = FindObjectOfType<controlsManager>();
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        inputHandler();
       // score.updateScore();
        KonamiCode();
    }

    void KonamiCode()
    {
        if (isPaused == false)
        {
            switch (konamiCode)
            {
                case 0:
                    if (Input.GetKeyDown(manager.upInput))
                    {
                        konamiCode++;
                        break;
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            konamiCode = 0;
                        }
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(manager.upInput))
                    {
                        konamiCode++;
                        break;
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            konamiCode = 0;
                        }
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(manager.downInput))
                    {
                        konamiCode++;
                        break;
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            konamiCode = 0;
                        }
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(manager.downInput))
                    {
                        konamiCode++;
                        break;
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            konamiCode = 0;
                        }
                    }
                    break;
                case 4:
                    if (Input.GetKeyDown(manager.leftInput))
                    {
                        konamiCode++;
                        break;
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            konamiCode = 0;
                        }
                    }
                    break;
                case 5:
                    if (Input.GetKeyDown(manager.rightInput))
                    {
                        konamiCode++;
                        break;
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            konamiCode = 0;
                        }
                    }
                    break;
                case 6:
                    if (Input.GetKeyDown(manager.leftInput))
                    {
                        konamiCode++;
                        break;
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            konamiCode = 0;
                        }
                    }
                    break;
                case 7:
                    if (Input.GetKeyDown(manager.rightInput))
                    {
                        konamiCode++;
                        break;
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            konamiCode = 0;
                        }
                    }
                    break;
                case 8:
                    if (Input.GetKeyDown(manager.shootInput))
                    {
                        konamiCode++;
                        break;
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            konamiCode = 0;
                        }
                    }
                    break;
                case 9:
                    if (Input.GetKeyDown(manager.shootInput))
                    {
                        konamiCode++;
                        break;
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            konamiCode = 0;
                        }
                    }
                    break;
                case 10:
                    if (Input.GetKeyDown(manager.startInput))
                    {
                        konamiCode++;
                        break;
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            konamiCode = 0;
                        }
                    }
                    break;
                case 11:
                    for(int i=segments.Count; i<100; i++)
                    {
                        Grow();
                    }
                    konamiCode = 0;
                    break;
            }
        }
    }

    void inputHandler()
    {
        if (isPaused == false)
        {
            if (Input.GetKeyDown(manager.shootInput))
            {
                shoot();
            }
            if (Input.GetKeyDown(manager.upInput))
            {
                if (!(direction == Vector2.down) && !(direction == Vector2.up) && !directionChanged)
                {
                    Vector2 lastDirection = direction;
                    direction = Vector2.up;
                    directionChanged = true;
                    if (lastDirection == Vector2.right) { this.transform.Rotate(0.0f, 0.0f, 90.0f); }
                    else { this.transform.Rotate(0.0f, 0.0f, -90.0f); }
                }
            }
            else if (Input.GetKeyDown(manager.leftInput))
            {
                if (!(direction == Vector2.right) && !(direction == Vector2.left) && !directionChanged)
                {
                    Vector2 lastDirection = direction;
                    direction = Vector2.left;
                    directionChanged = true;
                    if (lastDirection == Vector2.up) { this.transform.Rotate(0.0f, 0.0f, 90.0f); }
                    else { this.transform.Rotate(0.0f, 0.0f, -90.0f); }
                }
            }
            else if (Input.GetKeyDown(manager.downInput))
            {
                if (!(direction == Vector2.up) && !(direction == Vector2.down) && !directionChanged)
                {
                    Vector2 lastDirection = direction;
                    direction = Vector2.down;
                    directionChanged = true;
                    if (lastDirection == Vector2.left) { this.transform.Rotate(0.0f, 0.0f, 90.0f); }
                    else { this.transform.Rotate(0.0f, 0.0f, -90.0f); }

                }
            }
            else if (Input.GetKeyDown(manager.rightInput))
            {
                if (!(direction == Vector2.left) && !(direction == Vector2.right) && !directionChanged)
                {
                    Vector2 lastDirection = direction;
                    direction = Vector2.right;
                    directionChanged = true;
                    if (lastDirection == Vector2.down) { this.transform.Rotate(0.0f, 0.0f, 90.0f); }
                    else { this.transform.Rotate(0.0f, 0.0f, -90.0f); }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        bool damageFlag = false;
        int hitIndex = segments.Count;
        for (int i = segments.Count - 1; i > 1; i--)
        {
            if (damageFlag == false)
            {
                if (segments[i].GetComponent<segment>().damaged)
                {
                    hitIndex = i;
                    damageFlag = true;
                    i = segments.Count;
                }
            }
        }
        if (damageFlag)
        {
            for(int i=hitIndex; i<segments.Count; i++)
            {
                Destroy(segments[i].gameObject);
            }
            segments.RemoveRange(hitIndex, segments.Count - hitIndex);
            damageFlag = false;
        }
        for(int i= segments.Count-1; i>1; i--)
        {
            segments[i].GetComponent<segment>().SegmentUpdate(segments[i - 1]);
        }
        segments[1].position = segments[0].position;
        segments[1].GetComponent<segment>().segmentDirection = direction;
        segments[1].GetComponent<segment>().updateDirection();
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + 2 * direction.x,
            Mathf.Round(this.transform.position.y) + 2 * direction.y, 0.0f);
        directionChanged = false;
        segments[segments.Count - 1].GetComponent<SpriteRenderer>().sprite = tailSprite;
        if (segments[segments.Count - 1].GetComponent<segment>().segmentDirection == Vector2.up)
        {
            segments[segments.Count - 1].GetComponent<segment>().setAngle(180.0f);
        }
        if(segments[segments.Count - 1].GetComponent<segment>().segmentDirection == Vector2.down)
        {
            segments[segments.Count - 1].GetComponent<segment>().setAngle(0.0f);
        }
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.GetComponent<SpriteRenderer>().sprite = tailSprite;
        segments[segments.Count - 1].GetComponent<SpriteRenderer>().sprite = straightSprite;
        segment.position = segments[segments.Count - 1].position;
        segment.GetComponent<segment>().segmentDirection = segments[segments.Count - 1].GetComponent<segment>().segmentDirection;
        segments.Add(segment);
    }

    public void ResetState()
    {
        konamiCode = 0;
        isPaused = false;
        directionChanged = false;
        for(int i=1; i<segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);
        for (int i=1; i< this.initialSize; i++)
        {
            Transform segment = Instantiate(this.segmentPrefab);
            segments.Add(segment);
            //segment.position = this.transform.position;
            segment.position = new Vector3(100.0f, 0.0f, 0.0f); //fixes bug with new intial segments spawning in the map rather than on the snake initially
            segment.GetComponent<segment>().segmentDirection = direction;
        }
        this.transform.position = new Vector3(0.0f, -29.0f, 0.0f);
        apple.RandomizePosition();
      //  score.score = initialSize;
        segments[segments.Count - 1].GetComponent<SpriteRenderer>().sprite = tailSprite;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            if (other.GetComponent<Apple>().big)
            {
                Grow();
            }
            other.GetComponent<Apple>().RandomizePosition();
            other.GetComponent<Apple>().sounder.Play();
        }
        if(other.tag == "Obstacle" || other.tag == "Segment" || other.tag == "ActiveCactus")
        {
            lose();
        }
    }
    void shoot()
    {
        if (segments.Count >2)
        {
            Destroy(segments[segments.Count - 1].gameObject);
            segments.RemoveAt(segments.Count - 1);
         //   score.score--;
            Transform projectile=Instantiate(SnakeProjectilePrefab);
            projectile.gameObject.GetComponent<EnemyProjectile>().direction = direction;
            projectile.transform.position = new Vector3(transform.position.x+direction.x, transform.position.y+direction.y, transform.position.z);
        }
    }
    public void lose()
    {
        if (debugImortality == false)
        {
            ResetState();
            manager.sounder.clip = deathSound;
            manager.sounder.Play();
            GameplayVars.Set("previousScene", ""+SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(gameOverSceneName);
        }
        else
        {
            Debug.Log("Death Avoided via Immortality");
        }
    }
}
