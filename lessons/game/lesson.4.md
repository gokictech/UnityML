# Create the Environment
## Add River Water
Create new Cube on Game Scene
 - Right click (empty area on) Hierarchy Panel > 3D Object > Cube
 - Name it "Water"
 - Reset the Transform  
  
![Create river water](resources/img/create-river-water-cube.gif)

Make the Water game object cover the gap between the river banks  
Change the Transform settings to:
 - Position: -10, -0.5, 0
 - Scale: 15, 1, 31

![Scale and Position Water](resources/img/river-water-cube-transform.jpg)

## Let's add some color to this water  

First, we will create a place to save our Materials  
*(This is just so we can keep things organized)*
 - Create a Folder under Assets called "Art"
 - Create a Folder under Assets/Art called "Materials"  

![Create Art Materials Folder](resources/img/create-art-materials-folder.gif)

Now, we will create the Material for our River Water  
*(Materials are like the "paint" that we add to our 3D objects)*
 - Right click the Materials folder > Create > Material
 - Name it "WaterMaterial"

![Create Art Materials Folder](resources/img/create-water-material.gif)

Change the WaterMaterial settings to a water like color  
Here are the settings we used:  
 - Source: Albedo  
 - Smoothness: 0  
 - Albedo color: 0066D1  

![WaterMaterial Settings](resources/img/water-material-settings.JPG)

This is how we change those settings:  
![Changing the WaterMaterial Settings](resources/img/water-material-settings.gif)

## Add the WaterMaterial to our Water GameObject
You can drag the material to the Inspector or directly to the object on the game scene.  
I like draging it to the Inspector:
 - Select the Water GameObject (on the Hierarchy Panel)
 - Drag the WaterMaterial (Project Panel) to the MeshRenderer Material (Inspector Panel)

![Set Water Material](resources/img/set-water-material.jpg)
![Setting Water Material](resources/img/set-water-material.gif)

This is how it should look like now:  
![Setting Water Material](resources/img/river-look.jpg)

Make sure to save your scene frequently.
Simply press Control + S to save the scene.

To tell if your scene has any unsaved changes  
Look at the asterisk ("*") next to the scene name in the Hierarchy Panel

 - No changes:  
![Setting Water Material](resources/img/scene-no-changes.jpg)
 - With changes not saved:  
![Setting Water Material](resources/img/scene-unsaved-changes.jpg)

---
[<< Previous Lesson](lesson.3.md) | [Next Lesson >>](lesson.5.md)