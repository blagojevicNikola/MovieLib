   M S B A M L   `   `   `  џџџџC  ?MovieLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MovieLib.ViewsMovieLib.Views  5      #clr-namespace:MovieLibMovieLib  69   "    MovieLib.Views.MoviePageView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MovieLib.Views     5      +movielibclr-namespace:MovieLib     69     џ 	Resources  5
       є§ Sourceє§ 5   
   $ /Resources/Styles.xaml?§6   %    .ђџ5      џ  џ RowDefinitions 5   
   у§ 5      $
Ђџauto џ6   у§ 5      $Ђџ* џ6   .+џ5   
   Щџ $Сџ0Хў6   $Яџ20,15,15,15q§5      $
аџLeft=џ5         BackButtonStyle#Щџ[  5      љџ5      ьџ *BackToMoviesCommand+5      к§ 5   
   $Сџ1Хў6   $
џAuto=џ5      .ђџ5   
   џ $Сџ1Хў6    5      у§ 5      $
Ђџauto џ6    у§ 5      $
Ђџauto џ6    у§ 5      $
Ђџauto џ6    у§ 5      $Ђџ* џ6    .+џ5       џ $Сџ1Хў6    џ ColumnDefinitions 5!      Іџ 5"      $
ѓџauto џ6'   Іџ 5#      $ѓџ* џ6'   .+џ5&      Юџ 
ћџшци­џ$Уџ0Хў5'      $њџ2q§5(      $Яџ5q§5)       Юџ CornerRadius$ 8џ5*      ._џ5+      чў $	бџ290Єў5,      $	Чџ220Єў5-      $аџCenter=џ5/      Еџ5.      ьџ *	Movie.Uri+ ьџ TargetNullValue Zў 51      52      џ 53      $Уџ1Хў6    54      у§ 55      $
Ђџauto џ6(   у§ 56      $
Ђџauto џ6(   у§ 57      $
Ђџauto џ6(   у§ 58      $Ђџ* џ6(   .+џ5:      џ $Сџ0Хў6    5;      Іџ 5<      $
ѓџauto џ6/   Іџ 5=      $ѓџ* џ6/   .+џ5?      Ї§  Ї§ Orientation$ 
Horizontal=џ6%   $Уџ0Хў5@   %   .+џ5A      Іў $фџ34(џ5B   %   $сџSemiBold"џ5C   %   
рџшци­џђџ5A   %   ьџ *Movie.Title+5D   %   Іў 5E      $фџ30(џ5F   $   $ШџCenter=џ5G   $   $сџLight"џ5H   $   
рџшци­џђџ5E   $   ьџ *Movie.Published+5I   $   5J      Іў 5K      $Уџ1Хў6    $фџ34(џ5M       $аџRight=џ5N       $сџMedium"џ5O         	FontColor#рџН  5P       ђџ5L       ьџ *Movie.Rating+5P       5Q      Іў 5R      $Сџ1Хў6   $фџ24(џ5T      $Яџ8,0,0,0q§5U      $тџItalic$џ5V      $нџ0q§5W      $сџ
UltraLight"џ5X      #рџН  5Y      ђџ5S      ьџ *Movie.Director+5Y      Зў 5Z      $Сџ2Хў6#   $Яџ0,10,0,0q§5[   #   Ўџ5\   #   ьџ *Types+Бџ5]      џ 5^   "   .Rџ5_   &   џ .+џ5`   *   Юџ 
ќџшџџџ 
ћџшци­џ$њџ2q§5b   -   $ 10џ5c   -    Юџ Padding$ 0q§5d   -   $Яџ3,0,0,0q§5e   -   ._џ5f   .   Ї§ $ 
Horizontal=џ69   .+џ5g   2   Іў $ШџCenter=џ5h   1   $аџCenter=џ5i   1   $нџ0,0,0,3q§5j   1   $фџ16(џ5k   1     AdminFieldFontColor#рџН  5l   1   $тџItalic$џ5m   1   $Яџ3,4,3,0q§5n   1   ђџ5g   8   ьџ *Name+5n   1   5o   /   5p   +   5q   '   5r   #   Џџ5t      Жў 5u   "   .Rџ5v   &   § 5w   #   5y      § 5z      $Сџ3Хў6    $џ19(џ5{       $
џWrap=џ5|       $џLight"џ5}       #џН  5~       $Яџ8,15,8,4q§5       џ5       ьџ *Movie.Description+5       5      5      ж§ 5      $Сџ2Хў6   $Яџ	9,20,9,20q§5      џ 5      $Сџ3Хў6    5      у§ 5      $
Ђџauto џ6$   у§ 5      $
Ђџauto џ6$   у§ 5      $Ђџ* џ6(   .+џ5      § $Сџ0Хў6     CommentTextBox#Щџ[ 5      $	бџ100Єў5      $Яџ9q§5      џ5      ьџ *	Comment+5      џ 5      $Сџ1Хў6    5      Іџ 5      Іџ 5      .+џ5      Єџ $Чџ50Єў6#   $
аџLeft=џ5   #   $фџ18(џ5   #   
шџшгггџ$сџSemiBold"џ5   #   $пџCenter=џ5   #   $кџCenter=џ5   #   $Яџ9,0,0,0q§5   #    з§ SelectedIndex 5   #   ьџ *	RateIndex+.@џ5Ё      Ѓџ $ђџ1§6+     RateComboBoxStyle#Щџ[ 5Ђ   +   Ѓџ 5Ѓ      $ђџ2§6+   #Щџ[ 5Є   +   Ѓџ 5Ѕ      $ђџ3§6+   #Щџ[ 5І   +   Ѓџ 5Ї      $ђџ4§6+   #Щџ[ 5Ј   +   Ѓџ 5Љ      $ђџ5§6+   #Щџ[ 5Њ   +   Ѓџ 5Ћ      $ђџ6§6+   #Щџ[ 5Ќ   +   Ѓџ 5­      $ђџ7§6+   #Щџ[ 5Ў   +   Ѓџ 5Џ      $ђџ8§6+   #Щџ[ 5А   +   Ѓџ 5Б      $ђџ9§6+   #Щџ[ 5В   +   Ѓџ 5Г      $ђџ10§6+   #Щџ[ 5Д   +   5Е      Щџ 5Ж        NewMovieButtonStyle#Щџ[ 6!   $Уџ1Хў5З   !   $аџRight=џ5Й   !   $Яџ0,0,9,0q§5К   !   љџ5И   !   ьџ *PostReviewCommand+5К   !   5Л      Зў 5М      $Яџ0,19,0,0q§5Н   #   $Сџ2Хў5О   #   Ўџ5М   #   ьџ *	Reviews+Бџ5П      џ 5Р      .Rџ5С   "   џ $Яџ9,0,9,0q§6'   .+џ5Т   &   Юџ $њџ0,0,0,2q§6-     ReviewBackgroundColor#ќџН  5У   -   
ћџшгггџ5Ф   -   џ 5Х   &    5Ц   *   у§ 5Ч   .   $
Ђџauto џ6<   у§ 5Ш   .   $Ђџ* џ6<   .+џ5Ъ   *   џ $Сџ0Хў6/    5Ы   .   Іџ 5Ь   2   $ѓџ* џ6C   Іџ 5Э   2   $
ѓџauto џ6C   .+џ5Я   *   Ї§ $Уџ0Хў65   $ 
Horizontal=џ5а   5   .+џ5б   *   Іў $фџ22(џ5в   0   #рџН  5г   0   ђџ5б   0   ьџ *
Username+5г   0   Іў 5д   .   $ђџ(§64   $ШџCenter=џ5е   0   $нџ0q§5ж   0   $фџ16(џ5з   0     LightFontColor#рџН  5и   0   $сџ
UltraLight"џ5й   0   Іў 5к   .   $нџ0q§5л   0   $фџ16(џ5м   0   $ШџCenter=џ5н   0   #рџН  5о   0   $сџ
UltraLight"џ5п   0   ђџ5к   4   ьџ *
PostDate+5п   0   Іў 5р   .   $ђџ)§64   $ШџCenter=џ5с   0   $нџ0q§5т   0   $фџ16(џ5у   0   #рџН  5ф   0   $сџ
UltraLight"џ5х   0   5ц   +   Іў 5ч   .   $Уџ1Хў64   $сџSemiBold"џ5щ   0   $фџ18(џ5ъ   0     ReviewRatingColor#рџН  5ы   0   ђџ5ш   0   ьџ *Rate+5ы   0   5ь   +   § 5э   *   $Сџ1Хў64   $Яџ9,9,9,9q§5ю   2   $џ19(џ5№   2   $
џWrap=џ5ё   2   #џН  5ђ   2   џ5я   2   ьџ *	Comment+5ђ   2   5ѓ   '   5є   #   5ѕ      5ї      5ј      5      5     5     5     