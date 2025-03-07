#!/bin/sh
until /opt/mssql-tools/bin/sqlcmd -S SQL_Server -U sa -P "YourStrong!Passw0rd" -Q "SELECT 1"; do
  echo"Waiting for SQL Server to start..."
  sleep 5
done
echo"SQL Server is up. Starting backend..."