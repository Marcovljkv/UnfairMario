using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MarioMoves : MonoBehaviour
{
    //  Initialisation
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool Sol = false;
    float speed = 60f;
    float maxSpeed = 5f;
    [HideInInspector]
    public float jumpForce = 3500f;
    float maxJump = 20f;
    bool timerEnabled = false;
    float delay = 2f;
    bool mort = false;

    private Rigidbody2D rb2d;
    private Animator anim;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("Air", !Sol);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        //  Reload le level au bout de delay(secondes)
        if (timerEnabled)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                SceneManager.LoadScene("MortMario");
            }
        }
    }
    void FixedUpdate()
    {
        if (!mort)
        {
            //  Regarde si on a appuye droite ou gauche(-1 et 1)
            float h = Input.GetAxis("Horizontal");
            //  Deplacement droite/gauche
            if (h * rb2d.velocity.x < maxSpeed)
                rb2d.AddForce(Vector2.right * h * speed);
            //  Vitesse Maximum
            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
            //  S'arrete directement
            if (h == 0)
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            //  Se tourne si on appuye a droite
            if (h > 0 && !facingRight)
                Flip();
            //  Se tourne si on appuye a gauche
            if (h < 0 && facingRight)
                Flip();
            //  Saute si "Fleche du haut est pressé"
            if (Sol && Input.GetKey(KeyCode.UpArrow))
                Jump();
        }
        //  Correction Jump
        if (rb2d.velocity.y > maxJump)
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxJump);
    }
    /*
     * Se tourne
     */
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    /*
     * Saute
     */
    public void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(Vector2.up * jumpForce);
        Sol = false;
        //  Correction Jump
        if (rb2d.velocity.y > maxJump)
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxJump);
    }
    /*
     * Enclenche la mort de mario
     */
    public void MarioMeurt()
    {
        //  Ajoute 1 au compteur de morts
        PlayerPrefs.SetInt("nbMorts", PlayerPrefs.GetInt("nbMorts") + 1);
        //  Supprime tout les collider
        Destroy(gameObject.GetComponent<Collider2D>());
        Destroy(GameObject.Find("Sol Detection"));
        //  Saute
        Jump();
        //  Set Sol a false
        mort = true;
        //  Fait l'animation de mort
        anim.SetBool("Dead", true);
        //  Active le timer avant le recommencement
        timerEnabled = true;
        //  Empeche tout mouvement de mario
        speed = 0;
        rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
    }
}