# Student registration form
The project developed was the last work of the year in the Logic and Programming course at [Colégio Cotemig](https://www.cotemig.com.br/), consisting of a form created through the .NET Framework and linked to an SQL database.

![Image of the registration form](https://user-images.githubusercontent.com/96635074/205149428-84593829-7b32-45b3-a85a-a391cf26d315.png)

# 🔨 Project functionality
Simple registration form, created to receive and store some information from Cotemig students in a database.

# 💻 Technologies used 
* [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/): programming language
* [.NET Framework](https://learn.microsoft.com/pt-br/dotnet/framework/): platform for developing and running systems and applications
* [SQL](https://www.oracle.com/br/database/technologies/appdev/sql.html): Database creation and manipulation

## 📁 Access and execute project
### 1. Install and configure [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) on your computer
* I recommend watching [this video](https://www.youtube.com/watch?v=KKaDlo1I21Y) to help you

### 2. Clone [this repository](https://github.com/ArturColen/StudentRegistration) on your machine
* Create a folder on your computer for this program
* Copy the [URL](https://github.com/ArturColen/StudentRegistration.git) from the repository
* Open Visual Studio and click `Clone a repository`
* In the appropriate spaces paste the URL, select where you want to save the project and click the `clone` button
* Wait a while until cloning is complete

### 3. Install and configure [MySQL Workbench](https://www.mysql.com/products/workbench/) and [WampServer](https://www.youtube.com/watch?v=1cnXP8uw5gI) on your computer 
* I recommend watching [this video](https://www.youtube.com/watch?v=KKaDlo1I21Y) to help you

### 4. Copy and paste the code below to create the database
```
create database school;
use school;
create table students(
	id int primary key auto_increment,
	name varchar(100),
	age varchar(3),
	unit varchar(10),
	serie varchar(2),
	class varchar(2)
);
```

### 5. Connect the database to the form
* After running the database you created earlier (by clicking ⚡), click `Server` at the top of MySQL Workbench
* Then click `Data Export` and select the school database in the `Tables to Export` area
* Make sure `Dump Structure and Data` is selected and check where you want to export the database (in this case, inside the folder of the project that was cloned)
* Scroll down and click the `Start Export` button
* If a warning appears on your screen, click on `Overwrite` and then `OK` (leave the password space empty)

### 6. Run the project
* Go back to Visual Studio (in the project that was cloned) and click on `StudentRegistration.sln` in the 'Solution Explorer' area (right side of the screen) 
* Now, click on the arrow next to the `StudentRegistration` and finally double-click on the `FrmStudentRegistration.cs`
* When a screen similar to the one shown at the beginning of README.md appears, click `F5` on your keyboard or the `▶️ Start` button (top of the screen) to test the program
