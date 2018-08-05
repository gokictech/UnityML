# Project Title
Unity Infinity Runner Bootcamp

# Basic Information
Name: Rafael Bayer, Libby Knell  
Leads: Tiago Damasceno, Fernando Sanchez    
Team: Curriculum Development - Video Game & AI  
Start Date: 07/02/2018  
End Date: 08/31/2018

# Summary
One of the most engaging paltforms for teaching kids tech has been video game development. With kids learning how to build their own video games we want to use this opportunity to introduce kids to the the basic concepts of AI and Machine Learning. This will serve as a session to keep kids excited about what they are learning, an opportunity to stitch together what they are learning and a taste of how machines can learn. The goal is to build a 5 hour guided tutorial to build an infinity runner that uses Unity ML to teach the computer how to play and have the kids playing against other kids trained agents.

> Electricity changed how the world operated. It upended transportation, manufacturing, agriculture and health care.  
> AI is poised to have a similar impact. AI is becoming the new electricity - Andrew Ng[1]

AI is being engraved in every aspect of our society with Gartner predicting it as a new general-purpose technology beginning a 75-year technology cycle that will have far-reaching implications for every industry with machine learning being the most notable successes across industries [2]. As AI becomes seamlessly integrated in our society, diversity will be key to ensure a fair usage and implementation of new services and algorithms [3]. It is our duty at GOKiC to not only get the next generation ready to code, but to build a basic understanding of AI and machine learning and how it can affect and improve our communities.

[1] Andrew Ng, https://news.stanford.edu/thedish/2017/03/14/andrew-ng-why-ai-is-the-new-electricity/   
[2] Gartner, https://www.gartner.com/events-na/data-analytics/wp-content/uploads/sites/5/2017/10/Data-and-Analytics-Predictions.pdf  
[3] Timnit Gebru, https://www.technologyreview.com/s/610192/were-in-a-diversity-crisis-black-in-ais-founder-on-whats-poisoning-the-algorithms-in-our/

# Getting Started

### Git
Version control systems allows us to manage source code changes over time. It allows us to keep track of every modification we do to code and/or files. It also has the advantage that if mistakes or bugs are introduced, we can always revert back to an earlier state. We use Git/Github as our version control system and our code repository:

1. Install [Git](https://git-scm.com/downloads)
2. Read [Git documentation](https://git-scm.com/book/en/v2) chapters 1-4 or go through their [online tutorial](http://try.github.com/).
3. Git [cheat-sheet](https://www.atlassian.com/git/tutorials/atlassian-git-cheatsheet)
4. Clone this repository
5. Review the [branching structure](https://nvie.com/posts/a-successful-git-branching-model/?) we use.

A few more optional resources:
- What is version control and benefits [link](https://www.atlassian.com/git/tutorials/what-is-version-control).
- Why Git [link](https://www.atlassian.com/git/tutorials/why-git)

### Development Process
1. Clone repository, there must be at least two branches master and dev (git clone repo_url)
2. Change into the dev branch (git checkout dev)
3. Make a new branch out of dev with branch name format 'user-dev-feature' (git branch -b user-dev-feature)
4. Make a pull request (PR) to get your code reviewed.
5. Fix any [merge conflicts](https://help.github.com/articles/resolving-a-merge-conflict-using-the-command-line/) if any.
6. After all comments are addressed,  merge with dev.
7. When the new features are ready to production (ideally every week) we repeat 3-5 to merge dev into master.

This means that all production deployments happen form the master branch. No one has direct permission to master and all development must happen through a new branch out of dev except for hotfixes. Those are allowed to branch out of master, but must be merged back into master *and* dev to avoid conflicts in the future.

### Unity
1. Install [Unity](https://unity3d.com/get-unity/download)
2. Explore Unity learning [website](https://unity3d.com/learn)
3. Go through the begginner [tutorials](https://unity3d.com/learn/tutorials)
4. Prepare a presentation with all learning.

### Unity ML
Unity ML is majorly based on the theory behind reinforcement learning. As you ramp-up on Unity ML, start ramping-up also in the machine learning topic below.
- Unity's ML website https://unity3d.com/machine-learning
- Unity ML Documentation https://github.com/Unity-Technologies/ml-agents/tree/master/docs
- Blog post introducing Unity ML https://blogs.unity3d.com/2017/09/19/introducing-unity-machine-learning-agents/

### Machine Learning
Required online courses and resources (in order):
1. Reinforcement learning introduction https://ai.intel.com/demystifying-deep-reinforcement-learning/
2. Practical introduction http://www.fast.ai/
3. Theory introduction https://www.coursera.org/learn/machine-learning

Optional courses and resources:
- Deep learning https://www.coursera.org/specializations/deep-learning
- Theory of machine learning [CalTech](https://www.edx.org/course/learning-data-introductory-machine-caltechx-cs1156x-0)
- Reinforcement learning [Berkley](http://rail.eecs.berkeley.edu/deeprlcourse/)
- Tutorial on deep reinforcement learning [ICML](https://icml.cc/2016/tutorials/deep_rl_tutorial.pdf)

Setting up your machine to use machine learning with python
1. Install conda
2. Create a new conda environment for Python 3.6
3. Install tensorflow for CPU or GPU (if you have any).
4. Install keras
5. Install pytorch

# Plan

### Week 1
Iteration: 1807-1  
Milestones: Onboarding, Understanding  GOKiC, Understanding Project Requirements.  
Deliverables:
- Team introduction
- GOKiC values understanding
- Review existing documentation on GOKiC vision, programs, current projects.
- Follwup get started section
- Setup and get familiar with unity game develpment 

### Week 2
Iteration: 1807-2  
Milestones: Deep understanding of Unity ML agents and algorithms we can use  
Deliverables:
- Get familiar with unitiy ML development
- Update markdown documentation with a list of [example projects](https://blogs.unity3d.com/2018/03/15/ml-agents-v0-3-beta-released-imitation-learning-feedback-driven-features-and-more/) or [open source projects](https://github.com/UnityTechnologies/MachineLearningRoguelike) to learn Unity ML
- Setup and run a couple of unity ML project to explore options from the SDK, e.g training with tensorflowsharp vs python, brain types.
- Update documentation on available unity ML algorithms and how can it be applied to different games.
- Setup a presentation with mentor and manager to explain the games mechanics.
- Presentation should also cover fundamentals of Unity ML, how it works.
- Presentation should also explain how to setup the project
- Presentation should include a working demo of the example project
- Presentation should walkthrough the code to explain how all components work.

### Week 3
Iteration: 1807-3  
Milestones: Infinity runner prototype for N simultaneous agents.  
Deliverables:
- Implementation of an infinity runner in 3D
- The game should be able to run multiple simltaneuous agents.
- The game should track the reward each agent is collecting.
- The game should support at this point human agents and random agents. 
- Uupdates are sent to the team on how the game is looking to gather early feedback.

### Week 4
Iteration: 1807-4  
Milestones: Add support for ML agents with a neuroevolution library implementation.  
Deliverables:
- Research summary of multiple open source implementations of neuroevolution librarues that work with Unity.
- Update markdown documentation to explain the details of the learning algorithm, e.g. genetic algorithms, population, mutation. Here's an easy to follow introduction [library](https://github.com/xviniette/FlappyLearning/blob/gh-pages/Neuroevolution.js) in javascript. 
- Design, implement and render the concept of 'sensors' in an agent. 
- Sensors could be for instance the agent's field of vision, it's velocity, distance to ground hole, ... 
- Integrate the neuroevolution library into ML agents using agent's sensors as input for the neural net.
- Students should be able to easily code/configured which sensors to use before training.
- Students should be able to code/configure key components of the neuroevolution algorithm.
Deliverables if open source library *not* available: 
- Upadte markdown doc with design of a neuroevolution library to train ML agents. 
- Implementation of the neuroevolution algorithm in a public GOKiC repository.
- The library should be self-contained and test automation must be added
- The library should contain documentation on public interfaces
- The library should contain instructions or a single-click script to run all tests.
- The library should allow a user to inspect or step into the algorithm at important stages to allow for visualizations.

### Week 5 - Midpoint Checkpoint
Iteration: 1808-1  
Milestones: Guided tutorial in markdown  
Deliverables:
- Tutorial includes a pe-requisites section/steps, e.g. downloading unity, SDK, git. Estimate the time to finish.
- Tutorial clearly states the concepts the students will learn.
- Tutorial covers some coding on game mechanics, ML agent training and experimentation with sensors. 
- Tutorial broken into 10-15 steps introducing new concepts with the following format:
    - Summary explanation of the new concept
    - Explanation on how to proceed
    - Code with placeholders
    - Clear goals 
    - Run test or write the expected results
    - Images explaining step
    - [not for student] Difficulty estimate: easy, medium, hard
    - [not for student] Time estimate to finish the step (see open questions)
- Tutorial should aim for 3-4 hours (e.g. 15 steps * 15 min = 3:45 hrs)
- Tutorial should also contain suggestions on what's next for students that finish fast.
- Prepare a small questionnaire, about 10 questions, to measure concept understanding.  

### Week 6 & 7
Iteration: 1808-2, 1808-3  
Milestones: Tutorial dry-run with a few CS and non-CS people  
Deliverables:
- Select a few set of people to get feedback from: CS/Non-CS background, teachers with experience k-9, ...
- Users will go through the tutorial with minimal help.
- Written consent must be collected from all participants to collect extensive feedback/notes of their experience to improve the tutorial.
- Gather extensive notes in your markdown doc as they work through the tutorial documenting:
    - Roadblocks: was there something not explicit in the instructions, did we miss a pre-req, ...
    - Bugs: did the participant hit bugs in our code, what kind of bugs did they introduce as they go.
    - Time estimates: track the time to complete steps for every participant to evaluate against our estimates.
    - Difficulty: was a particular step complicated, complex, confusing. First take an observational note, then ask for feedback at the end.
    - Concept understanding: ask participants to write about what they learned, why it's useful, ask a few 'challenge' questions on how to use the new concepts. Make estensive notes on what concepts were clear vs confusing, exciting vs non-exciting, ...
    - Feedback: ask for open ended feedback but *only* at the end of the study, e.g. likes, dislikes, difficulty

### Week 8
Iteration: 1808-4  
Milestones: Post user study retrospective  
Deliverables:
- Retrospective on feedback gathered, adding personal comments to them.
- Prioritized and actionable plan to improve the tutorial based on feedback. 
- Plan presentation to mentors/manager to sign-off on it. 
- Data analysis on accuracy of our time and difficulty estimates.
- Present why we think estimates were off and proposals on improving accuracy.  

### Week 9
Iteration: 1809-1  
Milestones: User study plan implementation and project transition  
Deliverables:
- P0 action items from user study are addressed
- Project transition must ensure at least one person can build/run the project from scratch
- Documentation of missing steps while building/running the project from scratch.

# Prioritized Goals

**Priority:** 0  
**Title:** Plan Iterations  
**Goals:**  
- Read project goals
- Ask for clarification on goals
- Update project goals to better explain the goals

**Priority:** 0  
**Title:** Setup and get familiar with unity develpment  
**Goals:** 
- Setup dev environment with Unity, Python, Tensorflow, Unity ML Agents SDK, Git Repository, IDE 
- Get familiar with unitiy development by going through a couple of unity game tutorials.
- Prepare a markdown document with all the learning on unity development
- Research online for best practices on untity development: code structure, utilities, ...

**Priority:** 0  
**Title:** Setup, run your first unity ML project  
**Goals:** 
- Get familiar with unitiy ML development documentation
- Setup dev environment with ML Agents SDK
- Update your markdown documentation with a list of [example projects](https://blogs.unity3d.com/2018/03/15/ml-agents-v0-3-beta-released-imitation-learning-feedback-driven-features-and-more/) or [open source projects](https://github.com/UnityTechnologies/MachineLearningRoguelike) to learn Unity ML
- Setup and run a couple of unity ML project to explore options from the SDK, e.g training with tensorflowsharp vs python, brain types.
- Update your documentation on available unity ML algorithms and how can it be applied to different games.

**Priority:** 0  
**Title:** Demo presentation to explain the core concepts of Unity ML  
**Goals:** 
- Setup a presentation with mentor and manager to explain the game mechanics.
- Presentation should also cover fundamentals of Unity ML, how it works.
- Presentation should also explain how to setup the project
- Presentation should include a working demo of the example project
- Presentation should walkthrough the code to explain how all components work.

**Priority:** 0  
**Title:** Infinity runner prototype for N simultaneous agents.  
**Goals:** 
- Implement an infinity runner prototype in 3D
- The game should be able to run multiple simltaneuous agents.
- The game should track the reward each agent is collecting.
- The game should support at this point human agents and random agents.  

**Priority:** 0   
**Title:** Neuroevolution library  
**Goals:**  
- Research multiple open source implementations of this algorithms that could work with Unity.
- Update your documentation with the list of implementations found.
- Understand the details of the learning algorithm, here's an easy to follow introduction [library](https://github.com/xviniette/FlappyLearning/blob/gh-pages/Neuroevolution.js) in javascript. 
- If there's no open source library to reuse, design & implement a generic neuroevolution library to train ML agents. 
- The library should be self-contained and test automation must be added
- The library should contain instructions or a single-click script to run all tests.
- The library should allow a user to inspect or step into the algorithm at important stages to allow for  visualizations.
- Update your documentation with the most important concepts to teach regarding neuroevolution, e.g. genetic algorithms, mutation, ...

**Priority:** 0   
**Title:** Add support for ML agents leveraging the neuroevolution library.  
**Goals:** 
- Design, implement and render the concept of 'sensors' in an agent. 
- Sensors could be for instance the agent's field of vision, it's velocity, distance to ground hole, ... 
- Integrate the neuroevolution library into ML agents using agent's sensors as input for the neural net.
- Students should be able to easily code/configured which sensors to use before training.
- Students should be able to code/configure key components of the neuroevolution algorithm.

**Priority:** 0   
**Title:** Guided tutorial in markdown  
**Goals:** 
- Tutorial should first include a pe-requisites section/steps, e.g. downloading unity, SDK, git. Estimate the time to finish.
- Tutorial should clearly state the concepts the students will learn.
- Tutorial should cover some coding on game mechanics, ML agent training and experimentation with sensors. 
- Tutorial should be broken into 10-15 steps introducing new concepts with the following format:
    - Summary explanation of the new concept
    - Explanation on how to proceed
    - Code with placeholders
    - Clear goals 
    - Run test or write the expected results
    - Images explaining step
    - [not for student] Difficulty estimate: easy, medium, hard
    - [not for student] Time estimate to finish the step (see open questions)
- Tutorial should aim for 3-4 hours (e.g. 15 steps * 15 min = 3:45 hrs)
- Tutorial should also contain suggestions on what's next for students that finish fast.
- Prepare a small questionnaire, about 10 questions, to measure concept understanding.  
Notes:
- The less the student has to prepare in pre-requisites the better, automate or package as much as as you can to be ready in a few clicks.
- As you go through the steps, think of '[unplugged activities](https://studio.code.org/s/coursed-2018)' this are exciting for kids as they motivate group interactions and allow for kids to help each other. 
- See the 'resources' section for inspiration on other platforms doing similar teaching.

**Priority:** 1   
**Title:** Dry-run of the tutorial with a few CS and non-CS people  
**Goals:** The main goal is to conduct a user study to improve our tutorial:
- Select a few set of people to get feedback from: CS/Non-CS background, teachers with experience k-9
- You will let them go through the tutorial without help or trying to intervene as less as possible.
- Before starting ask for consent on the dynamics since you will take extensive notes of their experience to improve the tutorial.
- Gather extensive notes as they work through the tutorial documenting:
    - Roadblocks: was there something not explicit in the instructions, did we miss a pre-req, ...
    - Bugs: did the participant hit bugs in our code, what kind of bugs did they introduce as they go.
    - Time estimates: track the time to complete steps for every participant to evaluate against our estimates.
    - Difficulty: was a particular step complicated, complex, confusing. First take an observational note, then ask for feedback at the end.
    - Concept understanding: ask participants to write about what they learned, why it's useful, ask a few 'challenge' questions on how to use the new concepts. Make estensive notes on what concepts were clear vs confusing, exciting vs non-exciting, ...
    - Feedback: ask for open ended feedback but *only* at the end of the study, e.g. likes, dislikes, difficulty
Notes:
- Having students write about what they learned and why it’s useful can help to solidify the concepts they learned.

**Priority:** 1  
**Title:** Post user study retrospective  
**Goals:** 
- Do a retrospective on all feedback we gathered, internalize it and understand it.
- Prepare a prioritized and actionable plan to improve the tutorial. 
- Present the plan to your mentors/manager to sign-off on it. 
- The plan must also cover a data analysis on the accuracy of our time and difficulty estimates.
- The analysis needs to present why we think the estimates were off and proposals on how to close the gap.  
Guideline for task priorities in your plan:
- Priority 0 - Needs to be fixed to go through tutorial, e.g. roadblocks, bugs in our code. 
- Priority 1 - Updates to smooth the tutorial, e.g. confusing or very complex steps.
- Priority 2 - New ideas that could improve the experience

**Priority:** 2  
**Title:** The game allows students to save and load trained agent brains.  
**Goals:** 
- Provide a high level concept or wireframes on how students will save/load trained brains.
- Provide an interface to save neural nets in multiple formats, with at least one implementation for tensorflow.js   
- Implementation and test automation on this feature.

**Priority:** 2  
**Title:** The game allows to record and playback games.  
**Goals:**
- Design and implementation of the record and playback component. 
- Automatically save/serialize the last N games
- Provide an option at the end of a game to save a replay.
- Collect a sample of anonymous saved games of new people playing the game.
- Collected sample will act as our training data set to evaluate the performance of a trained brain
Notes:
For a simple game like infinity runner, the brain prerformnce might by a step function jumping from novice to perfect player
but is still good to quantify if this is true to balance the game if students train a perfect agent.  

**Priority:** 2  
**Title:** The game provides an option to avoid perfect agents.  
**Goals:** Now that we can quantify if a trained brain is a perfect player, we can detect it and introduce sudden changes in the 
map, such as adding new type of enemies or speeding up. The idea is that the student can still beat the agent, and if they do
provide suggestions or ideas on what can they do to get again a perfect player.

**Priority:** 3  
**Title:** The game provides a tournament option.  
**Goals:** 
- The games allows the teacher or students to set-up tournaments against trained agents and/or students.
- The game should allow to easily configure (in json?) the participants and their trained brain.
- The game should provide a visualization of the tournament tree.
- The configuration file should also include how many matches to run per participants.
- The configuration file should also allow for N simultaneous players/agents.
- The configuration file should allow to change or specify the keyboard keys used by each human player.

# Open Questions

## Neuroevolution library
If there's a neuroevolution library for unity we should use that.  
What are the implications of building it in c# vs python?  
If we do it in python, should we use tensorflow, keras, pythorch? 

## Estimating time to complete tutorial steps
We can approach this by running a rough estimates using the avg. typing speed for kids and measuring it in practice:
- Average adult typing speed: 45 WPM
- Avergae kid typing speed: 5 WPM per grade (probably biased towards affluent communities) 
- 20 lines of javascript: 100 words (rough estimate with 80 max chars per line)
We haven't found solid research on the avg. typing speed of kids, but gives us some lower/upper bound estimates.

Example:  
- 3rd grader at 15 WPM, 20 lines of code (100 words) = About 7 mins of coding  
- 3rd grader at 10 WPM, 20 lines of code (100 words) = About 10 mins of coding  
- We need a buffer, e.g. 5 min of explanation, questions, bugfixing.  

# Resources

| Resource | URL |
| --- | --- |
| Unity's ML website | https://unity3d.com/machine-learning |
| Unity ML Documentation | https://github.com/Unity-Technologies/ml-agents/tree/master/docs |
| Blog post introducing Unity ML | https://blogs.unity3d.com/2017/09/19/introducing-unity-machine-learning-agents/ |
| Rougelike blog post and repo | https://blogs.unity3d.com/2017/12/11/using-machine-learning-agents-in-a-real-game-a-beginners-guide |
| | https://github.com/UnityTechnologies/MachineLearningRoguelike |
| Infinity Runner simple input/output for ML model and easy to measure the model fitness |  https://twitter.com/MaximePlantady/status/914837842580443137 |
| | https://github.com/mplantady/ml-agents |
| Neuroevolution | https://eng.uber.com/deep-neuroevolution/ |
| | https://www.oreilly.com/ideas/neuroevolution-a-different-kind-of-deep-learning |
| | https://en.wikipedia.org/wiki/Neuroevolution |
| | https://arxiv.org/pdf/1712.06567.pdf |
| Neuroevolution - Javascript implementation | https://github.com/xviniette/FlappyLearning |
| FreeCodeCamp | https://learn.freecodecamp.org/ |
| Code.org | https://code.org/ | 
| Code.org - Lesson example | https://curriculum.code.org/csf-18/coursed/18/ |
| Code.org - Unplugged activity | https://studio.code.org/s/coursed-2018/stage/18/puzzle/1 |
| Git Branching Model | https://nvie.com/posts/a-successful-git-branching-model/? |

# Contacts
| Email | Role | Description |
| --- | --- | --- |
| pedro@gokic.org | Executive Director | |
| fernando@gokic.org | Board Member | |
| tiago@gokic.org | Board Member | |
| priscila@gokic.org | Board Member | |
| felip@gokic.org | Business Development | | 
