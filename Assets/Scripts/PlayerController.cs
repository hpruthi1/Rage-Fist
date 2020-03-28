using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float Speed;
    private bool canRun = false;
    public bool canJump = false;
    public float WalkSpeed , RunSpeed, Jumpforce;
    public bool isFacingRight;
    public bool isGrounded = false;
    public GameObject Enemy;
    public GameObject Panel;
    public GameObject Score;
    public GameObject HealthBars;
    public Image healthimage;
    public HealthSystem healthSystem;
    public KnifeAttack knifeAttack;
    public GameObject InitialPanel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isFacingRight = true;
        healthSystem = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        healthimage.fillAmount = healthSystem.Health / 100;
        float horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector2(horizontal * Speed, rb.velocity.y) * Time.deltaTime);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Flip(horizontal);
        Speed = WalkSpeed;

        if (healthSystem.Health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = RunSpeed;
            canRun = true;
            animator.SetTrigger("Run");
        }
        if (Input.GetMouseButton(0))
        {
            knifeAttack.KnifeAttackFunction(10);
            animator.SetTrigger("Attack1");
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.ResetTrigger("Attack1");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            canRun = false;
            animator.ResetTrigger("Run");
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            canJump = true;
            rb.AddRelativeForce(new Vector2(0f, Jumpforce), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");

        }
        else
        {
            canJump = false;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight){
            isFacingRight = !isFacingRight;
            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            Destroy(Enemy);
            StartCoroutine(Panelview());
        }
    }

    IEnumerator Panelview()
    {
        HealthBars.SetActive(false);
        Score.SetActive(false);
        InitialPanel.SetActive(false);
        Panel.SetActive(true);
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(2);
    }
    
}
