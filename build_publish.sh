export ALIAS=api-users
export IMAGENAME=registry:2/$ALIAS:1.0.2
docker build --network=host -t $IMAGENAME -f ./src/DubaiSmoke.Users.Api/Dockerfile .
docker rm -f $ALIAS
docker run -d --name api-users -p 5001:80 -e ASPNETCORE_ENVIRONMENT=prod --restart=always $IMAGENAME
docker rmi -f $IMAGENAME
