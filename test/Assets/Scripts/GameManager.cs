using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totallScore;
    public int stage;
    public Text StageScore;
    public Text PlayerScore;
    void Awake()
    {
        StageScore.text="/ "+totallScore;
    }
    public void GetScore(int count)
    {
        PlayerScore.text=count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
            SceneManager.LoadScene("Stage1_"+stage);
    }
}