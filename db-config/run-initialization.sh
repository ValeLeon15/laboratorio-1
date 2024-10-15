#!/bin/bash
sleep 30s
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Password123! -i persona_ddl_ms.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Password123! -i persona_dml_ms.sql