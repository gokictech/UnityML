# Introduction to UnityML

This is a brief overview of how to set up a UnityML project.
This tutorial assumes that you are familiar with Unity, I recommend
following UnityTutorial.md first, the last step of which contains important
information about configuring your Unity editor to work with Unity ML assets.

In this tutorial we will go over setting up a version of our Infinite Runner project.

Extra resources:
- https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Training-ML-Agents.md
- https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Learning-Environment-Create-New.md

## Contents: 
1. Basic setup
2. Scene setup
3. Training and exporting
4. Additional information

### 1. Basic setup
This section will primarily cover content from step 8 of the Unity Tutorial,
while more in depth, if you are already comfortable with that section you can 
safely skip to Scene setup.

First, create a new Unity Project, save the scene. We will need to import our UnityML assets
and configure our editor to communicate with tensorflow. 
- Download the tensorsharp unity package from: https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Using-TensorFlow-Sharp-in-Unity.md
- Download the Unity ML assets from: https://github.com/Unity-Technologies/ml-agents


1. Import the tensorsharp package into unity via Assets -> Import package -> custom package...  
2. Copy the contents of the assets folder unity Unity-Environment from the ML assets folder into your projects assets folder
3. Open up the Unity Player settings via Edit -> Project settings -> Player
4. Navigate to the other settings section and type "ENABLE_TENSORFLOW" into scripting define symbols, press enter after
5. Changing the scripting runtime version to .NET 4.x Equivalent, restart the editor when prompted
6. Delete unused plugins for Android and iOS platforms to avoid errors created by broken binaries

![alt text](https://i.imgur.com/nfixpQ8.png)

Our project is now configured to use UnityML and we can begin designing our agent and scene.

### 2. Scene setup

#### Academy
Unity ML requires several GameObjects in our scene to work. First, we need our Academy, this GameObject will manage 
the Brain and training process. Create a new Empty GameObject called RunnerAcademy. Add a new script component to 
RunnerAcademy called RunnerAcademy. In the script remove both the Start() and Update() methods as we won't need them 
for this projects Academy. Add a Using MLAgents statement to the top of the script, then change the base class to Academy.

This is all we need for the Academy in this project, as all functionality we will be using from it is inherited from the 
Academy class.

![alt text](https://i.imgur.com/bYLO9kQ.png)

#### Brain
Next we need to create the Brain GameObject that our Agent will interact with.
Create a new GameObject called Brain as a child of RunnerAcademy.
Attach UnityML's Brain component to it.
By editing the properties of the brain component we can change the networks input size and type, output size and type,
and configure our brain to either communicate with tensorflow for training, or use existing training data.
For now, leave the Brain type as player. 

![alt text](https://i.imgur.com/YjmjnWM.png)
#### Agent and Game
Now we must design our game and agent. Create a new 3D Plane GameObject and name it floor.
Change the scale on the Z-Axis to 2. This GameObject will act as the floor of the lane in our infinite runner game.
On the Mesh Renderer component, change the material from default-material to floor. This is purely aesthetic and can be
changed later. Next create 2 Cube GameObjects, move and scale them to act as walls for the sides of the lane.
Your Scene view and hierarchy should now look something like this:

![alt text](https://i.imgur.com/ZlUlKm8.png)

Now that we have our lane, lets design the agent!

Create a new Sphere GameObject called RunnerAgent and place it at the start of the lane: <b>~(0, 0.5, -9)</b>.
Add a Rigidbody component to the RunnerAgent, under constraints, enable constraints for position on the Y and Z axis,
as well as rotation on the X and Y axis. This will ensure the Agent only moves and rotates left and right. 

Similarly to the Floor Object, change the material of the RunnerAgents Mesh Renderer to something easier to see, I chose "Gold".

Now we can start writing code for our agent. Attach a new script component to the RunnerAgent called RunnerAgent.
Add a Using statement for MLAgents, and change the Base class to Agent.

Delete the Update() method as we will not need it for the agent. Add a public field called speed as a float, set the default value to 5f.
Create a private field called startPos as a Vector3. In the Start() method set startPos to tranform.position.
This saves the starting position of the agent to make reseting it easier later. Speed will be used to adjust how fast
the agent moves when it receives input. 

Now lets design our agent reset method, this will be called when the Agent is marked Done() when it either fails or completes
A task, and allows us to easily reset our agent to continue training. 
#### Agent Reset

Create a public override void method called AgentReset(), within this method we need to reset the agent back to it's starting state.
First we need to reset the position, simply set transform.position = startPos; This will reset the agent back to the starting position
we saved earlier. This is better than just changing the coordinates directly so that we can easily work with multiple parallel agents
on different coordinates. 

We also need to reset the properties of the Agents Rigidbody. Create a private field called rb as a Rigidbody.
In the start method, set rb = gameObject.getComponent<Rigidbody>(); This will set the rb variable to a reference to
this gameObjects Rigidbody component. 

In the AgentReset() method, add the following to reset the Rigidbodys properties:
```
rb.velocity = Vector3.zero; 
rb.angularVelocity = vector3.zero;
```

This will stop any movement or rotation the ball has when Done() is called. 

#### Observations

Now we need to collect observations about the game to send to the network. This effectively acts as the input
layer for our neural network. 

Create a new public override void method called CollectObservations(). 

In this method we can use the AddVectorObs Method to send information the the neural network.
In Unity, we can use a strategy called Raycasting. Raycasting essentially draws an invisible line from a position, 
towards a specified direction, and returns information about the first thing it hits. 

In this Project, we will use several raycasts to give our agent distances in various directions so it can make
decisions about how to react.

Additionally we will give the network the velocity of the agent on the X axis so it knows how fast it's moving.
All of these values should be normalized between [-1, 1] for the best results. First lets create a class constant
called MAX_OBS_DIST as a float with a value of 20f. We will use this to limit the distance of our raycasts and normalize
the distances of the things we hit. 

In the CollectObservations() method lets create a RaycastHit variable called hit. As we raycast we can store information
about what we hit in this variable, and use it to send inputs to the neural network. 
To see more information about Raycasting and syntax check the Unity API at: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html

First lets check the distances to the left and right of the Agent:
```
Physics.Raycast(transform.position, Vector3.left, out hit, MAX_OBS_DIST); 
```
An important note about Raycasts in Unity is that if they travel their max distance without hitting anything, the distance
property of the RaycastHit hit variable will be 0. To avoid telling the agent that something is "0" units away, we will pass the normalized
version of the MAX_OBS_DIST variable to the network, which will be 1!

We can achieve this by using an if statement to test if the collider property of hit is not null.   
```C#
if(hit.collider)  
{  
    AddVectorObs(hit.distance / MAX_OBS_DIST);  
}   
else  
{  
    AddVectorObs(1);  
}  
```

We can repeat this process to get the distance on the right by changing the direction of the raycast from Vector3.left to Vector3.right and copying the if else statements.  

Now we need to get distances in front of the agent, as well as diagonally, it's up to you exactly how many to use, you can adjust the direction of the raycast by adding together
various combinations of Vector3.forward, Vector3.left, and Vector3.right in the direction parameter of the Raycast.
I'm going to be using 5, Left-Left-forward, Left-forward, forward, Right-Forward, and Right-right Forward.

In the main version of the infinite runner I opted to used many more raycasts in a 180 degree fan using a forloop and some trigonometry. 
It's definitely harder to understand and control, so if you would rather use that strategy I recommend copying the code for that piece in the repo. 

To keep the code readable in this example, i'm also going to create a private helper method to return the normalized version of the distance to avoid
repeating the if/else block over and over. We can also use that to simplify the if/else block above to <code>AddVectorObs(normalizedDistance(hit));</code>

If you'd like you can further factor this down to make it more readable by making a method that takes a direction and returns a RaycastHit. 
Or even just return the normalized distance.  

Lastly we want to give the network one more input, the current velocity on the x-axis.
We can do this by reading the X value Rigidbodys velocity parameter and dividing it by speed to normalize it.

Your collectObservations method should now look something like this:

![alt text](https://i.imgur.com/Jb5Tgvu.png)

In this method we called AddVectorObs() a total of 8 times, that means we the input layer of our network should expect 
8 inputs. In the Brain GameObjects Brain component, change the vector observation space size to 8 to reflect this.

#### Actions
Now we need to collect the output from the network and use it to manipulate our Agent.  
This is also where we can assign reward values for various things that happen in the game, and mark our agent as Done()
if it has either completed or failed the task.

Create a public override void method called AgentAction() with the parameters (float[] vectorAction, string textAction).  
vectorAction is an array of float values representing the output of our neural network, textAction is a string version 
of this data that we will not actually be using in this Agent. 

Before we go about controlling our Agent, lets think about what behaviors we want to reward and punish.
- Positive reward associated with surviving over time
- Negative reward for hitting obstacles

It is often useful to have smaller rewards to act as suggestions for the agent as for how to behave. 
In the future we could try adding a small reward for each obstacle avoided, a small punishment for being
close to an obstacle, or any other ideas that may help the agent learn better. 

Similar to Raycasts, the Physics class in Unity also has a method called OverlapSphere that returns information
about all the colliders within a certain radius of a position. We can use this to look for objects near our Agent.

We can get an array of nearby colliders using the following line:  
Collider[] nearby = Physics.OverlapSphere(transform.position, 0.51f, LayerMask.GetMask("Obstacle"));  

This OverlapSphere starts at the position of the agent (transform.position), looks within a radius of 0.51 units,
and returns only Colliders from GameObjects on the Layer "Obstacle" which we will define later in this project and assign to our obstacles.

We could than iterate through the obstacles and assign small rewards and punishments based on the distances of the obstacles, but for this
example we will just worry about whether or not the agent has failed.  
We can use an if statement to do this, if nearby.Length > 0 that means an obstacle was within the radius we chose above, and we consider that
A collision, use addReward(-1f); to assign a negative reward for this outcome, and called Done() to reset the agent and begin a new training episode.
else, we can add a small positive reward, something like addReward(0.01f);

Now lets move on to actually controlling the agent. We need to apply force to the Rigidbody to move the agent, this force
is going to be determined by the output of the network.

We can do this by first creating a Vector3 called controlSignal and setting it to Vector3.zero, this will give us a new Vector3 of
(0, 0, 0). We can than set the X component of controlSignal to the first (and only) output of the network, vectorAction[0].
We can than apply this as a force to the Rigidbody after multiplying it by our speed field.

![alt text](https://i.imgur.com/DxM3Mne.png)

Since we want the network output to be between [-1, 1] we need to change the vector action space type to continuous instead of discrete
in the Brain.

Here is a look at the final code in case anything went wrong along the way:

<details><summary>CLICK ME</summary>
<p>

```C#
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using MLAgents;

	public class RunnerAgent : Agent {

		public float speed = 5f;
		public const float MAX_OBS_DIST = 20F;

		private Vector3 startPos;
		private Rigidbody rb;

		void Start () {
			startPos = transform.position;
			rb = gameObject.GetComponent<Rigidbody>();
		}

		public override void AgentReset()
		{
			transform.position = startPos;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		public override void CollectObservations()
		{
			RaycastHit hit;
			//left
			Physics.Raycast(transform.position, Vector3.left, out hit, MAX_OBS_DIST);
			AddVectorObs(normalizedDistance(hit));
			//right
			Physics.Raycast(transform.position, Vector3.right, out hit, MAX_OBS_DIST);
			AddVectorObs(normalizedDistance(hit));
			//left left forward
			Physics.Raycast(transform.position, Vector3.left + Vector3.left + Vector3.forward, out hit, MAX_OBS_DIST);
			AddVectorObs(normalizedDistance(hit));
			//left forward
			Physics.Raycast(transform.position, Vector3.left + Vector3.forward, out hit, MAX_OBS_DIST);
			AddVectorObs(normalizedDistance(hit));
			//forward
			Physics.Raycast(transform.position, Vector3.forward, out hit, MAX_OBS_DIST);
			AddVectorObs(normalizedDistance(hit));
			//right forward
			Physics.Raycast(transform.position, Vector3.right + Vector3.forward, out hit, MAX_OBS_DIST);
			AddVectorObs(normalizedDistance(hit));
			//right right forward
			Physics.Raycast(transform.position, Vector3.right + Vector3.right + Vector3.forward, out hit, MAX_OBS_DIST);
			AddVectorObs(normalizedDistance(hit));
			//speed
			AddVectorObs(rb.velocity.x / speed);

		}

		public override void AgentAction(float[] vectorAction, string textAction)
		{
			Collider[] nearby = Physics.OverlapSphere(transform.position, 0.75f, LayerMask.GetMask("Obstacle"));
			if(nearby.Length > 0)
			{
				//the agent has hit an obstacle
				AddReward(-1f);
				Done();//calls agent reset

			}
			else
			{
				//the agent has survived (for now)
				AddReward(0.01f);

			}

			Vector3 controlSignal = Vector3.zero;
			controlSignal.x = vectorAction[0];
			rb.AddForce(controlSignal * speed);
		   
		}

		private float normalizedDistance(RaycastHit hit)
		{
			if(hit.collider)
			{
				return hit.distance / MAX_OBS_DIST;
			}
			else
			{
				return 1f;
			}
		}
	}

```
</p>
</details>


#### Testing agent action

Lets test the AgentAction method by setting up player controls for the brain, make sure the brain is set to player:
- Expand the key continuous player actions section and change the size value to 2, we are going to map these to the outputs of the network
- We want to test the effects of the output -1 and 1, essentially seeing how the agent would react of that is what the neural networks output was
- For element 0, set the key to A, leave the index at 0, and set the value to -1. This means that when we press "A" we want vectorAction to have a value of -1 in the 0th index.
This means we are essentially simulating an output of -1.
- For element 1, do the same but use the D key, and a value of 1. 
- If you are more comfortable with arrow keys you can use those instead of A and D, you can use whatever keys you want. 

Before we can test, we need to tell the Agent to use the Brain in our scene, do this by opening the agent in the inspector and dragging the Brain from
the hierarchy into the Brain field of the RunnerAgent component we created.

Press play and try using the keys you chose above to move the agent! If everything was successful you should now see the agent rolling around in response to your key presses!
Press play again to resume editing.

#### Obstacles and management
Phew! Ok, hard part is over, the rest of Scene setup is just using Unity to create and manage the game itself, then we can move onto testing. 
This part is highly reliant on the concept of prefabs, if you aren't familiar with them brush up on the prefab section in the Unity Tutorial document. (part 7)

We are going to create an Obstacle Manager GameObject to spawn, manage, and remove obstacles at appropriate times during the game.

Create a new empty GameObject called ObstacleManager and place it at the end of the lane <b>(0, 0.5, 10)</b>

Lets attach a new script component to it called ObstacleManager:  
First we need to tell it what the obstacle is, create a public GameObject field called obstacle, we will set the value later via the editor.
Next, create a public float called delay, set it to a default value of 4f. This variable will determine how long the manager waits
between obstacles. Create another private float called lastSpawn, this will. hold the time at which the last obstacle was created.
We also want to have references to all the obstacles we have create so we can easily remove them later, create a private List<GameObject>
called spawnedObstacles. 

In the start method initialize our list to a new List<GameObject>();  
Also set lastSpawn to 0f;


Lets think about what needs to happen in update: 
- We need to check how long it's been since we last spawned an obstacle
- If it has been long enough, we need to create a new one and add it to the list
- We need to update lastSpawn so this process works again next Update()

Lets use an if statement:

```
if(Time.time > lastSpawn + delay)
{
	//spawn a new obstacle
	//add it to the list
	//update lastSpawn
}
```

Here we are checking if the time the game has been running (Time.time) is greater than when we last spawned an obstacle + our chosen delay,
now we need to implement the spawning and updating of the list.

We can create a new copy of a prefab using the Instantiate method, which also returns a reference to it, lets also create
A random offset for the obstacle
```
Vector3 offset = new Vector3(Random.Range(-3.75f, 3.75f), 0f);
GameObject newObs = Instantiate(obstacle, transform.position + offset, Quaternion.identity);
```

This means we are creating a new copy of the obstacle prefab GameObject, and giving it the transform (position, rotation, and scale) of the current GameObject (Obstacle Manager)

Lastly we need to add the obstacle to our list, and update lastSpawn to be the current time:

```
spawnedObstacles.Add(newObs);
lastSpawn = Time.time;
```

Great! Now once we create our obstacle prefab we can start our game, before we do that lets add a reset method to the ObstacleManager
to make reseting our Agent easier.

Create a new public void method called ResetObstacles(), in this method iterate through the list and use the Destroy() method
to get rid of all obstacles, then clear the list. The reason we can do this without a concurrent modification exception is because
the Destroy method just marks them for deletion within Unity, it doesn't actually do it until after the current Update() cycle is done.
```
public void resetObstacles()
{
	foreach(GameObject obs in spawnedObstacles)
	{
		Destroy(obs);   
	}

	spawnedObstacles.Clear();
}
```

Here is a look at the entire script:
<details><summary>CLICK ME</summary>
<p>

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

    public GameObject obstacle;
    public float delay = 4f;
    private float lastSpawn;
    private List<GameObject> spawnedObstacles;

	void Start ()
    {
        spawnedObstacles = new List<GameObject>();
        lastSpawn = 0f;
	}
	
	void Update ()
    {
        if(Time.time > lastSpawn + delay)
        {
            Vector3 offset = new Vector3(Random.Range(-3.75f, 3.75f), 0f);
            GameObject newObs = Instantiate(obstacle, transform.position + offset, Quaternion.identity);
            spawnedObstacles.Add(newObs);
            lastSpawn = Time.time;
        }	
	}

    public void resetObstacles()
    {
        foreach(GameObject obs in spawnedObstacles)
        {
            Destroy(obs);   
        }

        spawnedObstacles.Clear();
    }
}

```
</p>
</details>

Now lets design an obstacle prefab:
Create a new cube GameObject in the scene called obstacle. In the inspector set the Layer 
property to a new layer called Obstacle. Change the scale of the Obstacles transform to <b>(2, 1, 1)</b>  
Change the material under the mesh rendered to something a little flashier, I chose "obstacle".

Attach a new script component called ObstacleScript.

Create a new public field called speed as a float and give it a default value of 0.03f.
This will determine how far the obstacle moves towards the Agent every Update().

Since the Agent only gets information about the Obstacle every Physics update, we should change
Update() to FixedUpdate(), this simply means it's called every physics udpate instead of every frame, about
half as often (30/sec). 

We want to delete the obstacle once it passes the player, check if the position on the z axis is less than the players (-9).
If it is, use Destroy(gameObject) to delete the Obstacle.

Otherwise we want to move it towards the player, use transform.translate to move it -speed in the z directions

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

    public float speed = 0.03f;
	
	void FixedUpdate () {
        if (transform.position.z < -9)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(new Vector3(0f, 0f, -speed));
        }
	}
}
```

#### Final setup and testing

Now, return to the editor and drag the obstacle into the asset window to create a prefab, then delete it from
the hierarchy.

In the ObstacleManager inspector, drag the Obstacle prefab into the Obstacle property, now the ObstacleManager
has a refrence to the prefab so it knows what to spawn.

Before we start testing the game, update the Layer of the lane walls to also be Obstacle.
We also need to tell RunnerAgent to reset the obstacles in agent reset.

inside of RunnerAgent.cs, add a new public field called manager as an ObstacleManager, then in the editor
drag the ObstacleManager from the hierchy to the new field in RunnerAgent. 
Now within the AgentReset method we can add 
```
manager.resetObstacles();
```

Now we are ready to play our game, move the Main Camera to a more comfortable position, and hit play!
Try avoiding the obstacles and watching the agent and obstacles reset when you hit one!

### 3. Training and exporting
Now we can start training our network, change the brain type to external.  
Open up CMD and change directory to the location of the python folder within your ML agents assets, for example  
<b>C:\ml-agents-master\python</b> in my case. 

At this point ensure that you have all the required python modules installed, as well as tensorflow. 

- https://www.tensorflow.org/install/install_windows

Now run this command in CMD:  
python learn.py --train  
It may take several seconds, but the following should pop up: 

![alt text](https://i.imgur.com/yOJaPvU.png)

Once it appears, press play in the Unity Editor to begin training! Unity will massively increase the timescale
of your game so it may appear jittery. Experiment with editing variables in the trainer_config.yaml file to change how the training behaves,
specifically try increasing the maximum number of steps to give the training more time.

Because of design decision made throughout this project, we are also totally ready for parallel training, create a new empty GameObject called
gameInstance, set the position to (0, 0, 0), and drag the agent, wall, floor, and obstacle generator onto it so they become its child objects. 

Now you can just copy and paste the setup, offsetting it on the X axis, and you now have multiple independent instances of the game all interacting with the network.
Once you are satisfied with training, a folder will appear in your ml agents assets directory called ppo, it should be under python-> models

Copy the .bytes file and place it in the assets folder for your unity project, you can now swtich the Brain to internal and use this .bytes as the Brains graph model.

Now press play, and the agents will play the game using your training data!

### 4. Additional Information
In my testing with 10 parallel agents and about 200,000 steps of training, I was able to get a pretty competent network that could
survive for several seconds.

If you want to experiment further, try changing the number or type of inputs. 














