# BoingoPhotoAlbum  
<http://boingophotoalbum-dev.us-west-2.elasticbeanstalk.com/>  
Photo Album web application with drag and drop features. 
  
## How To Use  
Log in with email/pass
   - boingo@boingo<span></span>.com
   - Password1!
   
Search for images by either name or email, or use '*' to get all images.  
For example:  
   - john@john<span></span>.com
   - john  
   
 To remove pictures, press the delete button after searching for the user.  
 This will delete all of the specified user's images.  
   
 To add images, click the Add Images tab, then input a name and email.  
 Then drag and drop or upload your photos.  
 You can add a descriptions to each image before submitting if needed.  
 Press submit, and the images should be visible when searched for.  
  

## Developer notes  
- Current login requires a full email and nonbasic password.
- Users with shared emails but different names and vise versa are unique  
- If photos are added to an existing name and email combination, they will be added to his list.  
- Photos have static width and height
- Allow some time to spin, AWS free server may be slow.
- Mostly mobile responsive.  
  
- Views are mainly from Home/Index.cshtml and the layout Shared/_Layout.cshtml  
- Angular controllers and services located in Scripts/angular  
- Drag and drop done through dropzonejs, implemented in Index.cshtml's script area  
- When sending images, Controllers/HomeController is hit, all other API's are through Controllers/API/ImagesApiController.cs  
- API's call the service in Services/ImageUserService.cs


