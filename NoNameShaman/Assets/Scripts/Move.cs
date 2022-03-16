using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public GameObject Next;
    public GameObject GameOverMenu;
    public GameObject Character;

    public SceneManager MyScene;
    public SceneManager NextScene;

    private Rigidbody2D _Rigidbody2D;
    public float jumpForce;
    public float MovmentSpeed;

    public float coin;
    public Text CoinText;

    public AudioSource AudioS;
    public AudioSource AudioDeath;

    private void Start()
    {
        
        Time.timeScale = 1;
       _Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // A D Jump Kodlarý
        var movment = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movment,0,0) * Time.deltaTime * MovmentSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_Rigidbody2D.velocity.y) < 0.001f)
        {
            _Rigidbody2D.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
        }
        // Saða Sola dönerken oraya bakmasý kodu
        if (!Mathf.Approximately(0, movment))
        {
            transform.rotation = movment > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }    
    }
    // Coinleri alma
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Coin")
        {
            AudioS.Play();
            coin ++;
            CoinText.text = coin.ToString();
            Destroy(other.gameObject);
        }
    }
    // Fire çarpma
    
    private void OnCollisionEnter2D(Collision2D collision)
    {           
        if (collision.gameObject.tag == "Fire")
        {
            
            AudioDeath.Play();
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
            if (coin >= 10)
            {
               Time.timeScale = 0;
               Next.SetActive(true);
               GameOverMenu.SetActive(false);
            }       
        }
    }
 
}


