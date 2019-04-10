
namespace BlueGOAPTest
{
    public enum ActionEnum
    {
        IDLE,
        ATTACK_IDLE,
        Alert,
        MOVE,
        ATTACK,
        INJURE
    }

    public enum GoalEnum
    {
        /// <summary>
        /// 攻击
        /// </summary>
        ATTACK,
        /// <summary>
        /// 警戒
        /// </summary>
        ALERT,
        /// <summary>
        /// 移动
        /// </summary>
        MOVE,
        /// <summary>
        /// 战斗待机
        /// </summary>
        ATTACK_IDLE,
    }
    
    public enum KeyNameEnum
    {
        /// <summary>
        /// 发现敌人
        /// </summary>
        FIND_ENEMY,
        /// <summary>
        /// 巡逻
        /// </summary>
        GO_ON_PATROL,
        /// <summary>
        /// 看向敌人
        /// </summary>
        LOOK_AT_ENEMY,
        /// <summary>
        /// 待机
        /// </summary>
        IDLE,
        /// <summary>
        /// 战斗待机
        /// </summary>
        ATTACK_IDLE,
        /// <summary>
        /// 移动
        /// </summary>
        MOVE,
        /// <summary>
        /// 临近敌人
        /// </summary>
        NEAR_ENEMY,
        /// <summary>
        /// 攻击
        /// </summary>
        ATTACK,
        /// <summary>
        /// 受伤
        /// </summary>
        INJURE,
        /// <summary>
        /// 消灭敌人
        /// </summary>
        KILLED_ENEMY
    }

    public enum DataName
    {
        /// <summary>
        /// 自身的Transform对象
        /// </summary>
        SELF_TRANS,
        /// <summary>
        /// 敌人的Transform对象
        /// </summary>
        ENEMY_TRANS
    }
}
