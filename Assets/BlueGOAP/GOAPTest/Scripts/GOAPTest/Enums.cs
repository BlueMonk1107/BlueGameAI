
namespace BlueGOAPTest
{
    public enum ActionEnum
    {
        IDLE,
        MOVE,
        ATTACK,
        INJURE
    }

    public enum GoalEnum
    {
        ATTACK,
        IDLE
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
        /// 待机
        /// </summary>
        IDLE,
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
        INJURE
    }
}
