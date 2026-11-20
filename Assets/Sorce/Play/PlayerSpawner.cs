using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [Header("プレイヤーのプレハブ")]
    [SerializeField] private GameObject playerPrefab;
    [Header("プレイヤーのスポーン位置")]
    [SerializeField] private Vector3[] spawnPoints;
    [Header("プレイヤーの数")]
    [SerializeField] private int playerCount = 2;
    [Header("プレイヤーの初期アクションマップ")]
    [SerializeField] private string initialActionMap = "Gym";

    private void Start()
    {
        int playerIndex = 1;

        //接続されているゲームパッドを取得
        int gamepadCount = Gamepad.all.Count;
        //ゲームパッドの数だけプレイヤーをスポーン
        for(int i = 0; i < gamepadCount; i++)
        {
            InputDevice device = Gamepad.all[i];
            SpawnPlayer(playerIndex, device, "Gamepad");
            playerIndex++;
            if(playerIndex > playerCount) return;
        }

        //まだスポーンしていないプレイヤーがいる場合は、キーボード＆マウスを割り当てる
        if (Keyboard.current != null)
        {
            InputDevice device = Keyboard.current;
            SpawnPlayer(playerIndex, device, "Keyboard&Mouse");
            playerIndex++;
            if(playerIndex > playerCount) return;
        }
    }

    /// <summary>
    /// プレイヤーをスポーンさせる
    /// </summary>
    /// <param name="id">プレイヤーのID</param>
    /// <param name="device">割り当てたい入力デバイス</param>
    /// <param name="controlScheme">コントロールスキーム</param>
    private void SpawnPlayer(int id,InputDevice device,string controlScheme)
    {
        // プレイヤーのスポーン位置を決定
        Vector3 spawnPosition = spawnPoints[id - 1];
        // プレイヤーをスポーン
        GameObject player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        // プレイヤーの名前を設定
        player.name = $"Player{id}";
        //プレイヤーのIDを設定
        Player pl = player.GetComponent<Player>();
        if(pl != null)pl.playerId_ = id;

        // プレイヤーの入力デバイスを設定
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        if(playerInput != null)
        {
            // プレイヤーのデバイス・コントロールスキームを設定
            playerInput.SwitchCurrentControlScheme(controlScheme, device);
            // プレイヤーの初期アクションマップを設定
            playerInput.SwitchCurrentActionMap(initialActionMap);
        }
    }
}
