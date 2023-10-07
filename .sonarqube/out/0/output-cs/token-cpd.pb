≤
c/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Entities/AddressEntity.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Entities" *
{ 
[ 
Table 

( 
$str 
) 
] 
public 

class 
AddressEntity 
:  

BaseEntity! +
{ 
public 

UserEntity 
User 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
long		 
UserId		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public

 
string

 
AddressName

 !
{

" #
get

$ '
;

' (
set

) ,
;

, -
}

. /
public 
int 
AddressNumber  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
AddressComplement '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 

PostalCode  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
} Â
`/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Entities/BaseEntity.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Entities" *
{ 
public 

abstract 
class 

BaseEntity $
{ 
[ 	
Key	 
] 
public		 
long		 
Id		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
private

 
DateTime

 

_createdAt

 #
;

# $
public 
DateTime 
	CreatedAt !
{ 	
get 
{ 
return 

_createdAt #
==$ &
default' .
?/ 0
DateTime1 9
.9 :
Now: =
:> ?

_createdAt@ J
;J K
}L M
set 
{ 

_createdAt 
= 
value $
;$ %
}& '
} 	
public 
DateTime 
? 
	UpdatedAt "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
DateTime 
? 
	DeletedAt "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
HashCode 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ç

c/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Entities/ContactEntity.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Entities" *
{ 
[ 
Table 

(
 
$str 
) 
] 
public 

class 
ContactEntity 
:  

BaseEntity! +
{ 
public 
long 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public		 
long		 
TypeId		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public

 
string

 
Value

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
public 
ContactTypeEntity  
ContactType! ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 

UserEntity 
User 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} û
g/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Entities/ContactTypeEntity.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Entities" *
{ 
[ 
Table 

(
 
$str 
) 
] 
public 

class 
ContactTypeEntity "
:# $

BaseEntity% /
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
}		 
}

 „
`/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Entities/UserEntity.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Entities" *
{ 
[ 
Table 

(
 
$str 
) 
] 
public 

class 

UserEntity 
: 

BaseEntity (
{ 
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public

 
DateTime

 
BirthDay

  
{

! "
get

# &
;

& '
set

( +
;

+ ,
}

- .
public 
string 
Login 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ∆

g/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Interfaces/IAddressService.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "

Interfaces" ,
{ 
public 

	interface 
IAddressService $
{ 
Task		 
<		 
long		 
>		 
InsertAsync		 
(		 
AddressEntity		 ,
address		- 4
)		4 5
;		5 6
Task

 
<

 
AddressEntity

 
>

 
UpdateAsync

 '
(

' (
AddressEntity

( 5
address

6 =
)

= >
;

> ?
Task 
< 
bool 
> 
DeleteAsync 
( 
long #
id$ &
)& '
;' (
Task 
< 
AddressEntity 
> 
SelectAsync '
(' (
long( ,
id- /
)/ 0
;0 1
Task 
< 
List 
< 
AddressEntity 
>  
>  !
GetAddressByUserId" 4
(4 5
long5 9
userId: @
)@ A
;A B
} 
} «

g/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Interfaces/IContactService.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "

Interfaces" ,
{ 
public 

	interface 
IContactService $
{ 
Task		 
<		 
long		 
>		 
InsertAsync		 
(		 
ContactEntity		 ,
contact		- 4
)		4 5
;		5 6
Task

 
<

 
ContactEntity

 
>

 
UpdateAsync

 '
(

' (
ContactEntity

( 5
contact

6 =
)

= >
;

> ?
Task 
< 
bool 
> 
DeleteAsync 
( 
long #
id$ &
)& '
;' (
Task 
< 
ContactEntity 
> 
SelectAsync '
(' (
long( ,
id- /
)/ 0
;0 1
Task 
< 
List 
< 
ContactEntity 
>  
>  !
SelectByUserIdAsync" 5
(5 6
long6 :
userId; A
)A B
;B C
} 
} ¯
k/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Interfaces/IContactTypeService.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "

Interfaces" ,
{ 
public 

	interface 
IContactTypeService (
{ 
Task 
< 
long 
> 
InsertAsync 
( 
ContactTypeEntity 0
contacyType1 <
)< =
;= >
Task		 
<		 
ContactTypeEntity		 
>		 
UpdateAsync		  +
(		+ ,
ContactTypeEntity		, =
contacyType		> I
)		I J
;		J K
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
 
DeleteAsync

 
(

 
long

 #
id

$ &
)

& '
;

' (
Task 
< 
ContactTypeEntity 
> 
SelectAsync  +
(+ ,
long, 0
id1 3
)3 4
;4 5
} 
} Ò	
d/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Interfaces/IUserService.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "

Interfaces" ,
{ 
public 

	interface 
IUserService !
{ 
Task 
< 
long 
> 
InsertAsync 
( 

UserEntity )
user* .
). /
;/ 0
Task		 
<		 

UserEntity		 
>		 
UpdateAsync		 $
(		$ %

UserEntity		% /
user		0 4
)		4 5
;		5 6
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
 
DeleteAsync

 
(

 
long

 #
id

$ &
)

& '
;

' (
Task 
< 

UserEntity 
> 
SelectAsync $
($ %
long% )
id* ,
), -
;- .
Task 
< 
bool 
> 

LoginAsync 
( 

UserEntity (
user) -
)- .
;. /
} 
} €
l/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Repositories/IAddressRepository.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Repositories" .
{ 
public 

	interface 
IAddressRepository '
:( )
IRepository* 5
<5 6
AddressEntity6 C
>C D
{ 
Task		 
<		 
List		 
<		 
AddressEntity		  
>		  !
>		! "
GetAddressByUserId		# 5
(		5 6
long		6 :
userId		; A
)		A B
;		B C
}

 
} ‹
l/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Repositories/IContactRepository.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Repositories" .
{ 
public 

	interface 
IContactRepository '
:( )
IRepository* 5
<5 6
ContactEntity6 C
>C D
{ 
Task		 
<		 
List		 
<		 
ContactEntity		 
>		  
>		  !
SelectByUserIdAsync		" 5
(		5 6
long		6 :
userId		; A
)		A B
;		B C
}

 
} ˘
p/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Repositories/IContactTypeRepository.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Repositories" .
{ 
public 

	interface "
IContactTypeRepository +
:, -
IRepository. 9
<9 :
ContactTypeEntity: K
>K L
{ 
} 
}		 î	
e/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Repositories/IRepository.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Repositories" .
{ 
public 

	interface 
IRepository  
<  !
T! "
>" #
where$ )
T* +
:, -

BaseEntity. 8
{ 
Task 
< 
long 
> 
InsertAsync 
( 
T  
item! %
)% &
;& '
Task		 
<		 
T		 
>		 
UpdateAsync		 
(		 
T		 
item		 "
)		" #
;		# $
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
 
DeleteAsync

 
(

 
long

 #
id

$ &
)

& '
;

' (
Task 
< 
T 
> 
SelectAsync 
( 
long  
id! #
)# $
;$ %
} 
} ï
i/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Repositories/IUserRepository.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Repositories" .
{ 
public 

	interface 
IUserRepository $
:% &
IRepository' 2
<2 3

UserEntity3 =
>= >
{ 
Task 
< 
bool 
> 

LoginAsync 
( 

UserEntity (
user) -
)- .
;. /
}		 
}

 ”
d/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Services/AddressService.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Services" *
{ 
public		 

class		 
AddressService		 
:		  !
IAddressService		" 1
{

 
private 
IAddressRepository "
_addressRepository# 5
;5 6
public 
AddressService 
( 
IAddressRepository 0
addressRepository1 B
)B C
{ 	
_addressRepository 
=  
addressRepository! 2
;2 3
} 	
public 
async 
Task 
< 
bool 
> 
DeleteAsync  +
(+ ,
long, 0
id1 3
)3 4
{ 	
return 
await 
_addressRepository +
.+ ,
DeleteAsync, 7
(7 8
id8 :
): ;
;; <
} 	
public 
async 
Task 
< 
AddressEntity '
>' (
SelectAsync) 4
(4 5
long5 9
id: <
)< =
{ 	
return 
await 
_addressRepository +
.+ ,
SelectAsync, 7
(7 8
id8 :
): ;
;; <
} 	
public 
async 
Task 
< 
long 
> 
InsertAsync  +
(+ ,
AddressEntity, 9
address: A
)A B
{ 	
return 
await 
_addressRepository +
.+ ,
InsertAsync, 7
(7 8
address8 ?
)? @
;@ A
}   	
public"" 
async"" 
Task"" 
<"" 
AddressEntity"" '
>""' (
UpdateAsync"") 4
(""4 5
AddressEntity""5 B
address""C J
)""J K
{## 	
return$$ 
await$$ 
_addressRepository$$ +
.$$+ ,
UpdateAsync$$, 7
($$7 8
address$$8 ?
)$$? @
;$$@ A
}%% 	
public'' 
async'' 
Task'' 
<'' 
List'' 
<'' 
AddressEntity'' ,
>'', -
>''- .
GetAddressByUserId''/ A
(''A B
long''B F
userId''G M
)''M N
{(( 	
return)) 
await)) 
_addressRepository)) +
.))+ ,
GetAddressByUserId)), >
())> ?
userId))? E
)))E F
;))F G
}** 	
}++ 
},, Î
d/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Services/ContactService.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Services" *
{ 
public		 

class		 
ContactService		 
:		  !
IContactService		" 1
{

 
private 
readonly 
IContactRepository +
_contactRepository, >
;> ?
public 
ContactService 
( 
IContactRepository 0
contactRepository1 B
)B C
{ 	
_contactRepository 
=  
contactRepository! 2
;2 3
} 	
public 
async 
Task 
< 
bool 
> 
DeleteAsync  +
(+ ,
long, 0
id1 3
)3 4
{ 	
return 
await 
_contactRepository +
.+ ,
DeleteAsync, 7
(7 8
id8 :
): ;
;; <
} 	
public 
async 
Task 
< 
ContactEntity '
>' (
SelectAsync) 4
(4 5
long5 9
id: <
)< =
{ 	
return 
await 
_contactRepository +
.+ ,
SelectAsync, 7
(7 8
id8 :
): ;
;; <
} 	
public 
async 
Task 
< 
long 
> 
InsertAsync  +
(+ ,
ContactEntity, 9
contact: A
)A B
{ 	
return 
await 
_contactRepository +
.+ ,
InsertAsync, 7
(7 8
contact8 ?
)? @
;@ A
} 	
public!! 
async!! 
Task!! 
<!! 
ContactEntity!! '
>!!' (
UpdateAsync!!) 4
(!!4 5
ContactEntity!!5 B
contact!!C J
)!!J K
{"" 	
return## 
await## 
_contactRepository## +
.##+ ,
UpdateAsync##, 7
(##7 8
contact##8 ?
)##? @
;##@ A
}$$ 	
public&& 
async&& 
Task&& 
<&& 
List&& 
<&& 
ContactEntity&& ,
>&&, -
>&&- .
SelectByUserIdAsync&&/ B
(&&B C
long&&C G
userId&&H N
)&&N O
{'' 	
return(( 
await(( 
_contactRepository(( +
.((+ ,
SelectByUserIdAsync((, ?
(((? @
userId((@ F
)((F G
;((G H
})) 	
}** 
}++ –
h/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Services/ContactTypeService.cs
	namespace 	

DubaiSmoke
 
. 
Users 
. 
Domain !
.! "
Services" *
{ 
public 

class 
ContactTypeService #
:$ %
IContactTypeService& 9
{		 
private

 "
IContactTypeRepository

 &"
_contactTypeRepository

' =
;

= >
public 
ContactTypeService !
(! ""
IContactTypeRepository" 8!
contactTypeRepository9 N
)N O
{ 	"
_contactTypeRepository "
=# $!
contactTypeRepository% :
;: ;
} 	
public 
async 
Task 
< 
bool 
> 
DeleteAsync  +
(+ ,
long, 0
id1 3
)3 4
{ 	
return 
await "
_contactTypeRepository /
./ 0
DeleteAsync0 ;
(; <
id< >
)> ?
;? @
} 	
public 
async 
Task 
< 
ContactTypeEntity +
>+ ,
SelectAsync- 8
(8 9
long9 =
id> @
)@ A
{ 	
return 
await "
_contactTypeRepository /
./ 0
SelectAsync0 ;
(; <
id< >
)> ?
;? @
} 	
public 
async 
Task 
< 
long 
> 
InsertAsync  +
(+ ,
ContactTypeEntity, =
contactType> I
)I J
{ 	
return 
await "
_contactTypeRepository /
./ 0
InsertAsync0 ;
(; <
contactType< G
)G H
;H I
} 	
public   
async   
Task   
<   
ContactTypeEntity   +
>  + ,
UpdateAsync  - 8
(  8 9
ContactTypeEntity  9 J
contactType  K V
)  V W
{!! 	
return"" 
await"" "
_contactTypeRepository"" /
.""/ 0
UpdateAsync""0 ;
(""; <
contactType""< G
)""G H
;""H I
}## 	
}$$ 
}%% ò
a/home/nino/Desktop/Repos/DubaiSmoke.Users.Api/src/DubaiSmoke.Users.Domain/Services/UserService.cs
	namespace		 	

DubaiSmoke		
 
.		 
Users		 
.		 
Domain		 !
.		! "
Services		" *
{

 
public 

class 
UserService 
: 
IUserService +
{ 
private 
readonly 
IUserRepository (
_userRepository) 8
;8 9
private 
readonly $
ErrorHandlerNotification 1
_notifications2 @
;@ A
public 
UserService 
( 
IUserRepository *
userRepository+ 9
,9 :$
ErrorHandlerNotification; S
notificationT `
)` a
{ 	
_userRepository 
= 
userRepository ,
;, -
_notifications 
= 
notification )
;) *
} 	
public 
async 
Task 
< 
bool 
> 
DeleteAsync  +
(+ ,
long, 0
id1 3
)3 4
{ 	
return 
await 
_userRepository (
.( )
DeleteAsync) 4
(4 5
id5 7
)7 8
;8 9
} 	
public 
async 
Task 
< 

UserEntity $
>$ %
SelectAsync& 1
(1 2
long2 6
id7 9
)9 :
{ 	
var 
user 
= 
await 
_userRepository ,
., -
SelectAsync- 8
(8 9
id9 ;
); <
;< =
if 
( 
user 
is 
null 
) 
await   
_notifications   $
.  $ %
Handle  % +
(  + ,
new  , /
ErrorDetail  0 ;
(  ; <
$"  < >
$str  > V
{  V W
id  W Y
}  Y Z
"  Z [
,  [ \
$str  ] b
,  b c
string  d j
.  j k
Empty  k p
,  p q
HttpStatusCode	  r Ä
.
  Ä Å
NotFound
  Å â
)
  â ä
)
  ä ã
;
  ã å
return"" 
user"" 
;"" 
}## 	
public%% 
async%% 
Task%% 
<%% 
long%% 
>%% 
InsertAsync%%  +
(%%+ ,

UserEntity%%, 6
user%%7 ;
)%%; <
{&& 	
return'' 
await'' 
_userRepository'' (
.''( )
InsertAsync'') 4
(''4 5
user''5 9
)''9 :
;'': ;
}(( 	
public** 
async** 
Task** 
<** 

UserEntity** $
>**$ %
UpdateAsync**& 1
(**1 2

UserEntity**2 <
user**= A
)**A B
{++ 	
return,, 
await,, 
_userRepository,, (
.,,( )
UpdateAsync,,) 4
(,,4 5
user,,5 9
),,9 :
;,,: ;
}-- 	
public// 
async// 
Task// 
<// 
bool// 
>// 

LoginAsync//  *
(//* +

UserEntity//+ 5
user//6 :
)//: ;
{00 	
return11 
await11 
_userRepository11 (
.11( )

LoginAsync11) 3
(113 4
user114 8
)118 9
;119 :
}22 	
}33 
}44 