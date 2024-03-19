# default "latest" tag
sudo docker build -f Dockerfile-Latest . -t dockertest:latest

# alpine
sudo docker build -f Dockerfile-Alpine . -t dockertest:8.0-alpine

# ubuntu jammy (22.04)
sudo docker build -f Dockerfile-Jammy . -t dockertest:8.0-jammy

# ubuntu jammy chisled (22.04)
sudo docker build -f Dockerfile-JammyChisled . -t dockertest:8.0-jammy-chisled

sudo docker images | grep -i dockertest