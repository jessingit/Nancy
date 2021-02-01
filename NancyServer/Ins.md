from https://www.jenkins.io/doc/book/installing/docker/

Open CMD

![Arch](./resources/1.png)


Run jenkins in docker

`docker network create jenkins`

run a container from jenkins docker image - dind (docker in docker)
	
```
docker run --name jenkins-docker --rm --detach ^
  --privileged --network jenkins --network-alias docker ^
  --env DOCKER_TLS_CERTDIR=/certs ^
  --volume jenkins-docker-certs:/certs/client ^
  --volume jenkins-data:/var/jenkins_home ^
  docker:dind
```

Explained
- `rm` - Delete container when finished
- `detach` - run in background, so i can write on cl but container is running
- `privileged` - admin login 
- `network` - running on jenkins like wifi 
-  `env` - environment variables
-  `volume` - maps windows locations to container locations. so when the container deletes data isnt lost 
 

![Arch](./resources/2.png)


Build the following docker file:
```docker
# Dockerfile

FROM jenkins/jenkins:2.263.3-lts-jdk11
USER root
RUN apt-get update && apt-get install -y apt-transport-https \
       ca-certificates curl gnupg2 \
       software-properties-common
RUN curl -fsSL https://download.docker.com/linux/debian/gpg | apt-key add -
RUN apt-key fingerprint 0EBFCD88
RUN add-apt-repository \
       "deb [arch=amd64] https://download.docker.com/linux/debian \
       $(lsb_release -cs) stable"
RUN apt-get update && apt-get install -y docker-ce-cli
USER jenkins
RUN jenkins-plugin-cli --plugins blueocean:1.24.4
```

Use command `docker build -t myjenkins-blueocean:1.1 .`


- `.` - this means current directory not 'all'


Next start your jenkins container using the following command:

```
docker run --name jenkins-blueocean --rm --detach ^
  --network jenkins --env DOCKER_HOST=tcp://docker:2376 ^
  --env DOCKER_CERT_PATH=/certs/client --env DOCKER_TLS_VERIFY=1 ^
  --volume jenkins-data:/var/jenkins_home ^
  --volume jenkins-docker-certs:/certs/client:ro ^
  --publish 8080:8080 --publish 50000:50000 myjenkins-blueocean:1.1
```

to get the password run ` docker logs <container-name>`
