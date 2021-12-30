# Sprite Swap

This collection of examples show how to achieve different Sprite Swap outcomes.

![](images/2D-animation-samples-spriteswap-Scenes.png)

## Flipbook Animation Swap

This example shows how to use Sprite Swap to create reusable Animation Clip for Flipbook animation. Open the Scene `1 Flipbook Animation Swap` to see it in action.

![](images/2D-animation-samples-spriteswap-screenshot.png)

In the example, it uses 3 Sprite Library Assets that are located at `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 Sprite Swap/Sprite Library` and they are:

1. Hero.spriteLib

2. Zombie1.spriteLib

3. Zombie2.spriteLib

Each of the Sprite Library Assets uses the respective Sprites from `Scavengers_SpriteSheet.png` located in `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 SpriteSwap/Sprites`. Each Sprite Library Asset also has the same number of categories with the same name and the entries in each category also have the same name.

![](images/2D-animation-samples-spriteswap-SLAsset.png)

The following are the steps to reconstruct the *1 Flipbook Animation Swap* sample Scene

1. Create a GameObject called Hero.

   1. Add a Sprite Renderer component in the GameObject and set the Sprite property to one of the Sprites used in `Hero.spriteLib`.

   2. Add a Sprite Library component and assign the `Hero.spriteLib` in the **Sprite Library Asset** property.

   3. Add a Sprite Resolver component.

2. Add a Animation component and assigned the Scavengers Animation clip located in `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 SpriteSwap/Animation` into the Animation property.

3. Duplicate the Hero GameObject and name it `Zombie1`.

   - In the Sprite Renderer, set the **Sprite** property to one of the Sprites used in `Zombie1.spriteLib`.

4. Duplicate the Hero GameObject can call it `Zombie2`.

   - In the Sprite Renderer, set the **Sprite** property to one of the Sprites used in `Zombie2.spriteLib`

Observe that all 3 GameObjects use the same Animation Clip. However, when the Animation Clip is being played, all 3 GameObjects are switching to a different Sprite. This is because the Animation Clip is not animating the **Sprite** property of the Sprite Renderer but rather the Sprite the Sprite Resolver should resolve from the Sprite Library component. Thus this makes Animation Clip reusable as long as the Sprite Library or the Sprite Library Asset contains the category and entry the Sprite Resolver needs.

## Animated Swap

This example shows how to use Sprite Swap to create reusable Animation Clip for animation that requires swapping of visuals in an animation with deformation. For this example to work, the PSD Importer package needs to be installed. Open the Scene file `2 Animated Swap`to see it in action.

![Initial frame with the hands in thumbs-up position.](images/2D-animation-samples-spriteswap-animated1.png)

This uses the same concept in the Flipbook Animation Swap example. The example uses 2 different visuals located in `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 SpriteSwap/Sprites`. The example assets used are:

1. `dialog.psb`

2. `dialog gray.psb`

These assets are imported with the PSD Importer set to **Character** mode and rigged in the same way. Each asset also have 2 different hand Sprites that can be swapped during the animation.

![Swapped to a frame with the hands open.](images/2D-animation-samples-spriteswap-animated2.png)

Using the same technique in Flipbook Animation Swap, 2 Sprite Library Assets are created. They are located at `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 Sprite Swap/Sprite Library` and stored as:

1. `dialog.spriteLib`

   ![](images/2D-animation-samples-spriteswap-animated-spritelib1.png)



2. `dialog gray.spriteLib`

   ![](images/2D-animation-samples-spriteswap-animated-spritelib2.png)



The following are the steps to reconstruct the sample Scene:

1. Instantiate both `dialog` and `dialog gray` Prefab into the Scene.

2. On the `dialog` GameObject, add a Sprite Library component and assign the `dialog.spriteLib` Asset into the **Sprite Library Asset** property.

3. On the `dialog gray` GameObject, add a Sprite Library component and assign the dialog `gray.spriteLib` Asset into the **Sprite Library Asset** property.

4. Expand the dialog GameObject and look for `R_arm_2` GameObject and disable it. The asset is not needed since it will be swapped in during the animation.

5. In `R_arm_1`, add a Sprite Resolver Component and set it to use the `R_arm_2`.

   ![](images/2D-animation-samples-spriteswap-animated-spritelib3.png)

6. Repeat steps 4 and 5 with the `dialog gray` GameObject.

7. Add a Animator controller on both GameObjects and assign the Dialog Animator Controller asset located in `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 Sprite Swap/Animation/Animators` into the **Controller** property.

Observe that in this example, the Sprite Library component is not on the same GameObject as the Sprite Resolver. Sprite Resolver will attempt to locate a Sprite Library component starting from the same GameObject it is on and traverse up the GameObject hierarchy. This way it is possible to have one or many Sprite Resolvers to use the same Sprite Library component by having the Sprite Library component on a common root GameObject of the Sprite Resolvers.

## Part Swap

This example shows how to swap Sprite assets using the API provided by changing the Sprite Resolver data. This example uses the visual setup in the Multiple Skinned Sprites example. Open the  `3 Part Swap` Scene to see it in action.

![](images/2D-animation-samples-partswap-Scene.png)

In the Scene, each part has 3 different visual options that can be swapped. The graphic assets are located in `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 SpriteSwap/Sprites`:

1. `Rikr.png`
2. `Rikr Poison.png`
3. `Rikr Rage.png`

A Sprite Library Asset is set up to where each visual that is interchangeable is in the same category. The Asset is located at `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 SpriteSwap/Sprite Library/Rikr Full.spriteLib`.

![](images/2D-animation-samples-partswap-SLasset.png)

On the `Rikr_Root` GameObject in the Scene, a Sprite Library component is added and its **Sprite Library Asset** property is set to reference the `Rikr Full.spriteLib` Asset.

In all Sprite Renderers under the `Rikr_Root` GameObject, a Sprite Resolver is added and is set to use the appropriate Sprite. For example, the Sprite Resolver for the `Rikr_Body` GameObject, the Sprite Resolver is set to use one of the Body Sprites.

![](images/2D-animation-samples-partswap-SLasset-body.png)

### Swap Part Script

A custom MonoBehaviour script called `Swap Part` is attached to the `Rikr_Root` GameObject. The script is located at `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 SpriteSwap/Scripts/Runtime/SwapPart.cs`.

![](images/2D-animation-samples-spriteswap-script.png)

The script holds a reference to a Sprite Library component for retrieval of swappable Sprites. It also holds an array of data that describes the category of Sprites in the Sprite Library that can be changed by a Sprite Resolver.

When the Swap Part script starts up, it will attempt to fetch the Sprite Library Asset that is used by a Sprite Library component.

```c++
var libraryAsset = spriteLibrary.spriteLibraryAsset;
```

From the Sprite Library Asset, it will then fetch the entries name that are in the category

```c++
var labels = libraryAsset.GetCategoryLabelNames(swapOption.category);
```

This is then used to populate the UI Drop Down list.

When there is a value changed in the UI Drop Down List, it will then set the Sprite Resolver to use the relevant Sprite

```c++
swapOption.spriteResolver.SetCategoryAndLabel(swapOption.category, swapOption.dropdown.options[x].text);
```



## Full Skin Swap

This example shows how to swap Sprite visuals using the API provided by changing the Sprite Library Asset referenced by the Sprite Library component. This example uses the visual setup in the Multiple Skinned Sprites example. Open the `4 Full Swap` Scene to see it in action.

![](images/2D-animation-samples-fullswap-scene.png)

In the Scene, there are 3 different visual asset options that can be swapped. The assets are located in `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 SpriteSwap/Sprites`:

1. `Rikr.png`
2. `Rikr Poison.png`
3. `Rikr Rage.png`

Sprite Library Assets are set up to have identical categories and entries names but with a different Sprite reference. The asset are located at `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 SpriteSwap/Sprite Library`.

1. `Rikr.spriteLib`

2. `Rikr Posion.spriteLib`

3. `Rikr Rage.spriteLib`

On the `Rikr_Root` GameObject in the Scene, a Sprite Library component is added and its Sprite Library Asset property is set to reference the `Rikr.spriteLib` Asset.

On the individual Sprite Renderers under `Rikr_Root` GameObject, a Sprite Resolver is added and is set to use the appropriate Sprite. For example, the `Rikr_Body` GameObject, the Sprite Resolver is set to use the Body Sprite.

![](images/2D-animation-samples-fullswap-sresolver.png)

### Swap Full Skin Script

A custom MonoBehaviour script called the `Swap Part` is attached to the` Rikr_Root` GameObject. The script is located at `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 SpriteSwap/Scripts/Runtime/SwapFullSkin.cs`

![](images/2D-animation-samples-fullswap-script.png)

Where there is a value change in the UI Drop Down List, the component sets the relevant Sprite Library Asset to be used for the Sprite Library component.

```c++
spriteLibraryTarget.spriteLibraryAsset = spriteLibraries[value];
```

## DLC Swap

This example shows how to swap Sprite visuals using the API provided by changing the Sprite Library Asset referenced by the Sprite Library component. This example uses the visual setup in the Multiple Skinned Sprites example and builds on top of the Full Skin Swap example. However, instead of the Sprite Library Assets are referenced in Swap Full Skin component, it is loaded from an AssetBundle during runtime and added into the component later. Open the  `5 DLC Swap` Scene to see it in action.

![](images/2D-animation-samples-DLCswap-scene.png)

For more information about Asset Bundles, please refer to the [AssetBundle Manual](https://docs.unity3d.com/Manual/AssetBundlesIntro.html).

For the Asset Bundle to work, the `Rikr_Poison.spriteLib` and `Rikr_Rage.spriteLib` Asset in `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 SpriteSwap/Sprite Library` are labeled in their relevant AssetBundle tag.

![](images/2D-animation-samples-DLCswap-assetbundle-property.png)

### Load Swap DLC Script

A custom MonoBehaviour script called `Load Swap DLC` is attached to the Load DLC GameObject. The script is located at `Assets/Samples/2D Animation/[X.Y.Z]/Samples/5 SpriteSwap/Scripts/Runtime/LoadSwapDLC.cs`

The script is set up when the DLC is loaded, it will scan the AssetBundles for any Sprite Library Assets. Once the Sprite Library Assets are loaded, it will add these entries into the `Swap Full Skin` script from the previous example.
