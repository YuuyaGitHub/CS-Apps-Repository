# Random Selection
This program is a tool that randomly selects any character.
<br>It also comes with a random number generator.

# Usage
In the textbox on the left, enter the characters you want to select at random.
<br>Once entered, click the “Extract” button.
<br>It is then randomly selected.

Below is an example input:
| Before Extraction | After Extraction |
| ---- | ---- |
| GitHub<br>X<br>YouTube | X |

# Random Number Generator
**To switch to the random number generator, select the option:** _Tools > Random Number Generator_

You can generate values ranging from a minimum of 0 to a maximum of 1,000,000,000,000,000.

## Bugs
* If I specify a number greater than 2,147,483,648, I get the error ```Value was either too large or too small for an Int32.``` (`System.OverflowException`).
* If I specify a number of 2,147,483,647, I get the error ```The value of 'mixValue' cannot exceed maxValue``` (`System.ArgumentOutOfRangeException`).

Both are by design and there is no way to fix them.

## Separator
You can create a separator by entering ```=``` or ```-```.
<br>These characters will be ignored during random selection.

However, the separator characters are hard-coded and cannot be changed.

# Download
This program can be downloaded from [this](https://github.com/YuuyaGitHub/CS-Apps-Repository/raw/main/Random%20Selection/bin/Release/Random%20Selection.exe) link.

# Screenshots
If you're wondering what this program looks like, take a look at the image below:
![Character](https://github.com/YuuyaGitHub/CS-Apps-Repository/blob/main/Random%20Selection/Images/Character.png)
![Random Number](https://github.com/YuuyaGitHub/CS-Apps-Repository/blob/main/Random%20Selection/Images/Random%20Nember.png)
