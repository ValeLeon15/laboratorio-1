#!/bin/bash
# Ejecutar el script de inicialización en segundo plano
/usr/src/app/run-initialization.sh &

# Iniciar SQL Server
/opt/mssql/bin/sqlservr
