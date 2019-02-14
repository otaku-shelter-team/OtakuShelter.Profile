PREVIOUS_VERSION=`expr $TRAVIS_BUILD_NUMBER - 1`

echo docker pull otakushelter/profile:1.0.$TRAVIS_BUILD_NUMBER
echo docker rm \$\(docker stop \$\(docker ps -a -q --filter ancestor=otakushelter/profile:1.0.$PREVIOUS_VERSION --format="{{.ID}}"\)\)
echo docker rmi otakushelter/profile:1.0.$PREVIOUS_VERSION -f 
echo docker run -d -p 127.0.0.1:4003:80 otakushelter/profile:1.0.$TRAVIS_BUILD_NUMBER