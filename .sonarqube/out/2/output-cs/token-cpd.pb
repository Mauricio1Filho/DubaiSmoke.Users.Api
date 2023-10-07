Ò(
y/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Infrastructure/Repositories/MySql/AddressRepository.cs
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
 
Infrastructure

 )
.

) *
Repositories

* 6
.

6 7
MySql

7 <
{ 
public 

class 
AddressRepository "
:# $
IAddressRepository% 7
{ 
readonly 
IUnitOfWork 
_unitOfWork (
;( )
public 
AddressRepository  
(  !
IUnitOfWork! ,

unitOfWork- 7
)7 8
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
$str *
;* +
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
List 
< 
AddressEntity ,
>, -
>- .
GetAddressByUserId/ A
(A B
longB F
userIdG M
)M N
{ 	
string   
sql   
=   
$str " 8
;""8 9
var$$ 
result$$ 
=$$ 
await$$ 
_unitOfWork$$ *
.$$* +

Connection$$+ 5
.$$5 6

QueryAsync$$6 @
<$$@ A
AddressEntity$$A N
,$$N O

UserEntity$$P Z
,$$Z [
AddressEntity$$\ i
>$$i j
($$j k
sql$$k n
,$$n o
map%% 
:%% 
(%% 
a%% 
,%% 
u%% 
)%% 
=>%% 
{&& 
a'' 
.'' 
User'' 
='' 
u'' 
;'' 
return(( 
a(( 
;(( 
})) 
,)) 
splitOn** 
:** 
$str** 
,** 
param++ 
:++ 
new++ 
{++ 
userId++ #
}++$ %
)++% &
;++& '
return,, 
result,, 
.,, 
ToList,,  
(,,  !
),,! "
;,," #
}-- 	
public// 
async// 
Task// 
<// 
long// 
>// 
InsertAsync//  +
(//+ ,
AddressEntity//, 9
item//: >
)//> ?
{00 	
string11 
sql11 
=11 
$str13 S
;33S T
item55 
.55 
HashCode55 
=55 
Guid55  
.55  !
NewGuid55! (
(55( )
)55) *
.55* +
ToString55+ 3
(553 4
)554 5
;555 6
return66 
await66 
_unitOfWork66 $
.66$ %

Connection66% /
.66/ 0$
QueryFirstOrDefaultAsync660 H
<66H I
long66I M
>66M N
(66N O
sql66O R
,66R S
item66T X
)66X Y
;66Y Z
}77 	
public99 
async99 
Task99 
<99 
AddressEntity99 '
>99' (
SelectAsync99) 4
(994 5
long995 9
id99: <
)99< =
{:: 	
string;; 
sql;; 
=;; 
$str;; A
;;;A B
return== 
await== 
_unitOfWork== $
.==$ %

Connection==% /
.==/ 0$
QueryFirstOrDefaultAsync==0 H
<==H I
AddressEntity==I V
>==V W
(==W X
sql==X [
,==[ \
new==] `
{==a b
id==c e
}==f g
)==g h
;==h i
}>> 	
public@@ 
async@@ 
Task@@ 
<@@ 
AddressEntity@@ '
>@@' (
UpdateAsync@@) 4
(@@4 5
AddressEntity@@5 B
item@@C G
)@@G H
{AA 	
stringBB 
sqlBB 
=BB 
$strBH 5
;HH5 6
itemJJ 
.JJ 
	UpdatedAtJJ 
=JJ 
DateTimeJJ %
.JJ% &
NowJJ& )
;JJ) *
returnKK 
awaitKK 
_unitOfWorkKK $
.KK$ %

ConnectionKK% /
.KK/ 0$
QueryFirstOrDefaultAsyncKK0 H
<KKH I
AddressEntityKKI V
>KKV W
(KKW X
sqlKKX [
,KK[ \
itemKK] a
)KKa b
;KKb c
}LL 	
}MM 
}NN ß*
y/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Infrastructure/Repositories/MySql/ContactRepository.cs
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
 
Infrastructure

 )
.

) *
Repositories

* 6
.

6 7
MySql

7 <
{ 
public 

class 
ContactRepository "
:# $
IContactRepository% 7
{ 
readonly 
IUnitOfWork 
_unitOfWork (
;( )
public 
ContactRepository  
(  !
IUnitOfWork! ,

unitOfWork- 7
)7 8
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
(+ ,
ContactEntity, 9
item: >
)> ?
{ 	
string!! 
sql!! 
=!! 
$str!# T
;##T U
item%% 
.%% 
HashCode%% 
=%% 
Guid%%  
.%%  !
NewGuid%%! (
(%%( )
)%%) *
.%%* +
ToString%%+ 3
(%%3 4
)%%4 5
;%%5 6
return&& 
await&& 
_unitOfWork&& $
.&&$ %

Connection&&% /
.&&/ 0$
QueryFirstOrDefaultAsync&&0 H
<&&H I
long&&I M
>&&M N
(&&N O
sql&&O R
,&&R S
item&&T X
)&&X Y
;&&Y Z
}'' 	
public)) 
async)) 
Task)) 
<)) 
ContactEntity)) '
>))' (
SelectAsync))) 4
())4 5
long))5 9
id)): <
)))< =
{** 	
string++ 
sql++ 
=++ 
$str++ B
;++B C
return-- 
await-- 
_unitOfWork-- $
.--$ %

Connection--% /
.--/ 0$
QueryFirstOrDefaultAsync--0 H
<--H I
ContactEntity--I V
>--V W
(--W X
sql--X [
,--[ \
new--] `
{--a b
id--c e
}--f g
)--g h
;--h i
}.. 	
public00 
async00 
Task00 
<00 
ContactEntity00 '
>00' (
UpdateAsync00) 4
(004 5
ContactEntity005 B
item00C G
)00G H
{11 	
string22 
sql22 
=22 
$str26 4
;664 5
item88 
.88 
	UpdatedAt88 
=88 
DateTime88 %
.88% &
Now88& )
;88) *
return99 
await99 
_unitOfWork99 $
.99$ %

Connection99% /
.99/ 0$
QueryFirstOrDefaultAsync990 H
<99H I
ContactEntity99I V
>99V W
(99W X
sql99X [
,99[ \
item99] a
)99a b
;99b c
}:: 	
public<< 
async<< 
Task<< 
<<< 
List<< 
<<< 
ContactEntity<< ,
><<, -
><<- .
SelectByUserIdAsync<</ B
(<<B C
long<<C G
userId<<H N
)<<N O
{== 	
string>> 
sql>> 
=>> 
$str>A 6
;AA6 7
varCC 
resultCC 
=CC 
awaitCC 
_unitOfWorkCC *
.CC* +

ConnectionCC+ 5
.CC5 6

QueryAsyncCC6 @
<CC@ A
ContactEntityCCA N
,CCN O
ContactTypeEntityCCP a
,CCa b

UserEntityCCc m
,CCm n
ContactEntityCCo |
>CC| }
(CC} ~
sql	CC~ Å
,
CCÅ Ç
mapDD 
:DD 
(DD 
cDD 
,DD 
ctDD 
,DD 
uDD 
)DD 
=>DD  "
{EE 
cFF 
.FF 
ContactTypeFF "
=FF# $
ctFF% '
;FF' (
cGG 
.GG 
UserGG 
=GG 
uGG 
;GG  
returnHH 
cHH 
;HH 
}II 
,II 
splitOnJJ 
:JJ 
$strJJ 
,JJ 
paramKK 
:KK 
newKK 
{KK 
userIdKK #
}KK$ %
)KK% &
;KK& '
returnLL 
resultLL 
.LL 
ToListLL  
(LL  !
)LL! "
;LL" #
}MM 	
}NN 
}OO ¬
}/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Infrastructure/Repositories/MySql/ContactTypeRepository.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Infrastructure )
.) *
Repositories* 6
.6 7
MySql7 <
{		 
public

 

class

 !
ContactTypeRepository

 &
:

' ("
IContactTypeRepository

) ?
{ 
readonly 
IUnitOfWork 
_unitOfWork (
;( )
public !
ContactTypeRepository $
($ %
IUnitOfWork% 0

unitOfWork1 ;
); <
{ 	
_unitOfWork 
= 

unitOfWork $
;$ %
} 	
public 
async 
Task 
< 
bool 
> 
DeleteAsync  +
(+ ,
long, 0
id1 3
)3 4
{ 	
string 
sql 
= 
$str +
;+ ,
return 
await 
_unitOfWork $
.$ %

Connection% /
./ 0%
ExecuteAndReturnBoolAsync0 I
(I J
sqlJ M
,M N
newO R
{S T
	DeletedAtU ^
=_ `
DateTimea i
.i j
Nowj m
,m n
Ido q
=r s
idt v
}w x
)x y
;y z
} 	
public 
async 
Task 
< 
long 
> 
InsertAsync  +
(+ ,
ContactTypeEntity, =
item> B
)B C
{ 	
string 
sql 
= 
$str  Y
;  Y Z
item"" 
."" 
HashCode"" 
="" 
Guid""  
.""  !
NewGuid""! (
(""( )
)"") *
.""* +
ToString""+ 3
(""3 4
)""4 5
;""5 6
return## 
await## 
_unitOfWork## $
.##$ %

Connection##% /
.##/ 0$
QueryFirstOrDefaultAsync##0 H
<##H I
long##I M
>##M N
(##N O
sql##O R
,##R S
item##T X
)##X Y
;##Y Z
}$$ 	
public&& 
async&& 
Task&& 
<&& 
ContactTypeEntity&& +
>&&+ ,
SelectAsync&&- 8
(&&8 9
long&&9 =
id&&> @
)&&@ A
{'' 	
string(( 
sql(( 
=(( 
$str(( G
;((G H
return** 
await** 
_unitOfWork** $
.**$ %

Connection**% /
.**/ 0$
QueryFirstOrDefaultAsync**0 H
<**H I
ContactTypeEntity**I Z
>**Z [
(**[ \
sql**\ _
,**_ `
new**a d
{**e f
id**g i
}**j k
)**k l
;**l m
}++ 	
public-- 
async-- 
Task-- 
<-- 
ContactTypeEntity-- +
>--+ ,
UpdateAsync--- 8
(--8 9
ContactTypeEntity--9 J
item--K O
)--O P
{.. 	
string// 
sql// 
=// 
$str/2 +
;22+ ,
item44 
.44 
	UpdatedAt44 
=44 
DateTime44 %
.44% &
Now44& )
;44) *
return55 
await55 
_unitOfWork55 $
.55$ %

Connection55% /
.55/ 0$
QueryFirstOrDefaultAsync550 H
<55H I
ContactTypeEntity55I Z
>55Z [
(55[ \
sql55\ _
,55_ `
item55a e
)55e f
;55f g
}66 	
}77 
}88 ì

x/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Infrastructure/Repositories/MySql/DapperExtensions.cs
public 
static 
class 
DapperExtensions $
{ 
public 

static 
async 
Task 
< 
bool !
>! "%
ExecuteAndReturnBoolAsync# <
(< =
this= A
IDbConnectionB O

connectionP Z
,Z [
string\ b
sqlc f
,f g
objecth n
paramo t
=u v
nullw {
,{ |
IDbTransaction	} ã
transaction
å ó
=
ò ô
null
ö û
)
û ü
{ 
try		 
{

 	
var 
affectedRows 
= 
await $

connection% /
./ 0
ExecuteAsync0 <
(< =
sql= @
,@ A
paramB G
,G H
transactionI T
)T U
;U V
return 
affectedRows 
>  !
$num" #
;# $
} 	
catch 
{ 	
return 
false 
; 
} 	
} 
} ∞%
v/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Infrastructure/Repositories/MySql/UserRepository.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Infrastructure )
.) *
Repositories* 6
.6 7
MySql7 <
{		 
public

 

class

 
UserRepository

 
:

  !
IUserRepository

" 1
{ 
readonly 
IUnitOfWork 
_unitOfWork (
;( )
public 
UserRepository 
( 
IUnitOfWork )

unitOfWork* 4
)4 5
{ 	
_unitOfWork 
= 

unitOfWork $
;$ %
} 	
public 
async 
Task 
< 
bool 
> 
DeleteAsync  +
(+ ,
long, 0
id1 3
)3 4
{ 	
string 
sql 
= 
$str +
;+ ,
return 
await 
_unitOfWork $
.$ %

Connection% /
./ 0%
ExecuteAndReturnBoolAsync0 I
(I J
sqlJ M
,M N
newO R
{S T
	DeletedAtU ^
=_ `
DateTimea i
.i j
Nowj m
,m n
Ido q
=r s
idt v
}w x
)x y
;y z
} 	
public 
async 
Task 
< 
long 
> 
InsertAsync  +
(+ ,

UserEntity, 6
item7 ;
); <
{ 	
string 
sql 
= 
$str  Q
;  Q R
item"" 
."" 
HashCode"" 
="" 
Guid""  
.""  !
NewGuid""! (
(""( )
)"") *
.""* +
ToString""+ 3
(""3 4
)""4 5
;""5 6
return## 
await## 
_unitOfWork## $
.##$ %

Connection##% /
.##/ 0$
QueryFirstOrDefaultAsync##0 H
<##H I
long##I M
>##M N
(##N O
sql##O R
,##R S
item##T X
)##X Y
;##Y Z
}$$ 	
public&& 
async&& 
Task&& 
<&& 
bool&& 
>&& 

LoginAsync&&  *
(&&* +

UserEntity&&+ 5
user&&6 :
)&&: ;
{'' 	
string(( 
sql(( 
=(( 
$str(( h
;((h i
if** 
(** 
await** 
_unitOfWork** !
.**! "

Connection**" ,
.**, -$
QueryFirstOrDefaultAsync**- E
(**E F
sql**F I
,**I J
new**K N
{**O P
email**Q V
=**W X
user**Y ]
.**] ^
Login**^ c
,**c d
password**e m
=**n o
user**p t
.**t u
Password**u }
}**~ 
)	** Ä
is
**Å É
null
**Ñ à
)
**à â
return++ 
false++ 
;++ 
return-- 
true-- 
;-- 
}.. 	
public00 
async00 
Task00 
<00 

UserEntity00 $
>00$ %
SelectAsync00& 1
(001 2
long002 6
id007 9
)009 :
{11 	
string22 
sql22 
=22 
$str22 ?
;22? @
return44 
await44 
_unitOfWork44 $
.44$ %

Connection44% /
.44/ 0$
QueryFirstOrDefaultAsync440 H
<44H I

UserEntity44I S
>44S T
(44T U
sql44U X
,44X Y
new44Z ]
{44^ _
id44` b
}44c d
)44d e
;44e f
}55 	
public77 
async77 
Task77 
<77 

UserEntity77 $
>77$ %
UpdateAsync77& 1
(771 2

UserEntity772 <
item77= A
)77A B
{88 	
string99 
sql99 
=99 
$str9? +
;??+ ,
itemAA 
.AA 
	UpdatedAtAA 
=AA 
DateTimeAA %
.AA% &
NowAA& )
;AA) *
returnBB 
awaitBB 
_unitOfWorkBB $
.BB$ %

ConnectionBB% /
.BB/ 0$
QueryFirstOrDefaultAsyncBB0 H
<BBH I

UserEntityBBI S
>BBS T
(BBT U
sqlBBU X
,BBX Y
itemBBZ ^
)BB^ _
;BB_ `
}CC 	
}DD 
}EE 