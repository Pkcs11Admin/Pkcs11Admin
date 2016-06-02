#!/bin/sh

mono --version > /dev/null 2>&1
if [ $? -ne 0 ]; then
	echo "Mono is not installed"
	exit 1
fi

TARGET_DIR=`dirname $0`
mono $TARGET_DIR/Pkcs11Admin-x64.exe 2> /dev/null

