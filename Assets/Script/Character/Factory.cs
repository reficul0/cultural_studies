
namespace Character
{
    public class Factory
    {
        public static Structure Create()
        {
            return CreateCharacter();
        }
        static Structure CreateCharacter()
        {
            Structure character = new Structure();

            character.energy = (int)Description.maxEnergy;
            character.suitLevel = (uint)Description.SuitLevel.Common;

            return character;
        }
    }
}