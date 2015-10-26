# MicPicture
A simple drag and drop - game. 

Noticed a bug, you before you do all of this, you have to change in the propertys of the DB-projekt and change the connectionstring from (localdb)\ProjectV12 or whataver its called to your own (local)\SQLEXPRESS.

To get the dabase, start your Sql Server Management Studio, Create a dabatase named MicPictureDB.
Run the LocalDBToSchema in the Schema Comparison folder, then you get the db. 
Optional:
if you want the diagram of the database:
Run the script DiagFull in Scripts - Postscripts. You have to have created a diagram in the database but not "saved".
After you've done this, to get the pictures in to the database just run the script named PictureDataScript
