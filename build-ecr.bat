aws ecr get-login-password --region us-east-2 --profile Lucas-Admin | docker login --username AWS --password-stdin 396293663259.dkr.ecr.us-east-2.amazonaws.com
docker build -t backend-registry-repo .
docker tag backend-registry-repo:latest 396293663259.dkr.ecr.us-east-2.amazonaws.com/backend-registry-repo:latest
docker push 396293663259.dkr.ecr.us-east-2.amazonaws.com/backend-registry-repo:latest