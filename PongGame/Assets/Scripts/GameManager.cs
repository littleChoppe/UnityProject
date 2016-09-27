using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Use this for initialization
    public GameObject Player1;
    public GameObject Player2;

    private BoxCollider2D upWall;
    private BoxCollider2D downWall;
    private BoxCollider2D rightWall;
    private BoxCollider2D leftWall;

    private int score1;
    private int score2;

    public Text score1Text;
    public Text score2Text;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
    }
	void Start () {
        ResetWall();
        ResetPlayer();
	}

    void ResetWall()
    {
        upWall = transform.Find("UpWall").GetComponent<BoxCollider2D>();
        downWall = transform.Find("DownWall").GetComponent<BoxCollider2D>();
        leftWall = transform.Find("LeftWall").GetComponent<BoxCollider2D>();
        rightWall = transform.Find("RightWall").GetComponent<BoxCollider2D>();
        //Vector3 upWallPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
        //upWall.transform.position = upWallPosition + new Vector3(0, 0.5f, 0);
        //Vector3 rightUpPoint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //upWall.size = new Vector2(rightUpPoint.x * 2, 1);

        Vector3 rightUpPoint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        upWall.transform.position = new Vector3(0, rightUpPoint.y + 0.5f, 0);
        upWall.size = new Vector2(rightUpPoint.x * 2, 1);

        downWall.transform.position = new Vector3(0, -rightUpPoint.y - 0.5f, 0);
        downWall.size = new Vector2(rightUpPoint.x * 2, 1);

        leftWall.transform.position = new Vector3(-rightUpPoint.x - 0.5f, 0, 0);
        leftWall.size = new Vector2(1, rightUpPoint.y * 2);

        rightWall.transform.position = new Vector3(rightUpPoint.x + 0.5f, 0, 0);
        rightWall.size = new Vector2(1, rightUpPoint.y * 2);
    }

    void ResetPlayer()
    {
        Vector3 player1Position = Camera.main.ScreenToWorldPoint(new Vector2(100, Screen.height / 2));
        player1Position.z = 0;
        Player1.transform.position = player1Position;

        Vector3 player2Position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width -100, Screen.height / 2));
        player2Position.z = 0;
        Player2.transform.position = player2Position;
    }

    public void ChangeScore(string wallName)
    {
        if (wallName == "RightWall")
        {
            score1++;
        }
        else
        {
            score2++;
        }
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
    }

    void ResetScore()
    {
        score1 = 0;
        score2 = 0;
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
    }

    public void Reset()
    {
        ResetScore();
        ResetPlayer();
        GameObject.Find("Ball").SendMessage("ResetBall");
    }
}
