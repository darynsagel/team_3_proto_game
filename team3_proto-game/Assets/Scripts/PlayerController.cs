using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
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

    public ParticleSystem inksplot;
    public KeyCode activate;
    private float btwntime = 5.0f;
    private float timetostart = 0.0f;
    private GameObject enemy;

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

        if(horizontalMove < 0)
        {
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
            animator.SetFloat("speed", Mathf.Abs(totalMove));
        }
        if (horizontalMove > 0)
        {
            transform.localScale = new Vector2(someScale, transform.localScale.y);
            animator.SetFloat("speed", Mathf.Abs(totalMove));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) )
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
            Invoke("stopInk", 3);
            Invoke("destroyenemy", 2);
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

            if (score >= 45)
            {
                SoundManager.PlaySound("confetti");
                confetti_clone = Instantiate(confetti, Fish.transform.position, Quaternion.identity);
                Destroy(confetti_clone.gameObject, 2f);
                Invoke("next", 2f); // CHANGE TO CUTSCENE, NOT ENDGAME
            }
            else
            {
                gemtext.enabled = true;
                gemtext.text = "At least 45 gem points needed to continue!";
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
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy(Left)") || other.gameObject.CompareTag("e2") || other.gameObject.CompareTag("e3") || other.gameObject.CompareTag("e4") || other.gameObject.CompareTag("e1") || other.gameObject.CompareTag("e5") || other.gameObject.CompareTag("e6"))
        {
            if (alph > 0.5)
            {
                SoundManager.PlaySound("enemybump");
                life--;
            }
            else
            {
                if (other.gameObject.CompareTag("e2") || other.gameObject.CompareTag("e3") || other.gameObject.CompareTag("e4") || other.gameObject.CompareTag("e6"))
                    life--;
            }

        }
        if (life == 0)
            endgame();
     
    }


    public void endgame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
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

        enemy = GameObject.FindGameObjectWithTag("e1");
        if (Vector2.Distance(gameObject.transform.position, enemy.transform.position) < 10)
            Object.Destroy(enemy);

        enemy = GameObject.FindGameObjectWithTag("e2");
        if (Vector2.Distance(gameObject.transform.position, enemy.transform.position) < 10)
            Object.Destroy(enemy);

        enemy = GameObject.FindGameObjectWithTag("e3");
        if (Vector2.Distance(gameObject.transform.position, enemy.transform.position) < 10)
            Object.Destroy(enemy);

        enemy = GameObject.FindGameObjectWithTag("e4");
        if (Vector2.Distance(gameObject.transform.position, enemy.transform.position) < 10)
            Object.Destroy(enemy);

        enemy = GameObject.FindGameObjectWithTag("e5");
        if (Vector2.Distance(gameObject.transform.position, enemy.transform.position) < 10)
            Object.Destroy(enemy);

        enemy = GameObject.FindGameObjectWithTag("e6");
        if (Vector2.Distance(gameObject.transform.position, enemy.transform.position) < 10)
            Object.Destroy(enemy);
    }

    public void next()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}
}
