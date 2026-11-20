using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("各コントローラー")]
    [SerializeField] private PlayerGymController gymController_;
    [SerializeField] private PlayerBattleController battleController_;
    [Header("移動速度")]
    [SerializeField] private float MOVE_SPEED = 1.0f;

    //プレイヤーID
    public int playerId_ { get; set; }
    //トレーニングデータ
    public TrainingParamData trainingData_ { get; set; }
    //現在使える筋トレ器具
    public TrainingTool trainingTool_ { get; private set; }
    //現在アクティブなコントローラー
    public PlayerController controller_ { get; private set; }
    //プリレイヤーのリジッドボディ
    private Rigidbody rb_;

    private void Start()
    {
        if (gymController_ != null) gymController_.enabled = true;
        if (battleController_ != null) battleController_.enabled = false;
        controller_ = gymController_;

        rb_ = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerInputData input = controller_.currentInput_;
        Move(input);
        Training(input);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TrainingTool tool = collision.gameObject.GetComponent<TrainingTool>();
        if (tool == null) return;

        trainingTool_ = tool;

        Debug.Log("筋トレ器具を登録");
    }

    private void OnCollisionExit(Collision collision)
    {
        trainingTool_ = null;
    }

    private void Move(PlayerInputData input)
    {
        Vector2 move = input.move_;
        //もし入力ベクトルが0ベクトルなら抜ける
        if(move ==  Vector2.zero) return;

        Vector3 forward = transform.forward;
        //プレイヤーの前方ベクトルと入力ベクトルから移動方向を計算
        Vector3 moveDirection = (forward * move.x + forward * move.y).normalized;
        //速度分移動方向に移動
        transform.position = moveDirection * MOVE_SPEED;
    }

    private void Training(PlayerInputData input)
    {
        bool isInteract = input.interact_;
        //もしインタラクト中じゃなければ抜ける
        if (!isInteract) return;
        //もし使用できる筋トレ器具がなければ抜ける
        if (trainingTool_ == null) return;

        input.interact_ = false;

        var data = trainingData_;
        trainingTool_.ExecuteTraining(ref data);
        trainingData_ = data;

        Debug.Log($"攻撃力：{trainingData_.attackPowerCount}");
        Debug.Log($"攻撃速度：{trainingData_.attackSpeedCount}");
        Debug.Log($"移動速度：{trainingData_.moveSpeedCount}");
        Debug.Log($"ジャンプ力：{trainingData_.jumpForceCount}");
        Debug.Log($"HP：{trainingData_.hpCount}");

    }

    /// <summary>
    /// プレイヤーのモードを変更する
    /// </summary>
    /// <param name="mode">変更したいモード</param>
    public void SwitchMode(string mode)
    {
        //ジムモードなら
        if(mode == "GYM" || mode == "Gym")
        {
            gymController_.enabled = true;
            battleController_.enabled = false;
            controller_ = gymController_;
            return;
        }
        else if(mode == "BATTLE" || mode == "Battle")
        {
            gymController_.enabled = false;
            battleController_.enabled = true;
            controller_ = battleController_;
            return;
        }
    }
}
