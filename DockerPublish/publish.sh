# publish container (/t:PublishContainer is required for container creation) using default naming/settings
sudo dotnet publish /t:PublishContainer -p ContainerRepository=helloworld

# list the output of the images
sudo docker images

# run the container
sudo docker run helloworld