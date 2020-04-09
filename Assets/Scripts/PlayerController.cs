using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

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
    public bool VideoPanelActive = false;
    public bool CanAttack;
    public GameObject Enemy;
    public GameObject InvisibleWall;
    public GameObject ThirdScene;
    public GameObject Panel;
    public GameObject Score;
    public GameObject EndPoint;
    public GameObject EnemyHealthBar;
    public GameObject PlayerHealthBar;
    public Image healthimage;
    public HealthSystem healthSystem;
    protected Joystick joystick;
    protected JoyStickButton stickButton;
    public GameObject JoystickCanvas;
    public Audiomanager audiomanager;
    public UIManager uiManager;
    public CountDown countDown;
    public KnifeAttack knifeAttack;
    public GameObject InitialPanel;
    public GameObject Timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isFacingRight = true;
        healthSystem = GetComponent<HealthSystem>();
        InvisibleWall.SetActive(false);
        joystick = FindObjectOfType<Joystick>();
        stickButton = FindObjectOfType<JoyStickButton>();
    }

    void Update()
    {
        healthimage.fillAmount = healthSystem.Health / 100;
        float horizontal = Input.GetAxisRaw("Horizontal");
        horizontal += joystick.Horizontal;
        transform.Translate(new Vector2(horizontal * Speed, rb.velocity.y) * Time.deltaTime);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Speed = WalkSpeed;
        Flip(horizontal);
        

        if (healthSystem.Health <= 0)
        {
            Destroy(gameObject);
            Destroy(Enemy);
            SceneManager.LoadScene(2);

        }

        if (joystick.Horizontal >0.5f || joystick.Horizontal<-0.5 || (Input.GetKey(KeyCode.LeftShift)))
        {
            Speed = RunSpeed;
            canRun = true;
            animator.SetTrigger("Run");
        }

        if (stickButton.Pressed == true && !CanAttack)
        {
            FindObjectOfType<Audiomanager>().Play("Knife");
            CanAttack = true;
            knifeAttack.KnifeAttackFunction(10);
            animator.SetTrigger("Attack1");
        }

        if (!stickButton.Pressed && CanAttack)
        {
            CanAttack = false;
            animator.SetTrigger("Attack1");
        }

        if (Input.GetKey(KeyCode.Return))
        {
            if (VideoPanelActive == true)
            {
                Panel.SetActive(false);
                gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(-0.03473687f, 0.1169736f);
                gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(0.9331737f, 2.270053f);
                PlayerHealthBar.SetActive(true);
                Score.SetActive(true);
                Panel.SetActive(false);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            canRun = false;
            animator.ResetTrigger("Run");
        }
    }

    public void Jump()
    { 
        FindObjectOfType<Audiomanager>().Play("Jump");
        if (isGrounded == true)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shock"))
        {
            FindObjectOfType<Audiomanager>().Play("Shock");
            gameObject.GetComponent<HealthSystem>().healthDecrease(30);
        }

        if (collision.gameObject.CompareTag("Scene3"))
        {
            InvisibleWall.SetActive(true);
            if (uiManager.ChemicalsCollected == 0 )
            { 
                SceneManager.LoadScene(1);
            }
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(3);
        }
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
            countDown.timerIsActive = false;
            VideoPanelActive = true;
            StartCoroutine(Panelview()); 
        }
    }

    IEnumerator Panelview()
    {
        PlayerHealthBar.SetActive(false);
        EnemyHealthBar.SetActive(false);
        Timer.SetActive(false);
        Score.SetActive(false);
        InitialPanel.SetActive(false);
        JoystickCanvas.SetActive(false);
        Panel.SetActive(true);
        EndPoint.SetActive(false);
        yield return new WaitForSeconds(8f);
        VideoPanelActive = false;
        gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(-0.03473687f,0.1169736f);
        gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(0.9331737f, 2.270053f);
        PlayerHealthBar.SetActive(true);
        Score.SetActive(true);
        JoystickCanvas.SetActive(true);
        Panel.SetActive(false);
    }
}
