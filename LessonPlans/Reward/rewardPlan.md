# UnityML: Reward

This is the lesson plan for teaching the reward component of UnityML

## Core concepts:
1. Reinforcement learning
2. Positive and negative reinforcement
3. Connection to observation system


## Resources:
1. Slides: https://docs.google.com/presentation/d/14YSRRF1lUxlmlDdIiQ4hbgOBWVUxPgcgVIYDHyYwbgU/edit?usp=sharing
2. Code snippets (below)
3. Finalized infinite runner project


### Slideshow
- The slideshow is intended as a basic introduction to the concept of reward in machine learning
- It also introduces some UnityML syntax such as AddReward()
- The concepts in this slideshow should allow students to begin implementing the reward system in the AgentAction method


### Activity
- Filling in code snippets with the correct reward functions at appropriate times
- There are two files in the lesson plan for this section, one for the students to fill out and one as a key (RunnerAgent.cs)
- The key is not the only "correct" solution, many students may come up with slightly different implementations that work just as well

### Running their code
- To run the student code, copy their solution into a copy of the InfiniteRunnerML project (also in the repo)
- If we decide to leave all the rest of the code in the student solution template, it will run as is, otherwise we may need to copy their code into the rest of the RunnerAgent.cs file

### Important technical notes
- The student solution and key must be placed inside a copy of the unity project to run or interact with the unity API
- Depending on the ability level of the students we can either use prebuilt if statements and have them pick reward values, or let them think of conditions on their own
- Reward values are floats, if the students are seeing errors, try adding "f" after the number they chose  
(e.x. <b>AddReward(0.1f);</b> )

