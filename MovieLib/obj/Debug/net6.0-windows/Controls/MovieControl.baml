   M S B A M L   `   `   `  ????C  ?MovieLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MovieLib.ControlsMovieLib.Controls  5      $    MovieLib.Controls.MovieControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:MovieLib.Controls     5        ? 	Resources  5
       ?? Source?? 5   
   $ /Resources/Styles.xaml??6   %    .??5      ??  ? Cursor$
 Hand??6   ??5      ??  ?? Path$  DataContext.OnMovieCommand? ?? RelativeSource ??  ?? AncestorType ItemsControl??5      ?? ??5   
   ?? 5       ?? 
TargetType" ??6   .R?5      ?? $??buttonBorder??5      $	??200??5       ?? CornerRadius$ 14??5         MovieCardBackground#???   5      $??0,16,9,0q?5       J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   Opacity$
	 0.29Q?6+   
   	Direction$	
 270Q?5         Color$ black??5         
BlurRadius$ 7Q?5      ._?5       ?  ? ColumnDefinitions 5!      ?? 5"      $
??auto ?6/   ?? 5#      $??* ?6/   .+?5&      ?? $??0??6    $??20,0,0,0q?5'      $	??190??5(      $	??160??5*      ??5)      ?? *Uri+ ?? TargetNullValue Z? 5,      ? 5.      $??1??6   $??10,0,0,0q?5/       ? RowDefinitions 50      ?? 51   "   $
??auto ?60   ?? 52   "   $
??auto ?60   ?? 53   "   $??* ?60   ?? 54   "   $
??auto ?60   .+?57      ? $??0??6#    58   "   ?? 59   &   ?? 5:   &   $
??auto ?67   .+?5<   "   ?? $??0??6,   $??20(?5>      
?????_?$??5,5,5,0q?5@      $??SemiBold"?5A      ??5=      ?? *Title+5A      ?? 5C   "   $??1??6,   $??0,0,8,0q?5D       $??18(?5F      $
??Bold"?5G      ??5E      ?? *Rating+5G      5H      ?? 5I      $??1??5J      $??5,0,0,0q?5K      $??16(?5L       ?? Padding$ 0q?5M       J? Opacity$
 0.42Q?5N      $??
UltraLight"?5O      ??5I   (   ?? *
Director+5O      ?? 5P      $??2??6(   $??15(?5Q      $??Light"?5R      $
??Wrap=?5S      $??5,25,5,5q?5T      ??5U      ?? *Description+?? 5V      $??3??6%     AddToPlaylistButtonStyle#??[ 5W   %   $??Right=?5[   %   $??9q?5\   %   ??5X   %   ?? $&  DataContext.AddToPlaylistCommand? ??  ItemsControl??5Z   %   ?? 5\   %   5]      5^      5_       ?? Triggers 5a      P? 5b       P? Property ? ?? P? Value$
 True??63   . ?5c      ??  ?? 
TargetName$ buttonBorder??6!     OnClickColor ?? Value# ?  6Q    ?? Property ? ??5d      5f      5h      5i      