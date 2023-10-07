ò

n/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Interfaces/IAdressServiceApp.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

Interfaces' 1
{ 
public 

	interface 
IAddressServiceApp '
{ 
Task		 
<		 
AddressViewModel		 
>		 
SelectAsync		 *
(		* +
long		+ /
id		0 2
)		2 3
;		3 4
Task

 
<

 
long

 
>

 
InsertAsync

 
(

 #
AddressPayloadViewModel

 6
address

7 >
)

> ?
;

? @
Task 
< 
AddressViewModel 
> 
UpdateAsync *
(* +#
AddressPayloadViewModel+ B
addressC J
)J K
;K L
Task 
< 
bool 
> 
DeleteAsync 
( 
long #
id$ &
)& '
;' (
Task 
< 
List 
< 
AddressViewModel "
>" #
># $
GetAddressByUserId% 7
(7 8
long8 <
userId= C
)C D
;D E
} 
} ô

o/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Interfaces/IContactServiceApp.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

Interfaces' 1
{ 
public 

	interface 
IContactServiceApp '
{ 
Task		 
<		 
ContactViewModel		 
>		 
SelectAsync		 *
(		* +
long		+ /
id		0 2
)		2 3
;		3 4
Task

 
<

 
List

 
<

 
ContactViewModel

 "
>

" #
>

# $
SelectByUserIdAsync

% 8
(

8 9
long

9 =
userId

> D
)

D E
;

E F
Task 
< 
long 
> 
InsertAsync 
( #
ContactPayloadViewModel 6
contact7 >
)> ?
;? @
Task 
< 
ContactViewModel 
> 
UpdateAsync *
(* +#
ContactPayloadViewModel+ B
contactC J
)J K
;K L
Task 
< 
bool 
> 
DeleteAsync 
( 
long #
id$ &
)& '
;' (
} 
} ›	
s/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Interfaces/IContactTypeServiceApp.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

Interfaces' 1
{ 
public 

	interface "
IContactTypeServiceApp +
{ 
Task 
<  
ContactTypeViewModel !
>! "
SelectAsync# .
(. /
long/ 3
id4 6
)6 7
;7 8
Task		 
<		 
long		 
>		 
InsertAsync		 
(		 '
ContactTypePayloadViewModel		 :
contactType		; F
)		F G
;		G H
Task

 
<

  
ContactTypeViewModel

 !
>

! "
UpdateAsync

# .
(

. / 
ContactTypeViewModel

/ C
contactType

D O
)

O P
;

P Q
Task 
< 
bool 
> 
DeleteAsync 
( 
long #
id$ &
)& '
;' (
} 
} ¢

l/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Interfaces/IUserServiceApp.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

Interfaces' 1
{ 
public 

	interface 
IUserServiceApp $
{ 
Task 
< 
UserViewModel 
> 
SelectAsync '
(' (
long( ,
id- /
)/ 0
;0 1
Task		 
<		 
long		 
>		 
InsertAsync		 
(		  
UserPayloadViewModel		 3
user		4 8
)		8 9
;		9 :
Task

 
<

 
bool

 
>

 

LoginAsync

 
(

 !
LoginPayloadViewModel

 3
payload

4 ;
)

; <
;

< =
Task 
< 
UserViewModel 
> 
UpdateAsync '
(' (
UserViewModel( 5
user6 :
): ;
;; <
Task 
< 
bool 
> 
DeleteAsync 
( 
long #
id$ &
)& '
;' (
} 
} Ó
l/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Services/AddressServiceApp.cs
	namespace		 	

DubaiSmoke		
 
.		 
Users		 
.		 
Application		 &
.		& '
Services		' /
{

 
public 

class 
AddressServiceApp "
:# $
IAddressServiceApp% 7
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IAddressService (
_addressService) 8
;8 9
public 
AddressServiceApp  
(  !
IAddressService! 0
addressService1 ?
,? @
IMapperA H
mapperI O
)O P
{ 	
_addressService 
= 
addressService ,
;, -
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
long 
> 
InsertAsync  +
(+ ,#
AddressPayloadViewModel, C
addressD K
)K L
{ 	
return 
await 
_addressService (
.( )
InsertAsync) 4
(4 5
_mapper5 <
.< =
Map= @
<@ A
AddressEntityA N
>N O
(O P
addressP W
)W X
)X Y
;Y Z
} 	
public 
async 
Task 
< 
AddressViewModel *
>* +
SelectAsync, 7
(7 8
long8 <
id= ?
)? @
{ 	
return 
_mapper 
. 
Map 
< 
AddressViewModel /
>/ 0
(0 1
await1 6
_addressService7 F
.F G
SelectAsyncG R
(R S
idS U
)U V
)V W
;W X
} 	
public   
async   
Task   
<   
AddressViewModel   *
>  * +
UpdateAsync  , 7
(  7 8#
AddressPayloadViewModel  8 O
address  P W
)  W X
{!! 	
return"" 
_mapper"" 
."" 
Map"" 
<"" 
AddressViewModel"" /
>""/ 0
(""0 1
await""1 6
_addressService""7 F
.""F G
UpdateAsync""G R
(""R S
_mapper""S Z
.""Z [
Map""[ ^
<""^ _
AddressEntity""_ l
>""l m
(""m n
address""n u
)""u v
)""v w
)""w x
;""x y
}## 	
public%% 
async%% 
Task%% 
<%% 
bool%% 
>%% 
DeleteAsync%%  +
(%%+ ,
long%%, 0
id%%1 3
)%%3 4
{&& 	
return'' 
await'' 
_addressService'' (
.''( )
DeleteAsync'') 4
(''4 5
id''5 7
)''7 8
;''8 9
}(( 	
public** 
async** 
Task** 
<** 
List** 
<** 
AddressViewModel** /
>**/ 0
>**0 1
GetAddressByUserId**2 D
(**D E
long**E I
userId**J P
)**P Q
{++ 	
return,, 
_mapper,, 
.,, 
Map,, 
<,, 
List,, #
<,,# $
AddressViewModel,,$ 4
>,,4 5
>,,5 6
(,,6 7
await,,7 <
_addressService,,= L
.,,L M
GetAddressByUserId,,M _
(,,_ `
userId,,` f
),,f g
),,g h
;,,h i
}-- 	
}.. 
}// Õ
l/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Services/ContactServiceApp.cs
	namespace		 	

DubaiSmoke		
 
.		 
Users		 
.		 
Application		 &
.		& '
Services		' /
{

 
public 

class 
ContactServiceApp "
:# $
IContactServiceApp% 7
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IContactService (
_contactService) 8
;8 9
public 
ContactServiceApp  
(  !
IContactService! 0
contactService1 ?
,? @
IMapperA H
mapperI O
)O P
{ 	
_contactService 
= 
contactService ,
;, -
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
long 
> 
InsertAsync  +
(+ ,#
ContactPayloadViewModel, C
contactD K
)K L
{ 	
return 
await 
_contactService (
.( )
InsertAsync) 4
(4 5
_mapper5 <
.< =
Map= @
<@ A
ContactEntityA N
>N O
(O P
contactP W
)W X
)X Y
;Y Z
} 	
public 
async 
Task 
< 
ContactViewModel *
>* +
SelectAsync, 7
(7 8
long8 <
id= ?
)? @
{ 	
return 
_mapper 
. 
Map 
< 
ContactViewModel /
>/ 0
(0 1
await1 6
_contactService7 F
.F G
SelectAsyncG R
(R S
idS U
)U V
)V W
;W X
} 	
public   
async   
Task   
<   
ContactViewModel   *
>  * +
UpdateAsync  , 7
(  7 8#
ContactPayloadViewModel  8 O
contact  P W
)  W X
{!! 	
return"" 
_mapper"" 
."" 
Map"" 
<"" 
ContactViewModel"" /
>""/ 0
(""0 1
await""1 6
_contactService""7 F
.""F G
UpdateAsync""G R
(""R S
_mapper""S Z
.""Z [
Map""[ ^
<""^ _
ContactEntity""_ l
>""l m
(""m n
contact""n u
)""u v
)""v w
)""w x
;""x y
}## 	
public%% 
async%% 
Task%% 
<%% 
bool%% 
>%% 
DeleteAsync%%  +
(%%+ ,
long%%, 0
id%%1 3
)%%3 4
{&& 	
return'' 
await'' 
_contactService'' (
.''( )
DeleteAsync'') 4
(''4 5
id''5 7
)''7 8
;''8 9
}(( 	
public** 
async** 
Task** 
<** 
List** 
<** 
ContactViewModel** /
>**/ 0
>**0 1
SelectByUserIdAsync**2 E
(**E F
long**F J
userId**K Q
)**Q R
{++ 	
return,, 
_mapper,, 
.,, 
Map,, 
<,, 
List,, #
<,,# $
ContactViewModel,,$ 4
>,,4 5
>,,5 6
(,,6 7
await,,7 <
_contactService,,= L
.,,L M
SelectByUserIdAsync,,M `
(,,` a
userId,,a g
),,g h
),,h i
;,,i j
}-- 	
}.. 
}// £
p/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Services/ContactTypeServiceApp.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '
Services' /
{		 
public

 

class

 !
ContactTypeServiceApp

 &
:

' ("
IContactTypeServiceApp

) ?
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IContactTypeService ,
_contactTypeService- @
;@ A
public !
ContactTypeServiceApp $
($ %
IContactTypeService% 8
contactTypeService9 K
,K L
IMapperM T
mapperU [
)[ \
{ 	
_contactTypeService 
=  !
contactTypeService" 4
;4 5
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
long 
> 
InsertAsync  +
(+ ,'
ContactTypePayloadViewModel, G
contactTypeH S
)S T
{ 	
return 
await 
_contactTypeService ,
., -
InsertAsync- 8
(8 9
_mapper9 @
.@ A
MapA D
<D E
ContactTypeEntityE V
>V W
(W X
contactTypeX c
)c d
)d e
;e f
} 	
public 
async 
Task 
<  
ContactTypeViewModel .
>. /
SelectAsync0 ;
(; <
long< @
idA C
)C D
{ 	
return 
_mapper 
. 
Map 
<  
ContactTypeViewModel 3
>3 4
(4 5
await5 :
_contactTypeService; N
.N O
SelectAsyncO Z
(Z [
id[ ]
)] ^
)^ _
;_ `
} 	
public 
async 
Task 
<  
ContactTypeViewModel .
>. /
UpdateAsync0 ;
(; < 
ContactTypeViewModel< P
contactTypeQ \
)\ ]
{   	
return!! 
_mapper!! 
.!! 
Map!! 
<!!  
ContactTypeViewModel!! 3
>!!3 4
(!!4 5
await!!5 :
_contactTypeService!!; N
.!!N O
UpdateAsync!!O Z
(!!Z [
_mapper!![ b
.!!b c
Map!!c f
<!!f g
ContactTypeEntity!!g x
>!!x y
(!!y z
contactType	!!z …
)
!!… †
)
!!† ‡
)
!!‡ ˆ
;
!!ˆ ‰
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
bool$$ 
>$$ 
DeleteAsync$$  +
($$+ ,
long$$, 0
id$$1 3
)$$3 4
{%% 	
return&& 
await&& 
_contactTypeService&& ,
.&&, -
DeleteAsync&&- 8
(&&8 9
id&&9 ;
)&&; <
;&&< =
}'' 	
}(( 
})) Í
i/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Services/UserServiceApp.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '
Services' /
{		 
public

 

class

 
UserServiceApp

 
:

  !
IUserServiceApp

" 1
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IUserService %
_userService& 2
;2 3
public 
UserServiceApp 
( 
IUserService *
userService+ 6
,6 7
IMapper8 ?
mapper@ F
)F G
{ 	
_userService 
= 
userService &
;& '
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
long 
> 
InsertAsync  +
(+ , 
UserPayloadViewModel, @
userA E
)E F
{ 	
return 
await 
_userService %
.% &
InsertAsync& 1
(1 2
_mapper2 9
.9 :
Map: =
<= >

UserEntity> H
>H I
(I J
userJ N
)N O
)O P
;P Q
} 	
public 
async 
Task 
< 
UserViewModel '
>' (
SelectAsync) 4
(4 5
long5 9
id: <
)< =
{ 	
return 
_mapper 
. 
Map 
< 
UserViewModel ,
>, -
(- .
await. 3
_userService4 @
.@ A
SelectAsyncA L
(L M
idM O
)O P
)P Q
;Q R
} 	
public 
async 
Task 
< 
UserViewModel '
>' (
UpdateAsync) 4
(4 5
UserViewModel5 B
userC G
)G H
{   	
return!! 
_mapper!! 
.!! 
Map!! 
<!! 
UserViewModel!! ,
>!!, -
(!!- .
await!!. 3
_userService!!4 @
.!!@ A
UpdateAsync!!A L
(!!L M
_mapper!!M T
.!!T U
Map!!U X
<!!X Y

UserEntity!!Y c
>!!c d
(!!d e
user!!e i
)!!i j
)!!j k
)!!k l
;!!l m
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
bool$$ 
>$$ 
DeleteAsync$$  +
($$+ ,
long$$, 0
id$$1 3
)$$3 4
{%% 	
return&& 
await&& 
_userService&& %
.&&% &
DeleteAsync&&& 1
(&&1 2
id&&2 4
)&&4 5
;&&5 6
}'' 	
public)) 
async)) 
Task)) 
<)) 
bool)) 
>)) 

LoginAsync))  *
())* +!
LoginPayloadViewModel))+ @
payload))A H
)))H I
{** 	
var++ 
map++ 
=++ 
new++ 

UserEntity++ $
{,, 
Login-- 
=-- 
payload-- 
.--  
email--  %
,--% &
Password.. 
=.. 
payload.. "
..." #
password..# +
}// 
;// 
return11 
await11 
_userService11 %
.11% &

LoginAsync11& 0
(110 1
map111 4
)114 5
;115 6
}22 	
}33 
}44 »
m/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Validation/AddressValidator.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

Validation' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
AddressValidator !
:" #
AbstractValidator$ 5
<5 6#
AddressPayloadViewModel6 M
>M N
{		 
public

 
AddressValidator

 
(

  
)

  !
{ 	
RuleFor 
( 
x 
=> 
x 
. 
addressName &
)& '
.' (
NotNull( /
(/ 0
)0 1
.1 2
NotEmpty2 :
(: ;
); <
.< =
WithMessage= H
(H I
$strI c
)c d
;d e
RuleFor 
( 
x 
=> 
x 
. 
addressName &
)& '
.' (
MaximumLength( 5
(5 6
$num6 8
)8 9
.9 :
WithMessage: E
(E F
$strF w
)w x
;x y
RuleFor 
( 
x 
=> 
x 
. 
addressNumber (
)( )
.) *
NotNull* 1
(1 2
)2 3
.3 4
NotEmpty4 <
(< =
)= >
.> ?
WithMessage? J
(J K
$strK o
)o p
;p q
RuleFor 
( 
x 
=> 
x 
. 
addressComplement ,
), -
.- .
MaximumLength. ;
(; <
$num< >
)> ?
.? @
WithMessage@ K
(K L
$strL 
)	 €
;
€ 
RuleFor 
( 
x 
=> 
x 
. 

postalCode %
)% &
.& '
NotNull' .
(. /
)/ 0
.0 1
NotEmpty1 9
(9 :
): ;
;; <
RuleFor 
( 
x 
=> 
x 
. 

postalCode %
)% &
.& '
Length' -
(- .
$num. /
)/ 0
;0 1
} 	
} 
} ª
q/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Validation/ContactTypeValidator.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

Validation' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class  
ContactTypeValidator %
:& '
AbstractValidator( 9
<9 :'
ContactTypePayloadViewModel: U
>U V
{		 
public

  
ContactTypeValidator

 #
(

# $
)

$ %
{ 	
RuleFor 
( 
x 
=> 
x 
. 
name 
)  
.  !
NotNull! (
(( )
)) *
.* +
NotEmpty+ 3
(3 4
)4 5
.5 6
WithMessage6 A
(A B
$strB X
)X Y
;Y Z
} 	
} 
} û
m/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Validation/ContactValidator.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

Validation' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
ContactValidator !
:" #
AbstractValidator$ 5
<5 6#
ContactPayloadViewModel6 M
>M N
{		 
public

 
ContactValidator

 
(

  
)

  !
{ 	
RuleFor 
( 
x 
=> 
x 
. 
userId !
)! "
." #
NotNull# *
(* +
)+ ,
., -
NotEmpty- 5
(5 6
)6 7
.7 8
WithMessage8 C
(C D
$strD \
)\ ]
;] ^
RuleFor 
( 
x 
=> 
x 
. 
typeId !
)! "
." #
NotNull# *
(* +
)+ ,
., -
NotEmpty- 5
(5 6
)6 7
.7 8
WithMessage8 C
(C D
$strD \
)\ ]
;] ^
RuleFor 
( 
x 
=> 
x 
. 
value  
)  !
.! "
NotNull" )
() *
)* +
.+ ,
NotEmpty, 4
(4 5
)5 6
.6 7
WithMessage7 B
(B C
$strC Z
)Z [
;[ \
} 	
} 
} ã
j/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/Validation/UserValidator.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

Validation' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
UserValidator 
:  
AbstractValidator! 2
<2 3 
UserPayloadViewModel3 G
>G H
{		 
public

 
UserValidator

 
(

 
)

 
{ 	
RuleFor 
( 
x 
=> 
x 
. 
login  
)  !
.! "
NotNull" )
() *
)* +
.+ ,
NotEmpty, 4
(4 5
)5 6
.6 7
WithMessage7 B
(B C
$strC Z
)Z [
;[ \
RuleFor 
( 
x 
=> 
x 
. 
login  
)  !
.! "
EmailAddress" .
(. /
)/ 0
.0 1
WithMessage1 <
(< =
$str= X
)X Y
;Y Z
RuleFor 
( 
x 
=> 
x 
. 
name 
)  
.  !
NotEmpty! )
() *
)* +
.+ ,
WithMessage, 7
(7 8
$str8 N
)N O
;O P
RuleFor 
( 
x 
=> 
x 
. 
password #
)# $
.$ %
NotEmpty% -
(- .
). /
./ 0
WithMessage0 ;
(; <
$str< S
)S T
;T U
RuleFor 
( 
x 
=> 
x 
. 
password #
)# $
.$ %
MinimumLength% 2
(2 3
$num3 5
)5 6
.6 7
WithMessage7 B
(B C
$strC o
)o p
;p q
} 	
} 
} §
t/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/ViewModels/AddressPayloadViewModel.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

ViewModels' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class #
AddressPayloadViewModel (
{ 
[		 	
Required			 
(		 
ErrorMessage		 
=		  
$str		! $
)		$ %
]		% &
public

 
long

 
userId

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 
addressName !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
int 
addressNumber  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
addressComplement '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 

postalCode  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
} ¸
m/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/ViewModels/AddressViewModel.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

ViewModels' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
AddressViewModel !
{ 
[		 	
Required			 
(		 
ErrorMessage		 
=		  
$str		! $
)		$ %
]		% &
public

 
long

 
userId

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 
addressName !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
int 
addressNumber  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
addressComplement '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 

postalCode  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
UserViewModel 
user !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} Ë

t/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/ViewModels/ContactPayloadViewModel.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

ViewModels' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class #
ContactPayloadViewModel (
{ 
[		 	
Required			 
(		 
ErrorMessage		 
=		  
$str		! $
)		$ %
]		% &
public

 
long

 
userId

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
long 
typeId 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 
value 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ˆ
x/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/ViewModels/ContactTypePayloadViewModel.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

ViewModels' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class '
ContactTypePayloadViewModel ,
{ 
[		 	
Required			 
(		 
ErrorMessage		 
=		  
$str		! $
)		$ %
]		% &
public

 
string

 
name

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
} 
} ›
q/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/ViewModels/ContactTypeViewModel.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

ViewModels' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class  
ContactTypeViewModel %
{ 
[		 	
Required			 
(		 
ErrorMessage		 
=		  
$str		! $
)		$ %
]		% &
public

 
long

 
id

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 
name 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ‰
m/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/ViewModels/ContactViewModel.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

ViewModels' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
ContactViewModel !
{ 
[		 	
Required			 
(		 
ErrorMessage		 
=		  
$str		! $
)		$ %
]		% &
public

 
long

 
userId

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
long 
typeId 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 
value 
{ 
get !
;! "
set# &
;& '
}( )
public 
UserViewModel 
user !
{" #
get$ '
;' (
set) ,
;, -
}. /
public  
ContactTypeViewModel #
contactType$ /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
} 
} Œ
r/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/ViewModels/LoginPayloadViewModel.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

ViewModels' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class !
LoginPayloadViewModel &
{ 
public 
string 
email 
{ 
get !
;! "
set# &
;& '
}' (
public		 
string		 
password		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		* +
}

 
} ò
q/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/ViewModels/UserPayloadViewModel.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

ViewModels' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class  
UserPayloadViewModel %
{ 
[		 	
Required			 
(		 
ErrorMessage		 
=		  
$str		! $
)		$ %
]		% &
public

 
string

 
name

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 
birthDay 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 
login 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 
password 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ë
j/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Application/ViewModels/UserViewModel.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Application &
.& '

ViewModels' 1
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
UserViewModel 
{ 
public		 
long		 
id		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
[

 	
Required

	 
(

 
ErrorMessage

 
=

  
$str

! $
)

$ %
]

% &
public 
string 
name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
birthDay 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 
login 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
( 
ErrorMessage 
=  
$str! $
)$ %
]% &
public 
string 
password 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} 