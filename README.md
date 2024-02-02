# Interview

in this project I've used some of utility that I wrote before you can find them in 
https://github.com/alireza97kh/UnityUtility.git

main pages is 

main menu

which save and load player profile and also update daily rewards list 


leader board pop up 

send an async request and get list of players in leader board and then show their data like 
user name, avatar, and medals.


daily rewards pop up

it shows rewards that stored in DailyRewardData which is a scriptable object and you can easily edit, add or remove rewards on it.

ever reward type inheritance from RewardBase which is an abstract class and you can override functions like

"Init" : this function initial rewards and set data like reward sprite or reward count 

"Select" : which called when user select that reward and add it to his profile 

"SetRewardBg" : which controller reward background and change it if user already received the reward.

