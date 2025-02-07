#!/bin/bash -e

FAISS_VERSION=${1:-main}
GITHUB_ACCOUNT=${2:-facebookresearch}
arch=amd64
rm -f FaissMask/runtimes/linux-x64/native/*
docker-compose build --build-arg arch=$arch --build-arg FAISS_VERSION=$FAISS_VERSION --build-arg GITHUB_ACCOUNT=$GITHUB_ACCOUNT
docker run --platform=linux/${arch} --rm -v $PWD:/host faissmask_test bash -c 'cp /src/FaissMask/runtimes/linux-x64/native/* /host/FaissMask/runtimes/linux-x64/native/'
