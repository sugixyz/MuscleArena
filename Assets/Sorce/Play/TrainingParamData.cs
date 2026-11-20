using System;
using UnityEngine;

[Serializable]
public struct TrainingParamData
{
    public int attackPowerCount;
    public int attackSpeedCount;
    public int moveSpeedCount;
    public int jumpForceCount;
    public int hpCount;

    /// <summary>
    /// 効果に応じて数値を変更する
    /// </summary>
    /// <param name="type">効果が出るパラメータ</param>
    /// <param name="amount">変更する数値</param>
    public void AddStat(TrainingStatType type,int amount)
    {
        switch(type)
        {
            case TrainingStatType.ATTACK_POWER:
                attackPowerCount += amount;
                break;
            case TrainingStatType.ATTACK_SPEED:
                attackSpeedCount += amount;
                break;
            case TrainingStatType.MOVE_SPEED:
                moveSpeedCount += amount;
                break;
            case TrainingStatType.JUMP_FORCE:
                jumpForceCount += amount;
                break;
            case TrainingStatType.HP:
                hpCount += amount;
                break;
        }
    }
}
