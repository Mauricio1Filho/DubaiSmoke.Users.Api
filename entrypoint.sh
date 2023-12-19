#!/bin/bash

# Adiciona a entrada ao /etc/hosts
echo "192.168.15.161 dubaismoke.corp.com" >> /etc/hosts

# Inicia o aplicativo
exec "$@"
