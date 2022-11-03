2022-10-20
1042
- created default asp.net core mvc
- created with individual acc auth
- kept https default
- using .NET core 3.1 LTS
- added razor runtime

1044
- run the app and comment out json entry for https to run the app
- see properties/launchsettings.json

1047
 - built and ran the app
 - everything works
 - review packages ....see dependencies/packages
 - checked the packages to confirm sql server

 1052
 - lets push to github

 2022-10-25
 1115
 - cloned the app into machine
 - removed the options from Startup.cs (line 33)
 - built and ran the application
 - everything works
 - push to github

 2022-10-27
 1000
 - continuing work on assignment 2 part 1.
 - got all updated changes from GitHub remote
 - begin by building and running app to check.

 1002
 - ran the app. everything works fine.
 - let's create README.MD (overview readme) before continuing

 1017
 - In Startup.cs, set up the HTTP Pipeline (changed Line 45)

 1023
 - tried debugging by adding breakpoint
 - tested it
 - learnt how breakpoints work
 - push changes to GitHub

 1024
 - pushed changes to GitHub
 - starting part 1.3, that is adding Bootstrap theme


 1043
 - selected the darkly theme for project
 - downloaded the bootstrap.css file 
 - made necessary changes to other files
 - ran the project to check
 - everything works well

 1053
 - added additional third part app links
 - refer _Layout.cshtml file

 1110
 - added dropdown link in _Layout.cshtml file
 - tested the app
 - the changes are reflected
 - however, the dropdown menu does not open yet. need to fixt it
 - need to start part 1.4
 - push changes to github first

 2022-10-31
 1444
- pulled changes from GitHub.
- Build the app and test it

1445
- Tested the app. Everything works well
- now need to continue from part 1.4
- but before that, refactor the nav to make the dropdown work

1454
- the dropdown works but does not open. need to check, probably needs content
- now starting part 1.4

1511
- Added EFCore Relation Package
- Deleted the Migrations folder

1515
- The EF Identity Framework package already exists
- changed namespace in ApplicationDbContext.cs in Data Folder
- No class1.cs files found

1532
- made a mistake. created folder instead of class library
- corrected mistake
- created three new class libraries with the relevant folders
- deleting defualt class1.cs files

1540
- have some errors when building despite installing packages
- will look into that later

2022-11-01
0930
- Strarting again
- Cloned application into collge system.
- Built it. got build errors.
- Need to figure those

0945
- updated the required classes
- need to figure out errors
- need to update Error.cshtml file

0959
- got the error, the packages were installed in the wrong folder
- installed the packages and changed namespaces in all folders
- also changed folder names

1005
- still need to change error.cshtml
- need to correct dropdown
- will first push to GitHub

1055
- something went wrong. had to delete local copy and clone again
- will build app first

1056
- fixed build erros by referencing model file correctly
- now run app

1057
- everything runs fine
- will now continue working with utility class libary

1058
- added new static file
- push to GitHub first and then continue

1100
- added project referenceslets build and test before proceeding

1101
- all works well.
- lets push to GitHub before continuing

1118
- added area
- also changed startup file
- moved homecontroller file
- push to GitHub before continuing

1121
- changed are name to customer
- also added customer are reference in controller

1130
- moved view folder
- lets push to GiHub and try to run app

1138
- the app does not run now
- need to fix it


1140
- app works. had to change the route
- need to move to next part
- push to GitHub irst
- ToDo: fix Dropdown

1145
- cloned app to laptop
- build and test app
- will then continue

1154
- the app works in customer path
- yet to work in regular path
- push to GitHub first

1229
- route finally works
- added endpoint to startup properly
- To Do: adding new admin are, and dropdown correction

1236
- have checked app and pushed changes to repo
- will now continue to try dropdown

1259
- dropdown finally works
- issue with attribute value
- ran the app, everything works well
- push to GitHub
- last part is to create another area

0108
- moved viewimport file to view folder. was in customer folder
- app works fine
- push to GitHub

0110
- added admin area
- push to GitHub
- will work on this later

1507
- starting work again
- first build and test app

1508
- tested app, everything works well
- now continue with last part

1513
- added files to admin/views
- deleted the unrequired folders
-tested app, works fine
- will now push to GitHub

1524
- changed content of view pages
- tested app, works fine
- will now push to GitHub
- end of part 1

1529
- made updates to README.md file.
- will push these changes too.
- now end of part 1

2022-11-03
1029
- completed the correction of part 1
- now starting part 2
- first build the solution before beginning

1037
- built and tested app
- everything works well
- now begin part 2

1041
- created a new migration called addDefaultIdentityMigration
- first push to GitHub before continuing

1044
- pushed to GitHub
- also updated the database
- built and tested app
- runs without errors
- now continue with app

1058
- added new table by creating model class
- added the migration
- push to GitHub before continuing

