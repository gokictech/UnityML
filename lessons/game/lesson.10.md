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


// todo - everything below here  
Go back to Unity
 - Create BoatStartPosition gameobject
    - No collider, no mesh renderer, same position as the boat
 - Add Boat script to Boat gameobject
    - Set initialPosition variable in Boat script to BoatStartPosition GameObject
---
[<< Previous Lesson](lesson.9.md) | [Next Lesson >>](lesson.11.md)