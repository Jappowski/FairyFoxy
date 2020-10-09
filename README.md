# Baseline
Please use English for the entire project. That includes all of the code, comments, variable names, asset names and this entire repository.

The project uses 2018.4.12f1 version of Unity as per request of the lecturer. For sake of consistency, please download it from here: https://download.unity3d.com/download_unity/59ddc4c59b4f/UnityDownloadAssistant-2018.4.12f1.exe


# Coding style
The code style in the entire project should be consistent. In order to keep it as such, please follow the guidelines below:

 • The variable naming convenction is lowerCamelCase, where the first word starts with a small letter and the later ones always start from a big one. However, separate words with underscore if it is a variation of a specific context. Then return to lower letters for the first word.      
For example, if creating code for a double jump, the main context of the variable's name would be `doubleJump`. To setup variations of it, such as `width` or `endTimer`, use the notation that separates them with an underscore: `doubleJump_width`, `doubleJump_endTimer`.

 • Always name variables descriptively. Do not use abbreviations, unless it is a popular abbrevitation for a long word, such as `Coord` instead of `Coordinate` or `ID` for `IdentificationNumber`.
 
 • After finishing the code, consider if it can be understood just by following the code along. If not, comment it and explain what unclear lines do. The more comments, the better.
 
 • Start the new comments with `//|`. The `|` sign indicates that this is a new comment and not a continuation of one from previous line. Enter a space after writing `//` if it's does not contain the `|` sign. Long comments that are written through multiple lines should look like this:     
 `//|This is one of the comments.`    
 `// It refers to a specific thing`    
 `//|This is a separate comment`    
 `// It refers to a completely different`      
 `// thing than the previous one.`
 
 If writing a `TODO` comment, start it with `+`, instead of `|`. For example: `//+TODO: Clean-up the code.`
 
 # Commit descriptions
Commits always require a short description of which changes it introduces, so include a proper short description. It is a good practice to make a commit after finishing work on one thing, before moving to another. It helps you to describe the changes as one package, also allows you to easily roll back in case something goes wrong in the next step. Try to use proper English grammar in the descriptions, also include a sign in front of the description, depending on what was its primary change, in following fashion:    
 `+ This change added new assets, features, etc.`     
 `- This change removed things from the project or is a bug fix.`     
 `| This change changed reworked or changed form of something that already was in the project.`

Remember to always include a single space after the sign for sake of readability.
