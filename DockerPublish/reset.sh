#!/bin/bash

# Get a list of all docker images
images=$(sudo docker images --format "{{.Repository}}" | grep "helloworld")

# Loop through each image
for image in $images
do
    echo "Deleting image: $image"

    # Pull the latest version of the image
    sudo docker image rm $image -f
done

echo "Deletion complete."