# Rigging a character imported with the PSD Importer

This example shows how to rig a character that consists of multiple Sprites using PSDImporter with Character Import mode. For this example to work, the PSDImporter package needs to be installed.

![](images/2D-animation-samples-character-sample.png)

To view how the Sprite is rigged, open the Asset *Assets/Samples/2D Animation/[X.Y.Z]/Samples/4 Character/Sprites/Fei.psb* in the Skinning Module.

![](images/2D-animation-samples-character-skinning-module.png)

The *_Character *sample Scene shows how the Asset is used in a Scene with animation using deformation.

![](images/2D-animation-samples-character-rig.png)

The following are the steps to reconstruct the *_Character* sample Scene

1. In PSD Importer’s **Character** mode, a Prefab is generated as a sub asset which has the GameObjects setup with Sprite Renderers and Sprite Skin. Thus to reconstruct the Scene, simply drag the Prefab generated from `Assets/Samples/2D Animation/[X.Y.Z]/Samples/4 Character/Sprites/Fei.psb` into the Scene.
2. Add an Animator Component on the Fei GameObject and assign the Fei Animator Controller Asset located at `Assets/Samples/2D Animation/[X.Y.Z]/Samples/4 Character/Animation/Animators/Fei.controller` to the controller property.
