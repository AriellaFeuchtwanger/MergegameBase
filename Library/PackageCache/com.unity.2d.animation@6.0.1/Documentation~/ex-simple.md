# Simple single Sprite rig

This sample shows a simple single Sprite rig, when importing a source file with the **Texture Importer** property set to **Single Sprite Import mode**. The Project and Assets can be found in the following location:

![](images/2D-animation-samples-simple-import.png)<br/>Sample project location in the Project window (for 2D Animation 6.0).

To view how the Sprite is rigged, open the Asset *Assets/Samples/2D Animation/[X.Y.Z]/Samples/1 Simple/Sprites/Boris.png* in the Skinning Module.

![](images/2D-animation-samples-simple-skinning-module.png)

The *_Simple* sample Scene shows how the Asset is used in a Scene with animation using deformation.

![](images/2D-animation-samples-simple-animation.png)

![](images/2D-animation-samples-simple-deformed.png)

The following are the steps to reconstruct the *_Simple* sample Scene

1. Create a new Scene.

2. Create a GameObject and call it Root.

3. Create a GameObject and call it Boris.

4. Place the Boris GameObject as a child or the Root GameObject.

5. In Boris GameObject, add a Sprite Renderer component.

   * Assign the Boris Sprite to the Sprite Renderer’s Sprite property

6. In Boris GameObject, add a Sprite Skin component.

   * On the Sprite Skin component, select the **Create Bones** button.
   * This will create GameObject Transforms to represent the bones for the Sprite.

![](images/2D-animation-samples-simple-rigged.png)

7. On the Root GameObject, add a Animator component
   * In the Animator’s Controller property, assign the Root Animator Controller Asset located in *Assets/Samples/2D Animation/[X.Y.Z]/Samples/1 Simple/Animation/Animator/Root.controller*
8. On the Boris GameObject, add a Animator component

   * In the Animator’s Controller property, assign the Boris Animator Controller Asset located in *Assets/Samples/2D Animation/[X.Y.Z]/Samples/1 Simple/Animation/Animator/Boris.controller*
