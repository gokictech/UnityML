# UnityML: Observation

This is the lesson plan for teaching the observation component of UnityML

## Core concepts:
1. What are observations
2. Making good observations
3. Avoid useless information

## Resources:
1. Slides: https://docs.google.com/presentation/d/1yD5PUpNY-_mq9tbVcdnVUPZR6jyDVYCqZ7M-bvIQJAE/edit?usp=sharing
2. Code snippets (in folder)
3. UnityML infinite runner project (in git repo)

### Slides:
- The slides contain information explaining what an observation is
- Basic Unity syntax (collectObservation and AddVectorObs)
- exercise and discussion about what things we should observe

### Activity: 
- Filling in code snippets
- Students will add observations to the network
- Students will also need to avoid useless observations

## Running their code
- To run the student code, copy their solution into a copy of the InfiniteRunnerML project (also in the repo)
- If we decide to leave all the rest of the code in the student solution template, it will run as is, otherwise we may need to copy their code into the rest of the RunnerAgent.cs file

### Important technical notes
- The student solution and key must be placed inside a copy of the unity project to run or interact with the unity API
- Depending on the ability level of the students we can either use prebuilt if statements and have them pick reward values, or let them think of conditions on their own
- Reward values are floats, if the students are seeing errors, try adding "f" after the number they chose  
(e.x. <b>AddReward(0.1f);</b> )

