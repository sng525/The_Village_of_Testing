using Moq;

namespace The_Village_of_Testing;

public class RandomClass
{
    Random rand = new Random();

    public virtual Worker ReturnRandomWorker(int nameLength)
    {
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z"};
        string[] vowels = { "a", "e", "i", "o", "u"};
        string name = "";
        while (name.Length < nameLength)
        {
            name += consonants[rand.Next(consonants.Length)].ToUpper();
            name += vowels[rand.Next(vowels.Length)];
        }
        string[] occupationList = { "farmer", "miner", "woodcutter", "builder" };
        
        var occupation = occupationList[rand.Next(occupationList.Length)];
        return new Worker(name, occupation);
    }
}