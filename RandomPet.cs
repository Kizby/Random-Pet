using HarmonyLib;
using XRL.Rules;
using XRL.UI;
using XRL.World;

namespace XRL.RandomPet
{
    [HarmonyPatch(typeof(CreateCharacter), "GenerateCharacter")]
    public static class Patch
    {
        static void Prefix()
        {
            var options = GameObjectFactory.Factory.GetBlueprintsWithTag("StartingPet");
            if (0 == options.Count) {
                return;
            }
            var result = options[Stat.Random(0, options.Count - 1)];
            CreateCharacter.Template.Pet = result.Name;
            CreateCharacter.Template.PetName = result.DisplayName();
        }
    }
}