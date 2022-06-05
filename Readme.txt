*********************************TradeVilla*******************************

#Overview:

TradeVilla is a web platform for trading products online.You can create an 
account here and upload a post about your product that you want to trade for something else. People who are interested can comment on your post and see your profile for contact information.Then they can contact you with the details you have provided. They can also review you after trading products with you and other users can watch these reviews.


#Project Features:

-Responsive UI
-User Authentication
-User Profile Modification(Edit)
-Post Upload with multiple images
-Post Comment
-Post Delete
-Search
-Review User

#Frameworks and Libraries:
-ASP.NET MVC
-Entity
-Bootstrap


Instructions to Follow:

#Please have Visual Studio 2019 Community Version installed to run this project.
#Run the "TradeWeb.sln" file and go to NuGet package manager console.
You can find it from Tool->NuGet Package Manager->Package Manager Console
#Type this command "update-database"
If it shows you an error saying something about there is no migrations or 
like that then first run'add-migration xyz' command and then 'update-database'
#Then Run The Project by clicking IIS Express button.
The project should be running after that.
#If you get an error like this "Could not find a part of the path … bin\roslyn\csc.exe" - then run "Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r" command first and then update-database if you have not done yet.

Note: The database files are added in App_Data Folder. It contains some null values in some fields in some of the tables as the database tables were modified and those datas were inserted before that. So, if you see any broken image links that is because of that. But The new users and datas you will be adding now should be fine.

  
