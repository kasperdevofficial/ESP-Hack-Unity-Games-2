# ESPHack
To use the ESP Hack Cheat, create a new hack function and find an Active class and a new OnGUI function like that and that's it .... 

----------

TO ESP HACK FREE

Code
------

private void OnGUI () 
{

global :: ESPHack.OnGUI ();

global :: ESPHack.PlayerESP = true

global :: ESPHack.EspBox = true;

global :: ESPHack.EspLine = true;

global :: ESPHack.EspName = true;

}
-----

Active classes UIRoot AudioManager PlayerController SoundManager AdsManager
-------------------------------------------------------------------------------
Get in the game and see the impact

And now add a new enemy (GameObject) to the ESP
Looking for an active class, an active method such as OnGUI, Awake, Start

Code
------

private void Start () 
{
    Gameobject gameobject = new GameObject(); // Example
    if (gameobject != null) // If this object is inactive
	  {
        GameObject obj = gameobject // Object
        string name = "Enemy" // Name
        float clr = new Color(255f, 255f, 255f, 0) // RGB Color
        float hg = 0.7f // Hight
        float sz = 1.3f // Size
        ESP.tryAddEnemy(obj, name, clr, hg, sz);
    }
}
-----
ESP is our class, tryAddEnemy is the method




