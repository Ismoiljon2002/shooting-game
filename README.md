Space Shooter Adventure
Project Overview
Space Shooter Adventure is a 2D space shooter game developed using Unity as part of the "Mini Project 1" for the Fall Semester of 2024. In this game, players navigate a spaceship through an asteroid field, battle enemies, and collect power-ups to enhance gameplay.

This project helped us apply Unity and C# scripting, focusing on game mechanics, player controls, AI, user interface, and visual design.

Team Members and Contributions
Marjona: Project Manager (Coordination, Project Plan, Final Report)
Diyorbek: Player Controls Developer (Spaceship Movement, Boundary Handling)
Rahmatulloh: UI/UX Designer (Score Display, Health Bar, Main Menu, Game Over Screen)
Javokhir: Environment Designer (Space-Themed Background, Scrolling Effects)
Ismoil: Shooting Mechanism and Power-Ups Developer (Bullet Movement, Collision Detection, Power-Ups)
Davron: Enemy and Obstacle Developer (Enemy AI, Obstacle Generation, Spawning Logic)
Game Features
Spaceship Controls: Smooth and responsive controls allow the player to navigate through the field with boundary restrictions.
Shooting Mechanism: The player can shoot bullets at enemies, with collision detection ensuring hit registration.
Enemy AI and Obstacles: Enemies follow predefined movement patterns, and randomly generated obstacles add difficulty.
Power-Ups: Collectible power-ups provide boosts such as increased firepower or health regeneration.
UI Design: Real-time score display, health bar, and game over screen are fully functional. The game includes a main menu and a proper end screen.
Environment: A scrolling space background enhances immersion in the game’s atmosphere.
Development Process
Initial Setup: We began by setting up the Unity project structure and dividing responsibilities based on individual roles. Milestones were created to ensure timely progress.

Game Mechanics:

Player Controls: Diyorbek implemented smooth and intuitive spaceship controls, ensuring the spaceship remained within boundaries.
Shooting and Power-Ups: Ismoil worked on shooting mechanics, including bullet movement and collision detection. The design and implementation of power-ups added another layer of strategy to the gameplay.
Enemy and Obstacles: Davron designed the enemy AI and spawning system, adding random obstacles to increase the game's difficulty.
UI and Environment:

UI Design: Rahmatulloh designed a clean and responsive user interface, including score tracking and a health bar. He also worked on the main menu and game over screens.
Environment: Javokhir created the space-themed background with a scrolling effect, adding depth to the game’s visual presentation.
Polishing and Testing: After the individual components were completed, the entire team worked together to test and polish the game. We resolved bugs related to collision detection, enemy AI, and optimized the game's performance for smooth gameplay.

Challenges Faced
Collision Detection: Early in development, bullet collisions with enemies were inconsistent. This issue was resolved by adjusting the hitbox sizes and ensuring that the collision logic was appropriately configured.
Enemy AI Behavior: Defining the movement patterns of enemies was challenging. Some initial AI scripts resulted in unpredictable enemy movements, which we later refined by implementing simpler algorithms for smoother gameplay.
Power-Up Integration: Integrating power-ups without disrupting the gameplay balance was tricky. We implemented a gradual progression system for power-ups to maintain the challenge throughout the game.
UI Scaling: Ensuring the user interface elements displayed correctly across different screen sizes required adjusting UI scaling settings in Unity.
Solutions Implemented
Improved Hitboxes: Collision detection was made more accurate by resizing hitboxes for both bullets and enemies.
Optimized AI Movement: We simplified the enemy AI logic, making their movement patterns predictable yet challenging.
Balanced Power-Ups: The effects of power-ups were fine-tuned to ensure they offered strategic advantages without overpowering the player.
Responsive UI: Adjusted UI scaling for different screen resolutions, ensuring a consistent user experience across devices.
How to Play
Download and Install: Clone this repository to your local machine:

bash
Copy code
git clone https://github.com/yourusername/2D-SpaceShooter.git
Open the project in Unity and press Play to start the game.

Gameplay:

Control your spaceship using the arrow keys or WASD.
Shoot enemies using the spacebar.
Avoid obstacles and collect power-ups for enhanced gameplay.
The game ends when your health reaches zero.
