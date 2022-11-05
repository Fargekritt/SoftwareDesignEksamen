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

# BattleLogger
## Layout:
 * "-------------------------------------------------------------------"
 * {Player} attacked {Player} with {Unit}
 *  {Unit} hit {Unit} for x damage
 *  {Unit} had x armor and took x damage after reduction
 *  {Unit} current health is x
 *  {Unit} dealt total of x damage
 *  {Unit} healed x from lifesteal, current health is x 
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

* -Fixing string null values-
* String {getset}="";


