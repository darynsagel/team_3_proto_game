using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
    public int score = 0;
    public Text scoreBoard;

    private GameObject CageObj, Gem, EnemyHit, Fish;
	private Rigidbody2D rb;
	private Vector2 moveVelocity;

    public Animator animator;
    float verticalMove, horizontalMove, totalMove, someScale;


    public ParticleSystem gemsys;
    private ParticleSystem gemsys_clone;

    public ParticleSystem confetti;
    private ParticleSystem confetti_clone;


    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
        someScale = transform.localScale.x;
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
        else if (other.gameObject.CompareTag("VictoryFish"))
        {
            Fish = GameObject.FindGameObjectWithTag("VictoryFish");
            SoundManager.PlaySound("confetti");
            confetti_clone = Instantiate(confetti, Fish.transform.position, Quaternion.identity);
            Destroy(confetti_clone.gameObject, 2f);
            Invoke("endgame", 2f);
        }
        else if (other.gameObject.CompareTag("Gem1"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem1");
            gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
            SoundManager.PlaySound("gem");
            Object.Destroy(Gem);
            score++;
            scoreBoard.text = "Score: " + score;
            Destroy(gemsys_clone.gameObject, 2f);
        }
        else if (other.gameObject.CompareTag("Gem2"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem2");
            gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
            SoundManager.PlaySound("gem");
            Object.Destroy(Gem);
            score++;
            scoreBoard.text = "Score: " + score;
            Destroy(gemsys_clone.gameObject, 2f);
        }
        else if (other.gameObject.CompareTag("Gem3"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem3");
            gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
            SoundManager.PlaySound("gem");
            Object.Destroy(Gem);
            score++;
            scoreBoard.text = "Score: " + score;
            Destroy(gemsys_clone.gameObject, 2f);
        }
        else if (other.gameObject.CompareTag("Gem4"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem4");
            gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
            SoundManager.PlaySound("gem");
            Object.Destroy(Gem);
            score++;
            scoreBoard.text = "Score: " + score;
            Destroy(gemsys_clone.gameObject, 2f);
        }
        else if (other.gameObject.CompareTag("Gem5"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem5");
            gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
            SoundManager.PlaySound("gem");
            Object.Destroy(Gem);
            score++;
            scoreBoard.text = "Score: " + score;
            Destroy(gemsys_clone.gameObject, 2f);
        }
        else if (other.gameObject.CompareTag("Gem10"))
        {
            Gem = GameObject.FindGameObjectWithTag("Gem10");
            gemsys_clone = Instantiate(gemsys, Gem.transform.position, Quaternion.identity);
            SoundManager.PlaySound("gem");
            Object.Destroy(Gem);
            score = score + 10;
            scoreBoard.text = "Score: " + score;
            Destroy(gemsys_clone.gameObject, 2f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy(Left)"))
        {
            SoundManager.PlaySound("enemybump");

        }
     
    }

    public void endgame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
