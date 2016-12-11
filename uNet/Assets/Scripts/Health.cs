using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Health : NetworkBehaviour {
	public const int MaxHP = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int CurrentHP = MaxHP;
    public Slider HealthSlider;
    private NetworkStartPosition[] respawnPosition;

    void Start()
    {
        respawnPosition = FindObjectsOfType<NetworkStartPosition>();
    }

    public void TakeDemage(int demage)
    {
        if (isServer == false) return;  //血量处理只在服务器端执行
        CurrentHP -= demage;
        if (CurrentHP <= 0)
        {
            if (this.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
                return;
            }

            CurrentHP = MaxHP;
            Debug.Log("dead");
            RpcRespawn();
        }
    }

    void OnChangeHealth(int health)
    {
        HealthSlider.value = health / (float)MaxHP;
    }

    [ClientRpc] //remote process call
    void RpcRespawn()
    {
        if (!isLocalPlayer) return;
        Vector3 spawnPosition = Vector3.zero;
        //随机重生位置
        if (respawnPosition != null && respawnPosition.Length > 0)
        {
            spawnPosition = respawnPosition[Random.Range(0, respawnPosition.Length)].transform.position;
        }
        transform.position = spawnPosition;
    }
}
