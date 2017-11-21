# OpenBCI's connection with Unity ML - Agents (Beta) Learning Environment Version Alpha 1.0

For the original Unity ML Environment: https://github.com/Unity-Technologies/ml-agents/issues/142
For the original OpenBCI Environment: https://github.com/OpenBCI/OpenBCI_GUI

The Platform composed a tailered version of OpenBCI SDK and a matched Unity learning environment,
Tested with windows 7 and windows 10,
WIP project, for details, please refer to: https://www.xutongda.com/openhappiness

Collobration project by the Street Observers.

The Environemnt configeration is painstaking, please follow the instructions carefully: 

1. Install the dependency of OpenBCI on Processing 3(or higher): 

	gwoptics: http://www.gwoptics.org/processing/gwoptics_p5lib/
	ControlP5: http://www.sojamo.de/libraries/controlP5/
	minim: http://code.compartmental.net/minim/

2. Install and configure the Modified OpenBCI Library: 

Please unZip the file under processing folder, and make sure the *.files are under following path: 
	\Processing\OpenBCI_Processing-master\OpenBCI_GUI

The OpenBCI GUI would generate two files else than the log file under the following path: //
	C:\Git\ml-agents\unity-environment\Assets\ML-Agents\Alphawave

Please make sure Processing has the write access to create and rewrite under this path

3. Install the python and its environment for Unity-ML agent:

	Complex progress, please refer to this document: 
	https://unity3d.college/2017/10/25/machine-learning-in-unity3d-setting-up-the-environment-tensorflow-for-agentml-on-windows-10/

	Please note that although it is for win 10, it works for other windows(7 or higher) as well.

4. Install the Unity ML-agent Master: 

	please refer to this document: 
	https://github.com/Unity-Technologies/ml-agents/blob/master/docs/installation.md

	Please make sure the /python folder is under following path: 
	C:\Git\ml-agents\python

The path of unity environment scene file should be :

	\ml-agents\unity-environment\Assets\11-12-scene

For a built version: 

	\ml-agents\python\unity_environment_11_20_5

For a better training experience, start with hyperparameters as followings:

"### General parameters
max_steps = 400001 # Set maximum number of steps to run environment.
run_path = ""ppo"" # The sub-directory name for model and summary statistics
load_model = False # Whether to load a saved model.
train_model = True # Whether to train the model.
summary_freq = 10000 # Frequency at which to save training statistics.
save_freq = 50000 # Frequency at which to save model.
env_name = ""unity_environment_11_20_5"" # Name of the training environment file.

### Algorithm-specific parameters for tuning
gamma = 0.99 # Reward discount rate.
lambd = 0.95 # Lambda parameter for GAE.
time_horizon = 2048 # How many steps to collect per agent before adding to buffer.
beta = 1e-3 # Strength of entropy regularization
num_epoch = 5 # Number of gradient descent steps per batch of experiences.
epsilon = 0.2 # Acceptable threshold around ratio of old and new policy probabilities.
buffer_size = 16384 # How large the experience buffer should be before gradient descent.
learning_rate = 3e-5 # Model learning rate.
hidden_units = 256 # Number of units in hidden layer.
batch_size = 1024 # How many experiences per gradient descent update step."



