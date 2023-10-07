¸7
g/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Api/Controllers/AddressController.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Api 
. 
Controllers *
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
AddressController "
:# $
BaseController% 3
{ 
private 
readonly 
IAddressServiceApp +
_addressServiceApp, >
;> ?
public 
AddressController  
(  !
IAddressServiceApp! 3
addressServiceApp4 E
,E F$
ErrorHandlerNotificationG _
notifications` m
)m n
:o p
baseq u
(u v
notifications	v ƒ
)
ƒ „
{ 	
_addressServiceApp 
=  
addressServiceApp! 2
;2 3
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
AddressViewModel% 5
)5 6
,6 7
(8 9
int9 <
)< =
HttpStatusCode= K
.K L
OKL N
)N O
]O P
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
ClientError% 0
)0 1
,1 2
(3 4
int4 7
)7 8
HttpStatusCode8 F
.F G

BadRequestG Q
)Q R
]R S
public 
async 
Task 
< 
IActionResult '
>' (
SelectAsync) 4
(4 5
int5 8
id9 ;
); <
{ 	
return 
Response 
( 
await !
_addressServiceApp" 4
.4 5
SelectAsync5 @
(@ A
idA C
)C D
)D E
;E F
} 	
[   	
HttpGet  	 
(   
$str    
)    !
]  ! "
[!! 	 
ProducesResponseType!!	 
(!! 
typeof!! $
(!!$ %
List!!% )
<!!) *
AddressViewModel!!* :
>!!: ;
)!!; <
,!!< =
(!!> ?
int!!? B
)!!B C
HttpStatusCode!!C Q
.!!Q R
OK!!R T
)!!T U
]!!U V
["" 	 
ProducesResponseType""	 
("" 
typeof"" $
(""$ %
ClientError""% 0
)""0 1
,""1 2
(""3 4
int""4 7
)""7 8
HttpStatusCode""8 F
.""F G

BadRequest""G Q
)""Q R
]""R S
public## 
async## 
Task## 
<## 
IActionResult## '
>##' (
GetAddressByUserId##) ;
(##; <
int##< ?
userId##@ F
)##F G
{$$ 	
return%% 
Response%% 
(%% 
await%% !
_addressServiceApp%%" 4
.%%4 5
GetAddressByUserId%%5 G
(%%G H
userId%%H N
)%%N O
)%%O P
;%%P Q
}&& 	
[(( 	
HttpPost((	 
((( 
$str(( 
)(( 
](( 
[)) 	 
ProducesResponseType))	 
()) 
typeof)) $
())$ %
long))% )
)))) *
,))* +
()), -
int))- 0
)))0 1
HttpStatusCode))1 ?
.))? @
OK))@ B
)))B C
]))C D
[** 	 
ProducesResponseType**	 
(** 
typeof** $
(**$ %
ClientError**% 0
)**0 1
,**1 2
(**3 4
int**4 7
)**7 8
HttpStatusCode**8 F
.**F G

BadRequest**G Q
)**Q R
]**R S
public++ 
async++ 
Task++ 
<++ 
IActionResult++ '
>++' (
InsertAsync++) 4
(++4 5
[++5 6
FromBody++6 >
]++> ?#
AddressPayloadViewModel++@ W
payload++X _
)++_ `
{,, 	
return-- 
Response-- 
(-- 
await-- !
_addressServiceApp--" 4
.--4 5
InsertAsync--5 @
(--@ A
payload--A H
)--H I
)--I J
;--J K
}.. 	
[00 	
HttpPut00	 
(00 
$str00 
)00 
]00 
[11 	 
ProducesResponseType11	 
(11 
typeof11 $
(11$ %
AddressViewModel11% 5
)115 6
,116 7
(118 9
int119 <
)11< =
HttpStatusCode11= K
.11K L
OK11L N
)11N O
]11O P
[22 	 
ProducesResponseType22	 
(22 
typeof22 $
(22$ %
ClientError22% 0
)220 1
,221 2
(223 4
int224 7
)227 8
HttpStatusCode228 F
.22F G

BadRequest22G Q
)22Q R
]22R S
public33 
async33 
Task33 
<33 
IActionResult33 '
>33' (
UpdateAsync33) 4
(334 5
[335 6
FromBody336 >
]33> ?#
AddressPayloadViewModel33@ W
payload33X _
)33_ `
{44 	
return55 
Response55 
(55 
await55 !
_addressServiceApp55" 4
.554 5
UpdateAsync555 @
(55@ A
payload55A H
)55H I
)55I J
;55J K
}66 	
[88 	

HttpDelete88	 
(88 
$str88 
)88 
]88 
[99 	 
ProducesResponseType99	 
(99 
typeof99 $
(99$ %
bool99% )
)99) *
,99* +
(99, -
int99- 0
)990 1
HttpStatusCode991 ?
.99? @
OK99@ B
)99B C
]99C D
[:: 	 
ProducesResponseType::	 
(:: 
typeof:: $
(::$ %
ClientError::% 0
)::0 1
,::1 2
(::3 4
int::4 7
)::7 8
HttpStatusCode::8 F
.::F G

BadRequest::G Q
)::Q R
]::R S
public;; 
async;; 
Task;; 
<;; 
IActionResult;; '
>;;' (
DeleteAsync;;) 4
(;;4 5
long;;5 9
id;;: <
);;< =
{<< 	
return== 
Response== 
(== 
await== !
_addressServiceApp==" 4
.==4 5
DeleteAsync==5 @
(==@ A
id==A C
)==C D
)==D E
;==E F
}>> 	
}?? 
}@@ ¼7
g/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Api/Controllers/ContactController.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Api 
. 
Controllers *
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
ContactController "
:# $
BaseController% 3
{ 
private 
readonly 
IContactServiceApp +
_contactServiceApp, >
;> ?
public 
ContactController  
(  !
IContactServiceApp! 3
contactServiceApp4 E
,E F$
ErrorHandlerNotificationG _
notifications` m
)m n
:o p
baseq u
(u v
notifications	v ƒ
)
ƒ „
{ 	
_contactServiceApp 
=  
contactServiceApp! 2
;2 3
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
ContactViewModel% 5
)5 6
,6 7
(8 9
int9 <
)< =
HttpStatusCode= K
.K L
OKL N
)N O
]O P
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
ClientError% 0
)0 1
,1 2
(3 4
int4 7
)7 8
HttpStatusCode8 F
.F G

BadRequestG Q
)Q R
]R S
public 
async 
Task 
< 
IActionResult '
>' (
SelectAsync) 4
(4 5
long5 9
id: <
)< =
{ 	
return 
Response 
( 
await !
_contactServiceApp" 4
.4 5
SelectAsync5 @
(@ A
idA C
)C D
)D E
;E F
} 	
[   	
HttpGet  	 
(   
$str    
)    !
]  ! "
[!! 	 
ProducesResponseType!!	 
(!! 
typeof!! $
(!!$ %
List!!% )
<!!) *
ContactViewModel!!* :
>!!: ;
)!!; <
,!!< =
(!!> ?
int!!? B
)!!B C
HttpStatusCode!!C Q
.!!Q R
OK!!R T
)!!T U
]!!U V
["" 	 
ProducesResponseType""	 
("" 
typeof"" $
(""$ %
ClientError""% 0
)""0 1
,""1 2
(""3 4
int""4 7
)""7 8
HttpStatusCode""8 F
.""F G

BadRequest""G Q
)""Q R
]""R S
public## 
async## 
Task## 
<## 
IActionResult## '
>##' (
SelectByUserIdAsync##) <
(##< =
long##= A
userId##B H
)##H I
{$$ 	
return%% 
Response%% 
(%% 
await%% !
_contactServiceApp%%" 4
.%%4 5
SelectByUserIdAsync%%5 H
(%%H I
userId%%I O
)%%O P
)%%P Q
;%%Q R
}&& 	
[(( 	
HttpPost((	 
((( 
$str(( 
)(( 
](( 
[)) 	 
ProducesResponseType))	 
()) 
typeof)) $
())$ %
long))% )
)))) *
,))* +
()), -
int))- 0
)))0 1
HttpStatusCode))1 ?
.))? @
OK))@ B
)))B C
]))C D
[** 	 
ProducesResponseType**	 
(** 
typeof** $
(**$ %
ClientError**% 0
)**0 1
,**1 2
(**3 4
int**4 7
)**7 8
HttpStatusCode**8 F
.**F G

BadRequest**G Q
)**Q R
]**R S
public++ 
async++ 
Task++ 
<++ 
IActionResult++ '
>++' (
InsertAsync++) 4
(++4 5
[++5 6
FromBody++6 >
]++> ?#
ContactPayloadViewModel++@ W
payload++X _
)++_ `
{,, 	
return-- 
Response-- 
(-- 
await-- !
_contactServiceApp--" 4
.--4 5
InsertAsync--5 @
(--@ A
payload--A H
)--H I
)--I J
;--J K
}.. 	
[00 	
HttpPut00	 
(00 
$str00 
)00 
]00 
[11 	 
ProducesResponseType11	 
(11 
typeof11 $
(11$ %
ContactViewModel11% 5
)115 6
,116 7
(118 9
int119 <
)11< =
HttpStatusCode11= K
.11K L
OK11L N
)11N O
]11O P
[22 	 
ProducesResponseType22	 
(22 
typeof22 $
(22$ %
ClientError22% 0
)220 1
,221 2
(223 4
int224 7
)227 8
HttpStatusCode228 F
.22F G

BadRequest22G Q
)22Q R
]22R S
public33 
async33 
Task33 
<33 
IActionResult33 '
>33' (
UpdateAsync33) 4
(334 5
[335 6
FromBody336 >
]33> ?#
ContactPayloadViewModel33@ W
payload33X _
)33_ `
{44 	
return55 
Response55 
(55 
await55 !
_contactServiceApp55" 4
.554 5
UpdateAsync555 @
(55@ A
payload55A H
)55H I
)55I J
;55J K
}66 	
[88 	

HttpDelete88	 
(88 
$str88 
)88 
]88 
[99 	 
ProducesResponseType99	 
(99 
typeof99 $
(99$ %
bool99% )
)99) *
,99* +
(99, -
int99- 0
)990 1
HttpStatusCode991 ?
.99? @
OK99@ B
)99B C
]99C D
[:: 	 
ProducesResponseType::	 
(:: 
typeof:: $
(::$ %
ClientError::% 0
)::0 1
,::1 2
(::3 4
int::4 7
)::7 8
HttpStatusCode::8 F
.::F G

BadRequest::G Q
)::Q R
]::R S
public;; 
async;; 
Task;; 
<;; 
IActionResult;; '
>;;' (
DeleteAsync;;) 4
(;;4 5
long;;5 9
id;;: <
);;< =
{<< 	
return== 
Response== 
(== 
await== !
_contactServiceApp==" 4
.==4 5
DeleteAsync==5 @
(==@ A
id==A C
)==C D
)==D E
;==E F
}>> 	
}?? 
}@@ ·.
k/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Api/Controllers/ContactTypeController.cs
	namespace

 	

DubaiSmoke


 
.

 
Users

 
.

 
Api

 
.

 
Controllers

 *
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class !
ContactTypeController &
:' (
BaseController) 7
{ 
private 
readonly "
IContactTypeServiceApp /"
_contactTypeServiceApp0 F
;F G
public !
ContactTypeController $
($ %"
IContactTypeServiceApp% ;!
contactTypeServiceApp< Q
,Q R$
ErrorHandlerNotificationS k
notificationsl y
)y z
:{ |
base	} 
(
 ‚
notifications
‚ 
)
 
{ 	"
_contactTypeServiceApp "
=# $!
contactTypeServiceApp% :
;: ;
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	 
ProducesResponseType	 
( 
typeof $
($ % 
ContactTypeViewModel% 9
)9 :
,: ;
(< =
int= @
)@ A
HttpStatusCodeA O
.O P
OKP R
)R S
]S T
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
ClientError% 0
)0 1
,1 2
(3 4
int4 7
)7 8
HttpStatusCode8 F
.F G

BadRequestG Q
)Q R
]R S
public 
async 
Task 
< 
IActionResult '
>' (
SelectAsync) 4
(4 5
int5 8
id9 ;
); <
{ 	
return 
Response 
( 
await !"
_contactTypeServiceApp" 8
.8 9
SelectAsync9 D
(D E
idE G
)G H
)H I
;I J
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
long% )
)) *
,* +
(, -
int- 0
)0 1
HttpStatusCode1 ?
.? @
OK@ B
)B C
]C D
[   	 
ProducesResponseType  	 
(   
typeof   $
(  $ %
ClientError  % 0
)  0 1
,  1 2
(  3 4
int  4 7
)  7 8
HttpStatusCode  8 F
.  F G

BadRequest  G Q
)  Q R
]  R S
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
InsertAsync!!) 4
(!!4 5
[!!5 6
FromBody!!6 >
]!!> ?'
ContactTypePayloadViewModel!!@ [
payload!!\ c
)!!c d
{"" 	
return## 
Response## 
(## 
await## !"
_contactTypeServiceApp##" 8
.##8 9
InsertAsync##9 D
(##D E
payload##E L
)##L M
)##M N
;##N O
}$$ 	
[&& 	
HttpPut&&	 
(&& 
$str&& 
)&& 
]&& 
['' 	 
ProducesResponseType''	 
('' 
typeof'' $
(''$ % 
ContactTypeViewModel''% 9
)''9 :
,'': ;
(''< =
int''= @
)''@ A
HttpStatusCode''A O
.''O P
OK''P R
)''R S
]''S T
[(( 	 
ProducesResponseType((	 
((( 
typeof(( $
((($ %
ClientError((% 0
)((0 1
,((1 2
(((3 4
int((4 7
)((7 8
HttpStatusCode((8 F
.((F G

BadRequest((G Q
)((Q R
]((R S
public)) 
async)) 
Task)) 
<)) 
IActionResult)) '
>))' (
UpdateAsync))) 4
())4 5
[))5 6
FromBody))6 >
]))> ? 
ContactTypeViewModel))@ T
payload))U \
)))\ ]
{** 	
return++ 
Response++ 
(++ 
await++ !"
_contactTypeServiceApp++" 8
.++8 9
UpdateAsync++9 D
(++D E
payload++E L
)++L M
)++M N
;++N O
},, 	
[.. 	

HttpDelete..	 
(.. 
$str.. 
).. 
].. 
[// 	 
ProducesResponseType//	 
(// 
typeof// $
(//$ %
bool//% )
)//) *
,//* +
(//, -
int//- 0
)//0 1
HttpStatusCode//1 ?
.//? @
OK//@ B
)//B C
]//C D
[00 	 
ProducesResponseType00	 
(00 
typeof00 $
(00$ %
ClientError00% 0
)000 1
,001 2
(003 4
int004 7
)007 8
HttpStatusCode008 F
.00F G

BadRequest00G Q
)00Q R
]00R S
public11 
async11 
Task11 
<11 
IActionResult11 '
>11' (
DeleteAsync11) 4
(114 5
long115 9
id11: <
)11< =
{22 	
return33 
Response33 
(33 
await33 !"
_contactTypeServiceApp33" 8
.338 9
DeleteAsync339 D
(33D E
id33E G
)33G H
)33H I
;33I J
}44 	
}55 
}66 ð6
d/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Api/Controllers/UserController.cs
	namespace

 	

DubaiSmoke


 
.

 
Users

 
.

 
Api

 
.

 
Controllers

 *
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
UserController 
:  !
BaseController" 0
{ 
private 
readonly 
IUserServiceApp (
_userServiceApp) 8
;8 9
public 
UserController 
( 
IUserServiceApp -
userServiceApp. <
,< =$
ErrorHandlerNotification> V
notificationsW d
)d e
:f g
baseh l
(l m
notificationsm z
)z {
{ 	
_userServiceApp 
= 
userServiceApp ,
;, -
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
UserViewModel% 2
)2 3
,3 4
(5 6
int6 9
)9 :
HttpStatusCode: H
.H I
OKI K
)K L
]L M
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
ClientError% 0
)0 1
,1 2
(3 4
int4 7
)7 8
HttpStatusCode8 F
.F G

BadRequestG Q
)Q R
]R S
public 
async 
Task 
< 
IActionResult '
>' (
SelectAsync) 4
(4 5
int5 8
id9 ;
); <
{ 	
return 
Response 
( 
await !
_userServiceApp" 1
.1 2
SelectAsync2 =
(= >
id> @
)@ A
)A B
;B C
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
[   	 
ProducesResponseType  	 
(   
typeof   $
(  $ %
bool  % )
)  ) *
,  * +
(  , -
int  - 0
)  0 1
HttpStatusCode  1 ?
.  ? @
OK  @ B
)  B C
]  C D
[!! 	 
ProducesResponseType!!	 
(!! 
typeof!! $
(!!$ %
ClientError!!% 0
)!!0 1
,!!1 2
(!!3 4
int!!4 7
)!!7 8
HttpStatusCode!!8 F
.!!F G

BadRequest!!G Q
)!!Q R
]!!R S
public"" 
async"" 
Task"" 
<"" 
IActionResult"" '
>""' (
Login"") .
("". /
[""/ 0
FromBody""0 8
]""8 9!
LoginPayloadViewModel"": O
payload""P W
)""W X
{## 	
return$$ 
Response$$ 
($$ 
await$$ !
_userServiceApp$$" 1
.$$1 2

LoginAsync$$2 <
($$< =
payload$$= D
)$$D E
)$$E F
;$$F G
}%% 	
[(( 	
HttpPost((	 
((( 
$str(( 
)(( 
](( 
[)) 	 
ProducesResponseType))	 
()) 
typeof)) $
())$ %
long))% )
)))) *
,))* +
()), -
int))- 0
)))0 1
HttpStatusCode))1 ?
.))? @
OK))@ B
)))B C
]))C D
[** 	 
ProducesResponseType**	 
(** 
typeof** $
(**$ %
ClientError**% 0
)**0 1
,**1 2
(**3 4
int**4 7
)**7 8
HttpStatusCode**8 F
.**F G

BadRequest**G Q
)**Q R
]**R S
public++ 
async++ 
Task++ 
<++ 
IActionResult++ '
>++' (
InsertAsync++) 4
(++4 5
[++5 6
FromBody++6 >
]++> ? 
UserPayloadViewModel++@ T
payload++U \
)++\ ]
{,, 	
return-- 
Response-- 
(-- 
await-- !
_userServiceApp--" 1
.--1 2
InsertAsync--2 =
(--= >
payload--> E
)--E F
)--F G
;--G H
}.. 	
[00 	
HttpPut00	 
(00 
$str00 
)00 
]00 
[11 	 
ProducesResponseType11	 
(11 
typeof11 $
(11$ %
UserViewModel11% 2
)112 3
,113 4
(115 6
int116 9
)119 :
HttpStatusCode11: H
.11H I
OK11I K
)11K L
]11L M
[22 	 
ProducesResponseType22	 
(22 
typeof22 $
(22$ %
ClientError22% 0
)220 1
,221 2
(223 4
int224 7
)227 8
HttpStatusCode228 F
.22F G

BadRequest22G Q
)22Q R
]22R S
public33 
async33 
Task33 
<33 
IActionResult33 '
>33' (
UpdateAsync33) 4
(334 5
[335 6
FromBody336 >
]33> ?
UserViewModel33@ M
payload33N U
)33U V
{44 	
return55 
Response55 
(55 
await55 !
_userServiceApp55" 1
.551 2
UpdateAsync552 =
(55= >
payload55> E
)55E F
)55F G
;55G H
}66 	
[88 	

HttpDelete88	 
(88 
$str88 
)88 
]88 
[99 	 
ProducesResponseType99	 
(99 
typeof99 $
(99$ %
bool99% )
)99) *
,99* +
(99, -
int99- 0
)990 1
HttpStatusCode991 ?
.99? @
OK99@ B
)99B C
]99C D
[:: 	 
ProducesResponseType::	 
(:: 
typeof:: $
(::$ %
ClientError::% 0
)::0 1
,::1 2
(::3 4
int::4 7
)::7 8
HttpStatusCode::8 F
.::F G

BadRequest::G Q
)::Q R
]::R S
public;; 
async;; 
Task;; 
<;; 
IActionResult;; '
>;;' (
DeleteAsync;;) 4
(;;4 5
long;;5 9
id;;: <
);;< =
{<< 	
return== 
Response== 
(== 
await== !
_userServiceApp==" 1
.==1 2
DeleteAsync==2 =
(=== >
id==> @
)==@ A
)==A B
;==B C
}>> 	
}?? 
}@@ ¹

Q/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Api/Program.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Api 
{ 
[ #
ExcludeFromCodeCoverage 
] 
public		 

class		 
Program		 
{

 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IWebHostBuilder %
CreateHostBuilder& 7
(7 8
string8 >
[> ?
]? @
argsA E
)E F
=>G I
WebHost 
.  
CreateDefaultBuilder (
(( )
args) -
)- .
.. /

UseKestrel/ 9
(9 :
): ;
.; <

UseStartup< F
<F G
StartupG N
>N O
(O P
)P Q
;Q R
} 
} à(
Q/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Api/Startup.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Api 
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
Startup 
{ 
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddControllers #
(# $
)$ %
;% &
services 
. *
ConfigureDependeciesRepository 3
(3 4
Configuration4 A
)A B
;B C
services 
. (
ConfigureDependeciesServices 1
(1 2
)2 3
;3 4
	DbMapping   
.   
InitializeMapping   '
(  ' (
)  ( )
;  ) *
services!! 
.!! 
AddSwaggerGen!! "
(!!" #
)!!# $
;!!$ %
services## 
.## 
AddMvc## 
(## 
options## #
=>##$ &
{$$ 
options%% 
.%% 
Filters%% 
.%%  
Add%%  #
(%%# $
typeof%%$ *
(%%* +'
ValidateModelStateAttribute%%+ F
)%%F G
)%%G H
;%%H I
}&& 
)&& 
;&& 
services'' 
.'' 
	Configure'' 
<'' 
ApiBehaviorOptions'' 1
>''1 2
(''2 3
options''3 :
=>''; =
{(( 
options)) 
.)) +
SuppressModelStateInvalidFilter)) 7
=))8 9
true)): >
;))> ?
}** 
)** 
;** 
services,, 
.,, 
AddTransient,, !
<,,! "

IValidator,," ,
<,,, - 
UserPayloadViewModel,,- A
>,,A B
,,,B C
UserValidator,,D Q
>,,Q R
(,,R S
),,S T
;,,T U
services-- 
.-- 
AddTransient-- !
<--! "

IValidator--" ,
<--, -#
ContactPayloadViewModel--- D
>--D E
,--E F
ContactValidator--G W
>--W X
(--X Y
)--Y Z
;--Z [
services.. 
... 
AddTransient.. !
<..! "

IValidator.." ,
<.., -'
ContactTypePayloadViewModel..- H
>..H I
,..I J 
ContactTypeValidator..K _
>.._ `
(..` a
)..a b
;..b c
services// 
.// 
AddTransient// !
<//! "

IValidator//" ,
<//, -#
AddressPayloadViewModel//- D
>//D E
,//E F
AddressValidator//G W
>//W X
(//X Y
)//Y Z
;//Z [
}00 	
public33 
void33 
	Configure33 
(33 
IApplicationBuilder33 1
app332 5
)335 6
{44 	
app55 
.55 

UseRouting55 
(55 
)55 
;55 
app77 
.77 
UseAuthorization77  
(77  !
)77! "
;77" #
app99 
.99 
UseEndpoints99 
(99 
	endpoints99 &
=>99' )
{:: 
	endpoints;; 
.;; 
MapControllers;; (
(;;( )
);;) *
;;;* +
}<< 
)<< 
;<< 
app== 
.== 

UseSwagger== 
(== 
)== 
;== 
app>> 
.>> 
UseSwaggerUI>> 
(>> 
c>> 
=>>> !
{?? 
c@@ 
.@@ 
SwaggerEndpoint@@ !
(@@! "
$str@@" <
,@@< =
$str@@> V
)@@V W
;@@W X
cAA 
.AA 
RoutePrefixAA 
=AA 
stringAA  &
.AA& '
EmptyAA' ,
;AA, -
}BB 
)BB 
;BB 
varCC 
cultureInfoCC 
=CC 
newCC !
CultureInfoCC" -
(CC- .
$strCC. 5
)CC5 6
;CC6 7
cultureInfoDD 
.DD 
NumberFormatDD $
.DD$ %
CurrencySymbolDD% 3
=DD4 5
$strDD6 :
;DD: ;
CultureInfoEE 
.EE '
DefaultThreadCurrentCultureEE 3
=EE4 5
cultureInfoEE6 A
;EEA B
CultureInfoFF 
.FF )
DefaultThreadCurrentUICultureFF 5
=FF6 7
cultureInfoFF8 C
;FFC D
}GG 	
}HH 
}II 