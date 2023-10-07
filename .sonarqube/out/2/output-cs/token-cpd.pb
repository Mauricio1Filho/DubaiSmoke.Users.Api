¥)
y/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Infrastructure/Repositories/MySql/AddressRepository.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Infrastructure )
.) *
Repositories* 6
.6 7
MySql7 <
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
AddressRepository "
:# $
IAddressRepository% 7
{ 
readonly 
IUnitOfWork 
_unitOfWork (
;( )
public 
AddressRepository  
(  !
IUnitOfWork! ,

unitOfWork- 7
)7 8
{ 	
_unitOfWork 
= 

unitOfWork $
;$ %
} 	
public 
async 
Task 
< 
bool 
> 
DeleteAsync  +
(+ ,
long, 0
id1 3
)3 4
{ 	
string 
sql 
= 
$str *
;* +
return 
await 
_unitOfWork $
.$ %

Connection% /
./ 0%
ExecuteAndReturnBoolAsync0 I
(I J
sqlJ M
,M N
newO R
{S T
	DeletedAtU ^
=_ `
DateTimea i
.i j
Nowj m
,m n
Ido q
=r s
idt v
}w x
)x y
;y z
} 	
public   
async   
Task   
<   
List   
<   
AddressEntity   ,
>  , -
>  - .
GetAddressByUserId  / A
(  A B
long  B F
userId  G M
)  M N
{!! 	
string"" 
sql"" 
="" 
$str"$ 8
;$$8 9
var&& 
result&& 
=&& 
await&& 
_unitOfWork&& *
.&&* +

Connection&&+ 5
.&&5 6

QueryAsync&&6 @
<&&@ A
AddressEntity&&A N
,&&N O

UserEntity&&P Z
,&&Z [
AddressEntity&&\ i
>&&i j
(&&j k
sql&&k n
,&&n o
map'' 
:'' 
('' 
a'' 
,'' 
u'' 
)'' 
=>'' 
{(( 
a)) 
.)) 
User)) 
=)) 
u)) 
;)) 
return** 
a** 
;** 
}++ 
,++ 
splitOn,, 
:,, 
$str,, 
,,, 
param-- 
:-- 
new-- 
{-- 
userId-- #
}--$ %
)--% &
;--& '
return.. 
result.. 
... 
ToList..  
(..  !
)..! "
;.." #
}// 	
public11 
async11 
Task11 
<11 
long11 
>11 
InsertAsync11  +
(11+ ,
AddressEntity11, 9
item11: >
)11> ?
{22 	
string33 
sql33 
=33 
$str35 S
;55S T
item77 
.77 
HashCode77 
=77 
Guid77  
.77  !
NewGuid77! (
(77( )
)77) *
.77* +
ToString77+ 3
(773 4
)774 5
;775 6
return88 
await88 
_unitOfWork88 $
.88$ %

Connection88% /
.88/ 0$
QueryFirstOrDefaultAsync880 H
<88H I
long88I M
>88M N
(88N O
sql88O R
,88R S
item88T X
)88X Y
;88Y Z
}99 	
public;; 
async;; 
Task;; 
<;; 
AddressEntity;; '
>;;' (
SelectAsync;;) 4
(;;4 5
long;;5 9
id;;: <
);;< =
{<< 	
string== 
sql== 
=== 
$str== A
;==A B
return?? 
await?? 
_unitOfWork?? $
.??$ %

Connection??% /
.??/ 0$
QueryFirstOrDefaultAsync??0 H
<??H I
AddressEntity??I V
>??V W
(??W X
sql??X [
,??[ \
new??] `
{??a b
id??c e
}??f g
)??g h
;??h i
}@@ 	
publicBB 
asyncBB 
TaskBB 
<BB 
AddressEntityBB '
>BB' (
UpdateAsyncBB) 4
(BB4 5
AddressEntityBB5 B
itemBBC G
)BBG H
{CC 	
stringDD 
sqlDD 
=DD 
$strDJ 5
;JJ5 6
itemLL 
.LL 
	UpdatedAtLL 
=LL 
DateTimeLL %
.LL% &
NowLL& )
;LL) *
returnMM 
awaitMM 
_unitOfWorkMM $
.MM$ %

ConnectionMM% /
.MM/ 0$
QueryFirstOrDefaultAsyncMM0 H
<MMH I
AddressEntityMMI V
>MMV W
(MMW X
sqlMMX [
,MM[ \
itemMM] a
)MMa b
;MMb c
}NN 	
}OO 
}PP Í*
y/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Infrastructure/Repositories/MySql/ContactRepository.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Infrastructure )
.) *
Repositories* 6
.6 7
MySql7 <
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
ContactRepository "
:# $
IContactRepository% 7
{ 
readonly 
IUnitOfWork 
_unitOfWork (
;( )
public 
ContactRepository  
(  !
IUnitOfWork! ,

unitOfWork- 7
)7 8
{ 	
_unitOfWork 
= 

unitOfWork $
;$ %
} 	
public 
async 
Task 
< 
bool 
> 
DeleteAsync  +
(+ ,
long, 0
id1 3
)3 4
{ 	
string 
sql 
= 
$str +
;+ ,
return 
await 
_unitOfWork $
.$ %

Connection% /
./ 0%
ExecuteAndReturnBoolAsync0 I
(I J
sqlJ M
,M N
newO R
{S T
	DeletedAtU ^
=_ `
DateTimea i
.i j
Nowj m
,m n
Ido q
=r s
idt v
}w x
)x y
;y z
} 	
public   
async   
Task   
<   
long   
>   
InsertAsync    +
(  + ,
ContactEntity  , 9
item  : >
)  > ?
{!! 	
string## 
sql## 
=## 
$str#% T
;%%T U
item'' 
.'' 
HashCode'' 
='' 
Guid''  
.''  !
NewGuid''! (
(''( )
)'') *
.''* +
ToString''+ 3
(''3 4
)''4 5
;''5 6
return(( 
await(( 
_unitOfWork(( $
.(($ %

Connection((% /
.((/ 0$
QueryFirstOrDefaultAsync((0 H
<((H I
long((I M
>((M N
(((N O
sql((O R
,((R S
item((T X
)((X Y
;((Y Z
})) 	
public++ 
async++ 
Task++ 
<++ 
ContactEntity++ '
>++' (
SelectAsync++) 4
(++4 5
long++5 9
id++: <
)++< =
{,, 	
string-- 
sql-- 
=-- 
$str-- B
;--B C
return// 
await// 
_unitOfWork// $
.//$ %

Connection//% /
./// 0$
QueryFirstOrDefaultAsync//0 H
<//H I
ContactEntity//I V
>//V W
(//W X
sql//X [
,//[ \
new//] `
{//a b
id//c e
}//f g
)//g h
;//h i
}00 	
public22 
async22 
Task22 
<22 
ContactEntity22 '
>22' (
UpdateAsync22) 4
(224 5
ContactEntity225 B
item22C G
)22G H
{33 	
string44 
sql44 
=44 
$str48 4
;884 5
item:: 
.:: 
	UpdatedAt:: 
=:: 
DateTime:: %
.::% &
Now::& )
;::) *
return;; 
await;; 
_unitOfWork;; $
.;;$ %

Connection;;% /
.;;/ 0$
QueryFirstOrDefaultAsync;;0 H
<;;H I
ContactEntity;;I V
>;;V W
(;;W X
sql;;X [
,;;[ \
item;;] a
);;a b
;;;b c
}<< 	
public>> 
async>> 
Task>> 
<>> 
List>> 
<>> 
ContactEntity>> ,
>>>, -
>>>- .
SelectByUserIdAsync>>/ B
(>>B C
long>>C G
userId>>H N
)>>N O
{?? 	
string@@ 
sql@@ 
=@@ 
$str@C 6
;CC6 7
varEE 
resultEE 
=EE 
awaitEE 
_unitOfWorkEE *
.EE* +

ConnectionEE+ 5
.EE5 6

QueryAsyncEE6 @
<EE@ A
ContactEntityEEA N
,EEN O
ContactTypeEntityEEP a
,EEa b

UserEntityEEc m
,EEm n
ContactEntityEEo |
>EE| }
(EE} ~
sql	EE~ Å
,
EEÅ Ç
mapFF 
:FF 
(FF 
cFF 
,FF 
ctFF 
,FF 
uFF 
)FF 
=>FF  "
{GG 
cHH 
.HH 
ContactTypeHH "
=HH# $
ctHH% '
;HH' (
cII 
.II 
UserII 
=II 
uII 
;II  
returnJJ 
cJJ 
;JJ 
}KK 
,KK 
splitOnLL 
:LL 
$strLL 
,LL 
paramMM 
:MM 
newMM 
{MM 
userIdMM #
}MM$ %
)MM% &
;MM& '
returnNN 
resultNN 
.NN 
ToListNN  
(NN  !
)NN! "
;NN" #
}OO 	
}PP 
}QQ Ö
}/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Infrastructure/Repositories/MySql/ContactTypeRepository.cs
	namespace		 	

DubaiSmoke		
 
.		 
Users		 
.		 
Infrastructure		 )
.		) *
Repositories		* 6
.		6 7
MySql		7 <
{

 
[ #
ExcludeFromCodeCoverage 
] 
public 

class !
ContactTypeRepository &
:' ("
IContactTypeRepository) ?
{ 
readonly 
IUnitOfWork 
_unitOfWork (
;( )
public !
ContactTypeRepository $
($ %
IUnitOfWork% 0

unitOfWork1 ;
); <
{ 	
_unitOfWork 
= 

unitOfWork $
;$ %
} 	
public 
async 
Task 
< 
bool 
> 
DeleteAsync  +
(+ ,
long, 0
id1 3
)3 4
{ 	
string 
sql 
= 
$str +
;+ ,
return 
await 
_unitOfWork $
.$ %

Connection% /
./ 0%
ExecuteAndReturnBoolAsync0 I
(I J
sqlJ M
,M N
newO R
{S T
	DeletedAtU ^
=_ `
DateTimea i
.i j
Nowj m
,m n
Ido q
=r s
idt v
}w x
)x y
;y z
} 	
public 
async 
Task 
< 
long 
> 
InsertAsync  +
(+ ,
ContactTypeEntity, =
item> B
)B C
{ 	
string   
sql   
=   
$str " Y
;""Y Z
item$$ 
.$$ 
HashCode$$ 
=$$ 
Guid$$  
.$$  !
NewGuid$$! (
($$( )
)$$) *
.$$* +
ToString$$+ 3
($$3 4
)$$4 5
;$$5 6
return%% 
await%% 
_unitOfWork%% $
.%%$ %

Connection%%% /
.%%/ 0$
QueryFirstOrDefaultAsync%%0 H
<%%H I
long%%I M
>%%M N
(%%N O
sql%%O R
,%%R S
item%%T X
)%%X Y
;%%Y Z
}&& 	
public(( 
async(( 
Task(( 
<(( 
ContactTypeEntity(( +
>((+ ,
SelectAsync((- 8
(((8 9
long((9 =
id((> @
)((@ A
{)) 	
string** 
sql** 
=** 
$str** G
;**G H
return,, 
await,, 
_unitOfWork,, $
.,,$ %

Connection,,% /
.,,/ 0$
QueryFirstOrDefaultAsync,,0 H
<,,H I
ContactTypeEntity,,I Z
>,,Z [
(,,[ \
sql,,\ _
,,,_ `
new,,a d
{,,e f
id,,g i
},,j k
),,k l
;,,l m
}-- 	
public// 
async// 
Task// 
<// 
ContactTypeEntity// +
>//+ ,
UpdateAsync//- 8
(//8 9
ContactTypeEntity//9 J
item//K O
)//O P
{00 	
string11 
sql11 
=11 
$str14 +
;44+ ,
item66 
.66 
	UpdatedAt66 
=66 
DateTime66 %
.66% &
Now66& )
;66) *
return77 
await77 
_unitOfWork77 $
.77$ %

Connection77% /
.77/ 0$
QueryFirstOrDefaultAsync770 H
<77H I
ContactTypeEntity77I Z
>77Z [
(77[ \
sql77\ _
,77_ `
item77a e
)77e f
;77f g
}88 	
}99 
}:: Ω
x/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Infrastructure/Repositories/MySql/DapperExtensions.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Infrastructure )
.) *
Repositories* 6
.6 7
MySql7 <
{ 
[ #
ExcludeFromCodeCoverage 
] 
public		 

static		 
class		 
DapperExtensions		 (
{

 
public 
static 
async 
Task  
<  !
bool! %
>% &%
ExecuteAndReturnBoolAsync' @
(@ A
thisA E
IDbConnectionF S

connectionT ^
,^ _
string` f
sqlg j
,j k
objectl r
params x
=y z
null{ 
,	 Ä
IDbTransaction
Å è
transaction
ê õ
=
ú ù
null
û ¢
)
¢ £
{ 	
try 
{ 
var 
affectedRows  
=! "
await# (

connection) 3
.3 4
ExecuteAsync4 @
(@ A
sqlA D
,D E
paramF K
,K L
transactionM X
)X Y
;Y Z
return 
affectedRows #
>$ %
$num& '
;' (
} 
catch 
{ 
return 
false 
; 
} 
} 	
} 
} Û%
v/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Infrastructure/Repositories/MySql/UserRepository.cs
	namespace		 	

DubaiSmoke		
 
.		 
Users		 
.		 
Infrastructure		 )
.		) *
Repositories		* 6
.		6 7
MySql		7 <
{

 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
UserRepository 
:  !
IUserRepository" 1
{ 
readonly 
IUnitOfWork 
_unitOfWork (
;( )
public 
UserRepository 
( 
IUnitOfWork )

unitOfWork* 4
)4 5
{ 	
_unitOfWork 
= 

unitOfWork $
;$ %
} 	
public 
async 
Task 
< 
bool 
> 
DeleteAsync  +
(+ ,
long, 0
id1 3
)3 4
{ 	
string 
sql 
= 
$str +
;+ ,
return 
await 
_unitOfWork $
.$ %

Connection% /
./ 0%
ExecuteAndReturnBoolAsync0 I
(I J
sqlJ M
,M N
newO R
{S T
	DeletedAtU ^
=_ `
DateTimea i
.i j
Nowj m
,m n
Ido q
=r s
idt v
}w x
)x y
;y z
} 	
public 
async 
Task 
< 
long 
> 
InsertAsync  +
(+ ,

UserEntity, 6
item7 ;
); <
{ 	
string   
sql   
=   
$str " Q
;""Q R
item$$ 
.$$ 
HashCode$$ 
=$$ 
Guid$$  
.$$  !
NewGuid$$! (
($$( )
)$$) *
.$$* +
ToString$$+ 3
($$3 4
)$$4 5
;$$5 6
return%% 
await%% 
_unitOfWork%% $
.%%$ %

Connection%%% /
.%%/ 0$
QueryFirstOrDefaultAsync%%0 H
<%%H I
long%%I M
>%%M N
(%%N O
sql%%O R
,%%R S
item%%T X
)%%X Y
;%%Y Z
}&& 	
public(( 
async(( 
Task(( 
<(( 
bool(( 
>(( 

LoginAsync((  *
(((* +

UserEntity((+ 5
user((6 :
)((: ;
{)) 	
string** 
sql** 
=** 
$str** h
;**h i
if,, 
(,, 
await,, 
_unitOfWork,, !
.,,! "

Connection,," ,
.,,, -$
QueryFirstOrDefaultAsync,,- E
(,,E F
sql,,F I
,,,I J
new,,K N
{,,O P
email,,Q V
=,,W X
user,,Y ]
.,,] ^
Login,,^ c
,,,c d
password,,e m
=,,n o
user,,p t
.,,t u
Password,,u }
},,~ 
)	,, Ä
is
,,Å É
null
,,Ñ à
)
,,à â
return-- 
false-- 
;-- 
return// 
true// 
;// 
}00 	
public22 
async22 
Task22 
<22 

UserEntity22 $
>22$ %
SelectAsync22& 1
(221 2
long222 6
id227 9
)229 :
{33 	
string44 
sql44 
=44 
$str44 ?
;44? @
return66 
await66 
_unitOfWork66 $
.66$ %

Connection66% /
.66/ 0$
QueryFirstOrDefaultAsync660 H
<66H I

UserEntity66I S
>66S T
(66T U
sql66U X
,66X Y
new66Z ]
{66^ _
id66` b
}66c d
)66d e
;66e f
}77 	
public99 
async99 
Task99 
<99 

UserEntity99 $
>99$ %
UpdateAsync99& 1
(991 2

UserEntity992 <
item99= A
)99A B
{:: 	
string;; 
sql;; 
=;; 
$str;A +
;AA+ ,
itemCC 
.CC 
	UpdatedAtCC 
=CC 
DateTimeCC %
.CC% &
NowCC& )
;CC) *
returnDD 
awaitDD 
_unitOfWorkDD $
.DD$ %

ConnectionDD% /
.DD/ 0$
QueryFirstOrDefaultAsyncDD0 H
<DDH I

UserEntityDDI S
>DDS T
(DDT U
sqlDDU X
,DDX Y
itemDDZ ^
)DD^ _
;DD_ `
}EE 	
}FF 
}GG 