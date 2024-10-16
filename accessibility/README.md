# Accessibility Features Documentation 

  

## 1. **Subtitles and Closed Captions** 

   - **Purpose**: Provide players with hearing impairments or players who prefer playing with the sound off the ability to follow the game's dialogue and sound effects. 

    

   ### **Implementation**: 

   - **Subtitles**: 

     1. **Text Display**: Create a system that displays character dialogue in a readable font and color-contrasted text. Ensure the size of the text can be adjusted through the options menu. 

     2. **Synchronization**: Subtitles should sync with the spoken dialogue, appearing and disappearing at the appropriate times. 

     3. **Speaker Identification**: In multi-character dialogue, consider adding the name of the speaker to the subtitles to clarify who is speaking. 

  

   - **Closed Captions**: 

     1. **Sound Descriptions**: For non-verbal audio cues, such as explosions or background noise, closed captions should describe the sound (e.g., "[footsteps approaching]" or "[intense music]"). 

     2. **Styling**: Use different colors or symbols for sound effects to distinguish them from spoken dialogue. 

      

   ### **Design Insights**: 

   - **Font Legibility**: Use fonts that are clear and readable (e.g., sans-serif fonts). Avoid decorative fonts that could be hard to read, and ensure the text size is large enough to be comfortable for all users. 

   - **Feedback**: Based on feedback, we included adjustable font size and color settings to improve readability in different lighting conditions. We also added an outline or shadow to text to enhance visibility against bright or busy backgrounds. 

    

   ### **Incorporated Feedback**: 

   - During testing, some players found the default text size too small, so an option to increase the size up to 200% was added. 

   - Players who are colorblind provided feedback that captions without a background or outline were hard to see, prompting the addition of customizable backgrounds and outlines for better contrast. 

  

--- 

  

## 2. **Colorblind Modes** 

   - **Purpose**: Ensure that players with color vision deficiencies can distinguish between important gameplay elements. 

    

   ### **Implementation**: 

   - **Colorblind Filters**: 

     1. Offer multiple colorblind modes (e.g., Deuteranopia, Protanopia, Tritanopia) that adjust the color palette of the game. 

     2. Use shader techniques or color adjustment filters to apply these changes dynamically across all assets. 

    

   - **UI Design**: 

     1. Ensure that critical UI elements (e.g., health bars, ammo counters) are distinguishable using shapes, patterns, or brightness variations, not just color. 

     2. Provide an option to customize the UI color scheme or select from preset colorblind-friendly schemes. 

      

   ### **Design Insights**: 

   - **Testing with Simulators**: During development, we tested the game using colorblind simulators (such as Coblis) to evaluate how different color schemes appear to players with color deficiencies. 

   - **Avoiding Sole Reliance on Color**: Rather than using color as the only indicator, we used shapes, icons, and patterns to represent key information. For example, health packs not only appear red but also have a cross symbol, making them identifiable by shape and icon. 

  

   ### **Incorporated Feedback**: 

   - Feedback from colorblind players indicated that some puzzles were initially difficult to solve due to color-based mechanics. In response, we added alternative visual cues (such as symbols) to convey the same information. 

   - During beta testing, we discovered that some players preferred a global tint or filter over changing individual UI elements, so a global colorblind filter toggle was added. 

  

--- 

  

## 3. **Adjustable Text and UI Scaling** 

   - **Purpose**: Help players with visual impairments by allowing them to resize on-screen text and UI elements to a comfortable size. 

    

   ### **Implementation**: 

   - **UI Scaling**: 

     1. Implement a slider in the options menu that controls the scale of the entire UI, including buttons, icons, and text. 

     2. Ensure that UI scaling applies consistently across all screens (menus, in-game HUD, inventory, etc.). 

    

   - **Dynamic Text Size**: 

     1. Provide adjustable text size for all on-screen text, including subtitles, dialogue boxes, and HUD elements. The text size should increase proportionally with the UI scaling but also be adjustable independently. 

     2. Ensure that text remains readable at all sizes by adjusting line spacing and ensuring it doesn’t overflow or clip within its container. 

    

   ### **Design Insights**: 

   - **Responsiveness**: When scaling UI elements, we made sure that the layout remained functional and intuitive. This required dynamic layout adjustments, ensuring that text didn’t overlap or become misaligned. 

   - **Feedback**: Players expressed the need for a highly customizable interface, so we added multiple options to tweak UI and text size separately to better suit individual preferences. 

  

   ### **Incorporated Feedback**: 

   - Some players pointed out that when text scaling was applied, certain UI elements overlapped or became hidden. To solve this, we incorporated dynamic container resizing and made sure that UI elements reflow appropriately. 

   - We also received feedback about certain menus not applying the scaling properly, so we fixed the scaling to ensure it worked uniformly across all parts of the game. 

  

--- 

  

## 4. **Remappable Controls** 

   - **Purpose**: Allow players with physical disabilities or specific preferences to customize controls to better suit their needs. 

    

   ### **Implementation**: 

   - **Control Remapping System**: 

     1. Provide a user-friendly interface in the options menu where players can assign their preferred keys or buttons for every action. 

     2. Ensure that every action in the game (including UI navigation) is fully remappable. 

     3. For controllers, allow the remapping of all buttons, triggers, and joystick inputs. 

    

   - **Input Feedback**: 

     1. Show visual feedback for players when they remap controls (e.g., pressing a key highlights its function in the remapping menu). 

     2. Include a reset-to-default option to quickly revert changes. 

    

   ### **Design Insights**: 

   - **Flexibility**: Some players require specific control setups, especially if using adaptive controllers. As such, we made the control scheme flexible to work with a variety of input devices beyond just standard keyboards and controllers. 

   - **Accessibility Device Support**: We ensured compatibility with popular accessibility devices, such as Microsoft's Adaptive Controller, and allowed mapping for any input. 

  

   ### **Incorporated Feedback**: 

   - During testing, feedback from players using adaptive controllers helped us identify missing features, such as the ability to map multiple actions to a single button. We added this feature to accommodate those with limited mobility. 

   - Some players requested the ability to save and load different control profiles, so we added a profile system that allows for quick switching between custom setups. 

  

--- 

  

## 5. **Difficulty Options and Assist Modes** 

   - **Purpose**: Make the game accessible to players with varying skill levels by offering customizable difficulty settings and assistive features. 

    

   ### **Implementation**: 

   - **Customizable Difficulty**: 

     1. Offer multiple difficulty levels (e.g., Easy, Normal, Hard) with clear descriptions of how each level changes the game mechanics (e.g., enemy health, player damage). 

     2. Allow players to customize specific aspects of the game’s difficulty (e.g., enemy aggression, puzzle complexity, time limits) through granular difficulty sliders. 

  

   - **Assist Modes**: 

     1. Include assist modes such as auto-aim, extended time for puzzles, and reduced damage taken. These can be toggled individually based on player preferences. 

     2. Provide visual aids, like highlighting interactable objects or slowing down fast-moving elements, to assist players with cognitive disabilities. 

  

   ### **Design Insights**: 

   - **Balancing Challenge and Accessibility**: While we wanted to maintain challenge for those seeking it, we also wanted to ensure the game remained accessible to players who might find certain aspects too difficult. Assist modes and granular difficulty controls allowed players to tailor the experience without feeling excluded. 

   - **Feedback**: Based on player feedback, we realized that giving players control over individual difficulty settings (rather than preset difficulty modes) allowed for a more tailored experience. 

  

   ### **Incorporated Feedback**: 

   - Players appreciated the flexibility of the difficulty sliders but requested more clarity on how each slider affected gameplay. We added more detailed descriptions and visual indicators (such as graphs) to show the impact of changing each setting. 

   - Some players requested the ability to toggle assist modes mid-game without restarting, so we added in-game menus that allowed for on-the-fly adjustments. 

  