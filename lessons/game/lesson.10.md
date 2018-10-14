# Do something when hitting the sides

## Let's Code - Reset Boat
Create a new script called **Boat**
(move it to the scripts folder to keep things organized)
> In the script **Boat** add the variable
> - public variable, named *initialPosition* of type **Transform**  
> 
> In the script **Boat** add a new method called "Reset"
> - Takes no arguments
> - Returns **void**
> - It method is **public**  
> 
> In the method "Reset" in the **Boat** script
> - Set the transform position to the initialPosition's position  
> 
> In the script **Boat** add a new method called "OnCollisionEnter"
> - Takes one argument, named *other* of type **Collision**
> - Returns **void**
> - The method is **private**  
> 
> In the method "OnCollisionEnter" in the **Boat** script
> - call the function "Reset"
> - add a Debug.Log line that prints the other **GameObject**

Code Example : [Link](resources/code-example/Boat_example.1.cs)

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

## 

[<< Previous Lesson](lesson.9.md) | [Next Lesson >>](lesson.11.md)