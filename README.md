# TiwaUdon

[日本語リファレンス](https://hackmd.io/@vwcc/SJYNiHR2O)  
English Reference (Not currently supported 🙇)

## Setup

### Requirements

- Unity 2018.4.20f1
- [VRCSDK3 Worlds](https://vrchat.com/home/download)
- [UdonSharp] (https://github.com/Merlin-san/UdonSharp/releases/latest)

### Install Udonco Package

1. The latest [TiwaUdon Packages](https://github.com/tiwa0510/TiwaUdon/releases/)
2. **Import UdoncoCore.unitypackage (MUST!)**
3. Import Other Udonco package

## Getting started


Udonco Schematic Diagram (Command design pattern)
![image](https://user-images.githubusercontent.com/64125357/124367082-43bfa800-dc8f-11eb-9cf2-8bb96c9342dc.png)


### Sample Scene explanation
1. Please open the sample scene. ("Assets\TiwaUdon\Udonco\Core\Sample Scene\Sample.unity")
2. The sample scene contains a sample that changes the active state of a game object from several triggers.
3. Look at the U# script for "UdoncoInteracetEvent" attached to an object named "Interact"
4. "Invokers" contains a small Udon script to switch the active state of game objects.
5. When the Interact event is fired, the specified method of the Udon registered with the Invoker will be called.
6. Let's launch the sample scene and check it out.

#### Create New Command
1. Create a folder in the appropriate path to store the newly created U# script.
2. From the right-click menu, select 「 Create->Udonco Command U# Script 」 and choose a file name.
3. Open the newly created U# file and rename the "CustomEvent" method to the appropriate name.
