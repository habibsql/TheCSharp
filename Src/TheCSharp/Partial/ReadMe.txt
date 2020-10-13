###########################################################################

- Main reason is One class should share with multiple files
- 2 types of partial
	1) Partial Class
	2) Partial Method

- Very carefully create partical classes. Sometimes it creates navigational/reading problem. For example
  if any partial class implement any interface it extra efforts are needed to organize interface implementation.
- Personally I am not verymuch fan of Partial feature.

- Partial method must be return void
- Partial method shold not be contain acces modifier
- Partial method first declare then write its implementation (previous c/c++ function/method)

###########################################################################