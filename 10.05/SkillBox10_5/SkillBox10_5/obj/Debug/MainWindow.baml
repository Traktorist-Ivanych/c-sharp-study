   M S B A M L   `   `   `  ????G  CSkillBox10_5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SkillBox10_5SkillBox10_5  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 62       SkillBox10_5.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SkillBox10_5     5   	   6sys&clr-namespace:System;assembly=mscorlib     62     ? Title$  SkillBox10.5??5   	   $	??500??6   $
??1000??6+    ? 	Resources 5
         fontSize  
marginSize  paddingSize"  System.Windows.TextAlignment  centerAlignment(  "System.Windows.HorizontalAlignment  stretchHorizontalAlignment&   System.Windows.VerticalAlignment  stretchVerticalAlignment??%?   &	        &	      &	 4     &	 M     &	 k     &	 ?     X?5   
   18Q?6*   u?5   
   10q?6+   u?5   
   5q?6+    5   
   
Center=?68    5   
   Stretch=?6J    5   
   Stretch=?6F   5      .??5      ?  ? ShowGridLines .  ? RowDefinitions 5   
   ?? 5      $	??50* ?6   ?? 5      $
??200* ?6   ?? 5      $	??50* ?6   ?? 5      $
??200* ?6    ? ColumnDefinitions 5   
   ?? 5      $
??400* ?6   ?? 5      $
??200* ?6   ?? 5      $
??400* ?6   .+?5    
   ?? -   5         ??Name$ LineToWordsResultListBox??5!      $??2??5"      $??1??5#      #??[ 5$      #??[ 5%      #??[ 5&      #??[ 5'      #??[  5(      ?? 5+   
   -   5         ??Name$ WordsShaffleResultLabel??5,      $??2??5-      $??3??5.      #??[ 5/      #??[ 50      #??[ 51      #??[ 52      #??[  53      ?? 56   
   -   5         ??Name$ LineToWordsButton??57      $ ??Преобразовать??58      $??1??59      $??1??5:      #??[ 5;      #??[ 5<      #??[ 5=      #??[ 5>      #??[  5?      62   ?? 5B   
   -   5        $ WordsShaffleButton??5C      $ ??Преобразовать??5D      $??1??5E      $??3??5F      #??[ 5G      #??[ 5H      #??[ 5I      #??[ 5J      #??[  5K      62   ?? 5N   
   -   5         ??Name$ LineToWordsInputTextBox??5O      $??1??5P      #??[ 5Q      #??[ 5R      #??[ 5S      #??[ 5T      	 ?? TextAlignment#	 [ 5U      #??[  5V      
 ?? TextWrapping$

 Wrap=?5W      $+??%Введите предложение??5X      ?? 5[   
   -   5        $ WordsShaffleInputTextBox??5\      $??3??5]      #??[ 5^      #??[ 5_      #??[ 5`      #??[ 5a      #	 [ 5b      #??[  5c      $

 Wrap=?5d      $+??%Введите предложение??5e      ?? 5h   
   -   5         ??Name$ LineToWordsTextBlock??5h      #??[ 5i      #??[ 5j      #??[ 5k       ?? Padding# [ 5l       ?? TextAlignment# [ 5m      #??[  5n      $
??Wrap=?5o      $7??1Разделение строки на слова??5p      ?? 5s   
   -   5        $  LineToWordsResultTextBlock??5t      $??2??5u      #??[ 5v      #??[ 5w      #??[ 5x      # [ 5y      # [ 5z      #??[  5{      $
??Wrap=?5|      $%??Разделеные слова??5}      ?? 5?   
   -	   5        $ WordsShaffleTextBlock??5?      $??2??5?      #??[ 5?      #??[ 5?      #??[ 5?      # [ 5?      # [ 5?      #??[  5?      $
??Wrap=?5?      $A??;Перестановка слов в предложении??5?      ?? 5?   
   -
   5        $! WordsShaffleResultTextBlock??5?      $??2??5?      $??2??5?      #??[ 5?      #??[ 5?      #??[ 5?      # [ 5?      # [ 5?      #??[  5?      $
??Wrap=?5?      $K??EПерестановленные слова в предложении??5?      5?      5?      