Use git clone to download the repo

git clone https://gitlab.com/jsua986/proyecto-centros.git

After the clone, build the solution to restore the packages.

before commiting a change configure your email and username, run this 2 commands in the git bash

 git config --global user.email "you@example.com"
 git config --global user.name "Your Name"

before commit, in git bash use the command git status. This list the file changes in the project.

use git add <file change> to staged commits 

to commit a change use the git commit command

git commit -m "description of the changes"

this push the changes into the local repo

to push the commit changes in the local to the remote repo use git push command

git push  <REMOTENAME> <BRANCHNAME> 

As an example, you usually run (git push origin master) to push your local changes to your remote repository.

you can use sourcetree to control the repository in an easy way https://www.sourcetreeapp.com/

just download sourcetree and install.

to update the local repository use the command git pull

if you have changes commit or stash them with the command git stash.
