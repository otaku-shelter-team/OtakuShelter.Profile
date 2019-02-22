echo "ansible-playbook deploy.yml \
-e \"\
otakushelter_hosts=profiles \
otakushelter_container=otakushelter_profile \
otakushelter_image=otakushelter/profile \
otakushelter_port=4003 \
otakushelter_build_number=$TRAVIS_BUILD_NUMBER\" \
-i inventories/staging"