abp install-libs

cd src/BookStore.DbMigrator && dotnet run && cd -



cd src/BookStore.Web && dotnet dev-certs https -v -ep openiddict.pfx -p config.auth_server_default_pass_phrase 


exit 0