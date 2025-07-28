using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpPower;
    public int score;
    public GameManager manager;
    AudioSource getItem;
    bool isJump;
    Rigidbody rb;
    void Awake()
    {
        isJump=false;
        rb=GetComponent<Rigidbody>();
        getItem=GetComponent<AudioSource>();
    }
    void Update()
    {
        if(!isJump&&Input.GetButtonDown("Jump"))
        {
            isJump=true;
            rb.AddForce(new Vector3(0,jumpPower,0),ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float h=Input.GetAxisRaw("Horizontal");
        float v=Input.GetAxisRaw("Vertical");
        
        rb.AddForce(new Vector3(h,0,v),ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Floor")
            isJump=false;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Item")
        {
            score++;
            getItem.Play();
            other.gameObject.SetActive(false);
            manager.GetScore(score);
        }
        else if(other.tag=="Finish")
        {
            if(score==manager.totallScore)
                SceneManager.LoadScene("Stage1_"+(manager.stage+1).ToString());
            else
                SceneManager.LoadScene("Stage1_"+manager.stage);
        }
    }
}