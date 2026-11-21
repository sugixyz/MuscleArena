using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;

public enum TrainingStatType
{
    ATTACK_POWER,
    ATTACK_SPEED,
    MOVE_SPEED,
    JUMP_FORCE,
    HP
}

[Serializable]
public struct StatGainEntry
{
    [Tooltip("変更するパラメータの種類")]
    public TrainingStatType type;

    [Tooltip("1回のアクションで変化させるポイント")]
    public int delta;
}

public class TrainingTool : MonoBehaviour
{
    [Header("器具の名前")]
    [SerializeField] private string toolName_;
    [Header("トレーニング効果設定")]
    [SerializeField] private List<StatGainEntry> statGains_ = new List<StatGainEntry>();

    public string name_ {  get { return toolName_; } }

    public void ExecuteTraining(ref TrainingParamData trainingData)
    {
        foreach(StatGainEntry entry in statGains_)
        {
            trainingData.AddStat(entry.type, entry.delta);
        }
    }
}
