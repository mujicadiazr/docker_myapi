# To build a docker image from a Dockerfile
docker build -t username/appname:tag .

# To run a docker image and listen in ports 8080:80
docker run --rm -it -p 8080:80 username/appname:tag

# To run a container with current directory mounted as a volume from an image and start listening in the ports 8080:80
docker run --rm -it -v ${PWD}:/app -p 8080:80 username/appname:tag

# To start a container keeping the CLI free
docker-compose up -d

#To see logs of Docker compose
docker-compose logs

# To get back to the running container in the background
docker-compose logs

# To list images 
docker images mujirandockid/myapi:latest
docker images 
docker images ls -a

# To do get the microservice up after changes on the code
docker-compose up --build
 

