# default "latest" tag
docker build -f Dockerfile-Latest . -t dockertest:latest

# alpine
docker build -f Dockerfile-Alpine . -t dockertest:8.0-alpine

# ubuntu jammy (22.04)
docker build -f Dockerfile-Jammy . -t dockertest:8.0-jammy

# ubuntu jammy chisled (22.04)
docker build -f Dockerfile-JammyChisled . -t dockertest:8.0-jammy-chisled

docker images | findstr /c:dockertest /i