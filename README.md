# AnkiClone
Assignment to be done by the end of the spring semestre. First time using databases and windows form, will be updating it over and over with time.

#**#19.03.2022#**

![Screenshot_7](https://user-images.githubusercontent.com/64064136/159135183-0ba06a6d-7079-4f04-8ff9-07809270f9a2.png)


Trying to practice the database knowledge that I've got to learn in C#, I'm pretty a beginner at C#, and there are new concepts like OOP, but I am trying my best to 
apply them the best way I can, with good programming practices.

So far I can create a database, update it, insert data into it, and select from it. All done in MS Access DB. There is a login page that works pretty well, but only
for one user for now. I'll update it to become multi-usered soon. From the app it can be logged out.

My plan is to make Decks unique to the users. Today I've finished the login page, logging out was buggy, not anymore. We'll see what will happen later. I'll keep updating here.

I do think that everything is perfectly done in login page(except SQL injections, my code is open to that and i'll update it), it will warn you if you are registered already, or if its invalid password/nickname, it'll show an error msg
there about these stuff. You can't register with the taken usernames (checks from DB) and asks you if you dont want to set a password, if you try to register without
a password.

![Screenshot_8](https://user-images.githubusercontent.com/64064136/159135177-f27f4fd2-bc1e-4fbf-a0f1-f6a5d6c7cf23.png)

You can't open pages like Decks/Browse/Stats without logging in.
