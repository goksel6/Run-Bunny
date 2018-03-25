using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_Code : MonoBehaviour {

    public GameObject[] lifes;
    public GameObject gameOverPanel, gamePanel;

    public Text distanceText, longestDistanceText;
    public Text carrotText, goldText, totalScore;
    public Text mesafeoyunsonuyazi, skormesafeyazi;
    public Text goldCount, carrotCount;

    public float speed, jumpForce, maxSpeed, distance, longestDistance=0;
    public int life, maxLife, carrot, gold;
    public bool onGround, doubleJump;

    public Transform startPoint;
    public AudioClip[] sounds;

    Rigidbody2D weight;
    Animator animator;

	void Start () {
        gameOverPanel.SetActive (false);

        animator = GetComponent<Animator>();
        weight = GetComponent<Rigidbody2D>();
        life = maxLife;
        LifeSystem();
	}
	
	void Update () {
        distance = Vector2.Distance(startPoint.position, transform.position);

        distanceText.text = (int)distance + "M";

        goldCount.text = " " + gold;
        carrotCount.text = " " + carrot;
        // Zıplama- Çift zıplama ayarları
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                weight.AddForce(Vector2.up * jumpForce);
                doubleJump = true;
            }
            else if(doubleJump)
            {     
                doubleJump = false;
                weight.AddForce(Vector2.up * jumpForce);
            }
        }
        if (life<=0)
        {
            Die();
        }
	}

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Gate")
        {
            carrot++;
            obj.gameObject.transform.root.gameObject.GetComponent<Path>().active = true;
        }
        if (obj.gameObject.tag == "Carrot")
        {
            carrot++;
            GetComponent<AudioSource>().PlayOneShot(sounds[0]);
            obj.gameObject.SetActive(false);
            

        }
        if (obj.gameObject.tag == "Gold")
        {
            gold++;
            GetComponent<AudioSource>().PlayOneShot(sounds[1]);
            obj.gameObject.SetActive(false);

        }
        if (obj.gameObject.tag == "Life")
        {
            if (life != maxLife)
            {
                life++;
                LifeSystem();
                GetComponent<SpriteRenderer>().color = Color.magenta;
                Invoke("Reform", 0.5f);
                Destroy(obj.gameObject);


            }
            GetComponent<AudioSource>().PlayOneShot(sounds[1]);
          
        }

    }
    private void FixedUpdate()
    {
        float s= Input.GetAxis("Horizontal");
        weight.AddForce(Vector2.right * s * speed);
        animator.SetFloat("Speed", Mathf.Abs(s));
        animator.SetBool("OnGround", onGround);

        //Geri dönüşlerde tavşanın suratını döndürmek için...
        if (s>0.1f){
            transform.localScale = new Vector2 (1,1);
        }
        if (s < 0.1f){
            transform.localScale = new Vector2(-1,1);
        }

        //Kaymayı ve ivmeyi engellemek için...
        if (weight.velocity.x > maxSpeed) { 
            weight.velocity = new Vector2(maxSpeed, weight.velocity.y);
        }
        if (weight.velocity.x < -maxSpeed)
        {
            weight.velocity = new Vector2(-maxSpeed, weight.velocity.y);
        }
    }
    void Die()
    {
        Time.timeScale = 0;
        GameOver();
        
        if (false)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        
    }
    //Değdiğimiz anda=> Enter (Tuzak sistemi)

    private void OnCollisionEnter2D(Collision2D theobject)
    {
        if (theobject.gameObject.tag == "Trap") 
        {
            GetComponent<AudioSource>().PlayOneShot(sounds[2]);
            life -= Random.RandomRange(1, 3);
            weight.AddForce(Vector2.up * jumpForce);
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("Reform", 0.5f);
            LifeSystem();
        }
    }
    //Rengini yarım saniye sonra eski haline döndürür
    void Reform()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void LifeSystem()
    {
        for (int i = 0; i < maxLife; i++)
        {
            lifes[i].SetActive(false);
        }
        for (int i = 0; i < life; i++)
        {
            lifes[i].SetActive(true);
        }
    }
    void GameOver()
    {
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
        mesafeoyunsonuyazi.text = "DISTANCE: " + (int)distance + "M";
        longestDistance = PlayerPrefs.GetFloat("BEST: ");

        goldText.text = "" + (int)gold;
        carrotText.text = "" + (int)carrot;
        int x = ((gold * 4) + (carrot * 2) + ((int)distance * 3));
        totalScore.text = "TOTAL SCORE: " + (int)x;

        if (longestDistance>distance)
        {
            skormesafeyazi.text = "BEST: " + (int)longestDistance + "M";
        }
        else
        {
            longestDistance = distance;
            PlayerPrefs.SetFloat("BEST: ", longestDistance);
            mesafeoyunsonuyazi.text = "DISTANCE: " + (int)longestDistance + "M";
            skormesafeyazi.text = "BEST: " + (int)longestDistance + "M";
        }

        
    }
    public void ButtonClick()
    {
        gameOverPanel.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);

    }
}
