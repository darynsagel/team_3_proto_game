using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController2 : MonoBehaviour
{
    public float speed;
    public int score = 0;
    public Text scoreBoard;

    private GameObject CageObj, Gem, EnemyHit, Fish, heart;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public Animator animator;
    float verticalMove, horizontalMove, totalMove, someScale;

    public ParticleSystem gemsys;
    private ParticleSystem gemsys_clone;

    public ParticleSystem confetti;
    private ParticleSystem confetti_clone;

    public Text gemtext;

    public float alph;

    private int e1d = 0, e2d = 0, e3d = 0, e4d = 0, e5d = 0, e6d = 0, e7d = 0, e8d = 0;

    public ParticleSystem inksplot;
    public KeyCode activate;
    private float btwntime = 5.0f;
    private float timetostart = 0.0f;
    public GameObject enemy1, enemy2, enemy3, enemy4, enemy5, enemy6, enemy7, enemy8;

    public int life, maxlife;
    public Image[] hearts;
    public Sprite yesheart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        someScale = transform.localScale.x;
        gemtext.enabled = false;
        speed = 20.0f;
        alph = 1.0f;
        life = 3;
        maxlife = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");

        totalMove = Mathf.Abs(horizontalMove) + Mathf.Abs(verticalMove);

        animator.SetFloat("speed", Mathf.Abs(totalMove));

        if (horizontalMove < 0)
        {
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
            animator.SetFloat("speed", Mathf.Abs(totalMove));
        }
        if (horizontalMove > 0)
        {
            transform.localScale = new Vector2(someScale, transform.localScale.y);
            animator.SetFloat("speed", Mathf.Abs(totalMove));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SoundManager.PlaySound("bubbles");
        }

        alph = GameObject.Find("Player").GetComponent<PlayerAlpha>().alphaLevel;
        speed = GameObject.Find("Player").GetComponent<propulsion>().fast;

        if (Input.GetKeyDown(activate) && Time.time > timetostart)
        {
            timetostart = Time.time + btwntime;
            SoundManager.PlaySound("ink");
            inksplot.Play();
            Invoke("destroyenemy", 1);
            Invoke("stopInk", 3);

        }

        for (int i = 0; i < maxlife; i++)
        {
            if (i < life)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            CageObj = GameObject.FindGameObjectWithTag("Cage");
            SoundManager.PlaySound("cage");
            Object.Destroy(CageObj);
        }
        else if (other.gameObject.CompareTag("h1"))
        {
            if (life < 3)
            {
                heart = GameObject.FindGameObjectWithTag("h1");
                life++;
                Object.Destroy(heart);
            }
        }
        else if (other.gameObject.CompareTag("h2"))
        {
            if (life < 3)
            {
                heart = GameObject.FindGameObjectWithTag("h2");
                life++;
                Object.Destroy(heart);
            }
        }
        else if (other.gameObject.CompareTag("h3"))
        {
            if (life < 3)
            {
                heart = GameObject.FindGameObjectWithTag("h3");
                life++;
                Object.Destroy(heart);
            }
        }
        else if (other.gameObject.CompareTag("h4"))
        {
            if (life < 3)
            {
                heart = GameObject.FindGameObjectWithTag("h4");
                life++;
                Object.Destroy(heart);
            }
        }
        else if (other.gameObject.CompareTag("VictoryFish"))
        {
            Fish = GameObject.FindGameObjectWithTag("VictoryFish");

            if (score >= 60)
            {
                SoundManager.PlaySound("confetti");
                confetti_clone = Instantiate(confetti, Fish.transform.position, Quaternion.identity);
                Destroy(confetti_clone.gameObject, 2f);
                Invoke("next", 2f); // CHANGE TO CUTSCENE, NOT ENDGAME
            }
            else
            {
                gemtext.enabled = true;
                gemtext.text = "At least 60 gem points needed to continue!";
                Invoke("notext", 3f);

            }
        }
        else if (other.gameObject.CompareTag("Gem1"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem1");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score++;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);
            }

        }
        else if (other.gameObject.CompareTag("Gem2"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem2");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score++;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);

            }

        }
        else if (other.gameObject.CompareTag("Gem3"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem3");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score++;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);

            }

        }
        else if (other.gameObject.CompareTag("Gem4"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem4");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score++;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);

            }

        }
        else if (other.gameObject.CompareTag("Gem5"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem5");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score++;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);

            }

        }
        else if (other.gameObject.CompareTag("Gem10"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem10");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score = score + 5;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);

            }

        }
        else if (other.gameObject.CompareTag("Gem6"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem6");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score++;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);

            }

        }
        else if (other.gameObject.CompareTag("Gem7"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem7");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score = score + 10;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);

            }

        }
        else if (other.gameObject.CompareTag("Gem8"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem8");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score = score + 5;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);

            }

        }
        else if (other.gameObject.CompareTag("Gem9"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem9");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score = score + 10;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);

            }
        }
        else if (other.gameObject.CompareTag("Gem11"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem11");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score = score + 5;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);

            }

        }
        else if (other.gameObject.CompareTag("Gem12"))
        {
            if (alph > 0.5)
            {
                Gem = GameObject.FindGameObjectWithTag("Gem12");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score = score + 10;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);

            }

        }
        else if (other.gameObject.CompareTag("Gem13"))
        {
            if (alph > 0.5)
            {

                Gem = GameObject.FindGameObjectWithTag("Gem13");
                gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
                SoundManager.PlaySound("gem");
                Object.Destroy(Gem);
                score = score + 10;
                scoreBoard.text = "Score: " + score;
                Destroy(gemsys_clone.gameObject, 2f);
            }

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy(Left)") || other.gameObject.CompareTag("e8") ||other.gameObject.CompareTag("e7") || other.gameObject.CompareTag("e2") || other.gameObject.CompareTag("e3") || other.gameObject.CompareTag("e4") || other.gameObject.CompareTag("e1") || other.gameObject.CompareTag("e5") || other.gameObject.CompareTag("e6"))
        {
            if (alph > 0.5)
            {
                SoundManager.PlaySound("enemybump");
                life--;
            }
            else
            {
                if (other.gameObject.CompareTag("e2") || other.gameObject.CompareTag("e3") || other.gameObject.CompareTag("e7") || other.gameObject.CompareTag("e8") ||other.gameObject.CompareTag("e4") || other.gameObject.CompareTag("e6"))
                    life--;
            }

        }
        if (life == 0)
            SceneManager.LoadScene(5);

    }




    public void notext()
    {
        gemtext.enabled = false;
        gemtext.text = "";
    }

    public void stopInk()
    {
        inksplot.Stop();
    }

    public void destroyenemy()
    {

        //enemy1 = GameObject.FindGameObjectWithTag("e1");
        if (e1d == 0)
        {
            if (Vector2.Distance(gameObject.transform.position, enemy1.transform.position) < 20)
            {
                Object.Destroy(enemy1);
                Debug.Log("1 destroyed");
                e1d = 1;
            }
        }

        //enemy2 = GameObject.FindGameObjectWithTag("e2");
        if (e2d == 0)
        {
            if (Vector2.Distance(gameObject.transform.position, enemy2.transform.position) < 40)
            {
                Object.Destroy(enemy2);
                Debug.Log("2 destroyed");
                e2d = 1;
            }
        }

        //enemy3 = GameObject.FindGameObjectWithTag("e3");
        if (e3d == 0)
        {
            if (Vector2.Distance(gameObject.transform.position, enemy3.transform.position) < 40)
            {
                Object.Destroy(enemy3);
                Debug.Log("3 destroyed");
                e3d = 1;
            }
        }

        // enemy4 = GameObject.FindGameObjectWithTag("e4");
        if (e4d == 0)
        {
            if (Vector2.Distance(gameObject.transform.position, enemy4.transform.position) < 40)
            {
                Object.Destroy(enemy4);
                Debug.Log("4 destroyed");
                e4d = 1;
            }
        }

        // enemy5 = GameObject.FindGameObjectWithTag("e5");
        if (e5d == 0)
        {
            if (Vector2.Distance(gameObject.transform.position, enemy5.transform.position) < 20)
            {
                Object.Destroy(enemy5);
                Debug.Log("5 destroyed");
                e5d = 1;
            }
        }

        //enemy6 = GameObject.FindGameObjectWithTag("e6");
        if (e6d == 0)
        {
            if (Vector2.Distance(gameObject.transform.position, enemy6.transform.position) < 40)
            {
                Object.Destroy(enemy6);
                Debug.Log("6 destroyed");
                e6d = 1;
            }
        }

        // enemy7 = GameObject.FindGameObjectWithTag("e7");
        if (e7d == 0)
        {
            if (Vector2.Distance(gameObject.transform.position, enemy5.transform.position) < 40)
            {
                Object.Destroy(enemy7);
                Debug.Log("7 destroyed");
                e7d = 1;
            }
        }

        // enemy8 = GameObject.FindGameObjectWithTag("e8");
        if (e8d == 0)
        {
            if (Vector2.Distance(gameObject.transform.position, enemy6.transform.position) < 40)
            {
                Object.Destroy(enemy8);
                Debug.Log("8 destroyed");
                e8d = 1;
            }
        }
    }

public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
