# Obstacles!
 We need to add some difficulty to our game.  
 We will do that by adding two types of obstacles.  
 One that makes you lose and another that gives you points!  

We will start with spawning obstacles.

## Let's Code - Obstacle Spawner Script

Create a new script called "ObstacleSpawner"
> In the "ObstacleSpawner" script add the variables
> - public variable, named *river* of type **River**
> - public variable, named *spawnPrefab* of type **GameObject**
> - public variable, named *spawnFrequency* of type **float**
> - public variable, named *spawnPositionContainer* of type **Transform**
> - private variable, named *spawnTimer* of type **float**
> 
> In the "ObstacleScript" add a new method called "Spawn"
> - Takes one argument, named *position* of type **Vector3**
> - Returns **void**
> - The method is **private**
>  
> In the method "Spawn" in the "ObstacleSpawner" script
> - Instantiate a new GameObject with the arguments spawnPrefab, position and Quaternion.identity
> - store the returned value in a variable called spawned of type GameObject
> - call the method Add from the variable river and pass the "spawned" variable
> 
> In the method "Update" in the "ObstacleSpawner" script
> - decrease the variable spawnTimer with the value Time.deltaTime
> - if the variable spawnTimer is less than equal to zero
>   - set spawnTimer equal spawnFrequency
>   - retrieve a random child of spawnPositionContainer
>   - save the child's position to a variable called position
>   - call the method "Spawn" and pass the variable position

Code Example : [Link](resources/code-example/ObstacleSpawner_example.1.cs)

// todo - everythin below here

# Let's go back to Unity and hook up our GameObjects to our script
First create a new Cube 3D Object




## Add Points to the Game
reset points when we hit the River Banks

# Adding Obstacles

## Create Obstacle
    cube prefab with material

## Create ObstacleSpawner
    spawns prefab with a given frequency
    Spawns prefabs to predefined positions

## Create ObstacleSpawner Code

## Destroy Obstacle when boat hits it
    reset points as well



# Collecting Trash from River

## Create Trash
    cube prefab with material


## Destroy Trash when boat hits it
    and add points when collected trash

[<< Previous Lesson](lesson.10.md) | [Next Lesson >>](lesson.12.md)