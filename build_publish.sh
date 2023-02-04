docker build --network=host -t registry.dubaismoke.net.br:5000/api-users:1.0.0 -f ./src/DubaiSmoke.Users.Api/Dockerfile .
docker rm -f api-users
docker run -d --name api-users -p 5001:80 -e ASPNETCORE_ENVIRONMENT=prod --restart=always registry.dubaismoke.net.br:5000/api-users:1.0.0
docker rmi -f registry.dubaismoke.net.br:5000/api-users:1.0.0
