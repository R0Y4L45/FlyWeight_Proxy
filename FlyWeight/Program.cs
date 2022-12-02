// FlyWeight Pattern with example of Counter
// Strike Game


// A common interface for all players
interface Player
{
    void assignWeapon(string weapon);
    void mission();
}

// Terrorist must have weapon and mission
class Terrorist : Player
{
    // Intrinsic Attribute
    private string task;

    // Extrinsic Attribute
    private String weapon;

    public Terrorist()
    {
        task = "PLANT A BOMB";
    }
    public void assignWeapon(String weapon)
    {
        // Assign a weapon
        this.weapon = weapon;
    }
    public void mission()
    {
        //Work on the Mission
        Console.WriteLine("Terrorist with weapon "
                           + weapon + "|" + " task is " + task);
    }
}

// CounterTerrorist must have weapon and mission
class CounterTerrorist : Player
{
    // Intrinsic Attribute
    private string task;

    // Extrinsic Attribute
    private string weapon;

    public CounterTerrorist()
    {
        task = "DIFFUSE BOMB";
    }
    public void assignWeapon(string weapon)
    {
        this.weapon = weapon;
    }
    public void mission()
    {
        Console.WriteLine("Counter Terrorist with weapon "
                           + weapon + "|" + " task is " + task);
    }
}

// Class used to get a player using HashMap (Returns
// an existing player if a player of given type exists.
// Else creates a new player and returns it.
class PlayerFactory
{
    /* HashMap stores the reference to the object
       of Terrorist(TS) or CounterTerrorist(CT).  */
    private static Dictionary<string, Player> hm =
                         new Dictionary<string, Player>();

    // Method to get a player
    public static Player GetPlayer(string type)
    {
        Player p = null;

        /* If an object for TS or CT has already been
           created simply return its reference */
        if (hm.ContainsKey(type))
            p = hm[type];
        else
        {
            /* create an object of TS/CT  */
            switch (type)
            {
                case "Terrorist":
                    Console.WriteLine("Terrorist Created");
                    p = new Terrorist();
                    break;
                case "CounterTerrorist":
                    Console.WriteLine("Counter Terrorist Created");
                    p = new CounterTerrorist();
                    break;
            }

            // Once created insert it into the HashMap
            hm[type] = p;
        }
        return p;
    }
}

// Driver class
public class CounterStrike
{
    // All player types and weapon (used by getRandPlayerType()
    // and getRandWeapon()
    private static String[] playerType =
                    {"Terrorist", "CounterTerrorist"};
    private static String[] weapons =
      {"AK-47", "Maverick", "Gut Knife", "Desert Eagle"};


    // Driver code
    public static void Main()
    {
        /* Assume that we have a total of 10 players
           in the game. */
        for (int i = 0; i < 10; i++)
        {
            /* getPlayer() is called simply using the class
               name since the method is a static one */
            Player p = PlayerFactory.GetPlayer(getRandPlayerType());

            /* Assign a weapon chosen randomly uniformly
               from the weapon array  */
            p.assignWeapon(getRandWeapon());

            // Send this player on a mission
            p.mission();
        }
    }

    // Utility methods to get a random player type and
    // weapon
    public static string getRandPlayerType()
    {
        Random r = new Random();

        // Will return an integer between [0,2)
        int randInt = r.Next(playerType.Length);

        // return the player stored at index 'randInt'
        return playerType[randInt];
    }
    public static string getRandWeapon()
    {
        Random r = new Random();

        // Will return an integer between [0,5)
        int randInt = r.Next(weapons.Length);

        // Return the weapon stored at index 'randInt'
        return weapons[randInt];
    }
}