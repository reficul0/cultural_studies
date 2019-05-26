
namespace Enemy
{
    public class Factory
    {
        public static Structure Create()
        {
            return CreateEnemy();
        }
        static Structure CreateEnemy()
        {
            Structure enemy = new Structure
            {
                hp = (int)Description.maxHp
            };
            //character.suitLevel = (uint)Description.SuitLevel.Common;

            return enemy;
        }
    }
}