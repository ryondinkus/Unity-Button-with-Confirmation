# Unity Button with Confirmation
 A Unity asset for a button that activates after being held for a certain amount of time. Works in VR. This project comes with two example scenes, one for Desktop and one for VR, as well as the necessary ButtonConfirmation.cs and RadialProgress.cs scripts.
 
![ButtonConfirmation.cs](https://i.imgur.com/HcR9YRL.gif)
 
# How to Use
### 1. Setting up the actual progress bar.
In the Prefabs folder, you'll notice there's a CircularProgressBar prefab. This is the icon that will appear over the button while it's being held down. While you can certainly make your own with relative ease, it might be a good idea to look at this prefab to get an idea of what exactly is needed.

![CircularProgressBar Prefab](https://i.imgur.com/s5l40h8.png)

The CircularProgressBar is just a default Canvas object, with the added RadialProgress.cs component. This script is essential, as it controls the fill animation of the bar.

![RadialProgress.cs](https://i.imgur.com/kjvMKqC.png)

The prefab has two Image game objects as children. LoadingBar is the actual object which will fill up as the button is held. Note that RadialProgress.cs takes the LoadingBar as a parameter. The other child, Center, is just decorative, and isn't necessary for the animation to work.

![LoadingBar and Center](https://i.imgur.com/UWPLHvL.png)

To make your own ProgressBar, all you need is a canvas with the RadialProgress.cs component, and a LoadingBar image, which can be any image of your choosing. Additionally, with Unity's built in image script, you can change the fill method to be a horizontal fill bar instead of circular.

![ButtonConfirmation.cs](https://i.imgur.com/g7uCzn7.png)

### 2. The ButtonConfirmation Component
After creating the CircularProgressBar prefab, all you need now is the actual button. This is much easier. All you need to do is add the ButtonConfirmation.cs component to an already existing button.

![ButtonConfirmation.cs](https://i.imgur.com/ycuYLtE.png)

The first parameter on this component is the Progress Bar, which will be the CircularProgressBar prefab you created earlier.

The two colors will be the color of the CircularProgressBar. If the second color is different from the first, the fill bar will change colors after being about 75% filled. The seconds parameter determines how long the button needs to be held before confirming.

Finally, the MyUnityEvent() is where you should put the event that you want to happen when the button confirms.

**It's very important that you clear out the OnClick() event from the original Button component, otherwise the button will activate without the confirmation completing.**

![ButtonConfirmation.cs](https://i.imgur.com/MhfNmZA.png)

The button should work after this. This will work on both Desktop and VR environments, provided the VR environment has a functioning pointer + canvas system. For a good example of how to set this up, check the VR example scene in the project.
 
# Example Scenes
## Desktop
In the Desktop scene, you'll find a Button prefab on a blank canvas. The button will fill when it is clicked and held with a mouse. When the button confirms, it will disappear. This is just an example function to show that the button does not activate until the confirm bar is filled.

![ButtonConfirmation.cs](https://i.imgur.com/HcR9YRL.gif)

## VR
The VR is near identical to the Desktop scene, only with the proper VR tools to enable UI interaction. In this case, we are using SteamVR 1.2.3 with VRTK 3.3. VRTK UICanvas allows UI elements, such as buttons, to be seen through a VR headset. The VRTK UI Pointer allows the user to interact with the button via a laser pointer. That being said, any VR plugin should work with this button, as long as it has a pointer that can emulate a mouse click and a canvas that can be visible on VR headsets.

![ButtonConfirmation.cs](https://i.imgur.com/Ktde3u5.gif)

This was built as part of the Groove Catcher project at vizmoo.com
