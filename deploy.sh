sudo sshpass -p $ANSIBLE_PASSWORD ssh -o StrictHostKeyChecking=no $ANSIBLE_CONNECTION \
"cd /root/OtakuShelter.Infrastructure/src && \
ansible-playbook deploy.yml \
-e \"\
otakushelter_hosts=profiles \
otakushelter_container=otakushelter_profile \
otakushelter_image=otakushelter/profile \
otakushelter_port=4003 \
otakushelter_build_number=$TRAVIS_BUILD_NUMBER \
otakushelter_database_password=$OTAKUSHELTER_DATABASE_PASSWORD \
otakushelter_secret=$OTAKUSHELTER_SECRET\" \
-i inventories/staging"