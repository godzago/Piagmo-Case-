using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Money settings
    int money;
    int rongdorspenal = 25;
    int minCoinCount = 30;

    [Header("Move Speed & health")]
    [SerializeField] private float movSpeed = 3;
    public float health = 100;
    private float speedX, speedY;

    // Logic
    bool gameOver = false;
    bool rongArea = false;

    // Referance
    private Rigidbody2D rgb;
    private PlayerScorUpdate scorUpdate;
    private rongDor rongDorsS;

    private void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        scorUpdate = GetComponent<PlayerScorUpdate>();
        rongDorsS = GameObject.Find("rongDors01").GetComponent<rongDor>();
    }

    public void Start()
    {
        EventManager.Instance.onDedicateCoin += DedicateCoin;
        EventManager.Instance.onDamage += onDamage;
    }

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
            speedY = Input.GetAxisRaw("Vertical") * movSpeed;
            rgb.velocity = new Vector2(speedX, speedY);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            money += coin.money;
            other.gameObject.SetActive(false);
            AudioManager.instance.PlaySFX("coineffect");
        }
        if (other.TryGetComponent(out rongArea area))
        {
            rongArea = true;
        }

        if (other.TryGetComponent(out WinDor win))
        {
            if (money > minCoinCount)
            {
                AudioManager.instance.PlaySFX("Wineffect");
                win.winScren.SetActive(true);
                gameOver = true;
            }
        }
        if (other.TryGetComponent(out rongDor rongDors))
        {
            AudioManager.instance.PlaySFX("Rongeffect");
            health -= rongdorspenal;
        }
    }
        
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out rongArea area))
        {
            rongArea = false;
        }
    }

    private void Update()
    {
        if (health > 0 && rongArea == true)
        {
            health -= Time.deltaTime * 5;
        }
        else if (health < 0)
        {
            rongDorsS.LossScren.SetActive(true);
            AudioManager.instance.PlaySFX("Loseeffect");
            gameOver = true;
            Debug.Log("game over");
        }
    }

    public void DedicateCoin(object sender, EventArgs e)
    {
        if (money > minCoinCount)
        {
            scorUpdate.coinSpriteUpdate();
        }
        money = money;
        Debug.Log("money  : " + money);
        scorUpdate.updateScor(money);
    }

    public void onDamage(object sender, EventArgs e)
    {
        int my›nt;
        my›nt = Mathf.CeilToInt(health);
        health = health;
        Debug.Log("health  : " + health);
        scorUpdate.updateDamege(my›nt);
    }
}