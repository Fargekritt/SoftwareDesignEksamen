# Game

## Cost

* Should cost get higher in Decorators?
* CostBalance:
    * For every 2 points in stats the cost multiplies per point by 1.5.
    * 1 = 1
    * 2 = 2 (* 1.5) = 3
    * 3 = 4
    * 4 = 4 (* 1.5) = 6
    * 5 = 7 
* Base cost for stats is 1 gold.

## Score System
* BaseScore = 100
* PlayerOneScore = BaseScore + (PlayerOne.gold - PlayerTwo.gold)
* PlayerTwoScore = BaseScore + (PlayerTwo.gold - PlayerOne.gold)
* If a player use less gold than his opponent on starting army, he plays with an disadvantage and get awarded with higher score if he wins. 
* The more units a player kills the more gold he gets and get awarded with higher score depending on how many units enemy kills.


# BattleLogger
## Layout:
 * "-------------------------------------------------------------------"
 * {Player} attacked {Player} with {Unit} --> GameManager
 *  {Unit} hit {Unit} for x damage --> Army
 *  {Unit} had x armor and took x damage after reduction --> Unit
 *  {Unit} current health is x  --> Unit
 *  {Unit} dealt total of x damage --> Unit
 *  {Unit} healed x from lifesteal, current health is x --> Unit
 * "-------------------------------------------------------------------"
## Implementation
 * interface BattleLogger
 * BattleLogger Singleton (Lazy instantiate when first needed)
 * all classes that need to log battle info have BattleLogger as field.
 
## 

# Rapport

## DP
### Decorator pattern 
 * Used in unit directory.  
### Singleton
 * 
### Factory
 * 
## Comment structure
* Region
* Comment format with file

### DONT WANT ANY NULL VALUES!
 * Property {get;set;} = "";
 * set properties initial values in constructor.
 

