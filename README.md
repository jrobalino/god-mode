# god-mode

This repo contains my Udacity VR Developer Nanodegree capstone project. The experience casts players as a deity in charge of maintaining the status quo between a set of rich and poor dogs. Without pity, players must ration food unevenly, separate puppies from their parents, and risk the lives of poor dogs. Ultimately, players must sacrifice the souls of the poor dogs in order to bless the rich dogs. In return, players receive adoring worship from those that benefit. But is maintaining the status quo truly the only option?

## Video Walkthrough
[View on YouTube](https://youtu.be/pYS6a06gcqw)

## List of Achievements

The project satisfies the following achievements per the Udacity project rubric (view a [YouTube video overview of achievements here](https://youtu.be/yBV4xEjYz-4)):

### Fundamentals: 500 points

- **Scale Achievement**—The player is a deity of human size relative to the dogs and the environment.
- **Animation Achievement**—The dogs contain idle, bark, run, and jump animations. The animations states are triggered via script.
- **Lighting Achievement**—Every scene has a combination of realtime directional lights and baked lights (area, point, or spotlight).
- **Locomotion Achievement**—The player can teleport around the environment using the left trackpad.
- **Empathy Achievement**—As a deity tasked with preserving the status quo, the player is forced to play favorites with one group of dogs while being cruel to another group of dogs. Players must distribute food in unequal amounts, separate puppies from their parents, guide dogs through an active minefield, and forsake the souls of the unfortunate. Most players should experience a conflict of the heart, wanting to complete the instructions they are given but feeling bad for the less fortunate dogs.

### Completeness: 750 points

- **Gamification Achievement**—The player can unlock the following achievements throughout the game:

| Achievement | Level | Description |
| :---: | :---: | :---: |
| Top Chef | Food | Add mushrooms to the poor table. |
| Gluttony | Food | Add mushrooms to the rich table. |
| Adoption | Parents | Take a poor puppy to the top island where the rich dogs are. |
| Minesweeper | Landmine | Cross the minefield without losing a single dog. |
| Sharpshooter | Hellfire | Shoot four dogs into the hell portals without missing. |
| Favorite Uncle | Hellfire | Send the three puppies to heaven. |

- **Alternative Storyline Achievement**—In the last level, the player can choose whether to maintain the status quo. By casting the three puppies into hell and then sending the unlocked treasure chest to heaven, the player maintains the status quo and the ending shows the player being worshipped by the rich dogs. However, if the player casts the treasure chest (either closed or opened) into hell instead, then the rich dogs are not blessed with power, wealth, and good fortune. The ending shows the player worshipped by the poor dogs, alongside a large bowl of food ready to distribute to the masses.
- **3D Modeling Achievement**—I modeled the dog bowl in Blender.

### Challenges: 500 points
- **User Testing Achievement** (2X due to 750 points in Completeness section)—The following are the results of user testing:

| Tester | Quote | Change |
| :---: | :---: | :---: |
| Jacob | "The island looks a little bare." | Add additional props to scenery, such as trees and bushes |
| Jacob | "This mine level is a monster." |  Reduce the number of mines |
| Jacob | "Did I hit it?" | Deactivate hell targets after they are hit by a dog |
| Stuart | "Come on, you rich bastard. Time to fly." | Display a shield around rich dogs to indicate they cannot be thrown off the island |
| Stuart | "I'm stuck on an invisible rock." | Fix oversized collider in landmine level |
| Stuart | "What jail are we talking about?" | Change voiceover script to be more clear |
| Mauri | "I don't get anything for not missing?" | Add achievement system |
| Mauri | "It's a little low." | Spawn achievement at player height |
| Mauri | "What if I throw the chest into hell?" | Handle scenario where player casts unopened chest into hell |
| Mauri | "Do I have to do anything in this level?" | Change voiceover script in last scene to congratulate the player on a completed journey |

## Tip for Udacity Reviewer

The landmine level can be time consuming to complete, but if you're in a rush, no worries: I built a cheat into the system. Simply align a dog in front of a known mine location, teleport to the end of the level, and then drive the dog forward. A mine will blow up in the distance and the next dog will spawn near you at the end of the level.

## Ideas for Improvement

If I was going to further refine the experience, I'd focus on the following items:

- Add more levels (I had plans for a level where you use a catapult to preferentially destroy the homes of poor dogs from afar, a level where you need quick reflexes to prevent the rich dog's water supply from being contaminated, and a level where you deal with aggresive dogs, but decided to limit the scope of the project in the interest of time).
- Improve the handling mechanics of the dogs in the landmine level. Currently, the dogs move strictly forwards, backwards, left, and right, but the controls could be improved for a full range of motion, which would help to prevent the dogs from getting unaligned when they hit colliders in the environment.
- Add more achievements and employ a system that provides hints to players about what the achievements might be in a given level.
- Allow players to choose the 'good' path in every level, not just the last one, and determine the ending based on how many 'good' versus 'evil' actions they take throughout the game.




