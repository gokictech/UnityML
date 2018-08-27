# UnityML lesson outline: Observations

## Key Concepts
- Observations are how the AI agents “see”
- Observations are used to create the neural networks input layer
- We use float values between -1 and 1 for continuous observations
	Breakdown
1. Observations are how we tell our AI what’s going on
	- We can use distances, speeds, and positions, as well as other things to measure what is happening in our game
	- We need to keep our observations between 0 and 1, or -1 and 1, divide them by the maximum!
	- More observations means better information for our AI, but also slower performance, make sure to only give it what is actually useful!
2. Connection to the neural network
	- Observations are input!
	- We need the same number of observations in the same order every time we give them to the network
3. Behind the scenes
	- The neural network trains to associate certain inputs with certain outputs
	- Later we use reward to tell it how well it’s doing, and how much it should change by
## What we need to do:

1. Set up Unity Editor and ML assets
2. Set up infinite runner lesson
	- Take out parts we want the kids to do
3. Add comments with instructions and hints for what to add
4. Brain settings for num inputs and outputs
## What we should abstract
 1. Actual observation collection, easier raycasting
 2. Normalization 

