# Of course you can install MongoDB in your machine an connect the services directly to it, but why the hassle? 
# THis will start a docker container which means also that persistency wont be there... we'll come back to that
docker run -p 27017:27017 --name mongo_dev_instance -d mongo
docker logs mongo_dev_instance

