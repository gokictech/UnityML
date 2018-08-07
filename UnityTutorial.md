# Introduction to Unity3D

This is a brief tutorial for the Unity3D game engine,
it contains basic concept overviews for the essential components
of Unity, and explains their relation to our UnityML project.

## Contents:
1. What is Unity?
2. Interface Overview
3. Hierarchy 
4. Inspector
5. Component
6. GameObject/Monobehavior
7. Prefab/Assets
8. Setting up UnityML
<hr/>

### 1. What is Unity?

Unity is a 3D game engine that provides framework and features to allow developers to
quickly and efficiently create games. Unity takes care of things that happen behind the scenes
like physics, rendering, editing, and exporting so that we can focus on implementing features.

Unity also contains many prebuilt structures we can use without having to create ourselves, for example,
<i>RigidBody</i> is a component that we can attach to objects in our game that allow the object to interact with
physics-- collisions, gravity, drag, etc., without us having to explicitly program any of these behaviors.

We can also use C# and the Unity API to write our own code to add custom behavior to objects in the game, without
having to rely on prebuilt components.

### 2. Interface Overview

The Unity interface can be very overwhelming at first. Unity is often used to develop high end games, and therefore has many
features that we won't need to use for our project. Before proceeding, I recommend switching your layout to "2 by 3"
so that your editor looks like mine throughout this tutorial. 
This can be done by selecting <b>window -> layouts -> 2 by 3</b> at the top of your editor. Your editor should now look
something like this:

![alt text](https://i.imgur.com/0LhoZp2.png)

Here we can see many features and menus that will be very useful for our project.
- In the top left we have the Scene view, in this window we can manipulate objects in our game in 3D (even while
the game is running if we want to). The Scene view is useful to edit and view our game before it is actually running, 
we can also use to to view invisible debugging tools that may be useful in development but should not be seen by the player.

- In the bottom left we have the game view, this reflects what a player playing our game would actually see during gameplay.
It is controlled by our "main camera", a <b>GameObject</b> in our scene. To change the perspective of the player, we can move
the camera in the scene view, or control it with a script later on. 

- Along the middle of the editor we have the hierarchy, this is a list of all the GameObjects currently in our scene. 
We can create new objects in our scene by interacting with this menu. We can also select objects in ther heirarchy
by clicking on them to manipulate them in the <b>Inspector</b> window on the far right. 

- On the far right we have the inspector window, this allows us to view and manipulate selected objects and their components.
To open an object in the inspector we can click on it in the heirarchy, or in the asset window.

- Between the inspector and the heirarchy we have the asset window. This allows use to see a list of resources we can use in our game.
This includes items like classes and scripts, textures, librarys, prefabs, and other items we will use in our game. 


### 3. Hierarchy

In the hierarchy we can create new GameObjects, and manipulate existing ones in our scene. 

To create a new GameObject, right click in the hierarchy. We will mostly be using "create empty" and "3D object" for our
project. Try creating a new empty object in the hierarchy. You should see it listed alongside the items that were already
there when the scene was created. 

![alt text](https://i.imgur.com/KLtQWfD.png)

Once selected you can also view the properties and components of the GameObject in the inspector. 

### 4. Inspector

The inspector is where we can add and remove components to a GameObject, as well as change their properties.

![alt text](https://i.imgur.com/po8sh0u.png)

Here we can see that our new empty GameObject only has 1 component, "Transform". All GameObjects in Unity have at least
a Transform component. By editing the values of the Transform component we can change physical properties of the object
such as its position in the scene, its rotation, and its scale along the XYZ axes. We can also edit these properties in the
scene view using the transform, rotate, and scale tools.

We can add new components to our GameObject by selecting the "Add Component" button, here we have access to a huge
list of prebuilt components that we can use in our game. 

### 5. Component
Components are essentially behaviors we can add to a GameObject to give it functionality in our game.
Delete the empty game Object we previously created by selecting it in the hierarchy and pressing delete.
Create a new GameObject in the hierarchy, this time opting for 3D object -> Sphere. You will notice this new Sphere
already comes with several components other than transform. Mesh Filter, Mesh Renderer, and Sphere Collider are all components
used to control rendering and physical interaction with other GameObjects. Try pressing the play button at the top of the editor.
You will notice that nothing spectacular happens, the sphere just floats there. That's pretty boring, lets try adding
some behavior to the Sphere. Click add component and search for Rigidbody. Click it to add the component to our Sphere
GameObject.

![alt text](https://i.imgur.com/eumPyUa.png)

The Rigidbody component gives our Sphere GameObject the ability to interact with the built in physics engine in Unity.
By editing the properties of the Rigidbody in the inspector we can tweak how the object will behave. We can change properties
like Mass and Drag, we can toggle interaction with Gravity, and we can even use Constraints to prevent the object from
moving or rotating on specific axes. Try pressing play now, the object will quickly fall out of frame due to gravity.
Press play again to end the game and return it back to its original state. 

### 6. GameObject/Monobehavior
Lets try adding our own custom behavior to our Sphere. Lets say we don't want our sphere to leave our screen so fast, 
but we still want it to interact with gravity and physics. In the inspector click add component and start typing "BallController".
We will see that this component doesn't already exist, so lets make it! Hit </b>New Script -> Create and Add</b> to create
our new script component. You will notice that the script is now added as a component on our Sphere GameObject. A new asset
was also added to our asset window called "BallController", this is the new class we just created. Double click on it in either
the inspector or asset window to open it in your editor. I Use Visual Studio 2017 Community. Here we will see some code
has already been written for us, as all GameObjects in Unity extend the "Monobehavior" class. 

![alt text](https://i.imgur.com/KMrqFiq.png)

Here we see that two methods have already been created in our class, Start() and Update(). They should already have comments
over them explaing that they do.
- Start() is called once, when the object is created. (When you press play, or if the object is created during runtime)
- Update() is called every frame, about 60 times per second. 

We are going to write some code here to allow the player to make the sphere "jump" when we press a button. 
First we need a refrence to the Physics component of the GameObject, the Rigidbody we added earlier. 
Create a new private variable in the class: <code>private Rigidbody rb;</code>

Next we want to get a refrence to the Rigidbody component once the game starts. Within the Start() method add the following
code: <code>rb = gameObject.GetComponent<Rigidbody>();</code> to store a refrence to the Rigidbody in the rb variable.
This will search the current gameObject for a Rigidbody component and return it if it finds it, otherwise it returns null.

Note: "gameObject" (lowercase g) refers to the GameObject of the object the script is attached to, "GameObject" refers to
static methods and variables of the GameObject class that we can use to find and manipulate other gameObjects in the scene.

Next we need to check if the player as pressed a button and if they have we want to manipulate the Rigidbody accordingly.

in the Update() method add the following code:

![alt text](https://i.imgur.com/uX8K1oc.png)

This code uses the Input class to check if the "Space" key was pressed on this frame.
If it was, it calls the AddForce() method of Rigidbody and applies force in the upward direction using Vector3.up.

Try pressing play now, before the ball falls too far, try pressing space a couple times. You'll notice that the ball barely
jitters before falling offscreen. This is because we didn't apply very much force, try creating a new public class variable
called "force" as a float and initializing it to a value of 500f;

Now in the Update method, multiply the force added by our new force variable. Now when you press play you'll notice the ball
jumps much higher when you press space. Also, since the variable is public, it's serialized by the editor, and we can change
it in the inspector, much like we could change the properties of the Rigidbody!
![alt text](https://i.imgur.com/8YBJ1ok.png)

If something isn't quite working right, or you see any error messages in the bottom left, ensure your code looks like this:
![alt text](https://i.imgur.com/dmGfkvZ.png)
 
### 7. Prefab/Assets
Lets say we want to save this Sphere setup for later, we can drag it from the inspector into the asset window to create a
new "prefab". Prefabs are GameObjects that we can save as assets to easily clone or reuse later. Try creating a new
Sphere prefab by dragging the one we made into the asset window. 

![alt text](https://i.imgur.com/ZwY4Y4a.png)

We should now see it listed with our other assets! Try dragging it back into the hierarchy to create a new instance of our
Sphere prefab, offset it slighly in the inspector under transform, or use the transform handles in the scene view. 

![alt text](https://i.imgur.com/p6HdTEm.png)

If we press play we'll notice that both of the balls jump when you press space, because they both have Rigidbody components
as well as the script we created before. We can edit the force property of each sphere separately via the inspector, or even
change it in the prefab to affect new copies we create later. 

Similarly, all assets we have can be edited in the inspector if applicable. 

At the top of the inspector for the spheres in the scene we see options to select, apply, and revert
- Select will select the associated prefab in the asset window
- Apply will apply differences in this instance of the prefab to the prefab asset
- Revert will revert differences in this instance to the properties of the prefab asset


Next we will cover UnityMl, feel free to delete what we have added, or create a new project all together.
<hr>

### 8. Setting up UnityML

These are the very basics of the Unity Engine. Now lets prepare our project to use UnityML.
Save the current Scene, this will allow us to reopen it later. 

Download the UnityML assets from https://github.com/Unity-Technologies/ml-agents

Under the unity-environment folder, copy the contents of "assets" into the asset window of your unity editor.
You may need to open the asset folder in windows explorer to do this.

Next we need the tensorsharp plugin from https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Using-TensorFlow-Sharp-in-Unity.md
Under the requirements header. 

![alt text](https://i.imgur.com/4uUoBsx.png)

Download it and import it into the Unity editor via <b>Assets -> import package -> custom package...</b>

Allow Unity to decompress and import it, and press Import to finish importing all the assets.

Next we want to configure our project to work with tensorflow. At this point please ensure that tensorflow is installed
correctly on your machine. 

In the editor select <b>Edit -> project settings -> Player</b> To open the Unity Player settings in your inspector window.
From here navigate to the "other settings" section and make the following changes:
- Under Scripting Define Symbols* type in: <code>ENABLE_TENSORFLOW</code> and press enter to confirm. This will allow
your Unity editor to communicate with tensorflow. 

- Above that change the Scripting runtime version to .NET 4.x equivalent. Once this is done, you will be prompted to restart your editor.
Do this now.

Your project is now configured and ready to use UnityML. If you see any errors about broken assembly's for either
android or iOS feel free to ignore them or delete the offending plugins under Assets -> ML-Agents -> plugins. These errors
are occuring because we did not configure the editor to build for either of those platforms.
 




