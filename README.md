# Shooting game

Improved the spaceship game;
https://ariel-gamers.itch.io/shooting-spaceship

From Q1 - I decided to limit the amount of shots per second to 0.5 by default, I did this by changing the `KeyboardSpawner` script - counting the time since the last shot 
and only allowing the laser to spawn if 0.5 seconds have passed.

The cool down is serialized so you can change it in game through the editor.

My original change was to create another prefab, which spawned randomly from every portal and shot towards the player position.

I created a script called `DebrisShooter` which spawns a prefab from every portal.

Each spawn first calculates the vector of the player as well as its current position
it then calcualtes the vector needed for the velocity
```csharp
Vector3 starting_point = base.transform.position;
            Vector3 ending_point = player.transform.position;

            Vector3 velocity_vector = (ending_point - starting_point);
            float dist = velocity_vector.magnitude;
            velocity_vector /= dist;
            velocity_vector *= speed;
```
The vector is normalized over the distance and set at a certain speed. The speed is also configurable through the editor as well as the spawn rate. 

In order for the player to be hit by the debris, I needed to add it as a trigger to the player and destroy them. 
