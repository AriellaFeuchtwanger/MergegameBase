# Single Sprite rig with bone branching 
This sample shows a slightly more complicated 2D Sprite rig which contains bone branching using Sprite imported by the Texture Importer set to **Single Sprite Import** mode.

![](images/2D-animation-samples-single-skin-sample.png)

To view how the Sprite is rigged, open the Asset *Assets/Samples/2D Animation/[X.Y.Z]/Samples/2 Single Skinned Sprite/Sprites/Plunkah.png* in the Skinning Module.

![](images/2D-animation-samples-single-skin-skinning-module.png)

The *_Single Skinned Sprite *sample Scene shows how the Asset is used in a Scene with animation using deformation.

![](images/2D-animation-samples-single-skin-rig.png)

The following are the steps to reconstruct the *_Single Skinned Sprite* sample Scene

1. Create a new Scene.
2. Create a GameObject and named it Plunkah.
3. Add a Sprite Renderer component and assign the Plunkah Sprite to the Sprite property.
4. Add a Sprite Skin component and select the **Create Bones** button.
5. Add a Animator component and assign the Plunkah Animator Controller Asset to the Controller property.
