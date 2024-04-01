#!/bin/bash

# Get all docker images
images=$(sudo docker images -a | grep -i dockertest)

# Loop over all lines
while IFS= read -r line; do
    # Extract the image ID
    image_id=$(echo $line | awk '{print $3}')
    
    # Remove the image
    docker rmi -f $image_id
done <<< "$images"